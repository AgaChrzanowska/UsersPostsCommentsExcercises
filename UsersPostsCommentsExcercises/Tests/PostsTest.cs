﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UsersPostsCommentsExcercises.Pages;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class PostsTest
    {
        private IWebDriver _driver;
        PostsPageObject _postPageObject;
        FileLogHelper _fileLogHelper = new FileLogHelper();

        [TestInitialize]
        public void SetUp()
        { 
            _driver = new ChromeDriver();
            _postPageObject = new PostsPageObject(_driver);
            string url = "http://localhost:4200/posts";
            _driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void Check_H1_Text()
        {
            try
            {
                Assert.AreEqual("List of posts with authors", _postPageObject.H1Text.Text);
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Chech_Is_Table_Exist()
        {
            try
            {
                Assert.IsNotNull(_postPageObject.Table.Displayed);
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Count_Table_Name_Heading()
        {
            try
            {
                Assert.AreEqual(6, _postPageObject.TableHeading.Count);
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }
        [TestMethod]
        public void Check_Table_Name_Heading()
        {
            try
            {
                Assert.AreEqual("Post Title", _postPageObject.GetNameHeadings(3));
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }
        [TestMethod]
        public void Check_Is_Page_Report_Exist()
        {
            try
            {
                Assert.IsTrue(_postPageObject.PageReport.Displayed);
            }
            catch (AssertFailedException afe)
            {

                _fileLogHelper.Save(afe);
            }
        }

        [TestCleanup]
        public void Finish()
        {
            _driver.Dispose();
        }
    }
}
