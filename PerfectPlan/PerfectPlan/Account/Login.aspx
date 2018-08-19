<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">
    <div id="HeaderSession" class="header">
        <H1>LOGIN</H1>
    </div>
    <div id="CenterSession">
        <div class="header">
            <asp:ValidationSummary ID="ValidationSummaryLogin" runat="server" ValidationGroup="Login"/>
        </div>
        <div>
                <asp:Label ID="LabelUser" Width ="100px" runat="server" Text="E-mail"></asp:Label>
                <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
            <div style="display:none">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Login" runat="server" ErrorMessage="Please enter an E-mail!" ControlToValidate="TextBoxUser" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Login" runat="server" ErrorMessage="Please enter a Password!" ControlToValidate="TextBoxPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" ValidationGroup="Login" runat="server" ErrorMessage="E-mail or Password invalid!" OnServerValidate="ValidadeUserLoginEmail" ControlToValidate="TextBoxUser" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidatorUserExists" ValidationGroup="Login" runat="server" ErrorMessage="E-mail or Password invalid!" OnServerValidate="ValidadeUserLoginPassword" ControlToValidate="TextBoxPassword" Display="Dynamic"></asp:CustomValidator>
            </div>
        </div>
        <div>
            <asp:Label ID="LabelPassword" Width ="100px" runat="server" Text="Password"></asp:Label>            
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" ValidationGroup="Login"/>
        </div>
        <div id="FooterSession" class="center">
            <div>
                <asp:LinkButton ID="LinkButtonCreateAccount" runat="server" Text="Create Account" OnClick="RedirectCreateAccount"/>
                 &nbsp;|&nbsp;
                <asp:LinkButton ID="LinkButtonSubscribeVenueHost" runat="server" Text="Subscribe Venue Host" OnClick="RedirectSubscribeVenueHost" />
                    
            </div>
        </div>
    </div>

</asp:Content>

