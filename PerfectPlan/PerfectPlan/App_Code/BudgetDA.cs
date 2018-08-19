using System;
using System.Data.SqlClient;

public class BudgetDA : AbstractDAHelper
{
    private static BudgetDA instance;

    public static BudgetDA GetInstance()
    {
        if (instance == null)
        {
            instance = new BudgetDA();
        }
        return instance;
    }
    
    public override SqlParameter[] GetDAParameters(string[] values)
    {
        SqlParameter[] parameters = new SqlParameter[values.Length];

        parameters[0] = new SqlParameter() { ParameterName = "@budgetid", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[0] };
        parameters[1] = new SqlParameter() { ParameterName = "@eventid", SqlDbType = System.Data.SqlDbType.Int, Value = parameters[1] };
        parameters[2] = new SqlParameter() { ParameterName = "@description", SqlDbType = System.Data.SqlDbType.VarChar, Value = parameters[2] };
        parameters[3] = new SqlParameter() { ParameterName = "@value", SqlDbType = System.Data.SqlDbType.Decimal, Value = parameters[3] };
        return parameters;
    }

    public void InsertBudget(int budgetid, int eventid, string description, Double value)
    {
        SqlParameter[] parameters = new SqlParameter[4];
        parameters[0] = new SqlParameter() { ParameterName = "@budgetid", SqlDbType = System.Data.SqlDbType.Int, Value = budgetid };
        parameters[1] = new SqlParameter() { ParameterName = "@eventid", SqlDbType = System.Data.SqlDbType.Int, Value = eventid };
        parameters[2] = new SqlParameter() { ParameterName = "@description", SqlDbType = System.Data.SqlDbType.VarChar, Value = description };
        parameters[3] = new SqlParameter() { ParameterName = "@value", SqlDbType = System.Data.SqlDbType.Decimal, Value = value };
        
        InsertUsingTransaction(parameters);
    }

    public override string GetTableName()
    {
        return "pp_budgetitem";
    }

    public override string GetTableKeyName()
    {
        return "budgetitemid";
    }

    public override string GetColumns()
    {
        return "budgetitemid, eventid, description, value ";
    }

    public override Object CreateObject(SqlDataReader reader)
    {
        return new Budget((int)reader["budgetitemid"], (int)reader["eventid"],(string)reader["description"], (Double)reader["value"]);
    }    
}

