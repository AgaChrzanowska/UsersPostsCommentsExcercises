using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class BaseTests
    {
        protected IWebDriver Driver;
        protected FileLogHelper FileLogHelper;
        
        [TestCleanup]
        public void Finish()
        {
            Driver.Dispose();
        }
    }
}
