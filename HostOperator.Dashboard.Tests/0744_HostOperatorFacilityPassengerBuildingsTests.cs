using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorFacilityPassengerBuildingsTests : IDisposable
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
        public void PassengerBuildingsPage_TestReportOption()
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
            Assert.AreEqual(reportOption.GetAttribute("href"), $"{URLAfterClick}#");
        }

        [Test]
        public void PassengerBuildingsPage_TestFacilityOption()
        {
            // to click on report option 
            PassengerBuildingsPage_TestReportOption();

            var FacilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(FacilityOption.Text, "Facility");
            Assert.AreEqual(FacilityOption.GetAttribute("custom-data"), "Facility");
            var currentUrl = driver.Url;
            Assert.AreEqual(FacilityOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(FacilityOption.Displayed);
            Assert.IsTrue(FacilityOption.Enabled);
            FacilityOption.Click();
        }

        [Test]
        public void PassengerBuildingsPage_TestPassengerBuildingsOption()
        {
            // to click on report option 
            PassengerBuildingsPage_TestReportOption();
            // to click on equipment option
            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var PassengerBuildingsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a"));
            Assert.AreEqual(PassengerBuildingsOption.GetAttribute("custom-data"), "Passenger Buildings");
            var PassengerBuidlingsURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/PassengerBuildings";
            Assert.AreEqual(PassengerBuildingsOption.GetAttribute("href"), $"{PassengerBuidlingsURL}");
            Assert.AreEqual(PassengerBuildingsOption.GetAttribute("target"),"_self");
            Assert.IsTrue(PassengerBuildingsOption.Enabled);
            PassengerBuildingsOption.Click();
        }

        // to open page
        [Test]
        public void PassengerBuildingsPage_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var PassengerBuildingsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a"));
            PassengerBuildingsOption.Click();
        }

        [Test]
        public void PassengerBuildingsPaga_TableBarTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

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
        public void PassengerBuildingsPage_LogoutBtnTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

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
        public void PassengerBuildingsPage_NotificationTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void PassengerBuildingsPage_TestPageTitle()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Passenger Buildings");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void PassengerBuildingsPage_ReportBtnTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var reportBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(reportBtn.Text, "Reports");
            Assert.IsTrue(reportBtn.Displayed);
            Assert.IsTrue(reportBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            reportBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        // must be enabled and when click must open same page
        [Test]
        public void PassengerBuildingsPage_FacilityBtnTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var facilityBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(facilityBtn.Text, "Facility");
            Assert.IsTrue(facilityBtn.Displayed);
            Assert.IsTrue(facilityBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            facilityBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void PassengerBuildingsPage_PassengerBuildingsBtnTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var PassengerPacilitiesBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a"));
            Assert.AreEqual(PassengerPacilitiesBtn.Text, "Passenger Buildings");
            Assert.IsTrue(PassengerPacilitiesBtn.Displayed);
            Assert.IsTrue(PassengerPacilitiesBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            PassengerPacilitiesBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void PassengerBuildingssPage_DataTableLengthTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("passengerBuildings_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void PassengerBuildingsPage_DataTableFilterTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("passengerBuildings_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"passengerBuildings_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void PassengerBuildingsPage_AssetClassParagraphTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

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
        public void PassengerBuildingsPage_AssetSubClassParagraphTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Passenger Facilities");
        }

        [Test]
        public void PassengerBuildingssPage_AssetTypeParagraphTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Passenger Building");
        }

        [Test]
        public void PassengerBuildingssPage_ReOrderTableTest()
        {
            // to open passenger buildings page
            ///////////////////////////////////
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var PassengerBuildingsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a"));
            PassengerBuildingsOption.Click();
            ///////////////////////////////////

            var columns = driver.FindElements(By.Id("passengerBuildings"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNow = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNow.Displayed);
            Assert.IsTrue(RowNow.Enabled);
            Assert.AreEqual(RowNow.Text, "Row No");
            Assert.AreEqual(RowNow.GetAttribute("aria-controls"), "passengerBuildings");
            Assert.AreEqual(RowNow.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNow.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNow.Click();

            var AssetId = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetId.Displayed);
            Assert.IsTrue(AssetId.Enabled);
            Assert.AreEqual(AssetId.Text, "Asset Id");
            Assert.AreEqual(AssetId.GetAttribute("aria-label"), "Asset Id: activate to sort column ascending");
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "passengerBuildings");
            //AssetId.Click();

            var BuildingDesc = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[3]"));
            Assert.IsTrue(BuildingDesc.Displayed);
            Assert.IsTrue(BuildingDesc.Enabled);
            Assert.AreEqual(BuildingDesc.Text, "Building Desc");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-label"), "Building Desc: activate to sort column ascending");
            Assert.AreEqual(BuildingDesc.GetAttribute("aria-controls"), "passengerBuildings");
            //BuildingDesc.Click();

            var BuildingArea = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[4]"));
            Assert.IsTrue(BuildingArea.Displayed);
            Assert.IsTrue(BuildingArea.Enabled);
            Assert.AreEqual(BuildingArea.Text, "Building Area");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-label"), "Building Area: activate to sort column ascending");
            Assert.AreEqual(BuildingArea.GetAttribute("aria-controls"), "passengerBuildings");
            //BuildingArea.Click();

            var OverallRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[5]"));
            Assert.IsTrue(OverallRating.Displayed);
            Assert.IsTrue(OverallRating.Enabled);
            Assert.AreEqual(OverallRating.Text, "Overall Rating");
            Assert.AreEqual(OverallRating.GetAttribute("aria-label"), "Overall Rating: activate to sort column ascending");
            Assert.AreEqual(OverallRating.GetAttribute("aria-controls"), "passengerBuildings");
            //OverallRating.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[6]"));
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "passengerBuildings");
            //ConditionAssessmentDate.Click();

            var SiteRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[7]"));
            Assert.IsTrue(SiteRating.Displayed);
            Assert.IsTrue(SiteRating.Enabled);
            Assert.AreEqual(SiteRating.Text, "Site Rating");
            Assert.AreEqual(SiteRating.GetAttribute("aria-label"), "Site Rating: activate to sort column ascending");
            Assert.AreEqual(SiteRating.GetAttribute("aria-controls"), "passengerBuildings");
            //SiteRating.Click();

            var SubstructureRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[8]"));
            Assert.IsTrue(SubstructureRating.Displayed);
            Assert.IsTrue(SubstructureRating.Enabled);
            Assert.AreEqual(SubstructureRating.Text, "Substructure Rating");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-label"), "Substructure Rating: activate to sort column ascending");
            Assert.AreEqual(SubstructureRating.GetAttribute("aria-controls"), "passengerBuildings");
            //SubstructureRating.Click();

            var ShellRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[9]"));
            Assert.IsTrue(ShellRating.Displayed);
            Assert.IsTrue(ShellRating.Enabled);
            Assert.AreEqual(ShellRating.Text, "Shell Rating");
            Assert.AreEqual(ShellRating.GetAttribute("aria-label"), "Shell Rating: activate to sort column ascending");
            Assert.AreEqual(ShellRating.GetAttribute("aria-controls"), "passengerBuildings");
            //ShellRating.Click();

            var InteriorRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[10]"));
            Assert.IsTrue(InteriorRating.Displayed);
            Assert.IsTrue(InteriorRating.Enabled);
            Assert.AreEqual(InteriorRating.Text, "Interior Rating");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-label"), "Interior Rating: activate to sort column ascending");
            Assert.AreEqual(InteriorRating.GetAttribute("aria-controls"), "passengerBuildings");
            //InteriorRating.Click();

            var PlumbingRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[11]"));
            Assert.IsTrue(PlumbingRating.Displayed);
            Assert.IsTrue(PlumbingRating.Enabled);
            Assert.AreEqual(PlumbingRating.Text, "Plumbing Rating");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-label"), "Plumbing Rating: activate to sort column ascending");
            Assert.AreEqual(PlumbingRating.GetAttribute("aria-controls"), "passengerBuildings");
            //PlumbingRating.Click();

            var HVACRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[12]"));
            Assert.IsTrue(HVACRating.Displayed);
            Assert.IsTrue(HVACRating.Enabled);
            Assert.AreEqual(HVACRating.Text, "HVAC Rating");
            Assert.AreEqual(HVACRating.GetAttribute("aria-label"), "HVAC Rating: activate to sort column ascending");
            Assert.AreEqual(HVACRating.GetAttribute("aria-controls"), "passengerBuildings");
            //HVACRating.Click();

            var ElectricalRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[13]"));
            Assert.IsTrue(ElectricalRating.Displayed);
            Assert.IsTrue(ElectricalRating.Enabled);
            Assert.AreEqual(ElectricalRating.Text, "Electrical Rating");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-label"), "Electrical Rating: activate to sort column ascending");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-controls"), "passengerBuildings");
            //ElectricalRating.Click();

            var FireProtectionRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[14]"));
            Assert.IsTrue(FireProtectionRating.Displayed);
            Assert.IsTrue(FireProtectionRating.Enabled);
            Assert.AreEqual(FireProtectionRating.Text, "Fire Protection Rating");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-label"), "Fire Protection Rating: activate to sort column ascending");
            Assert.AreEqual(FireProtectionRating.GetAttribute("aria-controls"), "passengerBuildings");
            //FireProtectionRating.Click();

            var ConveyanceRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[15]"));
            Assert.IsTrue(ConveyanceRating.Displayed);
            Assert.IsTrue(ConveyanceRating.Enabled);
            Assert.AreEqual(ConveyanceRating.Text, "Conveyance Rating");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-label"), "Conveyance Rating: activate to sort column ascending");
            Assert.AreEqual(ConveyanceRating.GetAttribute("aria-controls"), "passengerBuildings");
            //ConveyanceRating.Click();

            var EquipmentRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[16]"));
            Assert.IsTrue(EquipmentRating.Displayed);
            Assert.IsTrue(EquipmentRating.Enabled);
            Assert.AreEqual(EquipmentRating.Text, "Equipment Rating");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-label"), "Equipment Rating: activate to sort column ascending");
            Assert.AreEqual(EquipmentRating.GetAttribute("aria-controls"), "passengerBuildings");
            //EquipmentRating.Click();

            var FareCollectionRating = driver.FindElement(By.XPath("//*[@id=\"passengerBuildings\"]/thead/tr/th[17]"));
            Assert.IsTrue(FareCollectionRating.Displayed);
            Assert.IsTrue(FareCollectionRating.Enabled);
            Assert.AreEqual(FareCollectionRating.Text, "Fare Collection Rating");
            Assert.AreEqual(FareCollectionRating.GetAttribute("aria-label"), "Fare Collection Rating: activate to sort column ascending");
            Assert.AreEqual(FareCollectionRating.GetAttribute("aria-controls"), "passengerBuildings");
            //FareCollectionRating.Click();
        }

        [Test]
        public void PassengerBuildingsPage_PaginateTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("passengerBuildings_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("passengerBuildings_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void PassengerBuildingsPage_ExportBtnTest()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void PassengerBuildingssPage_SideLeftMinimizeToggle()
        {
            // to open passenger buildings page
            PassengerBuildingsPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
