using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests
{
    public class CreateProjectTest : BaseTest
    {
        //[Test]
        //public void CreateProject()
        //{
        //    UserSteps userSteps = new(Driver);
        //    ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
        //    Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

        //    ActionsSteps actionsSteps = new(Driver);
        //    AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
        //    Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта
            
        //    actionsSteps.InputValuesInNameInputField("Тестовый проект");
        //    actionsSteps.InputValuesInSummaryInputField("Тестовое описание");
        //    Thread.Sleep(10000);
        //    ProjectsOverviewPage projectsOverviewPage = actionsSteps.AddProjectButtonClick();
        //    Thread.Sleep(10000);
        //    Assert.That(projectsOverviewPage.IsPageOpened); //страница addProjectPage открыта



        //    Thread.Sleep(10000);

        //}


        [Test]
        [Order(2)]
        public void DeleteProject()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
            Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта

            actionsSteps.InputValuesInNameInputField("Тестовый проект");
            actionsSteps.InputValuesInSummaryInputField("Тестовое описание");
            Thread.Sleep(10000);
            ProjectsOverviewPage projectsOverviewPage = actionsSteps.AddProjectButtonClick();
            Thread.Sleep(10000);
            Assert.That(projectsOverviewPage.IsPageOpened); //страница addProjectPage открыта



            Thread.Sleep(10000);

        }
    }
}
