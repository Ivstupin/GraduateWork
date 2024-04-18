using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace GraduateWork.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        
        private static readonly By PopupMessageBy = By.CssSelector("[class='avatar__text__identifier']"); //всплывающее сообщение
        private static readonly By PopupMessageDataContextBy = By.CssSelector("[data-content='Ivan Stupin']"); //всплывающее сообщение
        private static readonly By TitleLabelBy = By.XPath("//div[contains(text(),'Projects')]"); // название страницы Projects 
        private static readonly By PlusProjectButtonBy = By.XPath("//button[contains(text(),'Project')]"); //селектор кнопки добавить проект
        private static readonly By ProjectBy = By.CssSelector("[href*='https://ivst.testmo.net/projects/view']"); //селектор существующего проекта
        
        public ProjectsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
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
        /// найдёт все всплывающие сообщения на странице и покажет их
        /// </summary>
        public void MoveToPopupMessage() 
        {
            var allPopupMessage = WaitsHelper.WaitForAllVisibleElementsLocatedBy(PopupMessageBy); // вернёт коллекцию всех найденых на странице всплывающих сообщений
            var actions = new Actions(Driver);
            
            foreach (var msg in allPopupMessage) //перебор всех всплывающих сообщений
            {
                actions
                    .MoveToElement(msg)
                    .Build()
                    .Perform();
            }
        }
    }
}