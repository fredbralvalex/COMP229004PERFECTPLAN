public class AuthenticationHandler
{
    private static AuthenticationHandler instance;
    private UserDA userDA;
    private ParticipantDA participantDA;
    private VenueHostDA venueHostDA;

    //Will be only one instance
    public static AuthenticationHandler getInstance()
    {
        if (instance == null)
        {
            instance = new AuthenticationHandler();
        }
        return instance;
    }

    AuthenticationHandler()
    {
        userDA = UserDA.getInstance();
        participantDA = ParticipantDA.getInstance();
        venueHostDA = VenueHostDA.getInstance();
    }

    public User AuthenticateAndValidate(string user, string password)
    {
        User account = userDA.RecoverUser(user, password);
        if (account != null)
        {
            char type = account.GetAccountType();
            if (type == 'V')
            {
                account = venueHostDA.RecoverByUserId(account.GetId());
            }
            else if (type == 'P')
            {
                account = participantDA.RecoverByUserId(account.GetId());
            }

        }
        return account;
    }

    public bool ExistsEmail(string email)
    {
        return userDA.ExistsEmail(email);
    }
}