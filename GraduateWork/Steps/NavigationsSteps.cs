using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GraduateWork.Steps;

public class NavigationsSteps : BaseSteps
{
    public AddProjectPage addProjectPage;
    public ProjectsPage projectsPage;
    public ProjectsOverviewPage projectsOverviewPage;
    public ProjectsAdminPage projectsAdminPage;
    public RepositoryPage repositoryPage;
    public NavigationsSteps(IWebDriver driver) : base(driver)
    {
        addProjectPage = new AddProjectPage(Driver);
        
        projectsOverviewPage = new ProjectsOverviewPage(Driver);
        projectsAdminPage = new ProjectsAdminPage(Driver);
        //projectsPage = new ProjectsPage(Driver);
         repositoryPage = new RepositoryPage(Driver);
    }

    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage PlusProjectButtonClick() 
    {
        projectsPage._PlusProjectButton.Click();
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

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public ProjectsAdminPage ManageProjectsButtonClick()
    {
        projectsOverviewPage.ManageProjectsButtonLink.Click();

        return new ProjectsAdminPage(Driver);
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public ProjectsAdminPage DeleteProject()
    {
        projectsAdminPage.DeleteButton
            .Click();
        projectsAdminPage.CheckboxDelete
            .Click();
        projectsAdminPage.DeleteProjectButton
            .Click();
        return projectsAdminPage;
    }
    public RepositoryPage ToRepositoryPage()
    {
        projectsOverviewPage.RepositoryButton.Click();

        return new RepositoryPage(Driver);
    }



}


