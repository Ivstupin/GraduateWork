using GraduateWork.Pages;
using OpenQA.Selenium;
//using GraduateWork.Pages;
using GraduateWork.Helpers.Configuration;

namespace GraduateWork.Steps;

public class UserSteps : BaseSteps
{
    public LoginPage loginPage;
    public ProjectsPage projectsPage;

    public UserSteps(IWebDriver driver) : base(driver)
    {
        loginPage = new LoginPage(Driver);
        projectsPage = new ProjectsPage(Driver);
    }
    public ProjectsPage LoginByCorrect_User()
    {
        loginPage.UserEmailInput.SendKeys(Configurator.AppSettings.Email);
        loginPage.PswInput.SendKeys(Configurator.AppSettings.Password);
        loginPage.LoginInButton.Click();
        return new ProjectsPage(Driver);
    }

    public LoginPage LoginByWrong_PSW()
    {
        loginPage.UserEmailInput.SendKeys(Configurator.AppSettings.Email);
        loginPage.PswInput.SendKeys(Configurator.AppSettings.Password + "wrong_psw");
        loginPage.LoginInButton.Click();
        return loginPage;
    }


    //public ProductsPage LoginByPerformance_Glitch_User()
    //{
    //    _loginPage.UserNameInput.SendKeys(performance_Glitch_User);
    //    _loginPage.PswInput.SendKeys(PswForAllUsers);
    //    _loginPage.LoginInButton.Click();
    //    return new ProductsPage(Driver);
    //}

    //public ProductsPage LoginByError_User()
    //{
    //    _loginPage.UserNameInput.SendKeys(error_User);
    //    _loginPage.PswInput.SendKeys(PswForAllUsers);
    //    _loginPage.LoginInButton.Click();
    //    return new ProductsPage(Driver);
    //}
    //public ProductsPage LoginByVisual_User()
    //{
    //    _loginPage.UserNameInput.SendKeys(visual_User);
    //    _loginPage.PswInput.SendKeys(PswForAllUsers);
    //    _loginPage.LoginInButton.Click();
    //    return new ProductsPage(Driver);
    //}

    //public LoginPage LoginByInvalidUserNameAndPsw()
    //{
    //    _loginPage.UserNameInput.SendKeys("gdf");
    //    _loginPage.PswInput.SendKeys("fghgf");
    //    _loginPage.LoginInButton.Click();
    //    return _loginPage;
    //}
    //public LoginPage LoginByLockedUser()
    //{
    //    _loginPage.UserNameInput.SendKeys(locked_Out_User);
    //    _loginPage.PswInput.SendKeys(PswForAllUsers);
    //    _loginPage.LoginInButton.Click();
    //    return _loginPage;
    //}
    //public LoginPage LoginByEmptyUserName()
    //{
    //    _loginPage.UserNameInput.SendKeys("");
    //    _loginPage.PswInput.SendKeys(PswForAllUsers);
    //    _loginPage.LoginInButton.Click();
    //    return _loginPage;
    //}
    //public LoginPage LoginByEmptyPsw()
    //{
    //    _loginPage.UserNameInput.SendKeys("asd");
    //    _loginPage.PswInput.SendKeys("");
    //    _loginPage.LoginInButton.Click();
    //    return _loginPage;
    //}

    //Users
    readonly string standard_User = "standard_user";
    readonly string locked_Out_User = "locked_out_user";
    readonly string problem_User = "problem_user";
    readonly string performance_Glitch_User = "performance_glitch_user";
    readonly string error_User = "error_user";
    readonly string visual_User = "visual_user";
    //
    readonly string PswForAllUsers = "secret_sauce"; // пароль
}