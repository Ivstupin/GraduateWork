using GraduateWork.Models;
using NLog;
using System.Net;

namespace GraduateWork.Tests.API_Tests
{
    public class PostTest : BaseApiTest 
    {
        private AutomationRun _automationRun = new();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        [Test]
        [Category("NFE")]
        public void PostAutomationRunsTest()
        {
            var totalCntAutomationRuns = ProjectService!.GetAllAutomationRuns().Result.Total;   //получение значения перед выполнением POST 
            
            _automationRun = new AutomationRun
            {
                Name = "WP Test 1",
                Source = "backend"
            };

            var postAutomationRun = ProjectService!.PostAutomationRun(_automationRun);           //выполнение POST
            Assert.That(postAutomationRun, Is.EqualTo(HttpStatusCode.Created));
            var totalCntAutomationRunsUpd = ProjectService!.GetAllAutomationRuns().Result.Total; //получение значения после выполнением POST 
            Assert.That(totalCntAutomationRuns, Is.EqualTo(totalCntAutomationRunsUpd));        //сравнение значений до и после
        }
    }
}