using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_SubscribeVenueHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSubscribe_Click(object sender, EventArgs e)
    {
        if (!AuthenticationHandler.getInstance().ExistsEmail(TextBoxUser.Text))
        {
            int key = VenueHostHandler.getInstance().InsertVenueHost(TextBoxName.Text, TextBoxUser.Text, TextBoxPassword.Text, 'V');
            
            if (key == -1)
            {
                Response.Redirect("SubscribeVenueHostError.aspx");
            }
            else
            {
                Response.Redirect("SubscribeVenueHostSuccess.aspx");
            }
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void CheckEmailInUser(object source, ServerValidateEventArgs args)
    {
        string username = args.Value.ToLower();
        if (AuthenticationHandler.getInstance().ExistsEmail(username))
        {
            args.IsValid = false;
        }
    }
}