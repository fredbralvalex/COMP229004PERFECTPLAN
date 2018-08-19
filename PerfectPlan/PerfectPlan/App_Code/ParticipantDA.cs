using System;
using System.Data.SqlClient;

public class ParticipantDA : AbstractDAHelper
{

    private static ParticipantDA instance;

    //Will be only one instance
    public static ParticipantDA getInstance()
    {
        if (instance == null)
        {
            instance = new ParticipantDA();
        }
        return instance;
    }

    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Int, Value = values[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@addressId", SqlDbType = System.Data.SqlDbType.Int, Value = values[3] };
        
        return parameters;
    }

    public int InsertParticipant (string name, int userId, int addressId)
    {
        int key = GetNextValue();
        SqlParameter [] parameters = new SqlParameter[4];
        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.VarChar, Value = name };
        parameters[2] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Int, Value = userId };
        parameters[3] = new SqlParameter() { ParameterName = "@addressId", SqlDbType = System.Data.SqlDbType.Int, Value = addressId };

        InsertUsingTransaction(parameters);
        return key;
    }

    public override string GetTableName()
    {
        return "pp_participant";
    }

    public override string GetTableKeyName()
    {
        return "participantid";
    }

    public override string GetColumns()
    {
        return "participantid, participantname, userid, addressid";
    }

    public override Object CreateObject(SqlDataReader reader)
    {        
        return new Participant((int)reader["userid"], (int)reader["participantid"], (string)reader["participantname"], 
            (int)reader["addressid"], (string)reader["useremail"], ((string)reader["usertype"]).ToCharArray()[0]);
    }

    public Participant RecoverByUserId(int userid)
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select * from pp_user u, pp_participant p where p.userid = u.userid and u.userid = @id;", connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
        command.Parameters["@id"].Value = userid;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        Participant obj = null;
        if (reader.Read())
        {
            obj = (Participant)CreateObject(reader);
        }

        reader.Close();
        connection.Close();
        return obj;
    }

    public Participant RecoverById(int id)
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select * from pp_user u , pp_participant p where u.userid=p.userid and participantid = @id;", connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
        command.Parameters["@id"].Value = id;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        Participant obj = null;
        if (reader.Read())
        {
            obj = (Participant)CreateObject(reader);
        }

        reader.Close();
        connection.Close();
        return obj;
    }
}