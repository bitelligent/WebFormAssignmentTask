using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Application.Common.ConfigSettings
{
    public class Config
    {
        public string BucketBaseApiEndPointUrl()
        {
           return ConfigurationManager.AppSettings["bucket.baseURL"];
        }

        public string BucketListApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.bucketlist"];
            
        }

        public string PendingInvoicesEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.pendingInvoices"];
        }

        public string BucketDatabaseFilePath()
        {
            return "D:\\Development\\MyGitRepos\\WebFormAssignmentTask\\APIs\\Mock.Data\\Database\\Buckets.txt";
        }

        public string PendingInvoicesDatabaseFilePath()
        {
            return "D:\\Development\\MyGitRepos\\WebFormAssignmentTask\\APIs\\Mock.Data\\Database\\PendingInvoices.txt";
        
        }

        public string BucketDetailsApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.bucketdetails"];

        }

        public string AddInvoicesApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.addInvoices"];

        }

        public string DeleteBucketApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.deletebucket"];

        }

        public string SubmitBucketApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.submitbucket"];

        }

        public string RemoveInvoicesApiEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.removeInvoices"];

        }


        public string BucketDetailPageUrl()
        {
            return ConfigurationManager.AppSettings["BucketDetailPageUrl"];

        }

        public string BucketUpdateDateEndPointUrl()
        {
            return ConfigurationManager.AppSettings["bucketendpoints.updatedate"];

        }


        public string PencilIconGifUrl()
        {
            return ConfigurationManager.AppSettings["PencilIconGifUrl"];
        }

        public string GavelIconGifUrl()
        {
            return ConfigurationManager.AppSettings["GavelIconGifUrl"];
        }
    }
}
