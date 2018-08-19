public class EventParticipant
{
    private int eventId;
    private int participantId;
    private string status;
    private char owner;

    public EventParticipant(int eventId, int participantId, string status, char owner)
    {
        this.participantId = participantId;
        this.eventId = eventId;
        this.status = status;
        this.owner = owner;
    }

    public int GetParticipantId()
    {
        return participantId;
    }

    public int GetEventId()
    {
        return eventId;
    }
}