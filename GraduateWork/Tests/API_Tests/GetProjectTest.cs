using GraduateWork.Models;
using GraduateWork.Services;
using GraduateWork.Tests;
using NLog;
using GraduateWork.Models;
using System.Net;

namespace GraduateWork.Tests.API_Tests
{
    public class GetProjectTest : BaseApiTest //AFE
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
       // private Project _project = new Project();

        [Test]
        [Order(1)]
        public void GetProject_test()
        {
          var actualProject = ProjectService!.GetProject("161");

           Assert.That(actualProject.Result.Id, Is.EqualTo("4"));

            _logger.Info(actualProject);
        }

        [Test]
        [Order(2)]
        public void GetProjects_test()
        {
            var actualProject1 = ProjectService!.GetProjects();

            Assert.That(actualProject1.Result.Page, Is.EqualTo(1));
            Assert.That(actualProject1.Result.Total, Is.EqualTo(7));
            // _logger.Info(actualProject1);
        }
    }
}