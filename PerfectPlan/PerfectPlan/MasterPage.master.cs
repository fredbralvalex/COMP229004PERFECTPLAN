using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userCookie;
        userCookie = Request.Cookies["UserID"];
        if (userCookie == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            HttpCookie c1 = Request.Cookies["UserName"];
            if (c1 == null)
            {
                LabelUser.Text = "user";
            } else
            {
                LabelUser.Text = c1.Value;
            }

        }

        HttpCookie c = Request.Cookies["UserType"];
        LinkButtonHome.Visible = false;
        LinkButtonLogout.Visible = true;
        LinkButtonDashBoard.Visible = true;
        if (c == null)
        {
            Response.Redirect("Home.aspx");
        }
        else if (c.Value == "Participant")
        {
            LinkButtonCreateEvent.Visible = true;
            LinkButtonParticipantDetails.Visible = true;
            LinkButtonAddBranch.Visible = false;
        }
        else
        {
            LinkButtonAddBranch.Visible = true;
            LinkButtonCreateEvent.Visible = false;
            LinkButtonParticipantDetails.Visible = false;
        }
            
        
    }

    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
   
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        if (Request.Cookies["UserID"] != null)
        {
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Application.RemoveAll();
        }
        Response.Redirect("Login.aspx");
    }

    protected void LinkButtonParticipantDetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("ParticipantDetails.aspx");
    }

    protected void AddBranch_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBranch.aspx");
    }
    

    protected void Dashboard_Click(object sender, EventArgs e)
    {

        HttpCookie c = Request.Cookies["UserType"];
        if (c == null)
        {
            Response.Redirect("Home.aspx");
        }
        else if (c.Value == "Participant")
        {
            Response.Redirect("ParticipantDashBoard.aspx");
        }
        else
        {
            Response.Redirect("VenueHostDashBoard.aspx");
        }
    }

    protected void CreateEvent_Click(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["UserType"];
        if (c == null)
        {
            Response.Redirect("Home.aspx");
        }
        else if (c.Value == "Participant")
        {
            BudgetItensFactory.GetInstance().ClearTable();
            ParticipantsFactory.GetInstance().ClearTable();
            Response.Redirect("CreateEvent.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Create Event can be accessed by venue host.');", true);
        }
    }
}
