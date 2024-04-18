using GraduateWork.Pages;
using OpenQA.Selenium;
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
}