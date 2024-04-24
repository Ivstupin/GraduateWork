using GraduateWork.Models;
using NLog;
using System.Net;
using Newtonsoft.Json;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace GraduateWork.Tests.API_Tests
{
    //[AllureSuite("API_Tests")]
    public class GetTest : BaseApiTest 
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
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
                Assert.That(allProjects.Result.Total, Is.EqualTo(5));
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
            var incorrectUser = ProjectService!.GetInvalidUser();
            Assert.That(incorrectUser.Result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            ErrorResponse invalid = JsonConvert.DeserializeObject<ErrorResponse>(incorrectUser.Result.Content);
            Assert.Multiple(() =>
            {
                Assert.That(invalid.Message, Is.EqualTo("The user does not exist or was disabled."));
                Assert.That(invalid.Сode, Is.EqualTo(0));
            });

            AllureApi.Step("Получена ожидаемая ошибка");
        }

        [Test]
        [Category("AFE_GET")]
        public void GetIncorrectProject()
        {
            var incorrectProject = ProjectService!.GetInvalidProject();
            Assert.That(incorrectProject.Result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            ErrorResponse invalid = JsonConvert.DeserializeObject<ErrorResponse>(incorrectProject.Result.Content);
            Assert.Multiple(() =>
            {
                Assert.That(invalid.Message, Is.EqualTo("The project does not exist or you do not have the permissions to access it."));
                Assert.That(invalid.Сode, Is.EqualTo(0));
            });

            AllureApi.Step("Получена ожидаемая ошибка");
        }
    }
}