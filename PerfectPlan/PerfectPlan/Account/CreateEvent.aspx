<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    MaintainScrollPositionOnPostback="true"
    CodeFile="CreateEvent.aspx.cs" Inherits="Account_CreateEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 361px;
        }
        .auto-style2 {
            width: 188px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">
    <div id="HeaderSession" class="header">
        <H1>Create Event</H1>
    </div>

    <div id="CenterSession">
        <table border="0" style="margin-left:auto;margin-right:auto">   
            <tr><td colspan="2">
                <asp:CustomValidator ID="CustomValidatorCheckDates" runat="server" ErrorMessage="Event Date cannot be before Deadline Date!" 
                    ControlToValidate="TextBoxDeadLine" OnServerValidate="CheckOrderDates" 
                    ValidationGroup="CreateEvent" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>                
                </td></tr>
            <tr style="text-align:left">
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDescription" 
                ValidationGroup="CreateEvent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><asp:Label Text="Description" runat="server" /></td>
                <td class="auto-style1"><asp:TextBox ID="TextBoxDescription" runat="server" /></td>
            </tr>
            <tr style="text-align:left">
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEventDate" 
                ValidationGroup="CreateEvent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><asp:Label Text="Date" runat="server" /></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxEventDate" Visible="false" Enabled="false" runat="server" />
                    <asp:Calendar ID="CalendarEventDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px"
                        OnSelectionChanged="DateSelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr><td class="auto-style2"></td><td class="auto-style1"></td></tr>
            <tr style="text-align:left"><td class="auto-style2">
                
                <asp:Label Width ="100px" Text="Participants" runat="server" /></td><td class="auto-style1">
                <asp:ObjectDataSource ID="ObjectDataSourceParticipant" runat="server" DataObjectTypeName="Participant" 
                    DeleteMethod="removeItem" InsertMethod="addItem" SelectMethod="getItens" 
                    TypeName="ParticipantsFactory" UpdateMethod="updateItem"></asp:ObjectDataSource>
                <asp:DataList ID="DataListParticipantsSelected" runat="server" DataSourceID="ObjectDataSourceParticipant">
                     <ItemTemplate>
                        <asp:Label ID="LabelNameObject" runat="server" Text='<%# Eval("name") %>' />
                         : 
                        <asp:Label ID="LabelE_mailObject" runat="server" Text='<%# Eval("email") %>' />                      
                    </ItemTemplate>
                </asp:DataList>
                </td></tr>
            <tr><td class="auto-style2"></td><td class="auto-style1"></td></tr>
            <tr><td class="auto-style2"></td><td class="auto-style1"><asp:TextBox ID="TextBoxParticipantsEmailSearch" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonSearchParticipant" runat="server" OnClick="ButtonSearchParticipant_Click" Text="Search" />
                <asp:DataList ID="DataListParticipantsDatabase" runat="server" DataKeyField="participantid" DataSourceID="SqlDataSourceParticipantsDatabase">
                    <HeaderTemplate><table></HeaderTemplate>
                    <ItemTemplate>
                        <tr><td>
                            Name:</td><td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td></tr>
                        <tr><td>
                        E-mail:</td><td>
                        <asp:Label ID="E_mailLabel" runat="server" Text='<%# Eval("[E-mail]") %>' />
                        </td></tr>
                        <tr><td colspan="2">
                        <asp:LinkButton ID="LinkButtonSelectParticipant" runat="server" CommandArgument='<%# Eval("participantid") %>'  onclick="ParticipantList_Click" > Select Participant </asp:LinkButton>
                        </td></tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSourceParticipantsDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" 
                    SelectCommand="SELECT participantid, participantname as Name, useremail as 'E-mail' 
                    FROM pp_participant p, pp_user u where u.userid = p.userid and 
                    (participantname like '%' + @text + '%' or useremail like '%' + @text + '%')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBoxParticipantsEmailSearch" Name="text" PropertyName="Text" />                        
                    </SelectParameters>
                </asp:SqlDataSource></td></tr>
            <tr><td class="auto-style2"></td><td class="auto-style1"></td></tr>

            <tr style="text-align:left"><td class="auto-style2"><asp:Label Width ="100px" Text="Budget Items" runat="server" /></td><td class="auto-style1">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSourceBudgetItems">
                    <ItemTemplate>        
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("description") %>' />
                        :
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("value") %>' />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSourceBudgetItems" runat="server" DataObjectTypeName="Budget" 
                    DeleteMethod="removeBudgetItem" InsertMethod="addBudgetItem" SelectMethod="getBudgetsItens" 
                    TypeName="BudgetItensFactory" UpdateMethod="updateBudgetItem"></asp:ObjectDataSource>
                </td></tr>
            <tr><td class="auto-style2"></td><td class="auto-style1">Total: <asp:Label ID="LabelTotal" runat="server" Text=""></asp:Label></td></tr>
            <tr><td class="auto-style2"></td><td class="auto-style1">
                <table>
                    <tr><td><asp:Label ID="LabelBudgetDescription" runat="server" Text="Description"></asp:Label></td><td><asp:TextBox ID="TextBoxBudgetDescription" runat="server"></asp:TextBox></td></tr>
                    <tr><td><asp:Label ID="LabelBudgetValue" runat="server" Text="Value"></asp:Label></td><td><asp:TextBox ID="TextBoxBudgetValue" runat="server"></asp:TextBox></td></tr>
                    <tr><td colspan="2"><asp:Button ID="ButtonAddBudget" runat="server" OnClick="ButtonAddBudget_Click" Text="Add" /></td></tr>
                </table>                
                </td></tr>
            <tr style="text-align:left">
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxDeadLine" 
                ValidationGroup="CreateEvent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><asp:Label Width ="100px" Text="Payment Deadline" runat="server" /></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxDeadLine" Visible="false" Enabled="false" runat="server" />
                    <asp:Calendar ID="CalendarDeadLine" runat="server" BackColor="White" BorderColor="#999999" 
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                        Height="180px" Width="200px"
                        OnSelectionChanged="DeadlineSelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr style="text-align:left">
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListVenueHost" 
                ValidationGroup="CreateEvent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><asp:Label Text="Venue Host" runat="server" /></td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListVenueHost" runat="server" DataSourceID="SqlDataSourceVenueHost" DataTextField="venuehostname" DataValueField="venuehostid" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceVenueHost" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" 
                        SelectCommand="SELECT [venuehostname], [venuehostid] FROM [pp_venuehost]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr style="text-align:left">
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListBranch" 
                ValidationGroup="CreateEvent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><asp:Label Text="Locale" runat="server" /></td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListBranch" runat="server" DataSourceID="SqlDataSourceBranch" DataTextField="label" DataValueField="branchid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" SelectCommand="SELECT [label], [branchid] FROM [pp_branch] WHERE ([venuehostid] = @venuehostid)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownListVenueHost" Name="venuehostid" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    
    <div id="FooterSession" class="center">
        <div>
            <asp:Button ID="ButtonCreateEvent"  runat="server" OnClick="ButtonCreateEvent_Click" Text="Create Event" ValidationGroup="CreateEvent"  />
            <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
        </div>
    </div>
</asp:Content>


