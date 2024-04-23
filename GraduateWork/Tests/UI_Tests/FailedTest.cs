using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests;

public class FailedTest : BaseUITest
{
    [Test]
    public void Failed_LoginTest_Nlog()
    {
        UserSteps userSteps = new(Driver);
        LoginPage loginPage = userSteps.LoginByWrong_PSW();
        ProjectsPage projectsPage = new(Driver);
        try
        {
            Assert.That(projectsPage.IsPageOpened);
        }
        catch (Exception ex) { Logger.Error(ex, "Логируем ошибку"); }
    }

    [Test]
    [Description("Тест имитирует дефект и должен упасть")]
    [Ignore("Ignore this Test")]
    public void Failed_LoginTest()
    {
        UserSteps userSteps = new(Driver);
        LoginPage loginPage = userSteps.LoginByWrong_PSW();
        ProjectsPage projectsPage = new(Driver);
        Assert.That(projectsPage.IsPageOpened);
    }
}