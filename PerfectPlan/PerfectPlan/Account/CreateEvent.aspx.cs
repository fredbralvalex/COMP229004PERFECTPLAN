using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class Account_CreateEvent : System.Web.UI.Page
{
    private BudgetItensFactory budgetFactory;
    private ParticipantsFactory participantFactory;

    protected void Page_Load(object sender, EventArgs e)
    {

        budgetFactory = BudgetItensFactory.GetInstance();
        participantFactory = ParticipantsFactory.GetInstance();


        if (!IsPostBack)
        {
            DataList1.DataBind();
            DataListParticipantsSelected.DataBind();           
        }
    }

    protected void ButtonCreateEvent_Click(object sender, EventArgs e)
    {
        DateTime eventDate = CalendarEventDate.SelectedDate;
        DateTime deadline = CalendarDeadLine.SelectedDate;
        String description = TextBoxDescription.Text;
        String venueHostId = DropDownListVenueHost.SelectedValue;
        String branchId = DropDownListBranch.SelectedValue;

        if (checkEventDates(eventDate, deadline))
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["ParticipantID"];
            if (userCookie == null)
            {
                Response.Redirect("Login.aspx");
            }
            

            int key = EventHandler.GetInstance().InsertEvent(
                participantFactory.getParticipantsKeys(), budgetFactory.getBudgetItens(),
                int.Parse(userCookie.Value), int.Parse(venueHostId), int.Parse(branchId),description,eventDate, deadline);
            if (key == -1)
            {
                Response.Redirect("CreateEventError.aspx");
            }
            else
            {
                Response.Redirect("CreateEventSuccess.aspx");
            }
        }
    }

    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        budgetFactory.ClearTable();
        participantFactory.ClearTable();
        Response.Redirect("ParticipantDashBoard.aspx");
    }

    public void DeadlineSelectionChanged(Object s, EventArgs e)
    {
        TextBoxDeadLine.Text = "" + CalendarDeadLine.SelectedDate;
    }

    public void DateSelectionChanged(Object s, EventArgs e)
    {
        TextBoxEventDate.Text = "" + CalendarEventDate.SelectedDate;
    }

    protected void CheckOrderDates(object source, ServerValidateEventArgs args)
    {
        //string username = args.Value.ToLower();
        DateTime eventDate = CalendarEventDate.SelectedDate;
        DateTime deadline = CalendarDeadLine.SelectedDate;
        if (!checkEventDates(eventDate, deadline))
        {
            args.IsValid = false;
        }
    }

    protected Boolean checkEventDates(DateTime eventDate, DateTime deadline)
    {
        if (DateTime.Compare(eventDate, deadline) < 0)
        {
            return false;
        }
        return true;
    }

    protected void ButtonSearchParticipant_Click(object sender, EventArgs e)
    {
        DataListParticipantsDatabase.DataBind();
    }
    protected void ButtonAddBudget_Click(object sender, EventArgs e)
    {
        budgetFactory.addBudgetItem(new Budget(TextBoxBudgetDescription.Text, Double.Parse(TextBoxBudgetValue.Text)));
        DataList1.DataBind();
        LabelTotal.Text = "" + budgetFactory.GetTotal();
    }

    protected void ParticipantList_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        //Response.Write(btn.CommandArgument);
        int participantid = Convert.ToInt32(btn.CommandArgument);

        int userLoggedId = -1;
        HttpCookie c1 = Request.Cookies["UserID"];
        if (c1 == null)
        {
            //Do nothing
        }
        else
        {
            // not add the same user
            userLoggedId = Convert.ToInt32(c1.Value);
            Participant participant = ParticipantHandler.getInstance().Recover(participantid);
            if (userLoggedId != participant.GetId())
            {
                participantFactory.addItem(participant);
                DataListParticipantsSelected.DataBind();
            }
        }

        /*
        Application["regNo"] = Convert.ToInt32(btn.Text);
        Response.Redirect("EditClub.aspx");*/
    }
}