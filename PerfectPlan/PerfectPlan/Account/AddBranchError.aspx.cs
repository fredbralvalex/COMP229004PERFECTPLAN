using System;

public partial class Account_AddBranch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void ButtonReturn_Click(object sender, EventArgs e)
    {        
        Response.Redirect("AddBranch.aspx");
    }
}