using System;
using System.Data.SqlClient;

public class EventDA : AbstractDAHelper
{
    private static EventDA instance;

    public static EventDA GetInstance()
    {
        if (instance == null)
        {
            instance = new EventDA();
        }
        return instance;
    }

    // TODO change ArrayList<Event>
    /*
    public Event GetBranchList(int venuehostid)
    {
        String myCommand = "select b.branchid, b.label "
                         + "from pp_branch b, pp_venuehost v "
                         + "where b.venuehostid = v.venuehostid "
                         + "and v.venuehostid = @venuehostid;";

        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand(myCommand, connection);
        command.Parameters.Add("@venuehostid", System.Data.SqlDbType.Int);
        command.Parameters["@venuehostid"].Value = venuehostid;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        Event eventt = null;
        if (reader.Read())
        {
            eventt = new Event((int)reader["branchid"], (string)reader["label"]);
        }

        reader.Close();
        connection.Close();
        return eventt;
    }
    */


    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@venuehostid", SqlDbType = System.Data.SqlDbType.VarChar, Value = parameters[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@branchid", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@description", SqlDbType = System.Data.SqlDbType.VarChar, Value = parameters[3] };
        parameters[4] = new SqlParameter() { ParameterName = "@eventDate", SqlDbType = System.Data.SqlDbType.DateTime, Value = parameters[4] };
        parameters[5] = new SqlParameter() { ParameterName = "@deadLine", SqlDbType = System.Data.SqlDbType.DateTime, Value = parameters[5] };
        parameters[6] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Char, Value = parameters[6] };
        return parameters;
    }

    public int InsertEvent(int venuehostid, int branchid, string description, DateTime eventDate, DateTime deadLine)
    {
        int key = GetNextValue();
        SqlParameter[] parameters = new SqlParameter[7];
        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@venuehostid", SqlDbType = System.Data.SqlDbType.VarChar, Value = venuehostid };
        parameters[2] = new SqlParameter() { ParameterName = "@branchid", SqlDbType = System.Data.SqlDbType.Int, Value = branchid };
        parameters[3] = new SqlParameter() { ParameterName = "@description", SqlDbType = System.Data.SqlDbType.VarChar, Value = description };
        parameters[4] = new SqlParameter() { ParameterName = "@eventDate", SqlDbType = System.Data.SqlDbType.DateTime, Value = eventDate };
        parameters[5] = new SqlParameter() { ParameterName = "@deadLine", SqlDbType = System.Data.SqlDbType.DateTime, Value = deadLine };
        parameters[6] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Char, Value = 'O' };

        InsertUsingTransaction(parameters);
        return key;
    }

    public override string GetTableName()
    {
        return "pp_event";
    }

    public override string GetTableKeyName()
    {
        return "eventid";
    }

    public override string GetColumns()
    {
        return "eventid, venuehostid, branchid, description, eventdate, deadline, status";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new Event((int)reader["eventid"], (int)reader["venuehostid"],(int)reader["branchid"], (string)reader["description"],
                (DateTime)reader["eventdate"], (DateTime)reader["deadline"], ((string)reader["status"]).ToCharArray()[0]);
    }    
}

