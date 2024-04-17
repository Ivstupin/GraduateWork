﻿using GraduateWork.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Data;

namespace GraduateWork.Pages
{
    public class ProjectsAdminPage : BasePage
    {
        private static string END_POINT = "/admin/projects";

        // Описание элементов
        private static readonly By _PlusProjectButtonBy = By.XPath("//button[contains(text(),'Project')]"); //селектор кнопки добавить проект
        private static readonly By DeleteButtonBy = By.CssSelector("[data-action='delete']"); // селектор ссылки на страницу с тележкой 
        private static readonly By CheckboxDeleteBy = By.CssSelector("[data-target='confirmationLabel']"); //бэйдж с количеством товаров в тележке
        private static readonly By DeleteProjectButtonBy = By.CssSelector("[data-target='deleteButton']"); // dropdown Name (A to Z)
        private static readonly By RemovableProjectButtonBy = By.CssSelector("[class='deleted-entity']"); //селектор удаляемой сущности проекта (после удаления проекта)

        //public ThreeStripesMenuPage ThreeStripesMenuPage;
        public ProjectsAdminPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {

        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            Console.WriteLine(_PlusProjectButton.Text.Trim());
            return _PlusProjectButton.Text.Trim().Equals("Project");
        }

        /// <summary>
        /// сравнивает счётчик символов на странице
        /// </summary>
        //public bool CounterValue(string counter)
        //{
        //    Console.WriteLine(Counter.Text.Trim());
        //    return Counter.Text.Trim().Equals(counter);
        //}

        // Атомарные Методы
        public IWebElement _PlusProjectButton => WaitsHelper.WaitForExists(_PlusProjectButtonBy); // название страницы Projects 
        public IWebElement DeleteButton => WaitsHelper.WaitForExists(DeleteButtonBy);  
        public IWebElement CheckboxDelete => WaitsHelper.WaitForExists(CheckboxDeleteBy);//
        public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);//бэйдж с количеством товаров в тележке

        public IWebElement RemovableProjectButton => WaitsHelper.WaitForExists(RemovableProjectButtonBy);
        public bool WaitsInvisibleRemovableProjectButton => WaitsHelper.WaitForElementInvisible(RemovableProjectButton); //  кнопка со ссылкой на страницу с тележкой 
                                                                                                                       // public IWebElement NameProductsTitle => WaitsHelper.WaitForExists(NameProductsTitleBy); // заголовок товара
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        // public bool WaitForElementInvisibleRemoveButton => WaitsHelper.WaitForElementInvisible(RemoveButtonBy); //вернёт true если не найдёт selector кнопки Remove

        /// <summary>
        /// вернёт TRUE если на странице ProductsPage не добавлен ни один товар в тележку
        /// </summary>
        //  public bool ProductsNotChoosen()
        //{ }
        // try
        //  {
        //return WaitForElementInvisibleRemoveButton;
        // }
        // catch (WebDriverTimeoutException)
        //{
        //  return false;
        //}
        public bool IsProjectWasDelete()
        {
            try
            {
                while (RemovableProjectButton.Displayed)
                {
                    RefreshPage();
                }
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Проект удалён");
                return true;
            }
        }
    }
}