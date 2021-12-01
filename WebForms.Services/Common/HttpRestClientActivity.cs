using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebForms.Services.ExtensionMethods;
namespace WebForms.Services.Common
{
    public class HttpRestClientActivity
    {


        public  T RestActivity<T>(string baseUrl, string endPoint, Method method, object jsonObject = null,
                                                                Dictionary<string, string> pathParam = null,
                                                                Dictionary<string, string> postParam = null,
                                                                List<UploadedFile> fileParam = null,
                                                                bool ismultiPart = false) where T : new()
        {
            T resultObject;


            var client = new RestClient(baseUrl);
            var restRequest = new RestRequest(endPoint, method);
            SetHeaders(restRequest, ismultiPart);

            if (jsonObject != null)
                restRequest.AddJsonBody(jsonObject);

            if (pathParam != null && pathParam.Count > 0)
                foreach (var p in pathParam)
                    restRequest.AddUrlSegment(p.Key, p.Value);

            if (postParam != null && postParam.Count > 0)
                foreach (var p in postParam)
                    restRequest.AddParameter(p.Key, p.Value);

            if (fileParam != null && fileParam.Count > 0)
            {



                foreach (var p in fileParam)
                    restRequest.AddFile(p.FieldName, p.GetBytes(), p.FileName, p.MimeType);

                restRequest.AlwaysMultipartFormData = true;
            }

            var asyncResponse =  client.Execute<T>(restRequest);


            if (asyncResponse.IsSuccessful())
            {
                resultObject = asyncResponse.Data;
            }
            else
            {
                var resultMessage = HandleErrorResponse(restRequest, asyncResponse);
                throw new HttpException(resultMessage);

            }


            resultObject = (T)asyncResponse.Data;


            return resultObject;
        }


        private void SetHeaders(RestRequest request, bool multipart)
        {
            if (multipart)
            {
                request.JsonSerializer.ContentType = "multipart/form-data";
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AlwaysMultipartFormData = true;
            }
            else
            {
                request.AddHeader("Content-Type", "application/json");
            }

        }




        private string HandleErrorResponse(IRestRequest request, IRestResponse response)
        {
            string statusString =
                string.Format("{0} {1} - {2}", (int)response.StatusCode,
                    response.StatusCode, response.StatusDescription);

            string errorString = "Response status: " + statusString;

            string resultMessage = "";
            if (!response.StatusCode.IsSuccessStatusCode())
            {
                if (string.IsNullOrWhiteSpace(resultMessage))
                {
                    resultMessage = "An error occurred while processing the request: "
                                    + response.StatusDescription;
                }
            }
            if (response.ErrorException != null)
            {
                if (string.IsNullOrWhiteSpace(resultMessage))
                {
                    resultMessage = "An exception occurred while processing the request: "
                                    + response.ErrorException.Message;
                }
                errorString += ", Exception: " + response.ErrorException;
            }

            // (other error handling here)

            return resultMessage + " - " + errorString;
        }


        public class UploadedFile
        {
            public string FilePath { get; set; }
            public string FileName { get; set; }
            public string FieldName { get; set; }

            public string MimeType
            {
                get
                {
                    var fileName = Path.GetFileName(FilePath);

                    if (fileName != null) return MimeMapping.GetMimeMapping(fileName);

                    return "";
                }
            }

            public byte[] GetBytes()
            {

                 return File.ReadAllBytes(FilePath);

            }





        }





    }
}
