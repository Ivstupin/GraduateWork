using Allure.NUnit.Attributes;
using GraduateWork.Pages;
using GraduateWork.Steps;
using OpenQA.Selenium;

namespace GraduateWork.Tests
{
    public class CRUD_ProjectTest : BaseTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        //[Ignore("Ignore this Test")]
        //[Repeat(2)]
        public void CreateProject_CRUD_ProjectTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
            Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта

            actionsSteps.InputValuesInNameInputField("Тестовый проект");
            actionsSteps.InputValuesInSummaryInputField("Тестовое описание");
            //Thread.Sleep(10000);
            ProjectsOverviewPage projectsOverviewPage = actionsSteps.AddProjectButtonClick();
            //Thread.Sleep(10000);
            Assert.That(projectsOverviewPage.IsPageOpened); //страница addProjectPage открыта

            NavigationsSteps navigationsSteps = new(Driver);
            ProjectsAdminPage projectsAdminPage = navigationsSteps.ManageProjectsButtonClick();
            Assert.That(projectsAdminPage.IsPageOpened);

            //Thread.Sleep(10000);

        }
        
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        //[Ignore("Ignore this Test")]
        //[Repeat(20)]
        public void DeleteProject_CRUD_ProjectTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            //ActionsSteps actionsSteps = new(Driver);

            //ProjectsAdminPage projectsAdminPage = new(Driver);
           // ActionsSteps actionsSteps = new(Driver);
            NavigationsSteps navigationsSteps = new(Driver);
            ProjectsOverviewPage projectsOverviewPage = navigationsSteps.ProjectLinkClick();
            ProjectsAdminPage projectsAdminPage = navigationsSteps.ManageProjectsButtonClick();
            navigationsSteps.DeleteProject();
            Assert.Multiple(() =>
            {
                Assert.That(projectsAdminPage.RemovableProjectButton.Displayed);
                Assert.That(projectsAdminPage.IsProjectWasDelete());
            });
            
            //actionsSteps.DeleteProject();
            //Thread.Sleep(40000);
        }
    }
}
