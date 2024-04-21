﻿using GraduateWork.Models;
using GraduateWork.Services;
using GraduateWork.Tests;
using NLog;
using GraduateWork.Models;
using System.Net;
using System.Net.Mail;

namespace GraduateWork.Tests.API_Tests
{
    public class GetProjectTest : BaseApiTest //AFE
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
         private AutomationRun _automationRun  = new AutomationRun();
        public  int totalAutomationRunsTest;

        [Test]
        //[Order(1)]
        public void GetProject_test()
        {
            
            var actualProject = ProjectService!.GetProject();
            //Assert.That(actualProject.Equals , ( ));

            //Assert.That(actualProject.Result.Run_count, Is.EqualTo(4));

            _logger.Info(actualProject);
        }

        [Test]
        //[Order(2)]
        public void GetProjects_test()
        {

            var actualProject1 = ProjectService!.GetProjects();

            Assert.Multiple(() =>
            {
                Assert.That(actualProject1.Result.Page, Is.EqualTo(1));
                Assert.That(actualProject1.Result.Total, Is.EqualTo(4));
            });
            // _logger.Info(actualProject1);
        }

        [Test]
        [Order(1)]
        public void GetAllAutomationRunsTest()
        {
            var actualProject1 = ProjectService!.GetAllAutomationRuns();

            Assert.That(actualProject1.Result.Page, Is.EqualTo(1));
            Assert.That(actualProject1.Result.Per_page, Is.EqualTo(100)); 
             totalAutomationRunsTest = actualProject1.Result.Total;
             
        }

        [Test]
        [Order(2)]
        public void PostAutomationRunsTest()
        {
            _automationRun = new AutomationRun
            {
                Name = "WP Test 1",
                Source = "frontend"
            };

            var actual_automationRun = ProjectService!.PostAutomationRun(_automationRun);

            // Блок проверок
           
            
                Assert.That(actual_automationRun, Is.EqualTo(HttpStatusCode.Created));
            // Assert.That(actual_automationRun.Result.Source, Is.EqualTo(_automationRun.Source));
            // Assert.That(actual_automationRun.Result.SuiteMode, Is.EqualTo(_automationRun.SuiteMode));
            //Assert.That(totalAutomationRunsTest, Is.EqualTo(174));

           // _automationRun = actual_automationRun.Result;
           //_logger.Info(_automationRun.ToString);

        }

    }
}