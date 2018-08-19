using System;
using System.Data;
using System.Data.SqlClient;

public abstract class AbstractDAHelper
{    
    private static SqlTransaction transaction;
    private static SqlConnection connection;

    public abstract string GetTableName();
    public abstract string GetTableKeyName();
    public abstract string GetColumns();
    public abstract Object CreateObject(SqlDataReader reader);
    public abstract SqlParameter[] GetDAParameters(string [] values);

    public SqlConnection GetConection()
    {
        if (connection == null)
        {
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        }
        return connection;
    }

    public void openConnection()
    {
        GetConection();
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }

    public void closeConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public SqlTransaction BeginTransaction() {
        if (connection == null)
        {
            openConnection();
        }        
        transaction = connection.BeginTransaction();
        return transaction;
    }

    public Object Recover(string user, string password)
    {        
        SqlCommand command = new SqlCommand("select * from pp_user where useremail = @email and userpassword=@pwd;", connection);
        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
        command.Parameters["@email"].Value = user;
        command.Parameters.Add("@pwd", System.Data.SqlDbType.VarChar);
        command.Parameters["@pwd"].Value = password;
        openConnection();
        SqlDataReader reader = command.ExecuteReader();
        closeConnection();

        User account = null;
        if (reader.Read())
        {
            account = new User((int)reader["userid"], (string)reader["useremail"], ((string)reader["usertype"]).ToCharArray()[0]);
        }

        reader.Close();
        return account;
    }

    public Object Recover(int id)
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select * from " + GetTableName() + " where " + GetTableKeyName ()+ " = @id;", connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
        command.Parameters["@id"].Value = id;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        Object obj = null;
        if (reader.Read())
        {
            obj = CreateObject(reader);
        }

        reader.Close();
        connection.Close();
        return obj;
    }

    public bool Exists(string email)
    {
        bool exists = false;
        
        SqlCommand command = new SqlCommand("select count(*) from pp_user where LOWER(useremail) = LOWER(@email);", connection);
        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
        command.Parameters["@email"].Value = email;
        connection.Open();
        exists = (int)command.ExecuteScalar() > 0;
        connection.Close();
        return exists;
    }

    public void InsertUsingTransaction(SqlParameter [] parameters)
    {
        string par;
        object val;

        string parametersInsert="";
        int count = 0;
        foreach(SqlParameter parameter in parameters)
        {
            par = parameter.ParameterName;
            val = parameter.Value;
            parametersInsert += par;
            count++;
            if (count < parameters.Length)
            {
                parametersInsert += ",";
            }
            //command.Parameters.Add(parameter);
        }
        SqlCommand command = new SqlCommand(
            "Insert into " + GetTableName() + " ("+ GetColumns() + ") values ("+ parametersInsert + ")", connection);
        command.Parameters.AddRange(parameters);
        command.Transaction = transaction;
        
        command.ExecuteNonQuery();
        
    }

    public void Insert(SqlParameter[] parameters)
    {
        string par;
        object val;

        string parametersInsert = "";
        int count = 0;
        foreach (SqlParameter parameter in parameters)
        {
            par = parameter.ParameterName;
            val = parameter.Value;
            parametersInsert += par;
            count++;
            if (count < parameters.Length)
            {
                parametersInsert += ",";
            }
            //command.Parameters.Add(parameter);
        }
        SqlCommand command = new SqlCommand(
            "Insert into " + GetTableName() + " (" + GetColumns() + ") values (" + parametersInsert + ")", connection);
        command.Parameters.AddRange(parameters);

        openConnection();
        command.ExecuteNonQuery();
        closeConnection();
    }

    public int GetNextValue()
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("Select coalesce (max(" +GetTableKeyName() + "),0 ) as Id from " + GetTableName() + ";", connection);
        connection.Open();
        int nextId = (int)command.ExecuteScalar() + 1;
        connection.Close();
        return nextId;
    }

}