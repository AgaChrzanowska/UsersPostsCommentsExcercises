using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersPostsCommentsExcercises.Pages
{
    class AboutPageObject
    {
        public WebDriverWait _wait;
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.TagName, Using = "H1")]
        public IWebElement H1 { get; set; }

        [FindsBy(How = How.Id, Using = "about")]
        public IWebElement About { get; set; }

        public AboutPageObject(IWebDriver driver)
        {
            this.Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }
    }
}
