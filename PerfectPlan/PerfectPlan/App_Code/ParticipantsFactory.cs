using System;
using System.Collections.Generic;
using System.Data;

public class ParticipantsFactory
{
    //About Budgets
    private DataSet participants;
    private DataTable dt;    

    private static ParticipantsFactory instance;

    public static ParticipantsFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new ParticipantsFactory();
        }
        return instance;
    }

    public ParticipantsFactory()
    {
        participants = new DataSet();
        Initialize();
    }

    private void Initialize ()
    {
        dt = new DataTable("Participants");
        dt.Columns.Add(new DataColumn("id", typeof(int)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("email", typeof(string)));
        dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
        participants.Tables.Add(dt);
    }


    private DataSet retrieveItens()
    {
        return participants;
    }

    public DataSet getItens()
    {
        return ParticipantsFactory.GetInstance().retrieveItens();
    }

    private void addItem(DataRow dr)
    {

        if(!exists(dr))
        {
            dt.Rows.Add(dr);
        }
    }

    public Boolean exists(DataRow dr)
    {
        return ParticipantsFactory.GetInstance().existItem(dr);
    }
    
    private Boolean existItem(DataRow dr)
    {
        foreach (DataRow row in participants.Tables["Participants"].Rows)
        {
            if (row["id"].Equals(dr["id"]))
            {
                return true;
            }
        }
        return false;
    }

    public List<int> getParticipantsKeys()
    {
        return ParticipantsFactory.GetInstance().getKeys();
    }

    private List<int> getKeys()
    {
        List<int> keys = new List<int>();
        foreach (DataRow row in participants.Tables["Participants"].Rows)
        {
            keys.Add((int)row["id"]);
        }
        return keys;
    }

    public void addItem(Participant item)
    {
                
        DataRow dr = dt.NewRow();
        dr["id"] = item.GetParticipantId();
        dr["name"] = item.GetName();
        dr["email"] = item.GetEmail();

        ParticipantsFactory.GetInstance().addItem(dr);
    }

    public void removeItem(Participant item)
    {

    }

    public void updateItem(Participant item)
    {

    }

    public void ClearTable()
    {
        ParticipantsFactory.GetInstance().ClearTableInstance();
    }

    private void ClearTableInstance()
    {
        instance = new ParticipantsFactory();
    }
}