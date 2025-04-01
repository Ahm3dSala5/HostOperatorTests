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
        public void AdminMaintBuildingPage_TestReportOption()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
            Assert.IsTrue(reportOption.Displayed);
            Assert.IsTrue(reportOption.Enabled);
            var URLBeforeClick = driver.Url;
            reportOption.Click();
            var URLAfterClick = driver.Url;
            Assert.AreEqual(URLBeforeClick, $"{URLAfterClick}");
        }

        [Test]
        public void AdminMaintBuildings_TestFacilityOption()
        {
            // to click on report option 
            AdminMaintBuildingPage_TestReportOption();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(facilityOption.Text, "Facility");
            Assert.AreEqual(facilityOption.GetAttribute("custom-data"), "Facility");
            var currentUrl = driver.Url;
            Assert.AreEqual(facilityOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(facilityOption.Displayed);
            Assert.IsTrue(facilityOption.Enabled);
            facilityOption.Click();
        }

        [Test]
        public void AdminMaintBuildings_TestAdminMaintBuildings()
        {
            // to click on report option 
            AdminMaintBuildingPage_TestReportOption();
            // to click on equipment option
            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMaintBuildingsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a"));
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("custom-data"), "Admin/Maint Buildings");
            var adminMaintBuildingsURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Buildings";
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("href"), $"{adminMaintBuildingsURL}");
            Assert.AreEqual(adminMaintBuildingsOption.GetAttribute("target"), "_self");
            Assert.IsTrue(adminMaintBuildingsOption.Enabled);
            adminMaintBuildingsOption.Click();
        }

        // to open page
        [Test]
        public void AdminMaintBuildins_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMaintBuildingsOption = driver.FindElement
                  (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a"));
            adminMaintBuildingsOption.Click();
        }

        [Test]
        public void AdminMaintBuildingsPage_HiHostOperatorTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

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
        public void AdminMaintBuildingsPage_ServiceVehiclesPage_LogoutBtn()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

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
        public void AdminMaintBuildingsPage_NotificationTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void AdminMaintBuildingsPage_TestPageTitle()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Buildings");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void AdminMaintBuildingsPage_ReportsBtnTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(dashboardBtn.Text, "Reports");
            Assert.IsTrue(dashboardBtn.Displayed);
            Assert.IsTrue(dashboardBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            dashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        // must be enabled and when click must open same page
        [Test]
        public void AdminMaintBuildingsPage_FacilityBtnTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(facilityOption.Text, "Facility");
            Assert.IsTrue(facilityOption.Displayed);
            Assert.IsTrue(facilityOption.Enabled);
            var UrlBeforeClick = driver.Url;
            facilityOption.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void AdminMaintBuildingsPage_BuildingsBtnTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var buildingsBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.AreEqual(buildingsBtn.Text, "Buildings");
            Assert.IsTrue(buildingsBtn.Displayed);
            Assert.IsTrue(buildingsBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            buildingsBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintBuildingsPage_AssetClassParagraphTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

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
            AdminMaintBuildins_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Administrative/Maintenance Facilities");
        }

        [Test]
        public void AdminMaintBuildingsPage_AssetTypeParagraphTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            
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
            AdminMaintBuildins_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"buildings_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("buildings_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void AdminMaintBuildingsPage_DataTableFilterTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("buildings_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"buildings_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void AdminMaintBuildingsPage_ReOrderTableTest()
        {
            // to open admin maint buildings page
            /////////////////////////////////////
            var reportOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMaintBuildingsOption = driver.FindElement
                  (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[1]/a"));
            adminMaintBuildingsOption.Click();
            //////////////////////////////////////


            var columns = driver.FindElements(By.Id("buildings"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text,"Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "buildings");
            //RowNo.Click();

            var AssetId = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetId.Displayed);
            Assert.IsTrue(AssetId.Enabled);
            Assert.AreEqual(AssetId.Text, "Asset Id");
            Assert.AreEqual(AssetId.GetAttribute("aria-label"), "Asset Id: activate to sort column ascending");
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "buildings");
            //AssetId.Click();

            var BuildingDesc = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[3]"));
            Assert.IsTrue(BuildingDesc.Displayed);
            Assert.IsTrue(BuildingDesc.Enabled);
            Assert.AreEqual(BuildingDesc.Text, "Building Desc");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-label"), "Building Desc: activate to sort column ascending");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-controls"), "buildings");
            //BuildingDesc.Click();

            var BuildingArea = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[4]"));
            Assert.IsTrue(BuildingArea.Displayed);
            Assert.IsTrue(BuildingArea.Enabled);
            Assert.AreEqual(BuildingArea.Text, "Building Area");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-label"), "Building Area: activate to sort column ascending");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-controls"), "buildings");
            //BuildingArea.Click();

            var OverallRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[5]"));
            Assert.IsTrue(OverallRating.Displayed);
            Assert.IsTrue(OverallRating.Enabled);
            Assert.AreEqual(OverallRating.Text, "Overall Rating");
            Assert.AreEqual(OverallRating.GetAttribute("aria-label"), "Overall Rating: activate to sort column ascending");
            Assert.AreEqual(OverallRating.GetAttribute("aria-controls"), "buildings");
            //OverallRating.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[6]"));
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "buildings");
            //ConditionAssessmentDate.Click();

            var SiteRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[7]"));
            Assert.IsTrue(SiteRating.Displayed);
            Assert.IsTrue(SiteRating.Enabled);
            Assert.AreEqual(SiteRating.Text, "Site Rating");
            Assert.AreEqual(SiteRating.GetAttribute("aria-label"), "Site Rating: activate to sort column ascending");
            Assert.AreEqual(SiteRating.GetAttribute("aria-controls"), "buildings");
            //SiteRating.Click();

            var SubstructureRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[8]"));
            Assert.IsTrue(SubstructureRating.Displayed);
            Assert.IsTrue(SubstructureRating.Enabled);
            Assert.AreEqual(SubstructureRating.Text, "Substructure Rating");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-label"), "Substructure Rating: activate to sort column ascending");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-controls"), "buildings");
            //SubstructureRating.Click();

            var ShellRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[9]"));
            Assert.IsTrue(ShellRating.Displayed);
            Assert.IsTrue(ShellRating.Enabled);
            Assert.AreEqual(ShellRating.Text, "Shell Rating");
            Assert.AreEqual(ShellRating.GetAttribute("aria-label"), "Shell Rating: activate to sort column ascending");
            Assert.AreEqual(ShellRating.GetAttribute("aria-controls"), "buildings");
            //ShellRating.Click();

            var InteriorRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[10]"));
            Assert.IsTrue(InteriorRating.Displayed);
            Assert.IsTrue(InteriorRating.Enabled);
            Assert.AreEqual(InteriorRating.Text, "Interior Rating");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-label"), "Interior Rating: activate to sort column ascending");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-controls"), "buildings");
            //InteriorRating.Click();

            var PlumbingRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[11]"));
            Assert.IsTrue(PlumbingRating.Displayed);
            Assert.IsTrue(PlumbingRating.Enabled);
            Assert.AreEqual(PlumbingRating.Text, "Plumbing Rating");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-label"), "Plumbing Rating: activate to sort column ascending");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-controls"), "buildings");
            //PlumbingRating.Click();

            var HVACRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[12]"));
            Assert.IsTrue(HVACRating.Displayed);
            Assert.IsTrue(HVACRating.Enabled);
            Assert.AreEqual(HVACRating.Text, "HVAC Rating");
            Assert.AreEqual(HVACRating.GetAttribute("aria-label"), "HVAC Rating: activate to sort column ascending");
            Assert.AreEqual(HVACRating.GetAttribute("aria-controls"), "buildings");
            //HVACRating.Click();

            var ElectricalRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[13]"));
            Assert.IsTrue(ElectricalRating.Displayed);
            Assert.IsTrue(ElectricalRating.Enabled);
            Assert.AreEqual(ElectricalRating.Text, "Electrical Rating");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-label"), "Electrical Rating: activate to sort column ascending");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-controls"), "buildings");
            //ElectricalRating.Click();

            var FireProtectionRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[14]"));
            Assert.IsTrue(FireProtectionRating.Displayed);
            Assert.IsTrue(FireProtectionRating.Enabled);
            Assert.AreEqual(FireProtectionRating.Text, "Fire Protection Rating");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-label"), "Fire Protection Rating: activate to sort column ascending");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-controls"), "buildings");
            //FireProtectionRating.Click();

            var ConveyanceRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[15]"));
            Assert.IsTrue(ConveyanceRating.Displayed);
            Assert.IsTrue(ConveyanceRating.Enabled);
            Assert.AreEqual(ConveyanceRating.Text, "Conveyance Rating");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-label"), "Conveyance Rating: activate to sort column ascending");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-controls"), "buildings");
            //ConveyanceRating.Click();
             
            var EquipmentRating = driver.FindElement(By.XPath("//*[@id=\"buildings\"]/thead/tr/th[16]"));
            Assert.IsTrue(EquipmentRating.Displayed);
            Assert.IsTrue(EquipmentRating.Enabled);
            Assert.AreEqual(EquipmentRating.Text, "Equipment Rating");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-label"), "Equipment Rating: activate to sort column ascending");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-controls"), "buildings");
            //EquipmentRating.Click();
        }

        [Test]
        public void adminMaintBuildinsPage_PaginateTest()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var previousBtn = driver.FindElement(By.Id("buildings_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("buildings_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
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
            AdminMaintBuildins_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void AdminMaintBuildingsPage_SideLeftMinimizeToggle()
        {
            // to open admin maint buildings page
            AdminMaintBuildins_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
