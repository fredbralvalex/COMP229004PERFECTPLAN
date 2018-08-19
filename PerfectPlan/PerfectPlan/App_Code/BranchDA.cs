using System;
using System.Data.SqlClient;

public class BranchDA : AbstractDAHelper
{
    private static BranchDA instance;

    public static BranchDA GetInstance()
    {
        if (instance == null)
        {
            instance = new BranchDA();
        }
        return instance;
    }
    
    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@branchid", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@venuehostid", SqlDbType = System.Data.SqlDbType.VarChar, Value = parameters[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@addressid", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@label", SqlDbType = System.Data.SqlDbType.VarChar, Value = parameters[3] };
        return parameters;
    }

    public int InsertBranch(int venuehostid, int addressid, string label)
    {
        int key = GetNextValue();
        SqlParameter[] parameters = new SqlParameter[4];
        parameters[0] = new SqlParameter() { ParameterName = "@branchid", SqlDbType = System.Data.SqlDbType.Int, Value = key };
        parameters[1] = new SqlParameter() { ParameterName = "@venuehostid", SqlDbType = System.Data.SqlDbType.Int, Value = venuehostid };
        parameters[2] = new SqlParameter() { ParameterName = "@addressid", SqlDbType = System.Data.SqlDbType.Int, Value = addressid };
        parameters[3] = new SqlParameter() { ParameterName = "@label", SqlDbType = System.Data.SqlDbType.VarChar, Value = label };
        
        InsertUsingTransaction(parameters);
        return key;
    }

    public override string GetTableName()
    {
        return "pp_branch";
    }

    public override string GetTableKeyName()
    {
        return "branchid";
    }

    public override string GetColumns()
    {
        return "branchid, venuehostid, addressid, label ";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new Branch((int)reader["branchid"], (int)reader["venuehostid"],(int)reader["addressid"], (string)reader["label"]);
    }    
}

