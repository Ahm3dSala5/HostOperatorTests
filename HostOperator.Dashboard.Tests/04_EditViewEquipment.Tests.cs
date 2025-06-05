using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.WebAuthn;

namespace HostOperator.Tests
{
    public class HostOperatorEditViewEquipmentTests : IDisposable
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
        public void ViewEditsPage_ViewEditOptionTest()
        {
            var viewEditOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[4]/a"));
            Assert.IsTrue(viewEditOption.Enabled);
            Assert.IsTrue(viewEditOption.Displayed);
            Assert.AreEqual(viewEditOption.Text, "View/Edit");
            Assert.AreEqual(viewEditOption.GetAttribute("custom-data"), "View/Edit");
            Assert.AreEqual(viewEditOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var viewEditOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[4]/a/i[1]"));
            Assert.IsTrue(viewEditOptionIcon.Enabled);
            Assert.IsTrue(viewEditOptionIcon.Displayed);
            Assert.AreEqual(viewEditOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-search");

            var viewEditOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[4]/a/span/span"));
            Assert.IsTrue(viewEditOptionText.Enabled);
            Assert.IsTrue(viewEditOptionText.Displayed);
            Assert.AreEqual(viewEditOptionText.Text, "View/Edit");
            Assert.AreEqual(viewEditOptionText.GetAttribute("class"), "title");
        }

        // this for go to viewEdits Page
        [Test]
        public void ViewEditsPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/AssetClass");
        }

        [Test]
        public void ViewEditsPage_TopUserNameTest()
        {
            // to open  View Edit page
            ViewEditsPage_OpenPage();

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
        public void ViewEditsPage_LogoutBtn()
        {
            // to open  View Edit page
            ViewEditsPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            Thread.Sleep(5000);
            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void ViewEditsPage_NotificationIconTest()
        {
            // to open  View Edit page
            ViewEditsPage_OpenPage();

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
        public void ViewEditpage_SubHeaderTitleTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "View/Edit");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void ViewEditPage_DashboardNavlgationLinkTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text,"Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(dashboardNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void ViewEdisPage_ViewEditsNavigationLinkTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var viewEditsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));

            Assert.IsTrue(viewEditsNavLink.Enabled);
            Assert.IsTrue(viewEditsNavLink.Displayed);
            Assert.AreEqual(viewEditsNavLink.Text, "View/Edit");
            Assert.AreEqual(viewEditsNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void ViewEditPage_DataTableLengthTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"AssetsTable_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("AssetsTable_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "AssetsTable");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void viewEditPage_DataTableFilterTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled );
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"), "search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "AssetsTable");
        }

        [Test]
        public void ViewEditsPage_AssetClassDropdownlistTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[3]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"), "AssetSubClass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"), "form-control");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"No Asset Subclass");
        }

        [Test]
        public void ViewEditPage_AssetTypeDrowdownlistTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var assetTypeLabel = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[3]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("class"), "form-control");

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Please select ...");
        }

        [Test]
        public void ViewEditsPage_CreateBtnTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.IsTrue(createBtn.Enabled);
            Assert.IsTrue(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text,"Create");
            Assert.AreEqual(createBtn.GetAttribute("type"),"button");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-primary btnCreate");
            createBtn.Click();
        }

        [Test]
        public void ViewEditsPage_ConfigurationBtnTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var configBtn = driver.FindElement(By.Id("configBtn"));
            
            // This Must Be Disbaled
            Assert.IsFalse(configBtn.Enabled);
            Assert.IsTrue(configBtn.Displayed);
            Assert.AreEqual(configBtn.Text,"Configuration");
            Assert.AreEqual(configBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(configBtn.GetAttribute("disabled"),"true");
            Assert.AreEqual(configBtn.GetAttribute("class"), "btn btn-primary btnCofig");
        }

        [Test]
        public void ViewEditsPage_ViewEditsTableTest()
        {
            // open view/edit page
            ViewEditsPage_OpenPage();

            var table = driver.FindElement(By.Id("AssetsTable"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "AssetsTable_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
                column.Click();
            }

            var AssetId = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(AssetId.Enabled);
            Assert.IsTrue(AssetId.Displayed);
            Assert.AreEqual(AssetId.Text,"Asset ID");
            Assert.AreEqual(AssetId.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "AssetsTable");
            AssetId.Click();

            var AssetClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetClass.Enabled);
            Assert.IsTrue(AssetClass.Displayed);
            Assert.AreEqual(AssetClass.Text,"Asset Class");
            Assert.AreEqual(AssetClass.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetClass.GetAttribute("aria-controls"), "AssetsTable");
            AssetClass.Click();

            var AssetSubClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(AssetSubClass.Displayed);
            Assert.IsTrue(AssetSubClass.Enabled);
            Assert.AreEqual(AssetSubClass.Text, "Asset Subclass");
            Assert.AreEqual(AssetSubClass.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetSubClass.GetAttribute("aria-controls"), "AssetsTable");
            AssetSubClass.Click();

            var AssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(AssetType.Displayed);
            Assert.IsTrue(AssetType.Enabled);
            Assert.AreEqual(AssetType.Text, "Asset Type");
            Assert.AreEqual(AssetType.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetType.GetAttribute("aria-controls"), "AssetsTable");
            AssetType.Click();

            var Operator = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(Operator.Enabled);
            Assert.IsTrue(Operator.Displayed);
            Assert.AreEqual(Operator.Text, "Operator");
            Assert.AreEqual(Operator.GetAttribute("class"),"sorting");
            Assert.AreEqual(Operator.GetAttribute("aria-controls"), "AssetsTable");
            Operator.Click();

            var Asset = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(Asset.Enabled);
            Assert.IsTrue(Asset.Displayed);
            Assert.AreEqual(Asset.Text, "Asset");
            Assert.AreEqual(Asset.GetAttribute("class"), "sorting");
            Assert.AreEqual(Asset.GetAttribute("aria-controls"), "AssetsTable");
            Asset.Click();

            var State = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Enabled);
            Assert.IsTrue(State.Displayed);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(Asset.GetAttribute("class"), "sorting");
            Assert.AreEqual(Asset.GetAttribute("aria-controls"), "AssetsTable");
            State.Click();

            var createTime = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[8]"));
            Assert.IsTrue(createTime.Enabled);
            Assert.IsTrue(createTime.Displayed);
            Assert.AreEqual(createTime.Text, "Created Time");
            Assert.AreEqual(createTime.GetAttribute("class"), "sorting");
            Assert.AreEqual(createTime.GetAttribute("aria-controls"), "AssetsTable");
            createTime.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[9]"));
            Assert.IsTrue(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting");
            Assert.AreEqual(Actions.GetAttribute("aria-controls"), "AssetsTable");
            Actions.Click();
        }

        [Test]
        public void ViewEditsPage_SideLeftMinimizeToggle()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(sideLeft.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-tablet-and-mobile-inline-block");
            sideLeft.Click();
        }

        [Test]
        public void ViewEditPage_MasideHeaderMenuMobileToggleTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var asideHeaderMenuMobileToggle = driver.FindElement
                (By.Id("m_aside_header_menu_mobile_toggle"));

            Assert.IsTrue(asideHeaderMenuMobileToggle.Enabled);
            Assert.IsTrue(asideHeaderMenuMobileToggle.Displayed);
            Assert.AreEqual(asideHeaderMenuMobileToggle.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(asideHeaderMenuMobileToggle.GetAttribute("class"), "m-brand__icon m--visible-tablet-and-mobile-inline-block");
        }

        [Test]
        public void ViewEditsPage_CopyRightTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

// logoun btn
