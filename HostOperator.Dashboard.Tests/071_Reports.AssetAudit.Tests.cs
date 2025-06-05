using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorReportsAuditTests : IDisposable
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
        public void AssetAuditPage_ReportsOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.IsTrue(reportOption.Enabled);
            Assert.IsTrue(reportOption.Displayed);
            Assert.AreEqual(reportOption.Text,"Reports");
            Assert.AreEqual(reportOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(reportOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"),"Reports");
            Assert.AreEqual(reportOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var reportsOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/i[1]"));
            Assert.IsTrue(reportsOptionIcon.Enabled);
            Assert.IsTrue(reportsOptionIcon.Displayed);
            Assert.AreEqual(reportsOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var reportsOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/i[2]"));
            Assert.IsTrue(reportsOptionArrow.Enabled);
            Assert.IsTrue(reportsOptionArrow.Displayed);
            Assert.AreEqual(reportsOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var reportsOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/span/span"));
            Assert.IsTrue(reportsOptionText.Enabled);
            Assert.IsTrue(reportsOptionText.Displayed);
            Assert.AreEqual(reportsOptionText.Text,"Reports");
            Assert.AreEqual(reportsOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void AssetAuditPage_AssetAuditOptionTest()
        {
            // to click on reports option
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var assetAuditOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[1]/a"));
            Assert.IsTrue(assetAuditOption.Enabled);
            Assert.IsTrue(assetAuditOption.Displayed);
            Assert.AreEqual(assetAuditOption.Text, "Asset Audit");
            Assert.AreEqual(assetAuditOption.GetAttribute("target"), "_self");
            Assert.AreEqual(assetAuditOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(assetAuditOption.GetAttribute("custom-data"), "Asset Audit");
            Assert.AreEqual(assetAuditOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetAuditOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/AssetAudit");

            var assetAuditOptionIcon = driver.FindElement(By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(assetAuditOptionIcon.Enabled);
            Assert.IsTrue(assetAuditOptionIcon.Displayed);
            Assert.AreEqual(assetAuditOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var assetAuditOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(assetAuditOption.Enabled);
            Assert.IsTrue(assetAuditOption.Displayed);
            Assert.AreEqual(assetAuditOptionText.Text, "Asset Audit");
            Assert.AreEqual(assetAuditOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void  AssetAuditPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/AssetAudit");
        }

        [Test]
        public void AssetAuditPage_TopUserNameTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenPage();

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
        public void AssetAuditPage_LogoutBtn()
        {
            // to open asset audit page
            AssetAuditPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Thread.Sleep(5000);
            
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void AssetAuditPage_NotificationIconTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenPage();

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
        public void AssetAuditPage_SubHeaderTitleTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Asset Audit");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        // this method contains error in name dashboard ancor 
        // must be Dashboard but is Dashboard as
        [Test]
        public void AssetAuditPage_DashboardNavigationLinkTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            dashboardNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AssetAuditPage_AssetAuditNavigationLinkTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var assetAuditNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.IsTrue(assetAuditNavLink.Enabled);
            Assert.IsTrue(assetAuditNavLink.Displayed);
            Assert.AreEqual(assetAuditNavLink.Text,"Asset Audit");
            Assert.AreEqual(assetAuditNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AssetAuditPage_SeperatorBetweenNavLinksTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AssetAuditPage_AgencyNameLabelTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var agencyNameLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/label"));
            Assert.IsTrue(agencyNameLabel.Enabled);
            Assert.IsTrue(agencyNameLabel.Displayed);
            Assert.AreEqual(agencyNameLabel.Text, "Select Agency Name");
            Assert.AreEqual(agencyNameLabel.GetAttribute("for"), "AssetState");
            Assert.AreEqual(agencyNameLabel.GetAttribute("class"),"form-label");
        }

        [Test]
        public void AssetAuditPage_AgencyNameBtnTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var agencyName = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/button"));
            Assert.IsTrue(agencyName.Enabled);
            Assert.IsTrue(agencyName.Displayed);
            Assert.AreEqual(agencyName.GetAttribute("type"),"button");
            Assert.AreEqual(agencyName.GetAttribute("title"), "None selected");
            Assert.AreEqual(agencyName.GetAttribute("data-toggle"), "dropdown");
            Assert.AreEqual(agencyName.GetAttribute("class"), "multiselect dropdown-toggle btn btn-default");
            agencyName.Click();
        }

        [Test]
        public void AssetAuditPage_AgencyDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            Thread.Sleep(5000);
            var agencyName = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/button"));
            agencyName.Click();

            var searchInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/ul/li[1]/div/input"));
            Assert.IsTrue(searchInput.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"),"text");
            Assert.AreEqual(searchInput.GetAttribute("placeholder"),"Search");
            Assert.AreEqual(searchInput.GetAttribute("class"), "form-control multiselect-search");

            var selectAllAgencies = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/ul/li[2]/a/label/input"));
            Assert.IsTrue(selectAllAgencies.Enabled);
            Assert.IsTrue(selectAllAgencies.Displayed);
            Assert.AreEqual(selectAllAgencies.GetAttribute("type"), "checkbox");

            var agencies = driver.FindElements(By.ClassName("checkbox"));
            foreach(var agency in agencies)
            {
                Assert.IsTrue(agency.Enabled);
                Assert.IsTrue(agency.Displayed);
            }
        }

        [Test]
        public void AssetAuditPage_AssetClassDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[1]/div/div[1]/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"form-control form-line");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Select Asset Class");
        }

        [Test]
        public void AssetAuditPage_AssetSubclassDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[2]/div/div[1]/label"));
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"), "AssetSubClass");

            var assetSubClassInput = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"),"form-control");

            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Asset Subclass");
        }


        // this pice contains error in asset type label it must linked with asset subclass 
        // but is must be linked with asset label
        [Test]
        public void AssetAuditPage_AssetTypeDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[3]/div/div[1]/label"));
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("class"),"form-control");

            var selectedAssetType = new SelectElement(assetTypeInput);
            selectedAssetType.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Asset Types");
        }

        // error in this pice asset state label must be linked with asset state
        // but is linked with start date
        [Test]
        public void AssetAuditPage_AssetStateDropdownlist()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var assetStateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[4]/div/div/label"));
            Assert.IsTrue(assetStateLabel.Displayed);
            Assert.IsTrue(assetStateLabel.Enabled);
            Assert.AreEqual(assetStateLabel.Text, "Asset State");
            Assert.AreEqual(assetStateLabel.GetAttribute("for"),"AssetState");
            Assert.AreEqual(assetStateLabel.GetAttribute("class"),"form-label");

            var assetStateInput = driver.FindElement(By.Id("AssetStateIdChange"));
            Assert.IsTrue(assetStateInput.Enabled);
            Assert.IsTrue(assetStateInput.Displayed);
            Assert.AreEqual(assetStateInput.GetAttribute("class"),"form-label");

            var selectedAssetState = new SelectElement(assetStateInput);
            selectedAssetState.SelectByIndex(0);
        }

        [Test]
        public void AssetAuditPage_StartDateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var startDateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[5]/div/div/label"));
            Assert.IsTrue(startDateLabel.Displayed);
            Assert.IsTrue(startDateLabel.Enabled);
            Assert.AreEqual(startDateLabel.Text, "Start Date");
            Assert.AreEqual(startDateLabel.GetAttribute("for"), "StartDate");
            Assert.AreEqual(startDateLabel.GetAttribute("class"),"form-label");

            var startDataInout = driver.FindElement(By.Id("StartDate"));
            Assert.IsTrue(startDataInout.Enabled);
            Assert.IsTrue(startDataInout.Displayed);
            Assert.AreEqual(startDataInout.GetAttribute("type"),"date");
            Assert.AreEqual(startDataInout.GetAttribute("max"), $"{DateTime.Now.Year}-0{DateTime.Now.Month}-{DateTime.Now.Day}");
        }

        [Test]
        public void AssetAuditPage_EndDateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var endDateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[6]/div/div/label"));
            Assert.IsTrue(endDateLabel.Displayed);
            Assert.IsTrue(endDateLabel.Enabled);
            Assert.AreEqual(endDateLabel.Text, "End Date");
            Assert.AreEqual(endDateLabel.GetAttribute("for"), "StartDate");
            Assert.AreEqual(endDateLabel.GetAttribute("class"),"form-label");

            var startDataInput = driver.FindElement(By.Id("EndDate"));
            Assert.IsTrue(startDataInput.Enabled);
            Assert.IsTrue(startDataInput.Displayed);
            Assert.AreEqual(startDataInput.GetAttribute("type"), "date");
            Assert.AreEqual(startDataInput.GetAttribute("max"), "9999-12-31");
            Assert.AreEqual(startDataInput.GetAttribute("class"),"form-control");
        }

        [Test]
        public void AssetAuditPage_SubmitBtnTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var submitBtn = driver.FindElement(By.Id("subbtn"));
            Assert.IsTrue(submitBtn.Displayed);
            Assert.IsTrue(submitBtn.Enabled);
            Assert.AreEqual(submitBtn.Text, "Submit");
            Assert.AreEqual(submitBtn.GetAttribute("type"),"button");
            Assert.AreEqual(submitBtn.GetAttribute("class"), "btn btn-primary waves-effect");
        }

        [Test]
        public void AssetAuditPage_DataTableLengthTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

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
        public void AssetAuditPage_DataTableFilterTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "AssetsTable");
        }

        [Test]
        public void AssetAuditPage_PaginateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("AssetsTable_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");

            var nextBtn = driver.FindElement(By.Id("AssetsTable_next"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
        }

        [Test]
        public void AssetAuditPage_SideLeftMinimizeToggle()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }

        [Test]
        public void AssetAuditPage_DataTableInfoTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetsTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing"));
            Assert.IsTrue(tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AssetAuditPage_CopyRightTest()
        {
            // to open asset audit
            AssetAuditPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
