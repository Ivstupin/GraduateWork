using GraduateWork.Models;
using GraduateWork.Services;
using GraduateWork.Tests;
using NLog;
using GraduateWork.Models;
using System.Net;

namespace GraduateWork.Tests.API_Tests
{
    public class PostTest : BaseApiTest //AFE
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        // private Project _project = new Project();

        [Test]
        [Order(1)]
        [Category("NFE")]
        public void PostTest1()
        {
            // var actualProject = ProjectService!.AddProject();

            // Assert.That(actualProject.Result.Name, Is.EqualTo("4"));

            // _logger.Info(actualProject.Result.ToString);
        }

        //    [Test]
        //    [Order(2)]
        //    public void GetProjects_test(AutomationRun automationRun)
        //    {
        //        var projects = ProjectService?.GetProjects().Result;

        //        _logger.Info(projects.Total);
        //        // foreach (var project in projects.)

        //        Assert.That(projects.Page, Is.EqualTo(1));
        //        Assert.That(projects.Total, Is.EqualTo(3));
        //        //_logger.Info(projects);
        //    }
        //}
    }
}