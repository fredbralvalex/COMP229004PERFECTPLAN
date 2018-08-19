using System;
using System.Data.SqlClient;

public class EventParticipantDA : AbstractDAHelper
{

    private static EventParticipantDA instance;

    //Will be only one instance
    public static EventParticipantDA getInstance()
    {
        if (instance == null)
        {
            instance = new EventParticipantDA();
        }
        return instance;
    }

    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@eventid", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@participantid", SqlDbType = System.Data.SqlDbType.Int, Value = values[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@status", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@owner", SqlDbType = System.Data.SqlDbType.Char, Value = values[3] };
        
        return parameters;
    }

    public void InsertEventParticipant (int eventid, int participantid, string owner)
    {
        //int key = GetNextValue();
        SqlParameter [] parameters = new SqlParameter[4];

        parameters[0] = new SqlParameter() { ParameterName = "@eventid", SqlDbType = System.Data.SqlDbType.Int, Value = eventid };
        parameters[1] = new SqlParameter() { ParameterName = "@participantid", SqlDbType = System.Data.SqlDbType.Int, Value = participantid };
        parameters[2] = new SqlParameter() { ParameterName = "@status", SqlDbType = System.Data.SqlDbType.VarChar, Value = "PA" };
        parameters[3] = new SqlParameter() { ParameterName = "@owner", SqlDbType = System.Data.SqlDbType.Char, Value = owner.ToCharArray()[0] };

        InsertUsingTransaction(parameters);
    }

    public override string GetTableName()
    {
        return "pp_eventparticipant";
    }

    public override string GetTableKeyName()
    {
        return "eventid, participantid";
    }

    public override string GetColumns()
    {
        return "eventid, participantid, status, owner";
    }

    public override Object CreateObject(SqlDataReader reader)
    {        
        return new EventParticipant((int)reader["eventid"], (int)reader["participantid"], (string)reader["status"], 
            ((string)reader["owner"]).ToCharArray()[0]);
    }   
}