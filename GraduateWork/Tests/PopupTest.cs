using GraduateWork.Tests;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests
{
    public class PopupTest : BaseTest
    {
        [Test]
        public void PopupVisible()
        {
            UserSteps userSteps = new(Driver);
           ProjectsPage projectsPage = userSteps.LoginByCorrect_User();
            //Thread.Sleep(5000);
           Assert.That(projectsPage.IsPageOpened);

            projectsPage.MoveToPopupMessage(); Thread.Sleep(15000);
            
            Assert.That(projectsPage.IsPopupVisible()) ;
            // else(projectsPage.)
            //projectsPage.PopupMessage.
            Thread.Sleep(15000);
        }
    }
}
