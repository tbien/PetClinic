using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PetClinic.Entities;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class OwnersPage : ProjectPageObject
    {
        //locators
        private readonly ElementLocator owners = new ElementLocator(Locator.CssSelector, "table.table tr:nth-of-type({0})>td");
        private readonly ElementLocator numberOfRows = new ElementLocator(Locator.CssSelector, "table.table tr");

        public OwnersPage(IWebDriver driver) : base(driver)
        {
        }

        public List<Owner> Owners
        {
            get
            {
                var ownerList = new List<Owner>();

                var count = Driver.FindElements(numberOfRows).Count;
                for (int i = 0; i < count; i++)
                {
                    var list = Driver.FindElements(owners, i).Select(x => x.Text).ToList();
                    ownerList.Add(new Owner { Name = $"{list[0]}"});
                }

                return new List<Owner>();
            }
        }
    }
}
