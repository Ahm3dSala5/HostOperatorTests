using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorMessageInboxTests : IDisposable
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
        public void InboxPage_MessageOptionTest()
        {
            var messageOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            Assert.IsTrue(messageOption.Enabled);
            Assert.IsTrue(messageOption.Displayed);
            Assert.AreEqual(messageOption.Text, "Messages");
            Assert.AreEqual(messageOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(messageOption.GetAttribute("href"),$"{driver.Url}#");
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
            Assert.AreEqual(messageOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void InboxPage_InboxOptionText()
        {
            var messageOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            messageOption.Click();

            var inboxOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[1]/a"));
            Assert.IsTrue(inboxOption.Enabled);
            Assert.IsTrue(inboxOption.Displayed);
            Assert.AreEqual(inboxOption.Text,"Inbox");
            Assert.AreEqual(inboxOption.GetAttribute("target"), "_self");
            Assert.AreEqual(inboxOption.GetAttribute("custom-data"), "Inbox");
            Assert.AreEqual(inboxOption.GetAttribute("href"), $"http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
          
            var inboxOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(inboxOptionIcon.Enabled);
            Assert.IsTrue(inboxOptionIcon.Displayed);
            Assert.AreEqual(inboxOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-speech-bubble");

            var inboxOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(inboxOptionText.Enabled);
            Assert.IsTrue(inboxOptionText.Displayed);
            Assert.AreEqual(inboxOptionText.Text,"Inbox");
            Assert.AreEqual(inboxOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void InboxPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
        }

        [Test]
        public void InboxPage_TopUserNameTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

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
        public void InboxPage_NotificationIconTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

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
            Assert.IsTrue(unReadMessage.Enabled);
            Assert.IsTrue(unReadMessage.Displayed);
            Assert.AreEqual(unReadMessage.GetAttribute("class"), "m-badge m-badge--danger");
        }

        [Test]
        public void InboxPage_SubHeaderTitleTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Messages");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void InboxPage_DashboardNavigationLinkTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(dashboardNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        // must be enabled and when click must open same page
        [Test]
        public void InboxPage_MessagesNavigationLinkTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var messageNavLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(messageNavLink.Enabled);
            Assert.IsTrue(messageNavLink.Displayed);
            Assert.AreEqual(messageNavLink.Text, "Messages");
            Assert.AreEqual(messageNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void InboxPage_SentMessageBtnTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var sendMessageBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[1]/button"));
            Assert.IsTrue(sendMessageBtn.Enabled);
            Assert.IsTrue(sendMessageBtn.Displayed);
            Assert.AreEqual(sendMessageBtn.Text, "Send Message");
            Assert.AreEqual(sendMessageBtn.GetAttribute("onclick"), "sendMessage();");
            Assert.AreEqual(sendMessageBtn.GetAttribute("class"), "btn btn-primary waves-effect");
        }


        // after click on send message
        // will open page for send message page
        // test this page
        [Test]
        public void InboxPage_SendMessagePagesTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages/Send");

            var ToLabel = driver.FindElement
                (By.XPath("//*[@id=\"SendMessage\"]/form/div/div[1]/div/div/label"));
            Assert.IsTrue(ToLabel.Enabled);
            Assert.IsTrue(ToLabel.Displayed);
            Assert.AreEqual(ToLabel.GetAttribute("for"),"To");
            Assert.AreEqual(ToLabel.GetAttribute("class"),"form-label");

            var user = driver.FindElement(By.Id("UserIds"));
            Assert.IsTrue(user.Enabled);
            Assert.IsTrue(user.Displayed);
            Assert.AreEqual(user.GetAttribute("multiple"), "true");
            Assert.AreEqual(user.GetAttribute("class"),"form-control form-line");

            var selectedUser = new SelectElement(user);
            selectedUser.SelectByIndex(0); // Select the first user

            var subjectLabel = driver.FindElement
                (By.XPath("//*[@id=\"SendMessage\"]/form/div/div[2]/div/div/label"));
            Assert.IsTrue(subjectLabel.Enabled);
            Assert.IsTrue(subjectLabel.Displayed);
            Assert.AreEqual(subjectLabel.Text,"Subject");
            Assert.AreEqual(subjectLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(subjectLabel.GetAttribute("class"),"form-label");

            var subjectInput = driver.FindElement
                (By.Id("Subject"));
            Assert.IsTrue(subjectLabel.Enabled);
            Assert.IsTrue(subjectLabel.Displayed);
            Assert.AreEqual(subjectInput.GetAttribute("type"),"text");
            Assert.AreEqual(subjectInput.GetAttribute("required"),"true");
            Assert.AreEqual(subjectInput.GetAttribute("class"),"validate form-control");

            var messageLabel = driver.FindElement
                (By.XPath("//*[@id=\"SendMessage\"]/form/div/div[3]/div/div/label"));
            Assert.IsTrue(messageLabel.Enabled);
            Assert.IsTrue(messageLabel.Displayed);
            Assert.AreEqual(messageLabel.Text,"Message");
            Assert.AreEqual(messageLabel.GetAttribute("for"), "Message");
            Assert.AreEqual(messageLabel.GetAttribute("class"), "form-label");

            var messageInput = driver.FindElement(By.Id("Message"));
            Assert.IsTrue(messageInput.Enabled);
            Assert.IsTrue(messageInput.Displayed);
            Assert.AreEqual(messageInput.GetAttribute("required"),"true");
            Assert.AreEqual(messageInput.GetAttribute("class"),"form-control");

            var sendBtn = driver.FindElement
                (By.XPath("//*[@id=\"SendMessage\"]/form/div/div[4]/button"));
            Assert.IsTrue(sendBtn.Enabled);
            Assert.IsTrue(sendBtn.Displayed);
            Assert.AreEqual(sendBtn.Text,"Send");
            Assert.AreEqual(sendBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(sendBtn.GetAttribute("class"), "btn btn-primary waves-effect enableOnInput");
        }

        [Test]
        public void InboxPage_DataTableFilterTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/label[2]"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/label[2]/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("class"), "search-input");
        }

        [Test]
        public void InboxMessagePage_SideLeftMinimizeToggle()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
       
        [Test]
        public void InboxPage_CopyRightTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
