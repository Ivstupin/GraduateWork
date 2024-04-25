using GraduateWork.Helpers;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class AddProjectPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "";

        // Описание элементов
       
        private static readonly By TitleLabelSummaryBy = By.XPath("//*[contains(text(),'Summary')]"); // название поля Summary 
        private static readonly By SummaryInputFieldBy = By.XPath("//*/textarea"); //поле ввода Summary
        private static readonly By CounterBy = By.ClassName("maxlength-counter__counter"); //счётчик введённых символов в поле Summary
        private static readonly By NameInputFieldBy = By.CssSelector("[placeholder='Project name']");
        private static readonly By NameLabelBy = By.XPath("//*[contains(text(),'Name')]");
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='submitButton']"); 
                                                                                                        
        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            Console.WriteLine(TitleLabelSummary.Text.Trim());
            return TitleLabelSummary.Text.Trim().Equals("Summary");
        }

        public bool DialogueWindowIsDisplayed()
        {
            Console.WriteLine(NameLabel.Text.Trim());
            
            return NameLabel.Text.Trim().Equals("Name");
        }

        /// <summary>
        /// сравнивает счётчик символов на странице
        /// </summary>
        public bool CounterValue(string counter)
        {
            Console.WriteLine(Counter.Text.Trim());
            return Counter.Text.Trim().Equals(counter);
        }

        // Атомарные Методы
        public IWebElement TitleLabelSummary => WaitsHelper.WaitForExists(TitleLabelSummaryBy); // 
        public IWebElement SummaryInputField => WaitsHelper.WaitForExists(SummaryInputFieldBy);  //
        public IWebElement Counter => WaitsHelper.WaitForExists(CounterBy);//
        public IWebElement NameInputField => WaitsHelper.WaitForExists(NameInputFieldBy);//
        public IWebElement _AddProjectButton => WaitsHelper.WaitForExists(AddProjectButtonBy); //  
        public IWebElement NameLabel => WaitsHelper.WaitForExists(NameLabelBy);                                                                                     
    
    }
}