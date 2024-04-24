using Allure.NUnit.Attributes;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class CRUD_ProjectTest : BaseUITest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [Order(1)]
        //[Ignore("Ignore this Test")]
        //[Repeat(3)]
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

            ProjectsOverviewPage projectsOverviewPage = actionsSteps.AddProjectButtonClick();
            Assert.That(projectsOverviewPage.IsPageOpened); //страница addProjectPage открыта

            ProjectsAdminPage projectsAdminPage = actionsSteps.ManageProjectsButtonClick();

            Assert.That(projectsAdminPage.IsPageOpened);

        }

        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [Order(2)]
        //[Ignore("Ignore this Test")]
        //[Repeat(10)]
        public void DeleteProject_CRUD_ProjectTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта
            ActionsSteps actionsSteps = new(Driver);
            ProjectsOverviewPage projectsOverviewPage = actionsSteps.ProjectLinkClick();
            ProjectsAdminPage projectsAdminPage = actionsSteps.ManageProjectsButtonClick();
            actionsSteps.DeleteProject();
            Assert.Multiple(() =>
            {
                Assert.That(projectsAdminPage.RemovableProjectButton.Displayed);
                Assert.That(projectsAdminPage.IsProjectWasDelete());
            });
        }
    }
}
