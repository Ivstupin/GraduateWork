﻿using Allure.NUnit;
using GraduateWork.Clients;
using GraduateWork.Services;
using NLog;

namespace GraduateWork.Tests.API_Tests 
{
    [Parallelizable(scope: ParallelScope.Fixtures)]
    
    [AllureNUnit]
    public class BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected ProjectService? ProjectService;

        [OneTimeSetUp]
        public void SetUpApi()
        {
            var restClient = new RestClientExtended();
            ProjectService = new ProjectService(restClient);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ProjectService?.Dispose();
        }
    }
}