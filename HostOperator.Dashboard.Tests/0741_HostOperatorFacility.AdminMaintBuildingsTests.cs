using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorFacilityAdminMaintBuildingTests : IDisposable
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
        public void AdminMaintBuildingsPage_ReportsOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.IsTrue(reportOption.Enabled);
            Assert.IsTrue(reportOption.Displayed);
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(reportOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
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
            Assert.AreEqual(reportsOptionText.Text, "Reports");
            Assert.AreEqual(reportsOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void AdminMaintBuildingsPage_FacilityOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.IsTrue(facilityOption.Enabled);
            Assert.IsTrue(facilityOption.Displayed);
            Assert.AreEqual(facilityOption.Text, "Facility");
            Assert.AreEqual(facilityOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(facilityOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(facilityOption.GetAttribute("custom-data"), "Facility");
            Assert.AreEqual(facilityOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var facilityOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[2]"));
            Assert.IsTrue(facilityOptionArrow.Enabled);
            Assert.IsTrue(facilityOptionArrow.Displayed);
            Assert.AreEqual(facilityOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var facilityOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a/i[1]"));
            Assert.IsTrue(facilityOptionIcon.Enabled);
            Assert.IsTrue(facilityOptionIcon.Displayed);
            Assert.AreEqual(facilityOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var facilityOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(facilityOptionText.Enabled);
            Assert.IsTrue(facilityOptionText.Displayed);
            Assert.AreEqual(facilityOptionText.Text, "Facility");
            Assert.AreEqual(facilityOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void AdminMaintBuildings_AdminMaintBuildingsOptionTest()
        {
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Thread.Sleep(3000);
            facilityOption.Click();

            var adminMaintBuildingsOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a"));
            Assert.IsTrue(adminMaintBuildingsOption.Enabled);
            Assert.IsTrue(adminMaintBuildingsOption.Displayed);
            Assert.AreEqual(adminMaintBuildingsOption.Text, "Admin/Maint Buildings");
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("target"), "_self");
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("custom-data"), "Admin/Maint Buildings");
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Buildings");

            var adminMaintBuildingsOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(adminMaintBuildingsOptionIcon.Enabled);
            Assert.IsTrue(adminMaintBuildingsOptionIcon.Displayed);
            Assert.AreEqual(adminMaintBuildingsOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var adminMaintBuildingsOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(adminMaintBuildingsOptionText.Enabled);
            Assert.IsTrue(adminMaintBuildingsOptionText.Displayed);
            Assert.AreEqual(adminMaintBuildingsOptionText.Text, "Admin/Maint Buildings");
            Assert.AreEqual(adminMaintBuildingsOptionText.GetAttribute("class"), "title");
        }

        // to open page
        [Test]
        public void AdminMaintBuildinsPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Buildings");
        }

        [Test]
        public void AdminMaintBuildingsPage_TopUserNameTest()
        {
            // to open admin maint buildings page 
            AdminMaintBuildinsPage_OpenPage();

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
        public void AdminMaintBuildingsPage_LogoutBtn()
        {
            // to open admin maint buildings page 
            AdminMaintBuildinsPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Thread.Sleep(9000);
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void AdminMaintBuildingsPage_NotificationIconTest()
        {
            // to open admin maint buildings page 
            AdminMaintBuildinsPage_OpenPage();

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
        public void AdminMaintBuildingsPage_SubHeaderTitleTest()
        {
            // to open admin maint buildings page 
            AdminMaintBuildinsPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Buildings");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AdminMaintBuildingsPage_ReportsNavigationLinkTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            reportsNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintBuildings_Seperator1Test()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AdminMaintBuildingsPage_FacilityNavigationLinkTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var facilityNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(facilityNavLink.Enabled);
            Assert.IsTrue(facilityNavLink.Displayed);
            Assert.AreEqual(facilityNavLink.Text, "Facility");
            Assert.AreEqual(facilityNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            facilityNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintBuildings_Seperator2Test()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AdminMaintBuildingsPage_BuildingsNavigationLinkTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var buildingsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(buildingsNavLink.Enabled);
            Assert.IsTrue(buildingsNavLink.Displayed);
            Assert.AreEqual(buildingsNavLink.Text, "Buildings");
            Assert.AreEqual(buildingsNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            buildingsNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintBuildingsPage_AssetClassParagraphTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/b"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.Text, "Facility");
        }

        [Test]
        public void AdminMaintBuildingsPage_AssetSubClassParagraphTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Administrative/Maintenance Facilities");
        }

        // error in this pice asset type label must linked with asset type 
        // but is linked with asset sub class
        [Test]
        public void AdminMaintBuildingsPage_AssetTypeParagraphTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-control");

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Administrative/Maintenance Building");
        }

        [Test]
        public void AdminMaintBuildingsPage_DataTableLengthTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"buildings_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("buildings_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "buildings");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void AdminMaintBuildingsPage_DataTableFilterTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("buildings_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"buildings_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "buildings");
        }

        [Test]
        public void AdminMaintBuildingsPage_ReOrderTableTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var table = driver.FindElement(By.Id("buildings"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "buildings_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.Id("buildings"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text,"Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var AssetId = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetId.Enabled);
            Assert.IsTrue(AssetId.Displayed);
            Assert.AreEqual(AssetId.Text, "Asset Id");
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(AssetId.GetAttribute("aria-label"), "Asset Id: activate to sort column ascending");
            //AssetId.Click();

            var BuildingDesc = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[3]"));
            Assert.IsTrue(BuildingDesc.Enabled);
            Assert.IsTrue(BuildingDesc.Displayed);
            Assert.AreEqual(BuildingDesc.Text, "Building Desc");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-label"), "Building Desc: activate to sort column ascending");
            //BuildingDesc.Click();

            var BuildingArea = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[4]"));
            Assert.IsTrue(BuildingArea.Enabled);
            Assert.IsTrue(BuildingArea.Displayed);
            Assert.AreEqual(BuildingArea.Text, "Building Area");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-label"), "Building Area: activate to sort column ascending");
            //BuildingArea.Click();

            var OverallRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[5]"));
            Assert.IsTrue(OverallRating.Enabled);
            Assert.IsTrue(OverallRating.Displayed);
            Assert.AreEqual(OverallRating.Text, "Overall Rating");
            Assert.AreEqual(OverallRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(OverallRating.GetAttribute("aria-label"), "Overall Rating: activate to sort column ascending");
            //OverallRating.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[6]"));
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            //ConditionAssessmentDate.Click();

            var SiteRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[7]"));
            Assert.IsTrue(SiteRating.Enabled);
            Assert.IsTrue(SiteRating.Displayed);
            Assert.AreEqual(SiteRating.Text, "Site Rating");
            Assert.AreEqual(SiteRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(SiteRating.GetAttribute("aria-label"), "Site Rating: activate to sort column ascending");
            //SiteRating.Click();

            var SubstructureRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[8]"));
            Assert.IsTrue(SubstructureRating.Enabled);
            Assert.IsTrue(SubstructureRating.Displayed);
            Assert.AreEqual(SubstructureRating.Text, "Substructure Rating");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-label"), "Substructure Rating: activate to sort column ascending");
            //SubstructureRating.Click();

            var ShellRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[9]"));
            Assert.IsTrue(ShellRating.Enabled);
            Assert.IsTrue(ShellRating.Displayed);
            Assert.AreEqual(ShellRating.Text, "Shell Rating");
            Assert.AreEqual(ShellRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(ShellRating.GetAttribute("aria-label"), "Shell Rating: activate to sort column ascending");
            //ShellRating.Click();

            var InteriorRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[10]"));
            Assert.IsTrue(InteriorRating.Enabled);
            Assert.IsTrue(InteriorRating.Displayed);
            Assert.AreEqual(InteriorRating.Text, "Interior Rating");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-label"), "Interior Rating: activate to sort column ascending");
            //InteriorRating.Click();

            var PlumbingRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[11]"));
            Assert.IsTrue(PlumbingRating.Enabled);
            Assert.IsTrue(PlumbingRating.Displayed);
            Assert.AreEqual(PlumbingRating.Text, "Plumbing Rating");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-label"), "Plumbing Rating: activate to sort column ascending");
            //PlumbingRating.Click();

            var HVACRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[12]"));
            Assert.IsTrue(HVACRating.Enabled);
            Assert.IsTrue(HVACRating.Displayed);
            Assert.AreEqual(HVACRating.Text, "HVAC Rating");
            Assert.AreEqual(HVACRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(HVACRating.GetAttribute("aria-label"), "HVAC Rating: activate to sort column ascending");
            //HVACRating.Click();

            var ElectricalRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[13]"));
            Assert.IsTrue(ElectricalRating.Enabled);
            Assert.IsTrue(ElectricalRating.Displayed);
            Assert.AreEqual(ElectricalRating.Text, "Electrical Rating");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-label"), "Electrical Rating: activate to sort column ascending");
            //ElectricalRating.Click();

            var FireProtectionRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[14]"));
            Assert.IsTrue(FireProtectionRating.Enabled);
            Assert.IsTrue(FireProtectionRating.Displayed);
            Assert.AreEqual(FireProtectionRating.Text, "Fire Protection Rating");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-label"), "Fire Protection Rating: activate to sort column ascending");
            //FireProtectionRating.Click();

            var ConveyanceRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[15]"));
            Assert.IsTrue(ConveyanceRating.Enabled);
            Assert.IsTrue(ConveyanceRating.Displayed);
            Assert.AreEqual(ConveyanceRating.Text, "Conveyance Rating");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-label"), "Conveyance Rating: activate to sort column ascending");
            //ConveyanceRating.Click();
             
            var EquipmentRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[16]"));
            Assert.IsTrue(EquipmentRating.Enabled);
            Assert.IsTrue(EquipmentRating.Displayed);
            Assert.AreEqual(EquipmentRating.Text, "Equipment Rating");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-label"), "Equipment Rating: activate to sort column ascending");
            //EquipmentRating.Click();
        }

        [Test]
        public void adminMaintBuildinsPage_PaginateTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("buildings_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("buildings_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "buildings");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("buildings_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Enabled);
                page.Click();
            }
        }

        [Test]
        public void AdminMaintBuidlingsPage_ExportBtnTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void AdminMaintBuildingsPage_SideLeftMinimizeToggle()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void AdminMaintBuildinsPage_DataTableInfoTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("buildings_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AdminMaintBuildinsPage_CopyRightTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildinsPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
