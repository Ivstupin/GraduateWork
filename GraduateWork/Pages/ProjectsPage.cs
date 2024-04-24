using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace GraduateWork.Pages
{
    public class ProjectsPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "";

        // Описание элементов
        
        private static readonly By PopupMessageBy = By.CssSelector("[class='avatar__text__identifier']"); //всплывающее сообщение
        private static readonly By PopupMessageDataContextBy = By.CssSelector("[data-content='Ivan Stupin']"); //всплывающее сообщение
        private static readonly By TitleLabelBy = By.XPath("//div[contains(text(),'Projects')]"); // название страницы Projects 
        private static readonly By PlusProjectButtonBy = By.XPath("//button[contains(text(),'Project')]"); //селектор кнопки добавить проект
        private static readonly By ProjectBy = By.CssSelector("[href*='https://ivst.testmo.net/projects/view']"); //селектор существующего проекта
        
        

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return TitleLabel.Text.Trim().Equals("Projects");
        }

        public bool IsPopupVisible()
        {
            return PopupMessageDataContext.Displayed;
        }

        // Атомарные Методы
        public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy); // название страницы Projects 
        public IWebElement PopupMessage => WaitsHelper.WaitForExists(PopupMessageBy);  //всплывающее окно
        public IWebElement _PlusProjectButton => WaitsHelper.WaitForExists(PlusProjectButtonBy);// // кнопка добавить проект
        public IWebElement PopupMessageDataContext => WaitsHelper.WaitForExists(PopupMessageDataContextBy);//
        public IWebElement Project => WaitsHelper.WaitForExists(ProjectBy); // 
                                                                                              

        /// <summary>
        ///всплывающее сообщения на странице
        /// </summary>
        public void MoveToPopupMessage() 
        {
            var allPopupMessage = WaitsHelper.FluentWaitForElement(PopupMessageBy); 
            var actions = new Actions(Driver);

            actions
                    .MoveToElement(allPopupMessage)
                    .Build()
                    .Perform();
        }
    }
}