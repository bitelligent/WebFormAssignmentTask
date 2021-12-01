<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
       
        
        <h1>List of Buckets</h1>
        <h2 style="color: red"><asp:Literal runat="server" ID="lblErrorMessage"></asp:Literal></h2>

       <asp:GridView ID="gridOfBuckets" runat="server" AutoGenerateColumns="False"  CssClass="mydatagrid" PagerStyle-CssClass="pager"
                     HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
           <Columns>
              <asp:TemplateField HeaderText="Finance Method">
                  <ItemTemplate>
                      <asp:Label ID="lblFinanceMethod" runat="server" 
                                 Text='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).FinanceMethod %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Status">
                   <ItemTemplate>

                       <asp:HyperLink ID="lnkPDF" runat="server" ImageUrl='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).GetIcon() %>' NavigateUrl='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).GetEditingUrl() %>'></asp:HyperLink>
                           </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="IsDueDate">
                   <ItemTemplate>
                       <asp:Label ID="lblIsDueDate" runat="server" Text='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).IsDuedate %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Title">
                   <ItemTemplate>
                       <asp:Label ID="lblTitle" runat="server" Text='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).Title %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                   
               <asp:TemplateField HeaderText="Created On">
                   <ItemTemplate>
                       <asp:Label ID="lblDateCreated" runat="server" Text='<%# (Container.DataItem as Application.Common.ViewModels.BucketViewModel).DateInserted %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>







           </Columns>

       </asp:GridView>
        
        

    </div>

</asp:Content>
