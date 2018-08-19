public class User
{
    private int id;
    private string email;
    private char type;    

    public User(int id, string email, char type)
    {
        this.id = id;
        this.type = type;
        this.email = email;
    }

    public int GetId()
    {
        return this.id;
    }

    public char GetAccountType()
    {
        return this.type;
    }

    public string GetEmail()
    {
        return this.email;
    }
}