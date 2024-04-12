using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests
{
    public class CRUD_ProjectTest : BaseTest
    {
        [Test,Order(1)]
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
        
        [Test, Order(2)]
        //[Ignore("Ignore this Test")]
        //[Repeat(1)]
        public void DeleteProject_CRUD_ProjectTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            //ActionsSteps actionsSteps = new(Driver);

            //ProjectsAdminPage projectsAdminPage = new(Driver);
           // ActionsSteps actionsSteps = new(Driver);
            NavigationsSteps navigateSteps = new(Driver);
           
            ProjectsAdminPage projectsAdminPage = navigateSteps.DeleteProject();
            
           //actionsSteps.DeleteProject();
            //Thread.Sleep(10000);
        }
    }
}
