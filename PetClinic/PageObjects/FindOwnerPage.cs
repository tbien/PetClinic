using System.Threading;
using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class FindOwnerPage : ProjectPageObject
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "a[href*='/petclinic/owners/new']");


        public FindOwnerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public FindOwnerPage Open()
        {
            _driver.Navigate().GoToUrl($"{Url}/owners/find.html");
            return this;
        }

        public AddOwnerPage ClickAddOwnerButton()
        {
            this._driver.Click(this._addOwnerButton);
            return new AddOwnerPage(_driver);
        }
    }
}
