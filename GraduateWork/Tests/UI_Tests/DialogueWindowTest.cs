using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class DialogueWindowTest : BaseUITest
    {
        [Test]
        public void _DialogueWindowTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
            Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта
            Assert.That(addProjectPage.DialogueWindowIsDisplayed);
        }
    }
}
