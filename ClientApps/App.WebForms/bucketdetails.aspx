<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bucketdetails.aspx.cs" Inherits="App.WebForms._bucketdetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
       
        
        <h1>Bucket Details</h1>
        
           <h2 runat="server" id="lblHeading"> 
        Add Article</h2>
        
        <h2 style="color: red"><asp:Literal runat="server" ID="lblErrorMessage"></asp:Literal></h2>

    <div style="height: 10px;">
    </div>
    <table class="ctcTable">
        <tr>
            <td style="width: 300px;">
                <strong>Title</strong> <span class="required">*</span>
            </td>
            <td>
                Type</td>
            <td style="text-align: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Title"
                    ValidationGroup="vgBucket" ControlToValidate="txtTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        
        
        <tr>
            <td style="width: 300px;">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="cboType" runat="server">
                    <asp:ListItem runat="server" Text="WHOLE" Value="WHOLE"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Type"
                                            ValidationGroup="vgBucket" ControlToValidate="cboType">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        
        
        
        <tr>
            <td style="width: 300px;">
                <strong>Publish Date</strong> <span class="required">*</span>
            </td>
            <td>
                &nbsp;</td>
            <td style="text-align: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Title"
                    ValidationGroup="vgArticle" ControlToValidate="txtTitle">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        
        
        <tr>
            <td style="width: 300px;">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnUpdateDate" runat="server" Text="Update" OnClick="btnUpdateDate_Click" />
            </td>
            <td style="text-align: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Date"
                                            ValidationGroup="vgBucket" ControlToValidate="txtDate">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td valign="top">
                 </td>
            <td>
                <asp:Button ID="btnDeleteSelectedInvoices" runat="server" Text="Delete Selected" OnClick="btnDeleteSelectedInvoices_Click" />
                <asp:Button ID="btnAddMoreInvoices" runat="server" Text="Add Invoices" />
            </td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td colspan="2">
                 <asp:GridView ID="listOfBucketInvoices" runat="server" AutoGenerateColumns="False"  CssClass="mydatagrid" PagerStyle-CssClass="pager"
                              HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
               <Columns>
                   
                   <asp:TemplateField>
                       <ItemTemplate>
                           <asp:CheckBox runat="server" ID="chkSelected"/>
                          
                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Id">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblSupplierInvoicesEntityId"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).Id %>'></asp:Label>

                           </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Doc Reference">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblDocReference"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).DocReference %>'></asp:Label>

                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Invoice Date">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblInvoiceDate"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).InvoiceDate.ToShortDateString() %>'></asp:Label>                    

                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Total Amount">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblTotalAmount"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).TotalAmount.ToString("C") %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                   <asp:TemplateField HeaderText="Flag">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblCreditDebitFlag"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).CreditDebitFlag %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>

                   
                   <asp:TemplateField HeaderText="Credit Ref">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblCreditReference"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).CreditReference %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                   <asp:TemplateField HeaderText="Due Date">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblDueDate"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).DueDate.ToShortDateString() %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>

                   </Columns>
                </asp:GridView>

            </td>
            <td>
                &nbsp;
            </td>
        </tr>
  
        
        
        
        
        
        
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteBucket" runat="server" Text="Delete" OnClick="btnDeleteBucket_Click" />
                <asp:Button ID="btnSubmitBucket" runat="server" Text="Submit" OnClick="btnSubmitBucket_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:ValidationSummary runat="server" ID="vSummary" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vgBucket" />
        
        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlId="btnAddMoreInvoices" 
                                        PopupControlID="ModalPanel" OkControlID="OKButton" />
        
        <asp:Panel ID="ModalPanel" runat="server" Width="800px" CssClass="ShowModal">
          <h2>Pending Invoices</h2>
            
                <asp:GridView ID="listOfPendingInvoices" runat="server" AutoGenerateColumns="False"  CssClass="mydatagrid" PagerStyle-CssClass="pager"
                              HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
               <Columns>
                   
                   <asp:TemplateField>
                       <ItemTemplate>
                           <asp:CheckBox runat="server" ID="chkSelected"/>
                          
                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Id">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblSupplierInvoicesEntityId"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).Id %>'></asp:Label>

                           </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Doc Reference">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblDocReference"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).DocReference %>'></asp:Label>

                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Invoice Date">
                       <ItemTemplate>
                           <asp:Label runat="server" ID="lblInvoiceDate"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).InvoiceDate.ToShortDateString() %>'></asp:Label>                    

                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Total Amount">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblTotalAmount"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).TotalAmount.ToString("C") %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                   <asp:TemplateField HeaderText="Flag">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblCreditDebitFlag"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).CreditDebitFlag %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>

                   
                   <asp:TemplateField HeaderText="Credit Ref">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblCreditReference"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).CreditReference %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                   <asp:TemplateField HeaderText="Due Date">
                       <ItemTemplate>
                              
                           <asp:Label runat="server" ID="lblDueDate"
                                      Text='<%# (Container.DataItem as Application.Common.ViewModels.InvoiceViewModel).DueDate.ToShortDateString() %>'></asp:Label>   


                       </ItemTemplate>
                   </asp:TemplateField>

                   </Columns>
                </asp:GridView>

                    
                    
            <asp:Button runat="server" ID="btnAddSelectedInvoices" Text="Add Selected" OnClick="btnAddSelectedInvoices_OnClick"/>
                    
            
            <asp:Button ID="OKButton" runat="server" Text="Close" />
        </asp:Panel>


    </div>

</asp:Content>
