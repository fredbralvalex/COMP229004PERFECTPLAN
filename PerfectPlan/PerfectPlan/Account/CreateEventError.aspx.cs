using System;

public partial class Account_CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void ButtonReturn_Click(object sender, EventArgs e)
    {        
        Response.Redirect("CreateEvent.aspx");
    }
}