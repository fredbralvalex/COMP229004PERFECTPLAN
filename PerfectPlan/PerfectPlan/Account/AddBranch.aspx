<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="AddBranch.aspx.cs" Inherits="Account_AddBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">

    <div id="HeaderSession" class="header">
        <H1>Add Branch</H1>
    </div>
    <div id="CenterSession">
        <div>
           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
           
            <asp:Label Width ="100px" ID="LabelName" runat="server" Text="Branch Name"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </div>          
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxAddress" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxAddressNumber" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelNumber" runat="server" Text="Street Number"></asp:Label>
            <asp:TextBox ID="TextBoxAddressNumber" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidatorNumber" runat="server" ControlToValidate="TextBoxAddressNumber" 
                Display="Dynamic" ErrorMessage="Invalid Number!" ForeColor="Red" ValidationGroup="AddBranch"
                OnServerValidate="CheckNumber"></asp:CustomValidator>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxZipCode" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelZipCode" runat="server" Text="ZIP Code"></asp:Label>
            <asp:TextBox ID="TextBoxZipCode" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxCity" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label Width ="100px" ID="LabelCity" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownListProvince" 
                ValidationGroup="AddBranch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
           <asp:Button ID="ButtonAddBranch" runat="server" OnClick="ButtonAddBranch_Click" Text="AddBranch" ValidationGroup="AddBranch"/>
           <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
        </div>
    </div>
</asp:Content>

