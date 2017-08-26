using OpenQA.Selenium;

namespace PetClinic.PageObjects
{
    public abstract class ProjectPageObject
    {
        public readonly string Url = "http://localhost:8080/petclinic";

        protected IWebDriver Driver;

        protected ProjectPageObject(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}