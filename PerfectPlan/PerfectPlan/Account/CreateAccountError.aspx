﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="CreateAccountError.aspx.cs" Inherits="Account_CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPublic" Runat="Server">

    <div id="HeaderSession" class="header">
        <H1>Create Participant Account</H1>
    </div>
    <div id="CenterSession">
        <div class="errormessage">
            There was an Error - Try Again!
        </div>   
           
    </div>
        
   <div></div>
    <div id="FooterSession" class="center">
        <div>           
           <asp:Button ID="ButtonReturn" runat="server" OnClick="ButtonReturn_Click" Text="Return to Create Account" />
        </div>
    </div>
</asp:Content>

