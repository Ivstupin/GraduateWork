using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Core;
using System.Net;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
namespace GraduateWork.Tests.API_Tests
{
    public class ReqresInTest
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        const string BaseRestUri = "https://ivst.testmo.net";
        [Test]
        public void SimpleGetTest()
        {
            const string endpoint = "/api/v1/users/1";

            var options = new RestClientOptions(BaseRestUri)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("testmo_api_eyJpdiI6ImxCQWNsUFlYbXo4bHRwdUhDUENsbHc9PSIsInZhbHVlIjoidlFJMkFCa3BHRzZlazVBaEYzZUh6OUI3aGR4M2Yya1ZJeG8vclR0eDJjND0iLCJtYWMiOiJhNjg3ZTJiNGRmNzllNmUyODcyMTgyZGVjN2QxZmJmZjg2NDhlYzAxNjY1NzZkOTM5ZTEwZjUzNTFkMDEyMmQzIiwidGFnIjoiIn0=")
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint);

            var response = client.ExecuteGet(request);
            Logger.Info(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
