using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    private static bool onlyOneMessageValidation = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userCookie;
        userCookie = Request.Cookies["UserID"];
        if (userCookie == null)
        {
            //Nothing to do

        }
        else
        {
            //myLabel.Text = "Welcome Back, " + userCookie.Value;
            Response.Redirect("Home.aspx");
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        HttpCookie userCookie;
        userCookie = Request.Cookies["UserID"];
        if (userCookie == null)
        {
            // "Cookie Does not exists! Creating a cookie  now.";
            string user = TextBoxUser.Text;
            string password = TextBoxPassword.Text;

            //Do the authentication
            User account = AuthenticationHandler.getInstance().AuthenticateAndValidate(user, password);

            if (account == null)
            {
                //show error message
            }
            else
            {
                userCookie = new HttpCookie("UserID", "" + account.GetId());
                userCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(userCookie);

                HttpCookie c0 = new HttpCookie("UserType", ""+account.GetType());
                c0.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(c0);

                String userName = "";
                if (account is Participant)
                {
                    userName = ((Participant)account).GetName();
                    HttpCookie c1 = new HttpCookie("UserName", userName);
                    c1.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c1);

                    HttpCookie c2 = new HttpCookie("ParticipantID", ""+((Participant)account).GetParticipantId());
                    c2.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c2);

                    Response.Redirect("ParticipantDashBoard.aspx");
                }
                else if (account is VenueHost)
                {
                    userName = ((VenueHost)account).GetName();
                    HttpCookie c1 = new HttpCookie("UserName", userName);
                    userCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c1);

                    HttpCookie c2 = new HttpCookie("VenueHostID", "" + ((VenueHost)account).GetVenueHostId());
                    c2.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c2);

                    Response.Redirect("VenueHostDashBoard.aspx");
                }
            }
        }
    }

    protected void ValidadeUserLoginEmail(object source, ServerValidateEventArgs args)
    {
        string email = args.Value.ToLower();
        if (!AuthenticationHandler.getInstance().ExistsEmail(email))
        {
            if (onlyOneMessageValidation)
            {
                args.IsValid = false;
                onlyOneMessageValidation = false;
            }
            args.IsValid = false;
        }
        else
        {
            onlyOneMessageValidation = true;
        }

    }

    protected void ValidadeUserLoginPassword(object source, ServerValidateEventArgs args)
    {
        string password = args.Value.ToLower();
        if (!AuthenticationHandler.getInstance().ExistsEmail(password))
        {
            if (onlyOneMessageValidation)
            {            
                args.IsValid = false;
                onlyOneMessageValidation = false;
            }
            //args.IsValid = false;
        }
        else
        {
            onlyOneMessageValidation = true;
        }

    }

    protected void RedirectCreateAccount(object sender, EventArgs e)
    {
        Response.Redirect("CreateAccount.aspx");
    }

    protected void RedirectSubscribeVenueHost(object sender, EventArgs e)
    {
        Response.Redirect("SubscribeVenueHost.aspx");
    }
}