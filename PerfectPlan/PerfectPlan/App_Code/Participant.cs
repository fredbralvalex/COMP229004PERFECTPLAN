public class Participant : User
{
    private int participantId;
    private int addressId;
    private string name;

    public Participant(int id, int participantId, string name, int addressId, string email, char type) : base(id, email, type)
    {
        this.participantId = participantId;
        this.addressId = addressId;
        this.name = name;
    }

    public int GetParticipantId()
    {
        return participantId;
    }

    public string GetAddressId()
    {
        return name;
    }

    public string GetName()
    {
        return name;
    }
}