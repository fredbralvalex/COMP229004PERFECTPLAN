using System;
using System.Web.UI.WebControls;


public partial class Account_CreateAccount : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonCreateAccount_Click(object sender, EventArgs e)
    {
        if (!AuthenticationHandler.getInstance().ExistsEmail(TextBoxUser.Text) && checkNumber(TextBoxAddressNumber.Text))
        {
            int key = ParticipantHandler.getInstance().InsertParticipant(TextBoxName.Text, TextBoxUser.Text, TextBoxPassword.Text, 'P',
                TextBoxAddress.Text, Int32.Parse(TextBoxAddressNumber.Text), TextBoxZipCode.Text, TextBoxCity.Text, DropDownListProvince.Text, "Canada");
            if (key == -1)
            {
                Response.Redirect("CreateAccountError.aspx");
            } else
            {
                Response.Redirect("CreateAccountSuccess.aspx");
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

    protected void CheckNumber(object source, ServerValidateEventArgs args)
    {
        string value = args.Value;
        args.IsValid = checkNumber(value);
     }

    protected Boolean checkNumber(string value)
    {
        try
        {
            Int32.Parse(value);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}