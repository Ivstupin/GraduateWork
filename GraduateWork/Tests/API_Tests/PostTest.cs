using Allure.NUnit.Attributes;
using GraduateWork.Models;
using NLog;
using System.Net;

namespace GraduateWork.Tests.API_Tests
{
    [AllureSuite("API PostTest")]
    public class PostTest : BaseApiTest 
    {
        private AutomationRun _automationRun = new();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        [Test]
        [Category("NFE_POST")]
        public void PostAutomationRunTest()
        {
            var totalCntAutomationRuns = ProjectService!.GetAllAutomationRun().Result.Total;   //получение значения перед выполнением POST 
            
            _automationRun = new AutomationRun
            {
                Name = "WP Test 1",
                Source = "backend"
            };

            var postAutomationRun = ProjectService!.PostAutomationRun(_automationRun);           //выполнение POST
            Assert.That(postAutomationRun, Is.EqualTo(HttpStatusCode.Created));
            var totalCntAutomationRunsUpd = ProjectService!.GetAllAutomationRun().Result.Total;  //получение значения после выполнением POST 
            Assert.That(++totalCntAutomationRuns, Is.EqualTo(totalCntAutomationRunsUpd));        //сравнение значений до и после
        }
    }
}