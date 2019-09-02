using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsersPostsCommentsExcercises.Pages
{
    public class TopMenuPageObject : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "navbarTogglerDemo02")]
        public IWebElement NavBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "nav-item")]
        public IList<IWebElement> Menu { get; set; }
        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        public IWebElement HomeLink { get; set; }

        public TopMenuPageObject(IWebDriver driver): base(driver)
        {
        }
        public int GetListMenuCount()
        {
            int menuList = Menu.Count();
            return menuList;
        }
        public AboutPageObject RedirectToAbout()
        {
            Thread.Sleep(3000);
            IWebElement aboutMenuItem = Menu.ElementAt(2);
            aboutMenuItem.Click();
            return new AboutPageObject(Driver);
        }

        public PostsPageObject RedirectToPosts()
        {
            IWebElement postsMenuItem = Menu.ElementAt(1);
            postsMenuItem.Click();
            return new PostsPageObject(Driver);
        }

        public WelcomePageObject RedirectToHome()
        {
            HomeLink.Click();
            return new WelcomePageObject(this.Driver);
        }

    }
}
