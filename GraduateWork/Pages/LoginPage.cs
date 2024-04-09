using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
//using GraduateWork.Steps;

namespace GraduateWork.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        //private static readonly By LoginLogoBy = By.CssSelector("[class='login_logo']"); //лого Swag Labs
        private static readonly By UserNameInputBy = By.Id("user-name"); // поле ввода Email
        private static readonly By PswInputBy = By.Id("password");       // поле ввода Password
        private static readonly By LoginInButtonBy = By.Id("login-button"); // кнопка логин 
        private static readonly By ErrorBy = By.CssSelector("[data-test='error']");// поле для вывода ошибки

        // Инициализация класса
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return LoginInButton.Displayed && UserNameInput.Displayed;
        }

        // Методы
        public IWebElement UserNameInput => WaitsHelper.WaitForExists(UserNameInputBy);
        public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
        public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);
        public IWebElement ErrorLab => WaitsHelper.WaitForExists(ErrorBy);
    }
}