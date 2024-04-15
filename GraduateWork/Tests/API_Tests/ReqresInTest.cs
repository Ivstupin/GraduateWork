using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Core;
using System.Net;
namespace GraduateWork.Tests.API_Tests
{
    public class ReqresInTest
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        const string baseUrl = "https://ivst.testmo.net";
        [Test]
        public void SimpleGetTest()
        {
            const string endpoint = "/api/v1/users/1";
            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint);
            var response = client.ExecuteGet(request);
            Logger.Info(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
