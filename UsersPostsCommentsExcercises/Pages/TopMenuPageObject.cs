﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersPostsCommentsExcercises.Pages
{
    public class TopMenuPageObject : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "navbarTogglerDemo02")]
        public IWebElement NavBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "nav-item")]
        public IList<IWebElement> Menu { get; set; }

        public TopMenuPageObject(IWebDriver driver): base(driver)
        {
        }
        public int GetListMenuCount()
        {
            int menuList = Menu.Count();
            return menuList;
        }
    }
}
