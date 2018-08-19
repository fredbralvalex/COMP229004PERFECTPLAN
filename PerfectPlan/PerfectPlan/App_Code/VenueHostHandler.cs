using System;
using System.Data.SqlClient;

public class VenueHostHandler
{

    private static VenueHostHandler instance;
    private UserDA userDA;
    private AddressDA addressDA;
    private VenueHostDA venueHostDA;
    private BranchDA branchDA;

    //Will be only one instance
    public static VenueHostHandler getInstance()
    {
        if (instance == null)
        {
            instance = new VenueHostHandler();
        }
        return instance;
    }

    public VenueHostHandler()
    {
        userDA = UserDA.getInstance();
        addressDA = AddressDA.getInstance();
        venueHostDA = VenueHostDA.getInstance();
        branchDA = BranchDA.GetInstance();
    }


    //Need to be sincrhonyzed
    public int InsertVenueHost(string name, string email, string password, char type)
    {
        int key = -1;
        userDA.openConnection();
        SqlTransaction transaction = userDA.BeginTransaction();
        try
        {
            //insert the user
            int userKey = userDA.InsertUser(email, password, type);
            //insert the HostVenue
            int hostVenueKey = venueHostDA.InsertVenueHost(name, userKey);
            transaction.Commit();
            key = hostVenueKey;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            System.Diagnostics.Debug.Write(e);
        }
        finally
        {
            userDA.closeConnection();
        }
        return key;
    }

    //Need to be sincrhonyzed
    public int InsertBranch(int venuHostid, string label, string street, int number, string zipcode, string city, string province, string country)
    {
        int key = -1;      
        venueHostDA.openConnection();
        SqlTransaction transaction = userDA.BeginTransaction();
        try
        {            
            //insert the address
            int addressKey = addressDA.InsertAddress(street, number, zipcode, city, province, country);
            //insert the branch
            int branchKey = branchDA.InsertBranch(venuHostid, addressKey, label);
            transaction.Commit();
            key = branchKey;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            System.Diagnostics.Debug.Write(e);
        }
        finally
        {
            venueHostDA.closeConnection();
        }
        return key;
    }

    public VenueHost RecoverByUser(User user)
    {
        return (VenueHost)venueHostDA.RecoverByUserId(user.GetId());
    }
}