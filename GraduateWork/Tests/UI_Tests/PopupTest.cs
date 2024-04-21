using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class PopupTest : BaseUITest
    {
        [Test]
        public void PopupVisiblePopupTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User();
            Assert.That(projectsPage.IsPageOpened);
            projectsPage.MoveToPopupMessage();
            Assert.That(projectsPage.IsPopupVisible);
        }
    }
}