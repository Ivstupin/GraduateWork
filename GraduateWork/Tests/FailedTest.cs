using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests;

public class FailedTest : BaseTest
{
    [Test]
    [Description ("Тест имитирует дефект и должен упасть")]
    public void Failed_LoginTest()
    {
        UserSteps userSteps = new(Driver);
        LoginPage loginPage = userSteps.LoginByWrong_PSW();
        ProjectsPage projectsPage = new(Driver);
        Assert.That(projectsPage.IsPageOpened);
    }
}