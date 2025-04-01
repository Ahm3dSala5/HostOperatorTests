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
        public void InboxPage_TestMesssageOption()
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
        public void InboxPage_TestInboxOption()
        {
            // to click on Messages option 
            InboxPage_TestMesssageOption();
            // to click on Inbox option
            var InboxOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[1]/a"));
            Assert.AreEqual(InboxOption.GetAttribute("custom-data"), "Inbox");
            var InboxURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages";
            Assert.AreEqual(InboxOption.GetAttribute("href"), $"{InboxURL}");
            Assert.AreEqual(InboxOption.GetAttribute("target"), "_self");
            Assert.IsTrue(InboxOption.Enabled);
            InboxOption.Click();
        }

        [Test]
        public void InboxPage_OpenPage()
        {
            var messageOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/a"));
            messageOption.Click();

            var InboxOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[8]/nav/ul/li[1]/a"));
            InboxOption.Click();
        }

        [Test]
        public void InboxPage_TableBarTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

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
        public void InboxPage_LogoutBtnTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

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
        public void InboxPage_NotificationTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void InboxPage_TestPageTitle()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Messages");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void InboxPage_DashboardBtnTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

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
        public void InboxPage_MessagesBtnTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var NTDBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(NTDBtn.Text, "Messages");
            Assert.IsTrue(NTDBtn.Displayed);
            Assert.IsTrue(NTDBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            NTDBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void InboxPage_SentMessageBtn()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var sendMessage = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[1]/button"));
            Assert.IsTrue(sendMessage.Displayed);
            Assert.IsTrue(sendMessage.Enabled);
            Assert.AreEqual(sendMessage.Text,"Send Message");
            Assert.AreEqual(sendMessage.GetAttribute("onclick"), "sendMessage();");
        }

        [Test]
        public void InboxPage_DataTableFilterTest()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/label[2]"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/label[2]/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void SendMessagePage_Test()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var sendMessage = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[1]/button"));
            sendMessage.Click();

            var TOLabel = driver.FindElement
                (By.XPath("//*[@id=\"SendMessage\"]/form/div/div[1]/div/div/label"));
            Assert.AreEqual(TOLabel.Text,"To");
            Assert.IsTrue(TOLabel.Displayed);
            Assert.IsTrue(TOLabel.Enabled);

            var reciever = driver.FindElement(By.Id("UserIds"));
            var selectedReciever = new SelectElement(reciever);
            selectedReciever.SelectByIndex(0);
            Assert.IsTrue(reciever.Displayed);
            Assert.IsTrue(reciever.Enabled);

            var subjectLabel = driver.FindElement(By.XPath("//*[@id=\"SendMessage\"]/form/div/div[2]/div/div/label"));
            Assert.AreEqual(subjectLabel.Text,"Subject");
            Assert.IsTrue(subjectLabel.Displayed);
            Assert.IsTrue(subjectLabel.Enabled);

            var subjectInput = driver.FindElement(By.Id("Subject"));
            Assert.IsTrue(subjectInput.Displayed);
            Assert.IsTrue(subjectInput.Enabled);
            subjectInput.SendKeys("Test Subject");

            var messageLabel = driver.FindElement(By.XPath("//*[@id=\"SendMessage\"]/form/div/div[3]/div/div/label"));
            Assert.AreEqual(messageLabel.Text, "Message");
            Assert.IsTrue(messageLabel.Displayed);
            Assert.IsTrue(messageLabel.Enabled);

            var messageInput = driver.FindElement(By.Id("Message"));
            Assert.IsTrue(messageInput.Displayed);
            Assert.IsTrue(messageInput.Enabled);
            messageInput.SendKeys("Test Message");

            var sendBtn = driver.FindElement(By.XPath("//*[@id=\"SendMessage\"]/form/div/div[4]/button"));
            Assert.IsTrue(sendBtn.Displayed);
            Assert.IsTrue(sendBtn.Enabled);
            Assert.AreEqual(sendBtn.Text,"Send");
            sendBtn.Click();
        }

        [Test]
        public void InboxMessage_SideLeftMinimizeToggle()
        {
            // to open Inbox page
            InboxPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
