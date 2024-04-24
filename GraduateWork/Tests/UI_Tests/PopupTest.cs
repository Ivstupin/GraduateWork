using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class PopupTest : BaseUITest
    {
        [Test]
        [Category("Regression")]
        public void PopupVisiblePopupTest()
        {
            _navigationSteps
                .SuccessfulLogin(Admin);
            _navigationSteps
                .NavigateToProjectsPage()
                .MoveToPopupMessage();
                
            Assert.That(_navigationSteps
               .NavigateToProjectsPage()
                .IsPopupVisible);
        }
    }
}