using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class ActionsSteps : BaseSteps
{
    public AddProjectPage addProjectPage;
    public ProjectsPage projectsPage;
    public ProjectsOverviewPage projectsOverviewPage;

    public ActionsSteps(IWebDriver driver) : base(driver)
    {
        addProjectPage = new AddProjectPage(Driver);
        projectsPage = new ProjectsPage(Driver);
        projectsOverviewPage = new ProjectsOverviewPage(Driver);
    }

    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage PlusProjectButtonClick() 
    {
        projectsPage._AddProjectButton.Click();
        return new AddProjectPage(Driver);
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Summary
    /// </summary>
    public AddProjectPage InputValuesInSummaryInputField(string values)
    {
        addProjectPage.SummaryInputField.Click();
        addProjectPage.SummaryInputField.Clear();
        addProjectPage.SummaryInputField.SendKeys(values);
        return addProjectPage;
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public AddProjectPage InputValuesInNameInputField(string values)
    {
        addProjectPage.NameInputField.Click();
        addProjectPage.NameInputField.Clear();
        addProjectPage.NameInputField.SendKeys(values);
        return addProjectPage;
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public ProjectsOverviewPage AddProjectButtonClick()
    {
        addProjectPage._AddProjectButton.Click();
        
        return new ProjectsOverviewPage(Driver);
    }

}


