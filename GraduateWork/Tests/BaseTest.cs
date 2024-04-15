using GraduateWork.Core;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using GraduateWork.Steps;
using Allure.NUnit;
using Allure.Net.Commons;
using System.Text;
using NLog;

namespace GraduateWork.Tests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    // protected NavigationsSteps navigationsSteps;
    protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    [OneTimeSetUp]
    public static void SuiteSetup() 
    {
        //new NLogConfig().Config();
    }
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    public void FactoryDriverTest()
    {
        //Logger.Error("Error level...");
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        // NavigationsSteps = new NavigationsSteps(Driver);

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
                //AllureApi.AddAttachment("data.txt", "text/plain", Encoding.UTF8.GetBytes("Content"));
            }
        }
        catch (Exception) {throw;}
        Driver.Quit();
    }
}