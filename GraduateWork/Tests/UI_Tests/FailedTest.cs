using GraduateWork.Models;

namespace GraduateWork.Tests.UI_Tests;

public class FailedTest : BaseUITest
{
    [Test]
    [Description("Падение теста обработано логгером")]
    [Category("Regression")]
    public void Failed_LoginTest_Nlog()
    {
        try
        {
            Assert.That(
                    _navigationSteps
                        .IncorrectLogin(new User
                        {
                            Email = Admin.Email,
                            Password = Admin.Password
                        })
                        .ErrorTextIsVisible());
        }
        catch (Exception ex) { Logger.Error(ex, "Логируем ошибку"); }
    }

    [Test]
    [Description("Тест имитирует дефект и должен упасть")]
    [Category("Regression")]
    public void Failed_LoginTest()
    {
        Assert.That(
            _navigationSteps
                .SuccessfulLogin(new User
                {
                    Email = Admin.Email,
                    Password = Admin.Password + "wrng_psw"
                })
                .PopupMessage.Displayed);
    }
}