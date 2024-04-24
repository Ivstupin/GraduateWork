using GraduateWork.Models;

namespace GraduateWork.Tests.UI_Tests;

public class LoginTest : BaseUITest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
    public void Successfull_LoginTest()
    {
        Assert.That(
            _navigationSteps
                .SuccessfulLogin(Admin)
                .IsPopupVisible);
    }

    [Test]
    [Category("Regression")]
    public void WrongPassword_LoginTest()
    {
        Assert.That(
            _navigationSteps
                .IncorrectLogin(new User
                {
                    Email = Admin.Email,
                    Password = Admin.Password + "wrong_psw"
                })
                .ErrorTextIsVisible());
    }
}