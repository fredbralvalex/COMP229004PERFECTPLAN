<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VenueHostDashBoard.aspx.cs" Inherits="Account_VenueHostDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">
    <div id="maintitle" class="header">
        <H1>Dashboard</H1>               
    </div>
    <table border="0" style="margin-left:auto;margin-right:auto">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="branchid" 
                    DataSourceID="SqlDataSource1" Height="50px" Width="225px">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="label" HeaderText="Branch" SortExpression="label" />
                    </Columns>
                </asp:GridView>

                </td>
            </tr>
        </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" SelectCommand="SELECT [label], [addressid], [branchid] FROM [pp_branch] WHERE ([venuehostid] = @venuehostid)">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="VenueHostID" Name="venuehostid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" 
                SelectCommand="SELECT streetname, streetnumber, zipcode, city, province, country
                                    FROM pp_branch b, pp_address a
                                     where a.addressid = b.addressid and b.[branchid] = @branchid">
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="branchid" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
    <table border="0" style="margin-left:auto;margin-right:auto">
        <tr><td>
            <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSource2" Height="50px" Width="225px" AutoGenerateRows="False">
                <Fields>
                    <asp:BoundField DataField="streetname" HeaderText="Address" SortExpression="streetname" />
                    <asp:BoundField DataField="streetnumber" HeaderText="Number" SortExpression="streetnumber" />
                    <asp:BoundField DataField="zipcode" HeaderText="Zip Code" SortExpression="zipcode" />
                    <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                    <asp:BoundField DataField="province" HeaderText="Province" SortExpression="province" />
                    <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                </Fields>
            </asp:DetailsView>
            </td></tr>
        </table>
</asp:Content>

