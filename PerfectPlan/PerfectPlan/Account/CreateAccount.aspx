<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true"    
    CodeFile="CreateAccount.aspx.cs" Inherits="Account_CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">

    <div id="HeaderSession" class="header">
        <H1>Create Participant Account</H1>
    </div>
    <div id="CenterSession">
        <div>
           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
           
            <asp:Label Width ="100px" ID="LabelName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUser" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelUser" runat="server" Text="E-mail"></asp:Label>
            <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidatorCheckEmail" runat="server" ErrorMessage="E-mail already in use!" 
                ControlToValidate="TextBoxUser" OnServerValidate="CheckEmailInUser" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
        </div>        
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassword" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelPassword" runat="server" Text="Password"></asp:Label>            
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" ControlToCompare="TextBoxPassword"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPassword2" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelPassword2" runat="server" Text="Confirm Password"></asp:Label>            
            <asp:TextBox ID="TextBoxPassword2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password must match!" 
                ForeColor="Red" Display="Dynamic" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPassword2"></asp:CompareValidator>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxAddress" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxAddressNumber" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelNumber" runat="server" Text="Street Number"></asp:Label>
            <asp:TextBox ID="TextBoxAddressNumber" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidatorNumber" runat="server" ControlToValidate="TextBoxAddressNumber" 
                Display="Dynamic" ErrorMessage="Invalid Number!" ForeColor="Red" ValidationGroup="CreateAccount"
                OnServerValidate="CheckNumber"></asp:CustomValidator>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxZipCode" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelZipCode" runat="server" Text="ZIP Code"></asp:Label>
            <asp:TextBox ID="TextBoxZipCode" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxCity" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelCity" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownListProvince" 
                ValidationGroup="CreateAccount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelProvince" runat="server" Text="Province"></asp:Label>
            <%-- <asp:TextBox ID="TextBoxProvince" runat="server"></asp:TextBox>--%>
            <asp:DropDownList ID="DropDownListProvince" runat="server">
                <asp:ListItem>ON</asp:ListItem>
                <asp:ListItem>QC</asp:ListItem>
                <asp:ListItem>NS</asp:ListItem>
                <asp:ListItem>NB</asp:ListItem>
                <asp:ListItem>MB</asp:ListItem>
                <asp:ListItem>BC</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>SK</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
                <asp:ListItem>NL</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
        </div>
    </div>
   <div></div>
    <div id="FooterSession" class="center">
        <div>
           <asp:Button ID="ButtonCreateAccount" runat="server" OnClick="ButtonCreateAccount_Click" Text="Create Account" ValidationGroup="CreateAccount"/>
           <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
        </div>
    </div>
</asp:Content>

