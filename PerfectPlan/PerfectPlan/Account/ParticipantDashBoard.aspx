<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ParticipantDashBoard.aspx.cs" Inherits="Account_ParticipantDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">
    <div id="maintitle" class="header">
        <H1>Dashboard</H1>
        <table border="0" style="margin-left:auto;margin-right:auto">
        <tr>
            <td>
            <asp:GridView ID="GridViewEvents" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" Height="50px" Width="925px" AllowSorting="True" DataKeyNames="eventid">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Venue Host" HeaderText="Venue Host" SortExpression="Venue Host" />
                    <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="Payment Date" HeaderText="Payment Date" SortExpression="Payment Date" />
                    <asp:BoundField DataField="Event Status" HeaderText="Event Status" SortExpression="Event Status" />
                    <asp:BoundField DataField="Participant Status" HeaderText="Participant Status" SortExpression="Participant Status" />
                    <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" 
                SelectCommand="select e.eventid as eventid, description as Description, venuehostname as 'Venue Host', label as Branch, eventdate as 'Date', deadline as 'Payment Date', e.status as 'Event Status', ep.status as 'Participant Status', owner as 'Owner' from pp_user u, pp_participant p, pp_event e, pp_eventparticipant ep, pp_venuehost v, pp_branch b 
                        where e.eventid = ep.eventid and p.participantid = ep.participantid
                        and b.branchid = e.branchid and b.venuehostid=v.venuehostid
                        and p.userid = u.userid and u.userid = @participant;">
                <SelectParameters>
                    <asp:CookieParameter CookieName="UserID" Name="participant" />
                </SelectParameters>
            </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" 
                    SelectCommand="select participantname as 'Participant Name', ep.status as 'Participant Status', ep.owner as Owner 
                    from pp_eventparticipant ep, pp_participant p where p.participantid=ep.participantid and ep.eventid = @eventid">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridViewEvents" Name="eventid" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" SelectCommand="SELECT [description], [value] FROM [pp_budgetitem] WHERE ([eventid] = @eventid)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridViewEvents" Name="eventid" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource3"  Width="325px" Height="50px">                        
                    <HeaderTemplate><table  border="0">
                        <tr><td style="width:70px">Description</td><td style="width:70px">Value</td></tr>
                        </HeaderTemplate>                        
                    <ItemTemplate>
                        <tr><td style="width:70px">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("description") %>' />
                            </td><td style="width:70px">
                            <asp:Label ID="LabelE_mailObject" runat="server" Text='<%# Eval("value") %>' />
                            </td></tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2"  Width="325px" Height="50px">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <table  border="1">
                        <tr><td style="width:70px">Name</td><td style="width:140px"><asp:Label ID="LabelNameObject" runat="server" Text='<%# Eval("Participant Name") %>' /></td></tr>
                        <tr><td style="width:70px">Status</td><td style="width:140px"><asp:Label ID="LabelE_mailObject" runat="server" Text='<%# Eval("Participant Status") %>' /></td></tr>
                        <tr><td style="width:70px">Owner</td><td style="width:140px"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Owner") %>' /></td></tr>
                            </table>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:DataList>
        </td></tr></table>               
    </div>
</asp:Content>

