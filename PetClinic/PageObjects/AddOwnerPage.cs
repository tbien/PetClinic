using OpenQA.Selenium;
using PetClinic.Entities;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class AddOwnerPage
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _ownerName = new ElementLocator(Locator.Id, "firstName");
        private readonly ElementLocator _ownerLastName = new ElementLocator(Locator.Id, "lastName");
        private readonly ElementLocator _ownerAddress = new ElementLocator(Locator.Id, "address");
        private readonly ElementLocator _ownerCity = new ElementLocator(Locator.Id, "city");
        private readonly ElementLocator _ownerTelephone = new ElementLocator(Locator.Id, "telephone");
        private readonly ElementLocator _addOwnerButton = new ElementLocator(Locator.CssSelector, "button[type='submit']");

        public AddOwnerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public AddOwnerPage EnterOwnerDetails(Owner owner)
        {
            _driver.SendKeys(_ownerName, owner.FirstName);
            _driver.SendKeys(_ownerLastName, owner.LastName);
            _driver.SendKeys(_ownerAddress, owner.Address);
            _driver.SendKeys(_ownerCity, owner.City);
            _driver.SendKeys(_ownerTelephone, owner.Telephone);
            return this;
        }

        public OwnerInformationPage ClickAddOwnerButton()
        {
            _driver.Click(_addOwnerButton);
            return new OwnerInformationPage(_driver);
        }
    }
}
