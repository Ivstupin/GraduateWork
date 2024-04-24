using GraduateWork.Core;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using NLog;
using Allure.NUnit.Attributes;
using GraduateWork.Steps;
using GraduateWork.Models;

namespace GraduateWork.Tests.UI_Tests;

[Parallelizable(scope: ParallelScope.Fixtures)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]

[AllureSuite("UI_Tests")]
public class BaseUITest
{
    protected IWebDriver Driver { get; private set; }
    //protected WaitsHelper WaitsHelper { get; private set; }
    protected NavigationSteps _navigationSteps;
    protected ActionsSteps _actionsSteps;
    protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    protected User? Admin { get; private set; }

    [OneTimeSetUp]
    //public static void SuiteSetup()
    //{
    //    //new NLogConfig().Config();
    //}
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    public void FactoryDriverTest()
    {
        //Logger.Error("Error level...");
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
        //WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        Admin = Configurator.Admin;

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;
                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }
        }
        catch (Exception) { throw; }
        Driver.Quit();
    }
}