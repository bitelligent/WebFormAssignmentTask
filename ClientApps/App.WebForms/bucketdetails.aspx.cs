using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Application.Common.ConfigSettings;
using Application.Common.Messages.Bucket.Requests;
using Application.Common.ViewModels;
using WebForms.Services.Bucket;
using WebForms.Services.Invoice;

namespace App.WebForms
{
    public partial class _bucketdetails : Page
    {

        #region Config to handle
        private Config _config;
        protected Config Config
        {
            get
            {
                if (_config == null)
                    _config = new Config();

                return _config;
            }
        }

        #endregion

        #region Bucket to handle
        private IBucketHttpClientService bucketHttpClientService;
        protected IBucketHttpClientService _bucketHttpClientService
        {
            get
            {
                if (bucketHttpClientService == null)
                    bucketHttpClientService = new BucketHttpClientService();

                return bucketHttpClientService;
            }
        }



        #endregion



        #region Bucket to handle
        private IInvoiceHttpClientService invoiceHttpClientService;
        protected IInvoiceHttpClientService _invoiceHttpClientService
        {
            get
            {
                if (invoiceHttpClientService == null)
                    invoiceHttpClientService = new InvoiceHttpClientService();

                return invoiceHttpClientService;
            }
        }



        #endregion



        #region BucketID to handle
        private int _bucketId;
        protected int BucketId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    _bucketId = Convert.ToInt32(Request.QueryString["id"].ToString());

                return _bucketId;
            }
        }



        #endregion

        //  private BucketApiClient _bucketClient = new BucketApiClient();
        //   
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {

               btnDeleteSelectedInvoices.OnClientClick = "return confirm('Are you sure you want to delete the selected items?');";
               btnUpdateDate.OnClientClick = "return confirm('Are you sure you want to update the date?');";
               btnDeleteBucket.OnClientClick = "return confirm('Are you sure you want to delete the bucket?');";
               btnSubmitBucket.OnClientClick = "return confirm('Are you sure you want to submit the bucket?');";

                LoadPendingInvoices();
                LoadBucket();
            }
        }

        private void LoadPendingInvoices()
        {
            var response = _invoiceHttpClientService.GetPendingInvoices();
            if (!response.Success)
            {
                lblErrorMessage.Text = response.ErrorMessage;
                return;
                
            }

            listOfPendingInvoices.DataSource = response.PendingInvoices;
            listOfPendingInvoices.DataBind();
        }


        private void LoadBucket()
        {


            var bucketDetailRespone = _bucketHttpClientService.GetBucketDetails(BucketId);

            if (!bucketDetailRespone.Success)
            {
                lblErrorMessage.Text = bucketDetailRespone.ErrorMessage;
                return;
                
            }

            if (bucketDetailRespone.Bucket == null)
            {
                lblErrorMessage.Text = "Bucket not found!";
                return;
            }

            if (!bucketDetailRespone.Bucket.IsEditingAllowed())
            {
                btnSubmitBucket.Enabled = false;
                btnAddMoreInvoices.Enabled = false;
                btnDeleteBucket.Enabled = false; 
                btnDeleteSelectedInvoices.Enabled = false;
                btnUpdateDate.Enabled = false;

            }

            txtTitle.Text = bucketDetailRespone.Bucket.Title;
            txtDate.Text = bucketDetailRespone.Bucket.FutureFinanceDate.ToShortDateString();
            cboType.SelectedValue = bucketDetailRespone.Bucket.FinanceMethod;

            listOfBucketInvoices.DataSource = bucketDetailRespone.Bucket.SupplierInvoices;
            listOfBucketInvoices.DataBind();




        }

        protected void btnAddSelectedInvoices_OnClick(object sender, EventArgs e)
        {
            AddSelectedInvoicesToCurrentBucket();
        }

        private void AddSelectedInvoicesToCurrentBucket()
        {
            var listOfSelectedInvoices = GetListOfSelecetedInvoiceIds(listOfPendingInvoices);

            var request = new AddInvoicesRequest {BucketId = BucketId, InvoiceIds = listOfSelectedInvoices};

            var response = _bucketHttpClientService.AddInvoicesToBucket(request);

            if (!response.Success)
            {
                lblErrorMessage.Text = response.ErrorMessage;
                return;
            }

            LoadPendingInvoices();
            LoadBucket();
        }

        private List<int> GetListOfSelecetedInvoiceIds(GridView grid)
        {
            var listOfInvoiceIds = new List<int>();

            foreach (GridViewRow row in grid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSelected = (row.Cells[0].FindControl("chkSelected") as CheckBox);
                    if (chkSelected.Checked)
                    {
                        string Id = (row.Cells[1].FindControl("lblSupplierInvoicesEntityId") as Label).Text;
                        int invoiceId = 0;
                        
                        int.TryParse(Id, out invoiceId);
                        if(invoiceId > 0)
                            listOfInvoiceIds.Add(invoiceId);
                    }
                }
            }

            return listOfInvoiceIds;
        }

        protected void btnDeleteSelectedInvoices_Click(object sender, EventArgs e)
        {
            RemoveInvoicesFromCurrentBucket();
        }

        private void RemoveInvoicesFromCurrentBucket()
        {
            var listOfSelectedInvoices = GetListOfSelecetedInvoiceIds(listOfBucketInvoices);

            var request = new RemoveInvoicesRequest() {BucketId = BucketId, InvoiceIds = listOfSelectedInvoices};

            var response = _bucketHttpClientService.RemoveInvoicesToBucket(request);

            if (!response.Success)
            {
                lblErrorMessage.Text = response.ErrorMessage;
                return;
            }

            LoadPendingInvoices();
            LoadBucket();
        }

        protected void btnDeleteBucket_Click(object sender, EventArgs e)
        {
            DeleteCurentBucket();
        }

        private void DeleteCurentBucket()
        {
           
            var request = new DeleteBucketRequest() { BucketId = BucketId };

            var response = _bucketHttpClientService.DeleteBucket(request);

            if (!response.Success)
            {
                lblErrorMessage.Text = response.ErrorMessage;
                return;
            }

            Response.Redirect("/");

        }


        private void SubmitCurentBucket()
        {

            var request = new SubmitBucketRequest() { BucketId = BucketId };

            var response = _bucketHttpClientService.SubmitBucket(request);

            if (!response.Success)
            {
                lblErrorMessage.Text = response.ErrorMessage;
                return;
            }

            Response.Redirect("/");

        }

        protected void btnSubmitBucket_Click(object sender, EventArgs e)
        {
            SubmitCurentBucket();
        }

        protected void btnUpdateDate_Click(object sender, EventArgs e)
        {
            UpdateBucketDate();


        }

        protected void UpdateBucketDate()
        {
            try
            {
                var request = new UpdateDateRequest() { BucketId = BucketId, UpdateDate = DateTime.Parse(txtDate.Text) };
                var response = _bucketHttpClientService.UpdateDate(request);

                if (!response.Success)
                {
                    lblErrorMessage.Text = response.ErrorMessage;
                    return;
                }

                Response.Redirect("/");
            }
            catch (Exception e)
            {
                lblErrorMessage.Text = "Enter Valid date";
            }
            

          
        }
    }
}