<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="AddBranchError.aspx.cs" Inherits="Account_AddBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">

    <div id="HeaderSession" class="header">
        <H1>Add Branch</H1>
    </div>
    <div id="CenterSession">
        <div class="errormessage">
            There was an Error - Try Again!
        </div>   
           
    </div>
        
   <div></div>
    <div id="FooterSession" class="center">
        <div>           
           <asp:Button ID="ButtonReturn" runat="server" OnClick="ButtonReturn_Click" Text="Return to Add Branch" />
        </div>
    </div>
</asp:Content>

