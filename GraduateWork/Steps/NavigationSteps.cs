using GraduateWork.Pages;
using OpenQA.Selenium;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using Allure.NUnit.Attributes;
using System.Reflection;

namespace GraduateWork.Steps;

public class NavigationSteps : BaseSteps
{
    public NavigationSteps(IWebDriver driver) : base(driver) { }
    
    [AllureStep]
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }

    [AllureStep]
    public ProjectsPage NavigateToProjectsPage()
    {
        return new ProjectsPage(Driver);
    }


    [AllureStep]
    public ProjectsPage SuccessfulLogin(User user)
    {
        return Login<ProjectsPage>(user);
    }

    [AllureStep]
    public LoginPage IncorrectLogin(User user)
    {
        return Login<LoginPage>(user);
    }

    public T Login<T>(User user) where T : BasePage
    {
        LoginPage = new LoginPage(Driver);

        LoginPage.UserEmailInput.SendKeys(user.Email);
        LoginPage.PswInput.SendKeys(user.Password);
        LoginPage.LoginInButton.Click();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }

    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage NavigateAddProjectPage()
    {
        return new AddProjectPage(Driver);
    }
    public ProjectsOverviewPage NavigateProjectsOverviewPage()
    {
        return new ProjectsOverviewPage(Driver);
    }

    public ProjectsAdminPage NavigateProjectsAdminPage()
    {
        return new ProjectsAdminPage(Driver);
    }

    public AddProjectPage InputValuesInSummaryInputField(string values)
    {
        AddProjectPage = new AddProjectPage(Driver);
        AddProjectPage.SummaryInputField.Click();
        AddProjectPage.SummaryInputField.Clear();
        AddProjectPage.SummaryInputField.SendKeys(values);
        return AddProjectPage;
    }

    public RepositoryPage NavigateRepositoryPage()
    {
        return new RepositoryPage(Driver);
    }

    /// <summary>
    /// при создании тест-кейса загружаем картинку с котом во вложения
    /// </summary>
    //public RepositoryPage UploadFile()
    //{
    //    RepositoryPage repositoryPage = new RepositoryPage(Driver);

    //    string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    //    string filePath = Path.Combine(assemblyPath, "Resources", "cat_time.jpg");

    //    repositoryPage.ChooseFilesFileUpload.SendKeys(filePath);

    //    if (repositoryPage.ImageUploaded.Displayed)
    //    {
    //        repositoryPage.AddCaseButton.Click();
    //    }
    //    else throw new Exception("Файл не загружен");

    //    return repositoryPage;
    //}

    /// <summary>
    /// на странице RepositoryPage заполняем поле ввода Name при создании тест-кейса
    /// </summary>
    public RepositoryPage NameInputFieldAddTestCase(string values)
    {
        RepositoryPage  = new RepositoryPage(Driver);
       // RepositoryPage.NameInputField.Click();
       //RepositoryPage.NameInputField.Clear();
        RepositoryPage.NameInputField.SendKeys(values);
        return RepositoryPage;
    }

}