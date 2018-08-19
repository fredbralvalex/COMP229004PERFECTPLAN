using System;
using System.Data.SqlClient;

public class UserDA:AbstractDAHelper
{

    private static UserDA instance;

    //Will be only one instance
    public static UserDA getInstance()
    {
        if (instance == null)
        {
            instance = new UserDA();
        }
        return instance;
    }

    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@userid", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@useremail", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@userpassword", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@usertype", SqlDbType = System.Data.SqlDbType.Char, Value = values[3] };

        return parameters;
    }

    public int InsertUser (string email, string password, char type)
    {
        int key = GetNextValue();
        SqlParameter [] parameters = new SqlParameter[4];
        parameters[0] = new SqlParameter() { ParameterName = "@userid", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@useremail", SqlDbType = System.Data.SqlDbType.VarChar, Value = email };
        parameters[2] = new SqlParameter() { ParameterName = "@userpassword", SqlDbType = System.Data.SqlDbType.VarChar, Value = password };
        parameters[3] = new SqlParameter() { ParameterName = "@usertype", SqlDbType = System.Data.SqlDbType.Char, Value = type };

        InsertUsingTransaction(parameters);
        return key;
    }

    public User RecoverUser(string user, string password)
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select * from pp_user where useremail = @email and userpassword=@pwd;", connection);
        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
        command.Parameters["@email"].Value = user;
        command.Parameters.Add("@pwd", System.Data.SqlDbType.VarChar);
        command.Parameters["@pwd"].Value = password;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        User account = null;
        if (reader.Read())
        {
            account = new User((int)reader["userid"], (string)reader["useremail"], ((string)reader["usertype"]).ToCharArray()[0]);
        }

        reader.Close();
        connection.Close();
        return account;
    }

    public bool ValidateUser(string user, string password)
    {
        bool exists = false;
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select count(*) from pp_user where useremail = @email and userpassword=@pwd;", connection);
        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
        command.Parameters["@email"].Value = user;
        command.Parameters.Add("@pwd", System.Data.SqlDbType.VarChar);
        command.Parameters["@pwd"].Value = password;
        connection.Open();
        exists = (int)command.ExecuteScalar() > 0;
        connection.Close();
        return exists;
    }

    public bool ExistsEmail(string email)
    {
        bool exists = false;
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select count(*) from pp_user where LOWER(useremail) = LOWER(@email);", connection);
        command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
        command.Parameters["@email"].Value = email;
        connection.Open();
        exists = (int)command.ExecuteScalar() > 0;
        connection.Close();
        return exists;
    }

    public bool ExistsPassword(string password)
    {
        bool exists = false;
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select count(*) from pp_user where LOWER(userpassword) = LOWER(@pwd);", connection);
        command.Parameters.Add("@pwd", System.Data.SqlDbType.VarChar);
        command.Parameters["@pwd"].Value = password;
        connection.Open();
        exists = (int)command.ExecuteScalar() > 0;
        connection.Close();
        return exists;
    }

    public override string GetTableName()
    {
        return "pp_user";
    }

    public override string GetTableKeyName()
    {
        return "userid";
    }

    public override string GetColumns()
    {
        return "userid, useremail, userpassword, usertype";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new User((int)reader["userid"], (string)reader["useremail"], ((string)reader["usertype"]).ToCharArray()[0]);        
    }
}