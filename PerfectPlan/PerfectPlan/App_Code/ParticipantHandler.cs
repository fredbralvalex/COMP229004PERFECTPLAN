using System;
using System.Data.SqlClient;

public class ParticipantHandler
{

    private static ParticipantHandler instance;
    private UserDA userDA;
    private AddressDA addressDA;
    private ParticipantDA participantDA;

    //Will be only one instance
    public static ParticipantHandler getInstance()
    {
        if (instance == null)
        {
            instance = new ParticipantHandler();
        }
        return instance;
    }

    public ParticipantHandler()
    {
        userDA = UserDA.getInstance();
        addressDA = AddressDA.getInstance();
        participantDA = ParticipantDA.getInstance();
    }


    //Need to be sincrhonyzed
    public int InsertParticipant(string name, string email, string password, char type, string street, int number, string zipcode, string city, string province, string country)
    {
        int key = -1;
        userDA.openConnection();
        SqlTransaction transaction =  userDA.BeginTransaction();
        try
        {
            //insert the user
            int userKey = userDA.InsertUser(email, password, type);
            //insert the address
            int addressKey = addressDA.InsertAddress(street, number, zipcode, city, province, country);
            //insert the Participant
            int participantKey = participantDA.InsertParticipant(name, userKey, addressKey);
            //insertWallet
            transaction.Commit();
            key = participantKey;
        } catch (Exception e)
        {
            transaction.Rollback();
            Console.Write("Hello via Console!");
            System.Diagnostics.Debug.Write("Hello via Debug!");
            System.Diagnostics.Trace.Write("Hello via Trace!");            
        } finally
        {
            userDA.closeConnection();
        }
        return key;
    }

    public Participant RecoverByUser(User user)
    {
        return (Participant)participantDA.RecoverByUserId(user.GetId());
    }


    public Participant Recover(int id)
    {
        return (Participant)participantDA.RecoverById(id);
    }
}