using System;
using System.Collections.Generic;
using System.Data;

public class BudgetItensFactory
{
    //About Budgets
    private DataSet budgets;
    private int counter = 1;
    private DataTable dt;
    private double total;

    private static BudgetItensFactory instance;

    public static BudgetItensFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new BudgetItensFactory();
        }
        return instance;
    }

    public BudgetItensFactory()
    {
        budgets = new DataSet();
        Initialize();
    }

    private void Initialize ()
    {
        dt = new DataTable("BudgetItems");
        dt.Columns.Add(new DataColumn("id", typeof(int)));
        dt.Columns.Add(new DataColumn("description", typeof(string)));
        dt.Columns.Add(new DataColumn("value", typeof(double)));
        dt.PrimaryKey = new DataColumn[] { dt.Columns["description"] };
        budgets.Tables.Add(dt);
    }

    public Boolean exists(DataRow dr)
    {
        return BudgetItensFactory.GetInstance().existItem(dr);
    }

    private Boolean existItem(DataRow dr)
    {
        foreach (DataRow row in budgets.Tables["BudgetItems"].Rows)
        {
            if (row["description"].Equals(dr["description"]))
            {
                return true;
            }
        }
        return false;
    }


    public DataSet retrieveBudgetsItens()
    {
        return budgets;
    }

    public DataSet getBudgetsItens()
    {
        return BudgetItensFactory.GetInstance().retrieveBudgetsItens();
    }

    public void addBudgetItem(DataRow dr)
    {
        if (!exists(dr))
        {
            dt.Rows.Add(dr);
            total = total + (Double)dr["value"];

        }
    }

        public void addBudgetItem(Budget budgetItem)
    {
        
        DataRow dr = dt.NewRow();
        dr["id"] = counter++;
        dr["description"] = budgetItem.Description;
        dr["value"] = budgetItem.Value;
        
        BudgetItensFactory.GetInstance().addBudgetItem(dr);
    }

    public List<Budget> getBudgetItens()
    {
        return BudgetItensFactory.GetInstance().getBudget();
    }

    private List<Budget> getBudget()
    {
        List<Budget> budgetsList = new List<Budget>();
        foreach (DataRow row in budgets.Tables["BudgetItems"].Rows)
        {
            budgetsList.Add(new Budget(0, (int)row["id"], (string)row["description"], (double)row["value"]));
        }
        return budgetsList;
    }


    public void removeBudgetItem(Budget budgetItem)
    {

    }

    public void updateBudgetItem(Budget budgetItem)
    {

    }

    public double GetTotal()
    {
        return BudgetItensFactory.GetInstance().GetTotalValue();
    }

    public double GetTotalValue()
    {
        return total;
    }

    public void ClearTable()
    {
        BudgetItensFactory.GetInstance().ClearTableInstance();
    }

    public void ClearTableInstance()
    {
        instance = new BudgetItensFactory();
    }
}