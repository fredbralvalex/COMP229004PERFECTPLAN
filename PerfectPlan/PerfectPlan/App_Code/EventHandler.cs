using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class EventHandler
{
    private static EventHandler instance;

    private EventDA eventDA;
    private BudgetDA budgetDA;
    private EventParticipantDA eventParticipantDA;

    public static EventHandler GetInstance()
    {
        if (instance == null)
        {
            instance = new EventHandler();
        }
        return instance;
    }

    public EventHandler()
    {
        eventDA = EventDA.GetInstance();
        eventParticipantDA = EventParticipantDA.getInstance();
        budgetDA = BudgetDA.GetInstance();
    }

    //Need to be sincrhonyzed
    public int InsertEvent(
        List<int> participantsKeys, List<Budget> items,
        int participantid, int venuehostid, int branchid, string description, DateTime eventDate, DateTime deadLine)
    {
        int key = -1;
        eventDA.openConnection();
        SqlTransaction transaction = eventDA.BeginTransaction();
        try
        {
            //insert the Event
            int eventKey = eventDA.InsertEvent(venuehostid, branchid, description, eventDate, deadLine);
            //insertParticipant Event
            eventParticipantDA.InsertEventParticipant(eventKey, participantid, "1");
            
            foreach(int participantkey in participantsKeys)
            {
                eventParticipantDA.InsertEventParticipant(eventKey, participantkey, "0");
            }
            
            
            foreach(Budget budget in items)
            {
                budgetDA.InsertBudget(budget.Budgetid, eventKey, budget.Description, budget.Value);
            }
            transaction.Commit();
            key = eventKey;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            System.Diagnostics.Debug.Write(e);
        }
        finally
        {
            eventDA.closeConnection();
        }
        return key;
    }
}