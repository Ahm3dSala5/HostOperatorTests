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
        public void DashbaordPage_DashboardOptionTest()
        {
            var dashboardOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a"));
            Assert.IsTrue(dashboardOption.Enabled);
            Assert.IsTrue(dashboardOption.Displayed);
            Assert.AreEqual(dashboardOption.Text,"Dashboard");
            Assert.AreEqual(dashboardOption.GetAttribute("target"),"_self");
            Assert.AreEqual(dashboardOption.GetAttribute("custom-data"), "Dashboard");
            Assert.AreEqual(dashboardOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(dashboardOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
           
            var dashboardOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/i"));
            Assert.IsTrue(dashboardOptionIcon.Enabled);
            Assert.IsTrue(dashboardOptionIcon.Displayed);
            Assert.AreEqual(dashboardOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-dashboard");

            var dashboardOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            Assert.IsTrue(dashboardOptionText.Enabled);
            Assert.IsTrue(dashboardOptionText.Displayed);
            Assert.AreEqual(dashboardOptionText.Text, "Dashboard");
            Assert.AreEqual(dashboardOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void DashboardPage_OpenPage()
        {
            var dashboardOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            dashboardOption.Click();
        }

        [Test]
        public void DashboardPage_TopUserNameTest()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

            var HiUserName = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.IsTrue(HiUserName.Enabled);
            Assert.IsTrue(HiUserName.Displayed);
            Assert.AreEqual(HiUserName.Text,"HI,");
            Assert.AreEqual(HiUserName.GetAttribute("class"), "m-topbar__username");

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Enabled);
            Assert.True(username.Displayed);
            Assert.AreEqual(username.GetAttribute("style"), "cursor: pointer; margin-bottom: -1.5rem;");
        }

        [Test]
        public void DashboardPage_LogoutBtn()
        {
            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            hiHostOperator.Click();

            Thread.Sleep(4000);
            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text,"Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }


        [Test]
        public void DashboardPage_NotificationIconTest()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

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
        public void DashboardPage_PageTextTest()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

            var dashboardText = driver.FindElement
                (By.ClassName("textStyl"));

            Assert.IsTrue(dashboardText.Enabled);
            Assert.IsTrue(dashboardText.Displayed);
            string WelcomeMessage = "Welcome to the CTDOT Transit Asset Management Database!";
            var informationMessage = "This database stores asset inventory data of Connecticut transit providers. Please use the menu bar on the left or dashboard controls to view, edit, create or delete assets. Note that any edits made by a transit operator must be approved before they can be incorporated in the inventory.";
            Assert.IsTrue(dashboardText.Text.Contains(WelcomeMessage));
            Assert.IsTrue(dashboardText.Text.Contains(informationMessage));
        }

        [Test]
        public void DashboardPage_RevenueVehicleTest()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/h2"));
            Assert.IsTrue(title.Enabled);
            Assert.IsTrue(title.Displayed);
            Assert.AreEqual(title.Text, "Revenue Vehicle");

            var approved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[1]/span"));
            Assert.IsTrue(approved.Enabled);
            Assert.IsTrue(approved.Displayed);
            Assert.AreEqual(approved.Text,"Approved");

            var viewEdit = driver.FindElement(By.XPath("//*[@id=\"cd value=1 \"]"));
            Assert.IsTrue(viewEdit.Enabled);
            Assert.IsTrue(viewEdit.Displayed);
            Assert.AreEqual(viewEdit.Text, "View/Edit");
            Assert.AreEqual(viewEdit.GetAttribute("type"), "button");
            Assert.IsTrue(viewEdit.GetAttribute("onclick").Contains("ViewEdit"));
            Assert.AreEqual(viewEdit.GetAttribute("class"), "btn btn-primary cd");

            var pending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/div/span"));
            Assert.IsTrue(pending.Enabled);
            Assert.IsTrue(pending.Displayed);
            Assert.AreEqual(pending.Text,"Pending");

            var reviewPending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/button"));
            Assert.IsTrue(reviewPending.Enabled);
            Assert.IsTrue(reviewPending.Displayed);
            Assert.AreEqual(reviewPending.Text, "Review");
            Assert.AreEqual(reviewPending.GetAttribute("type"), "button");
            Assert.AreEqual(reviewPending.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewPending.GetAttribute("onclick").Contains("RevewEditPending"));

            var upapproved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/div/span"));
            Assert.IsTrue(upapproved.Enabled);
            Assert.IsTrue(upapproved.Displayed);
            Assert.AreEqual(upapproved.Text, "Unapproved");

            var reviewUnapproved = driver.FindElement
               (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/button"));
            Assert.IsTrue(reviewUnapproved.Enabled);
            Assert.IsTrue(reviewUnapproved.Displayed);
            Assert.AreEqual(reviewUnapproved.Text, "Review");
            Assert.AreEqual(reviewUnapproved.GetAttribute("type"), "button");
            Assert.AreEqual(reviewUnapproved.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewUnapproved.GetAttribute("onclick").Contains("RevewEditUnapprove"));

            var deleteRequest = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/div/span"));
            Assert.IsTrue(deleteRequest.Enabled);
            Assert.IsTrue(deleteRequest.Displayed);
            Assert.AreEqual(deleteRequest.Text, "Delete Request");

            var reviewDeleteRequest = driver.FindElement
              (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/button"));
            Assert.IsTrue(reviewDeleteRequest.Enabled);
            Assert.IsTrue(reviewDeleteRequest.Displayed);
            Assert.AreEqual(reviewDeleteRequest.Text, "Review");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("type"),"button");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewDeleteRequest.GetAttribute("onclick").Contains("RevewEditDelete"));
        }

        [Test]
        public void DashboardPage_FixedGuidewayTest()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[2]/div/div/div/h2"));
            Assert.IsTrue(title.Enabled);
            Assert.IsTrue(title.Displayed);
            Assert.AreEqual(title.Text, "Facility");

            var approved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[1]/span"));
            Assert.IsTrue(approved.Enabled);
            Assert.IsTrue(approved.Displayed);
            Assert.AreEqual(approved.Text, "Approved");

            var viewEdit = driver.FindElement(By.XPath("//*[@id=\"cd value=1 \"]"));
            Assert.IsTrue(viewEdit.Displayed);
            Assert.IsTrue(viewEdit.Enabled);
            Assert.AreEqual(viewEdit.Text, "View/Edit");
            Assert.AreEqual(viewEdit.GetAttribute("type"), "button");
            Assert.IsTrue(viewEdit.GetAttribute("onclick").Contains("ViewEdit"));
            Assert.AreEqual(viewEdit.GetAttribute("class"), "btn btn-primary cd");

            var pending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/div/span"));
            Assert.IsTrue(pending.Enabled);
            Assert.IsTrue(pending.Displayed);
            Assert.AreEqual(pending.Text, "Pending");

            var reviewPending = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[1]/button"));
            Assert.IsTrue(reviewPending.Enabled);
            Assert.IsTrue(reviewPending.Displayed);
            Assert.AreEqual(reviewPending.Text, "Review");
            Assert.AreEqual(reviewPending.GetAttribute("type"), "button");
            Assert.AreEqual(reviewPending.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewPending.GetAttribute("onclick").Contains("RevewEditPending"));

            var upapproved = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/div/span"));
            Assert.IsTrue(upapproved.Enabled);
            Assert.IsTrue(upapproved.Displayed);
            Assert.AreEqual(upapproved.Text, "Unapproved");

            var reviewUnapproved = driver.FindElement
               (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[2]/button"));
            Assert.IsTrue(reviewUnapproved.Enabled);
            Assert.IsTrue(reviewUnapproved.Displayed);
            Assert.AreEqual(reviewUnapproved.Text, "Review");
            Assert.AreEqual(reviewUnapproved.GetAttribute("type"), "button");
            Assert.AreEqual(reviewUnapproved.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewUnapproved.GetAttribute("onclick").Contains("RevewEditUnapprove"));

            var deleteRequest = driver.FindElement
                (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/div/span"));
            Assert.IsTrue(deleteRequest.Enabled);
            Assert.IsTrue(deleteRequest.Displayed);
            Assert.AreEqual(deleteRequest.Text, "Delete Request");

            var reviewDeleteRequest = driver.FindElement
              (By.XPath("//*[@id=\"dynamicAddTextBoX\"]/div[1]/div/div/div/div[2]/div[3]/button"));
            Assert.IsTrue(reviewDeleteRequest.Enabled);
            Assert.IsTrue(reviewDeleteRequest.Displayed);
            Assert.AreEqual(reviewDeleteRequest.Text, "Review");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("type"), "button");
            Assert.AreEqual(reviewDeleteRequest.GetAttribute("class"), "btn btn-primary");
            Assert.IsTrue(reviewDeleteRequest.GetAttribute("onclick").Contains("RevewEditDelete"));
        }

        [Test]
        public void DashbioardPage_SideLeftMinimizeToggle()
        {
            // to open dashboard page
            DashboardPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(sideLeft.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
            sideLeft.Click();
        }

        [Test]
        public void DashboardPage_CopyRightTest()
        {
            // to open dashboard page 
            DashboardPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));

            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}