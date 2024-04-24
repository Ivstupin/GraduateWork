using GraduateWork.Helpers;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class LoginPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "";

        // Описание элементов
        private static readonly By UserEmailInputBy = By.Name("email");   // поле ввода Email
        private static readonly By PswInputBy = By.CssSelector("[type='password']");          // поле ввода Password
        private static readonly By LoginInButtonBy = By.CssSelector("[type='submit']"); // кнопка логин 
        private static readonly By ErrorBy = By.XPath("//div[contains(text(),'These')]");// поле для вывода ошибки 'These credentials do not match our records or the user account is not allowed to log in.'

        // Инициализация класса
       

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return LoginInButton.Displayed && UserEmailInput.Displayed;
        }

        // Методы
        public IWebElement UserEmailInput => WaitsHelper.WaitForExists(UserEmailInputBy);
        public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
        public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);
        public IWebElement ErrorText => WaitsHelper.WaitForExists(ErrorBy);

        public bool ErrorTextIsVisible()
        {
            Console.WriteLine(ErrorText.Text.Trim());
            return ErrorText.Text.Trim().Equals("These credentials do not match our records or the user account is not allowed to log in.");
        }
    }
}