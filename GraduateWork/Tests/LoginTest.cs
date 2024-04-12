using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests;

public class LoginTest : BaseTest
{
    [Test]
    public void Successfull_LoginTest()
    {
        UserSteps userSteps = new(Driver);
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User();
        Assert.That(projectsPage.IsPageOpened);
    }

    [Test]
    public void WrongPassword_LoginTest()
    {
        UserSteps userSteps = new(Driver);
        LoginPage loginPage = userSteps.LoginByWrong_PSW();
        Thread.Sleep(5000);
        Assert.That(loginPage.IsPageOpened);
        Assert.That(loginPage.ErrorTextIsVisible);
    }
}