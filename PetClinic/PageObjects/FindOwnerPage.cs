using System;
using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class FindOwnerPage : ProjectPageObject
    {
        //locators
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "a[href*='/petclinic/owners/new']");
        private readonly ElementLocator _searchField = new ElementLocator(Locator.Id, "lastName");
        private readonly ElementLocator _findOwner = new ElementLocator(Locator.CssSelector, "button");

        public FindOwnerPage(IWebDriver driver) : base(driver)
        {
        }

        public FindOwnerPage Open()
        {
            Driver.Navigate().GoToUrl($"{Url}/owners/find.html");
            return this;
        }

        public AddOwnerPage ClickAddOwnerButton()
        {
            Driver.Click(_addOwnerButton);
            return new AddOwnerPage(Driver);
        }

        public T SearchForOwner<T>(string ownerLastName, Func<IWebDriver, T> creator)
        {
            Driver.SendKeys(_searchField, ownerLastName);
            Driver.Click(_findOwner);
            return creator(Driver);
        }
    }
}