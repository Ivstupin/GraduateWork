using GraduateWork.Helpers;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
       
       private static readonly By TitleLabelSummaryBy = By.XPath("//*[contains(text(),'Summary')]"); // название поля Summary 
       private static readonly By SummaryInputFieldBy = By.XPath("//*/textarea"); //поле ввода Summary
       private static readonly By CounterBy = By.ClassName("maxlength-counter__counter"); //счётчик введённых символов в поле Summary
       private static readonly By NameInputFieldBy = By.CssSelector("[data-target='name']"); //поле ввода Name
       private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='submitButton']"); //бэйдж с количеством товаров в тележке
                                                                                             // private static readonly By DropdownNameBy = By.CssSelector("[class='product_sort_container']"); // dropdown Name (A to Z)
                                                                                             //private static readonly By NameProductsTitleBy = By.CssSelector("[class~='inventory_item_name']"); //селектор имени товара со ссылкой на страницу его описания

        //public ThreeStripesMenuPage ThreeStripesMenuPage;
        public AddProjectPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            // ThreeStripesMenuPage = new ThreeStripesMenuPage(Driver); //три точки меню слева вверху
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            Console.WriteLine(TitleLabelSummary.Text.Trim());
            return TitleLabelSummary.Text.Trim().Equals("Summary");
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
                                                                                                 // public IWebElement NameProductsTitle => WaitsHelper.WaitForExists(NameProductsTitleBy); // заголовок товара


        // public bool WaitForElementInvisibleRemoveButton => WaitsHelper.WaitForElementInvisible(RemoveButtonBy); //вернёт true если не найдёт selector кнопки Remove

        /// <summary>
        /// вернёт TRUE если на странице ProductsPage не добавлен ни один товар в тележку
        /// </summary>
        //  public bool ProductsNotChoosen()
        // {
        // try
        //  {
        //return WaitForElementInvisibleRemoveButton;
        // }
        // catch (WebDriverTimeoutException)
        //{
        //  return false;
        //}
        

    }
}