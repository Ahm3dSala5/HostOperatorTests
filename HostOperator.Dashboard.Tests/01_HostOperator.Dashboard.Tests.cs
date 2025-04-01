using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Dashboard.Tests
{
    public class HostOperatorDashboardTests : IDisposable
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
        public void DashboardPage_OpenDashboardPage()
        {
            var dashboardBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            dashboardBtn.Click();
        }

        [Test]
        public void DashbaordPage_DashboardOptionTest()
        {
            var dashboardOption = driver.FindElement(By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a"));

            Assert.AreEqual(dashboardOption.GetAttribute("custom-data"), "Dashboard");
            Assert.IsTrue(dashboardOption.Displayed);
            Assert.IsTrue(dashboardOption.Enabled);
        }

        [Test]
        public void DashboardPage_HiHostOperatorTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.AreEqual(hiHostOperator.Text,"HI,");
            Assert.True(hiHostOperator.Displayed);
            Assert.True(hiHostOperator.Enabled);

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Displayed);
            Assert.True(username.Enabled);
        }

        [Test]
        public void DashboardPage_LogoutBtn()
        {
            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text,"Logout");

            var UrlBeforeClickOnLogout = driver.Url;
            logoutBtn.Click();
            var UrlAfterClickOnLogout = driver.Url;
            Assert.AreNotEqual(UrlBeforeClickOnLogout,UrlAfterClickOnLogout);
        }

        [Test]
        public void DashboardPage_ModalTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var modalTitle = driver.FindElement(By.XPath("//*[@id=\"demo\"]"));
            Assert.IsFalse(modalTitle.Displayed);
            Assert.IsTrue(modalTitle.Enabled);

            var selectedTenant = driver.FindElement(By.Id("TenantDropDownChange"));
            var selectedTenantValue = new SelectElement(selectedTenant);
            selectedTenantValue.SelectByIndex(0);

            var closeBtn = driver.FindElement(By.Id("close"));
            Assert.AreEqual(closeBtn.GetAttribute("type"),"button");
            Assert.IsFalse(closeBtn.Displayed);
            Assert.IsTrue(closeBtn.Enabled);
        }

        [Test]
        public void DashboardPage_NotificationTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"), 
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void DashboardPage_ParagraphTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var paragraph = "Welcome to the CTDOT Transit Asset Management Database!\r\n\r\nThis database stores asset inventory data of Connecticut transit providers. Please use the menu bar on the left or dashboard controls to view, edit, create or delete assets. Note that any edits made by a transit operator must be approved before they can be incorporated in the inventory.";
            var pageText = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/h3/span"));
            Assert.IsTrue(pageText.Displayed);
            Assert.IsTrue(pageText.Enabled);
            Assert.AreEqual(paragraph,pageText.Text);
        }

        [Test]
        public void DashboardPage_RevenueVehicleTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var title = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/h2"));
            Assert.AreEqual(title.Text, "Revenue Vehicle");

            var approved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[1]/span"));
            Assert.AreEqual(approved.Text,"Approved");
            Assert.IsTrue(approved.Displayed);
            Assert.IsTrue(approved.Enabled);

            var editView = driver.FindElement(By.XPath("//*[@id=\"cd value=1 \"]"));
            Assert.IsTrue(editView.Displayed);
            Assert.IsTrue(editView.Enabled);
            Assert.AreEqual(editView.Text, "View/Edit");
            Assert.AreEqual(editView.GetAttribute("type"), "button");

            var pending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/div/span"));
            Assert.AreEqual(pending.Text,"Pending");
            Assert.IsTrue(pending.Enabled);
            Assert.IsTrue(pending.Displayed);

            var reviewPending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/button"));
            Assert.AreEqual(reviewPending.Text, "Review");
            Assert.IsTrue(reviewPending.Displayed);
            Assert.IsTrue(reviewPending.Enabled);
            Assert.AreEqual(reviewPending.GetAttribute("onclick"), "RevewEditPending(1)");
            Assert.AreEqual(reviewPending.GetAttribute("type"), "button");

            var upapproved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/div/span"));
            Assert.AreEqual(upapproved.Text, "Unapproved");
            Assert.IsTrue(upapproved.Displayed);
            Assert.IsTrue(upapproved.Enabled);

            var reviewUnapproved = driver.FindElement
               (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/button"));
            Assert.AreEqual(reviewUnapproved.Text, "Review");
            Assert.IsTrue(reviewUnapproved.Displayed);
            Assert.IsTrue(reviewUnapproved.Enabled);
            Assert.AreEqual(reviewUnapproved.GetAttribute("onclick"), "RevewEditUnapprove(1)");
            Assert.AreEqual(reviewUnapproved.GetAttribute("type"), "button");

            var deleteRequest = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/div/span"));
            Assert.AreEqual(deleteRequest.Text, "Delete Request");
            Assert.IsTrue(deleteRequest.Displayed);
            Assert.IsTrue(deleteRequest.Enabled);

            var reviewDeleteRequest = driver.FindElement
              (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/button"));
            Assert.AreEqual(reviewDeleteRequest.Text, "Review");
            Assert.IsTrue(reviewDeleteRequest.Displayed);
            Assert.IsTrue(reviewDeleteRequest.Enabled);
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("onclick"), "RevewEditDelete(1)");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("type"),"button");
        }

        [Test]
        public void DashboardPage_FixedGuidewayTest()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var title = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[2]/div/div/div/h2"));
            Assert.AreEqual(title.Text, "Fixed Guideway");

            var approved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[1]/span"));
            Assert.AreEqual(approved.Text, "Approved");
            Assert.IsTrue(approved.Displayed);
            Assert.IsTrue(approved.Enabled);

            var editView = driver.FindElement(By.XPath("//*[@id=\"cd value=1 \"]"));
            Assert.IsTrue(editView.Displayed);
            Assert.IsTrue(editView.Enabled);
            Assert.AreEqual(editView.Text, "View/Edit");
            Assert.AreEqual(editView.GetAttribute("type"), "button");

            var pending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/div/span"));
            Assert.AreEqual(pending.Text, "Pending");
            Assert.IsTrue(pending.Enabled);
            Assert.IsTrue(pending.Displayed);

            var reviewPending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/button"));
            Assert.AreEqual(reviewPending.Text, "Review");
            Assert.IsTrue(reviewPending.Displayed);
            Assert.IsTrue(reviewPending.Enabled);
            Assert.AreEqual(reviewPending.GetAttribute("onclick"), "RevewEditPending(1)");
            Assert.AreEqual(reviewPending.GetAttribute("type"), "button");

            var upapproved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/div/span"));
            Assert.AreEqual(upapproved.Text, "Unapproved");
            Assert.IsTrue(upapproved.Displayed);
            Assert.IsTrue(upapproved.Enabled);

            var reviewUnapproved = driver.FindElement
               (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/button"));
            Assert.AreEqual(reviewUnapproved.Text, "Review");
            Assert.IsTrue(reviewUnapproved.Displayed);
            Assert.IsTrue(reviewUnapproved.Enabled);
            Assert.AreEqual(reviewUnapproved.GetAttribute("onclick"), "RevewEditUnapprove(1)");
            Assert.AreEqual(reviewUnapproved.GetAttribute("type"), "button");

            var deleteRequest = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/div/span"));
            Assert.AreEqual(deleteRequest.Text, "Delete Request");
            Assert.IsTrue(deleteRequest.Displayed);
            Assert.IsTrue(deleteRequest.Enabled);

            var reviewDeleteRequest = driver.FindElement
              (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/button"));
            Assert.AreEqual(reviewDeleteRequest.Text, "Review");
            Assert.IsTrue(reviewDeleteRequest.Displayed);
            Assert.IsTrue(reviewDeleteRequest.Enabled);
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("onclick"), "RevewEditDelete(1)");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("type"), "button");
        }

        [Test]
        public void DashbioardPage_SideLeftMinimizeToggle()
        {
            // to open dashboard page
            DashboardPage_OpenDashboardPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}