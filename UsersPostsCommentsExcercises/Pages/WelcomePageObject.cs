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
    public class WelcomePageObject : BasePageObject, IHaveTopMenu
    {
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

        public WelcomePageObject(IWebDriver driver): base(driver)
        {
        }
       
        public PostsPageObject RedirectToPosts()
        {
            BtnSeePosts.Click();
            return new PostsPageObject(this.Driver);
        }

        public TopMenuPageObject GetTopMenu()
        {
            return new TopMenuPageObject(this.Driver);
        }

    }
}
