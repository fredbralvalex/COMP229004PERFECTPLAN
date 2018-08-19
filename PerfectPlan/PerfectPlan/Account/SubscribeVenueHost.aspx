<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="SubscribeVenueHost.aspx.cs" Inherits="Account_SubscribeVenueHost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">

    <div id="HeaderSession" class="header">
        <H1>Subscribe Venue Host</H1>
    </div>
    <div id="CenterSession">
        <div>           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" 
                ValidationGroup="Subscribe" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>           
            <asp:Label Width ="100px" ID="LabelName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUser" 
                ValidationGroup="Subscribe" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelUser" runat="server" Text="E-mail"></asp:Label>
            <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidatorCheckEmail" runat="server" ErrorMessage="E-mail already in use!" 
                ControlToValidate="TextBoxUser"  ValidationGroup="Subscribe"
                OnServerValidate="CheckEmailInUser" Display="Dynamic" ForeColor="Red" ClientValidationFunction="CheckEmailInUser"></asp:CustomValidator>
        </div>        
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassword" 
                ValidationGroup="Subscribe"
                ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="Label2" runat="server" Text="Password"></asp:Label>            
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" ControlToCompare="TextBoxPassword"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPassword2" 
                ValidationGroup="Subscribe" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelPassword2" runat="server" Text="Confirm Password"></asp:Label>            
            <asp:TextBox ID="TextBoxPassword2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password must match!" 
                ForeColor="Red" Display="Dynamic" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPassword2"></asp:CompareValidator>
        </div>
    </div>
   <div></div>
    <div id="FooterSession" class="center">
        <div>
            <asp:Button ID="ButtonSubscribe"  runat="server" OnClick="ButtonSubscribe_Click" Text="Subscribe" ValidationGroup="Subscribe"  />
            <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
        </div>
    </div>

</asp:Content>

