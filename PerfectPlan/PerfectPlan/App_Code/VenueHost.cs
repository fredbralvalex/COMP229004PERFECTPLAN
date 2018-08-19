public class VenueHost : User
{
    private int venueHostId;
    private string name;
    private char subscribed;
    
    public VenueHost(int id, string email, char type, int venueHostId, string name, char subscribed) : base(id, email, type)
    {
        this.venueHostId = venueHostId;
        this.name = name;
        this.subscribed = subscribed;
    }

    public int GetVenueHostId()
    {
        return venueHostId;
    }

    public char GetSubscribed()
    {
        return subscribed;
    }

    public string GetName()
    {
        return name;
    }
}