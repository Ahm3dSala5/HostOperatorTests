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
        public void SentMessagePage_MessageOptionTest()
        {
            var messageOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            Assert.IsTrue(messageOption.Enabled);
            Assert.IsTrue(messageOption.Displayed);
            Assert.AreEqual(messageOption.Text, "Messages");
            Assert.AreEqual(messageOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(messageOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(messageOption.GetAttribute("custom-data"), "Messages");
            Assert.AreEqual(messageOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var messageOoptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a/i[2]"));
            Assert.IsTrue(messageOoptionArrow.Enabled);
            Assert.IsTrue(messageOoptionArrow.Displayed);
            Assert.AreEqual(messageOoptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var messageOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a/i[1]"));
            Assert.IsTrue(messageOptionIcon.Enabled);
            Assert.IsTrue(messageOptionIcon.Displayed);
            Assert.AreEqual(messageOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-speech-bubble");

            var messageOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a/span/span"));
            Assert.IsTrue(messageOptionText.Enabled);
            Assert.IsTrue(messageOptionText.Displayed);
            Assert.AreEqual(messageOptionText.Text, "Messages");
            Assert.AreEqual(messageOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void SendMessagePage_SendMessageOptionTest()
        {
            var messageOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            messageOption.Click();

            var systemMessagesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[3]/a"));
            Assert.IsTrue(systemMessagesOption.Enabled);
            Assert.IsTrue(systemMessagesOption.Displayed);
            Assert.AreEqual(systemMessagesOption.Text, "System Messages");
            Assert.AreEqual(systemMessagesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(systemMessagesOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(systemMessagesOption.GetAttribute("custom-data"), "System Messages");
            Assert.AreEqual(systemMessagesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(systemMessagesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages/System");

            var systemMessagesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[3]/a/i"));
            Assert.IsTrue(systemMessagesOptionIcon.Enabled);
            Assert.IsTrue(systemMessagesOptionIcon.Displayed);
            Assert.AreEqual(systemMessagesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-speech-bubble");

            var systemMessagesOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(systemMessagesOptionText.Enabled);
            Assert.IsTrue(systemMessagesOptionText.Displayed);
            Assert.AreEqual(systemMessagesOptionText.Text, "System Messages");
            Assert.AreEqual(systemMessagesOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void SystemMessagesPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages/System");
        }

        [Test]
        public void SystemMessagesPage_TopUserNameTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var HiUserName = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.IsTrue(HiUserName.Enabled);
            Assert.IsTrue(HiUserName.Displayed);
            Assert.AreEqual(HiUserName.Text, "HI,");
            Assert.AreEqual(HiUserName.GetAttribute("class"), "m-topbar__username");

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Enabled);
            Assert.True(username.Displayed);
            Assert.AreEqual(username.GetAttribute("style"), "cursor: pointer; margin-bottom: -1.5rem;");
        }

        [Test]
        public void SystemMessagesPage_NotificationIconTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var notificationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationBtn.Enabled);
            Assert.IsTrue(notificationBtn.Displayed);
            Assert.AreEqual(notificationBtn.GetAttribute("class"), "m-nav__link m-dropdown__toggle");
            Assert.AreEqual(notificationBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a/span[1]/i"));
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.AreEqual(notificationIcon.GetAttribute("class"), "flaticon-bell");

            var unReadMessage = driver.FindElement(By.Id("UnreadChatMessageCount"));
            Assert.
                IsTrue(unReadMessage.Enabled);
            Assert.IsTrue(unReadMessage.Displayed);
            Assert.AreEqual(unReadMessage.GetAttribute("class"), "m-badge m-badge--danger");
        }

        [Test]
        public void SystemMessagesPage_SubHeaderTitleTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "System Messages");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void SystemMessagesPage_DashboardNavigationLinkTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(dashboardNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void SystemMessagesPage_SeperatorTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        // must be enabled and when click must open same page
        [Test]
        public void SystemMessagesPage_SystemMessagesNavLinkTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var systemMessagesNavLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(systemMessagesNavLink.Enabled);
            Assert.IsTrue(systemMessagesNavLink.Displayed);
            Assert.AreEqual(systemMessagesNavLink.Text, "System Messages");
            Assert.AreEqual(systemMessagesNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void SystemMessagesPage_MessageTableTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

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
            SystemMessagesPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("messageTable_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "messageTable");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");

            var nextBtn = driver.FindElement(By.Id("messageTable_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "messageTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next");
        }

        [Test]
        public void SystemMessage_SideLeftMinimizeToggle()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void SystemMessagesPage_DataTableInfoTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("messageTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void SystemMessagesPage_CopyRightTest()
        {
            // to open System messages page
            SystemMessagesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
