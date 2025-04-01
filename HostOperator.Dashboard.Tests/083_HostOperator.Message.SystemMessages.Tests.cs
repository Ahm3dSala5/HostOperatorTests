using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HostOperator.Tests
{
    public class HostOperatorMessageSystemMessagesTests : IDisposable
    {
        private IWebDriver driver;
        public void Dispose()
        {
            driver.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Login");

            // this for skip login page
            var usernameField = driver.FindElement(By.Name("usernameOrEmailAddress"));
            var passwordField = driver.FindElement(By.Name("Password"));
            var signInButton = driver.FindElement(By.Id("LoginButton"));
            usernameField.SendKeys("Host_operator");
            passwordField.SendKeys("NpSCiS5X");
            signInButton.Click();

            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
        }

        [Test]
        public void SystemMessagesPage_TestMesssageOption()
        {
            var messageOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            Assert.AreEqual(messageOption.Text, "Messages");
            Assert.AreEqual(messageOption.GetAttribute("custom-data"), "Messages");
            Assert.IsTrue(messageOption.Displayed);
            Assert.IsTrue(messageOption.Enabled);
            var URLBeforeClick = driver.Url;
            messageOption.Click();
            var URLAfterClick = driver.Url;
            Assert.AreEqual(URLBeforeClick, $"{URLAfterClick}");
            Assert.AreEqual(messageOption.GetAttribute("href"), $"{URLAfterClick}#");
        }

        [Test]
        public void SystemMessagesPage_TestSystemMessagesOption()
        {
            // to click on Messages option 
            SystemMessagesPage_TestMesssageOption();
            // to click on System Messages option
            var SystemMessagesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[3]/a"));
            Assert.AreEqual(SystemMessagesOption.GetAttribute("custom-data"), "System Messages");
            var SentMessageURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages/System";
            Assert.AreEqual(SystemMessagesOption.GetAttribute("href"), $"{SentMessageURL}");
            Assert.AreEqual(SystemMessagesOption.GetAttribute("target"), "_self");
            Assert.IsTrue(SystemMessagesOption.Enabled);
            SystemMessagesOption.Click();
        }

        [Test]
        public void SystemMessages_OpenPage()
        {
            var messageOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            messageOption.Click();

            var SystemMessagesOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[3]/a"));
            SystemMessagesOption.Click();
        }

        [Test]
        public void SystemMessagesPage_TableBarTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.AreEqual(hiHostOperator.Text, "HI,");
            Assert.True(hiHostOperator.Displayed);
            Assert.True(hiHostOperator.Enabled);

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Displayed);
            Assert.True(username.Enabled);
        }

        [Test]
        public void SystemMessagesPage_LogoutBtnTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");

            var UrlBeforeClickOnLogout = driver.Url;
            logoutBtn.Click();
            var UrlAfterClickOnLogout = driver.Url;
            Assert.AreNotEqual(UrlBeforeClickOnLogout, UrlAfterClickOnLogout);
        }

        [Test]
        public void SystemMessagePage_NotificationTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void SystemMessagePage_TestPageTitle()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "System Messages");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void SystemMessagesPage_DashboardBtnTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var DashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(DashboardBtn.Text, "Dashboard");
            Assert.IsTrue(DashboardBtn.Displayed);
            Assert.IsTrue(DashboardBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            DashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        // must be enabled and when click must open same page
        [Test]
        public void SystemMessagesPage_SystemMessagesBtnTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var sentMessageBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(sentMessageBtn.Text, "System Messages");
            Assert.IsTrue(sentMessageBtn.Displayed);
            Assert.IsTrue(sentMessageBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            sentMessageBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void SystemMessagesPage_MessageTableTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var messageTable = driver.FindElement(By.Id("messageTable"));
            Assert.IsTrue(messageTable.Displayed);
            Assert.IsTrue(messageTable.Enabled);


            // to ensure all message is appear in table
            foreach (var row in driver.FindElements(By.Id("messageTable")))
            {
                Assert.IsTrue(row.Enabled);
                Assert.IsTrue(row.Displayed);
            }
        }

        [Test]
        public void SystemMessagesPage_PaginateTest()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var previousBtn = driver.FindElement(By.Id("messageTable_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);

            var nextBtn = driver.FindElement(By.Id("messageTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);

            var pages = driver.FindElements(By.Id("messageTable_paginate"));
            foreach (var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Displayed);
                //page.Click();
            }
        }

        [Test]
        public void SystemMessage_SideLeftMinimizeToggle()
        {
            // to open System messages page
            SystemMessages_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
