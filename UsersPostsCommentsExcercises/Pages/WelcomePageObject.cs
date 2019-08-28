using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersPostsCommentsExcercises.Pages
{
    public class WelcomePageObject
    {
        private WebDriverWait _wait;
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "navbarTogglerDemo02")]
        public IWebElement NavBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "nav-item")]
        public IList<IWebElement> Menu { get; set; }

        [FindsBy(How = How.ClassName, Using = "display-4")]
        public IWebElement H1Welcome { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.ClassName, Using = "my-4")]
        public IWebElement About { get; set; }

        [FindsBy(How = How.Id, Using = "btn1")]
        public IWebElement BtnSeePosts { get; set; }

        public WelcomePageObject(IWebDriver driver)
        {
            this.Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public int GetListMenuCount()
        {
            int menuList = Menu.Count();
            return menuList;
        }

        public PostsPageObject RedirectToPosts()
        {
            BtnSeePosts.Click();
            return new PostsPageObject(this.Driver);
        }

    }
}
