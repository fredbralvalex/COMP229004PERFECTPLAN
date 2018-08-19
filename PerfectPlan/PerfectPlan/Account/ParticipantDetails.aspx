<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ParticipantDetails.aspx.cs" Inherits="Account_ParticipantDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">
     <div id="maintitle" class="header">
        <H1>Participant Details</H1>
         
             <table border="0" style="margin-left:auto;margin-right:auto">
        <tr>
            <td>
             <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                 Height="50px" Width="325px" DataKeyNames="participantid" DataSourceID="SqlDataSource1">
                 <Columns>
                     <asp:CommandField ShowSelectButton="True" />
                     <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                     <asp:BoundField DataField="E-mail" HeaderText="E-mail" SortExpression="E-mail" />
                 </Columns>
             </asp:GridView>
                </td>
            </tr>
             </table>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" DeleteCommand="DELETE FROM [pp_participant] WHERE [participantid] = @participantid" InsertCommand="INSERT INTO [pp_participant] ([participantid], [participantname], [userid], [addressid]) VALUES (@participantid, @participantname, @userid, @addressid)" SelectCommand="SELECT participantname as Name, participantid, useremail as 'E-mail' FROM pp_participant p, pp_user u where u.userid=p.userid" UpdateCommand="UPDATE [pp_participant] SET [participantname] = @participantname, [userid] = @userid, [addressid] = @addressid WHERE [participantid] = @participantid">
                 <DeleteParameters>
                     <asp:Parameter Name="participantid" Type="Int32" />
                 </DeleteParameters>
                 <InsertParameters>
                     <asp:Parameter Name="participantid" Type="Int32" />
                     <asp:Parameter Name="participantname" Type="String" />
                     <asp:Parameter Name="userid" Type="Int32" />
                     <asp:Parameter Name="addressid" Type="Int32" />
                 </InsertParameters>
                 <UpdateParameters>
                     <asp:Parameter Name="participantname" Type="String" />
                     <asp:Parameter Name="userid" Type="Int32" />
                     <asp:Parameter Name="addressid" Type="Int32" />
                     <asp:Parameter Name="participantid" Type="Int32" />
                 </UpdateParameters>
             </asp:SqlDataSource>

             <table border="0" style="margin-left:auto;margin-right:auto">
        <tr>
            <td>
             <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="addressid" 
                 DataSourceID="SqlDataSource2" Height="50px" Width="325px" >
                 <Fields>
                     <asp:BoundField DataField="addressid" HeaderText="addressid" ReadOnly="True" SortExpression="addressid" />
                     <asp:BoundField DataField="streetname" HeaderText="Street Name" SortExpression="streetname" />
                     <asp:BoundField DataField="streetnumber" HeaderText="Street Number" SortExpression="streetnumber" />
                     <asp:BoundField DataField="zipcode" HeaderText="Postal Code" SortExpression="zipcode" />
                     <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                     <asp:BoundField DataField="province" HeaderText="Province" SortExpression="province" />
                     <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                 </Fields>
             </asp:DetailsView>
                </td></tr></table>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" SelectCommand="SELECT * FROM [pp_address] WHERE ([addressid] = @addressid)">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="GridView1" Name="addressid" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:SqlDataSource>
               
    </div>
</asp:Content>

