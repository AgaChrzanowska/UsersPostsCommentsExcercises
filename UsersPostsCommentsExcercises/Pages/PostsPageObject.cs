using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UsersPostsCommentsExcercises.Pages
{
    public class PostsPageObject: BasePageObject, IHaveTopMenu
    {
        [FindsBy(How = How.CssSelector, Using = "#content > div > app-posts > div > h1")]
        public IWebElement H1Text { get; set; }

        [FindsBy(How = How.ClassName, Using = "table-sm")]
        public IWebElement Table { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#content > div > app-posts > div > table > thead th")]
        public IList<IWebElement> TableHeading { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "float-right")]
        public IWebElement PageReport { get; set; }

        public PostsPageObject(IWebDriver driver): base(driver)
        {
        }

        public string GetNameHeadings(int index)
        {
            IWebElement nameOfHeading = TableHeading.ElementAt(index);
            return nameOfHeading.Text;
        }
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
        public TopMenuPageObject GetTopMenu()
        {
            throw new NotImplementedException();
        }
    }
}