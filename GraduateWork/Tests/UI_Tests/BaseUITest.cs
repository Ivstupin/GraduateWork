using GraduateWork.Core;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using NLog;

namespace GraduateWork.Tests.UI_Tests;

[Parallelizable(scope: ParallelScope.Fixtures)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseUITest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [OneTimeSetUp]
    public static void SuiteSetup()
    {
        //new NLogConfig().Config();
    }
    //public static void GlobalSetup()
    //{
    //    AllureLifecycle.Instance.CleanupResultDirectory();
    //}

    [SetUp]
    public void FactoryDriverTest()
    {
        //Logger.Error("Error level...");
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        

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