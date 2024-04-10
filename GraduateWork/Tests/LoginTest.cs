using GraduateWork.Tests;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests;

public class LoginTest : BaseTest
{
    [Test]
    public void SuccessfulLoginTest()
    {
        UserSteps userSteps = new UserSteps(Driver);
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User();
        Thread.Sleep(5000);
        Assert.That(projectsPage.IsPageOpened);
        
    }

    //[Test]
    //public void LoginByProblem_UserLoginTest()
    //{
    //    UserSteps userSteps = new(Driver);
    //    ProductsPage productsPage = userSteps
    //        .LoginByProblem_user();

    //    Assert.That(productsPage.IsPageOpened);
    //}

    //[Test]
    //public void LoginByPerformance_Glitch_User_LoginTest()
    //{
    //    UserSteps userSteps = new(Driver);
    //    ProductsPage productsPage = userSteps
    //        .LoginByPerformance_Glitch_User();

    //    Assert.That(productsPage.IsPageOpened);
    //}

    //[Test]
    //public void LoginByError_User_LoginTest()
    //{
    //    UserSteps userSteps = new(Driver);
    //    ProductsPage productsPage = userSteps
    //        .LoginByError_User();

    //    Assert.That(productsPage.IsPageOpened);
    //}

    //[Test]
    //public void LoginByVisual_UserLoginTest()
    //{
    //    UserSteps userSteps = new(Driver);
    //    ProductsPage productsPage = userSteps
    //        .LoginByVisual_User();

    //    Assert.That(productsPage.IsPageOpened);
    //}

    //[Test]
    //public void InvalidUserNameAndPswLoginTest()
    //{
    //    Assert.That(
    //         new UserSteps(Driver)
    //          .LoginByInvalidUserNameAndPsw()
    //          .ErrorLab.Text.Trim(),
    //        Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    //}

    //[Test]
    //public void LockedUserLoginTest()
    //{
    //    Assert.That(
    //         new UserSteps(Driver)
    //          .LoginByLockedUser()
    //          .ErrorLab.Text.Trim(),
    //        Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    //}

    //[Test]
    //public void EmptyUserNameLoginTest()
    //{
    //    Assert.That(
    //         new UserSteps(Driver)
    //          .LoginByEmptyUserName()
    //          .ErrorLab.Text.Trim(),
    //        Is.EqualTo("Epic sadface: Username is required"));
    //}

    //[Test]
    //public void EmptyPswLoginTest()
    //{
    //    Assert.That(
    //         new UserSteps(Driver)
    //          .LoginByEmptyPsw()
    //          .ErrorLab.Text.Trim(),
    //        Is.EqualTo("Epic sadface: Password is required"));
    //}
}