<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
       
        
        <h1>List of Buckets</h1>

       <asp:GridView ID="gridOfBuckets" runat="server">

       </asp:GridView>
        
        

    </div>

</asp:Content>
