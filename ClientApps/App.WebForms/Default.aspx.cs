using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.WebSockets;
using Application.Common.ConfigSettings;
using Application.Common.ViewModels;
using WebForms.Services.Bucket;

namespace App.WebForms
{
    public partial class _Default : Page
    {

        #region Config to handle
        private Config _config;
        protected Config Config
        {
            get
            {
                if (_config == null)
                 _config= new Config();

                return _config;
            }
        }

        #endregion

        #region Config to handle
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



        //  private BucketApiClient _bucketClient = new BucketApiClient();
        //   
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                LoadBuckets();
            }
        }





        private void LoadBuckets()
        {


            var bucketListResponse = _bucketHttpClientService.BucketList();
            if (!bucketListResponse.Success)
            {
                lblErrorMessage.Text = bucketListResponse.ErrorMessage;
                return;

            }

            gridOfBuckets.DataSource = bucketListResponse.Buckets;
            gridOfBuckets.DataBind();




        }
    }
}