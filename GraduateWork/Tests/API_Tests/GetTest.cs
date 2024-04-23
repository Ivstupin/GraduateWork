using GraduateWork.Models;
using GraduateWork.Services;
using GraduateWork.Tests;
using NLog;
using GraduateWork.Models;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace GraduateWork.Tests.API_Tests
{
    public class GetTest : BaseApiTest 
    {
       // var _project;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
       // private AutomationRun _automationRun  = new AutomationRun();
        //public  int totalAutomationRunsTest;

        [Test]
        [Category("NFE_GET")]
        public void GetProject_test()
        {
            Project project = new Project();
            var actualProject = ProjectService!.GetProject(project);
            Assert.That(actualProject, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [Category("NFE_GET")]
        public void GetAllProjects_test()
        {
            var allProjects = ProjectService!.GetProjects();

            Assert.Multiple(() =>
            {
                Assert.That(allProjects.Result.Page, Is.EqualTo(1));
                Assert.That(allProjects.Result.Total, Is.EqualTo(7));
            });
        }

        [Test]
        [Category("NFE_GET")]
        public void GetAllAutomationRunsTest()
        {
            var autoRun_project = ProjectService!.GetAllAutomationRun().Result;

            Assert.Multiple(() =>
            {
                Assert.That(autoRun_project.Page, Is.EqualTo(1));
                Assert.That(autoRun_project.Last_page, Is.EqualTo(1));
            });
        }

        [Test]
        [Category("AFE_GET")]
        public void GetIncorrectUser()
        {
            var IncorrectUser = ProjectService!.GetInvalidUser();
            Assert.That(IncorrectUser, Is.EqualTo(HttpStatusCode.NotFound));

        }

        [Test]
        [Category("AFE_GET")]
        public void GetAllAutomationRunsTest5()
        {
            var autoRun_project = ProjectService!.GetAllAutomationRun().Result;

            Assert.Multiple(() =>
            {
                Assert.That(autoRun_project.Page, Is.EqualTo(1));
                Assert.That(autoRun_project.Last_page, Is.EqualTo(1));
            });
        }
    }
}