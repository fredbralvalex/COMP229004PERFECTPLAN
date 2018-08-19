using System;
public class Budget
{
    private int budgetid;
    private int eventid;
    private String description;
    private Double value;

    public int Budgetid
    {
        get
        {
            return budgetid;
        }

        set
        {
            budgetid = value;
        }
    }

    public int Eventid
    {
        get
        {
            return eventid;
        }

        set
        {
            eventid = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public double Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    public Budget(int eventid, int budgetid, String description, Double value)
    {
        this.Eventid = eventid;
        this.Budgetid = budgetid;
        this.Value = value;
        this.Description = description;
    }

    public Budget(String description, Double value)
    {
        this.Value = value;
        this.Description = description;
    }
}