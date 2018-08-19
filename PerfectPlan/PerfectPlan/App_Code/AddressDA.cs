using System;
using System.Data.SqlClient;

public class AddressDA:AbstractDAHelper
{

    private static AddressDA instance;

    //Will be only one instance
    public static AddressDA getInstance()
    {
        if (instance == null)
        {
            instance = new AddressDA();
        }
        return instance;
    }

    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@addressid", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@street", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@number", SqlDbType = System.Data.SqlDbType.Int, Value = values[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@zipcode", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[3] };
        parameters[4] = new SqlParameter() { ParameterName = "@city", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[4] };
        parameters[5] = new SqlParameter() { ParameterName = "@province", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[5] };
        parameters[6] = new SqlParameter() { ParameterName = "@country", SqlDbType = System.Data.SqlDbType.VarChar, Value = values[6] };
        return parameters;
    }

    public int InsertAddress (string street, int number, string zipcode, string city, string province, string country)
    {
        int key = GetNextValue();
        SqlParameter [] parameters = new SqlParameter[7];
        parameters[0] = new SqlParameter() { ParameterName = "@addressid", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@street", SqlDbType = System.Data.SqlDbType.VarChar, Value = street };
        parameters[2] = new SqlParameter() { ParameterName = "@number", SqlDbType = System.Data.SqlDbType.Int, Value = number };
        parameters[3] = new SqlParameter() { ParameterName = "@zipcode", SqlDbType = System.Data.SqlDbType.VarChar, Value = zipcode };
        parameters[4] = new SqlParameter() { ParameterName = "@city", SqlDbType = System.Data.SqlDbType.VarChar, Value = city };
        parameters[5] = new SqlParameter() { ParameterName = "@province", SqlDbType = System.Data.SqlDbType.VarChar, Value = province };
        parameters[6] = new SqlParameter() { ParameterName = "@country", SqlDbType = System.Data.SqlDbType.VarChar, Value = country };


        InsertUsingTransaction(parameters);
        return key;
    }

    public override string GetTableName()
    {
        return "pp_address";
    }

    public override string GetTableKeyName()
    {
        return "addressid";
    }

    public override string GetColumns()
    {
        return "addressid, streetname, streetnumber, zipcode, city, province, country";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new Address((int)reader["addressid"], (string)reader["streetname"], 
            (int)reader["streetnumber"], (string)reader["zipcode"], (string)reader["city"], 
            (string)reader["province"], (string)reader["country"]);
    }
}