using System;

public class Event
{
    private int eventid;
    private int venuehostid;
    private int branchid;
    private String description;
    private DateTime eventDate;
    private DateTime deadLine;
    private char status;


    public Event(int eventid, int venuehostid, int branchid, String description, DateTime eventDate, DateTime deadLine, char status)
    {
        this.eventid = eventid;
        this.venuehostid = venuehostid;
        this.branchid = branchid;
        this.description = description;
        this.eventDate = eventDate;
        this.deadLine = deadLine;
        this.status = status;

    }
  
}