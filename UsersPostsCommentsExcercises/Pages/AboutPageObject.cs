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
    public class AboutPageObject: BasePageObject, IHaveTopMenu
    {
        [FindsBy(How = How.TagName, Using = "H1")]
        public IWebElement H1 { get; set; }

        [FindsBy(How = How.Id, Using = "about")]
        public IWebElement About { get; set; }

        public AboutPageObject(IWebDriver driver): base(driver)
        {
        }

        public TopMenuPageObject GetTopMenu()
        {
            throw new NotImplementedException();
        }
    }
}
