using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        //private static readonly By PopupBy = By.ClassName("tour-popup__step__header__title"); //всплывающее окно
        private static readonly By TitleLabelSummaryBy = By.XPath("//*[contains(text(),'Summary')]"); // название поля Summary 
       // private static readonly By SummaryInputFieldBy = By.ClassName("maxlength-counter"); //поле ввода Summary
        private static readonly By SummaryInputFieldBy = By.XPath("//*/textarea"); //поле ввода Summary

       private static readonly By CounterBy = By.ClassName("maxlength-counter__counter"); //селектор кнопки удалить из тележки
                                                                                            //private static readonly By ShoppingCartButtonBy = By.CssSelector("[class='shopping_cart_link']"); // селектор ссылки на страницу с тележкой 
                                                                                            //private static readonly By ShoppingCartBadgeBy = By.CssSelector("[class='shopping_cart_badge']"); //бэйдж с количеством товаров в тележке
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

        public bool CounterValue(string counter)
        {
            Console.WriteLine(Counter.Text.Trim());
            return Counter.Text.Trim().Equals(counter);
        }

        // Атомарные Методы
        public IWebElement TitleLabelSummary => WaitsHelper.WaitForExists(TitleLabelSummaryBy); // название страницы Projects 
        public IWebElement SummaryInputField => WaitsHelper.WaitForExists(SummaryInputFieldBy);  //всплывающее окно
        public IWebElement Counter => WaitsHelper.WaitForExists(CounterBy);// кнопка удалить из тележки
                                                                                                 // public IWebElement ShoppingCartBadge => WaitsHelper.WaitForExists(ShoppingCartBadgeBy);//бэйдж с количеством товаров в тележке
                                                                                                 // public IWebElement ShoppingCartButton => WaitsHelper.WaitForExists(ShoppingCartButtonBy); //  кнопка со ссылкой на страницу с тележкой 
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