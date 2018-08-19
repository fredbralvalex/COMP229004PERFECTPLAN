using System;
using System.Web;
using System.Web.UI.WebControls;


public partial class Account_AddBranch: System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonAddBranch_Click(object sender, EventArgs e)
    {
        HttpCookie userCookie;
        userCookie = Request.Cookies["VenueHostID"];
        if (userCookie == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (checkNumber(TextBoxAddressNumber.Text))
        {


            int key = VenueHostHandler.getInstance().InsertBranch(Int32.Parse(userCookie.Value), TextBoxName.Text,
                TextBoxAddress.Text, Int32.Parse(TextBoxAddressNumber.Text), TextBoxZipCode.Text, TextBoxCity.Text, DropDownListProvince.Text, "Canada");
            if (key == -1)
            {
                Response.Redirect("AddBranchError.aspx");
            } else
            {
                Response.Redirect("VenueHostDashBoard.aspx");
            }
        }

    }

    protected void ButtonCancel_Click(object sender, EventArgs e)
    {        
        Response.Redirect("VenueHostDashBoard.aspx");
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