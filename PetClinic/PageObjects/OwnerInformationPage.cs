using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class OwnerInformationPage : ProjectPageObject
    {
        //locators
        private readonly ElementLocator _address = new ElementLocator(Locator.XPath, "//th[text()='Address']/following-sibling::td");
        private readonly ElementLocator _city = new ElementLocator(Locator.XPath, "//th[text()='City']/following-sibling::td");
        private readonly ElementLocator _name = new ElementLocator(Locator.XPath, "//th[text()='Name']/following-sibling::td/b");
        private readonly ElementLocator _telephone = new ElementLocator(Locator.XPath, "//th[text()='Telephone']/following-sibling::td");
        private readonly ElementLocator _findOwner = new ElementLocator(Locator.CssSelector, "a[href='/petclinic/owners/find.html']");

        public OwnerInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public string Name => Driver.GetText(_name);
        public string Address => Driver.GetText(_address);
        public string City => Driver.GetText(_city);
        public string Telephone => Driver.GetText(_telephone);

        public FindOwnerPage GoToFindOwnerPage()
        {
            Driver.Click(_findOwner);
            return new FindOwnerPage(Driver);
        }
    }
}