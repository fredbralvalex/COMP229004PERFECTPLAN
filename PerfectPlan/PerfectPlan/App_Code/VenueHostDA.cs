using System;
using System.Data.SqlClient;

public class VenueHostDA : AbstractDAHelper
{

    private static VenueHostDA instance;

    //Will be only one instance
    public static VenueHostDA getInstance()
    {
        if (instance == null)
        {
            instance = new VenueHostDA();
        }
        return instance;
    }

    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Int, Value = values[2] };
        
        return parameters;
    }

    public int InsertVenueHost(string name, int userId)
    {
        int key = GetNextValue();
        SqlParameter [] parameters = new SqlParameter[3];
        parameters[0] = new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.VarChar, Value = name };
        parameters[2] = new SqlParameter() { ParameterName = "@userId", SqlDbType = System.Data.SqlDbType.Int, Value = userId };

        InsertUsingTransaction(parameters);
        return key;
    }

    public override string GetTableName()
    {
        return "pp_venuehost";
    }

    public override string GetTableKeyName()
    {
        return "venuehostid";
    }

    public override string GetColumns()
    {
        return "venuehostid, venuehostname, userid";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new VenueHost((int)reader["userid"], (string)reader["useremail"], ((string)reader["usertype"]).ToCharArray()[0],
                (int)reader["venuehostid"], (string)reader["venuehostname"], ((string)reader["subscribed"]).ToCharArray()[0]);
    }

    public VenueHost RecoverByUserId(int userid)
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
        SqlCommand command = new SqlCommand("select * from pp_user u, pp_venuehost v where u.userid = v.userid and u.userid = @id;", connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
        command.Parameters["@id"].Value = userid;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        VenueHost obj = null;
        if (reader.Read())
        {
            obj = (VenueHost)CreateObject(reader);
        }

        reader.Close();
        connection.Close();
        return obj;
    }
}