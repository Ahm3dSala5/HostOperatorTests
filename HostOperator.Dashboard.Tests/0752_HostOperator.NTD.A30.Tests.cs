using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorNTDA30Tests : IDisposable
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
        public void A30Page_TestReportOption()
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
        public void A30Page_TestNTDOption()
        {
            // to click on report option 
            A30Page_TestReportOption();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            Assert.AreEqual(NTDOption.GetAttribute("custom-data"), "NTD");
            var currentUrl = driver.Url;
            Assert.AreEqual(NTDOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(NTDOption.Displayed);
            Assert.IsTrue(NTDOption.Enabled);
            NTDOption.Click();
        }

        [Test]
        public void A30Page_TestA30Btn()
        {
            // to click on report option 
            A30Page_TestReportOption();
            // to click on NTD option
            var NTDOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A30Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a"));
            Assert.AreEqual(A30Option.GetAttribute("custom-data"), "A-30");
            var A30URl = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A30Details";
            Assert.AreEqual(A30Option.GetAttribute("href"), $"{A30URl}");
            Assert.AreEqual(A30Option.GetAttribute("target"), "_self");
            Assert.IsTrue(A30Option.Enabled);
            A30Option.Click();
        }

        // to open page
        [Test]
        public void A30Page_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A30Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a"));
            A30Option.Click();
        }

        [Test]
        public void A30Page_TableBarTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30Page_LogoutBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30Page_NotificationTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void A30Page_TestPageTitle()
        {
            // to open A30 page
            A30Page_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "A-30");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void A30Page_ReportBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30_NTDBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var NTDBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(NTDBtn.Text, "NTD");
            Assert.IsTrue(NTDBtn.Displayed);
            Assert.IsTrue(NTDBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            NTDBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void A30Page_A30BtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var A15Btn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a/span"));
            Assert.AreEqual(A15Btn.Text, "A-30");
            Assert.IsTrue(A15Btn.Displayed);
            Assert.IsTrue(A15Btn.Enabled);
            var UrlBeforeClick = driver.Url;
            A15Btn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void A30Page_DataTableLengthTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a30Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a30Details_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void A30Page_DataTableFilterTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a30Details_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a30Details_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void A30Page_AssetClassParagraphTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/b"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.Text, "Revenue Vehicle");
        }

        [Test]
        public void A30Page_AssetSubClassDropdownlistTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);

            var selectedAssetSubClass = new SelectElement(assetSubClassValue);
            selectedAssetSubClass.SelectByIndex(0);
        }

        [Test]
        public void A30Page_AssetTypeDropdownlistTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeValue = driver.FindElement
            (By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            var selectedAssetSubClass = new SelectElement(assetTypeValue);
            selectedAssetSubClass.SelectByIndex(0);
        }

        [Test]
        public void A30Page_ReOrderTableTest()
        {
            // to open A30 page
            ////////////////////////////////////
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A30Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a"));
            A30Option.Click();
            ////////////////////////////////////

            var columns = driver.FindElements(By.Id("a30Details"));
            foreach(var column in  columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var NTDId = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[2]"));
            Assert.IsTrue(NTDId.Displayed);
            Assert.IsTrue(NTDId.Enabled);
            Assert.AreEqual(NTDId.Text, "NTD Id");
            Assert.AreEqual(NTDId.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(NTDId.GetAttribute("aria-label"), "NTD Id: activate to sort column ascending");
            //NTDId.Click();

            var FleetId = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[3]"));
            Assert.IsTrue(FleetId.Displayed);
            Assert.IsTrue(FleetId.Enabled);
            Assert.AreEqual(FleetId.Text, "Fleet Id");
            Assert.AreEqual(FleetId.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FleetId.GetAttribute("aria-label"), "Fleet Id: activate to sort column ascending");
            //FleetId.Click();

            var VehicleType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[4]"));
            Assert.IsTrue(VehicleType.Displayed);
            Assert.IsTrue(VehicleType.Enabled);
            Assert.AreEqual(VehicleType.Text, "Vehicle Type");
            Assert.AreEqual(VehicleType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(VehicleType.GetAttribute("aria-label"), "Vehicle Type: activate to sort column ascending");
            //VehicleType.Click();

            var ActiveVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[5]"));
            Assert.IsTrue(ActiveVehicle.Displayed);
            Assert.IsTrue(ActiveVehicle.Enabled);
            Assert.AreEqual(ActiveVehicle.Text, "Active Vehicle");
            Assert.AreEqual(ActiveVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(ActiveVehicle.GetAttribute("aria-label"), "Active Vehicle: activate to sort column ascending");
            //ActiveVehicle.Click();

            var DedicatedVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[6]"));
            Assert.IsTrue(DedicatedVehicle.Displayed);
            Assert.IsTrue(DedicatedVehicle.Enabled);
            Assert.AreEqual(DedicatedVehicle.Text, "Dedicated Vehicle");
            Assert.AreEqual(DedicatedVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(DedicatedVehicle.GetAttribute("aria-label"), "Dedicated Vehicle: activate to sort column ascending");
            //DedicatedVehicle.Click();

            var ReplacementResponsibility = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[7]"));
            Assert.IsTrue(ReplacementResponsibility.Displayed);
            Assert.IsTrue(ReplacementResponsibility.Enabled);
            Assert.AreEqual(ReplacementResponsibility.Text, "Replacement Responsibility");
            Assert.AreEqual(ReplacementResponsibility.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(ReplacementResponsibility.GetAttribute("aria-label"), "Replacement Responsibility: activate to sort column ascending");
            //ReplacementResponsibility.Click();

            var AutonomousVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[8]"));
            Assert.IsTrue(AutonomousVehicle.Displayed);
            Assert.IsTrue(AutonomousVehicle.Enabled);
            Assert.AreEqual(AutonomousVehicle.Text, "Autonomous Vehicle");
            Assert.AreEqual(AutonomousVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AutonomousVehicle.GetAttribute("aria-label"), "Autonomous Vehicle: activate to sort column ascending");
            //AutonomousVehicle.Click();

            var Manufacturer = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[9]"));
            Assert.IsTrue(Manufacturer.Displayed);
            Assert.IsTrue(Manufacturer.Enabled);
            Assert.AreEqual(Manufacturer.Text, "Manufacturer");
            Assert.AreEqual(Manufacturer.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Manufacturer.GetAttribute("aria-label"), "Manufacturer: activate to sort column ascending");
            //Manufacturer.Click();

            var OtherManufacturer = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[10]"));
            Assert.IsTrue(OtherManufacturer.Displayed);
            Assert.IsTrue(OtherManufacturer.Enabled);
            Assert.AreEqual(OtherManufacturer.Text, "Other Manufacturer");
            Assert.AreEqual(OtherManufacturer.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherManufacturer.GetAttribute("aria-label"), "Other Manufacturer: activate to sort column ascending");
            //OtherManufacturer.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[11]"));
            Assert.IsTrue(Model.Displayed);
            Assert.IsTrue(Model.Enabled);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var YearManufactured = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[12]"));
            Assert.IsTrue(YearManufactured.Displayed);
            Assert.IsTrue(YearManufactured.Enabled);
            Assert.AreEqual(YearManufactured.Text, "Year Manufactured");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-label"), "Year Manufactured: activate to sort column ascending");
            //YearManufactured.Click();

            var YearRebuilt = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[13]"));
            Assert.IsTrue(YearRebuilt.Displayed);
            Assert.IsTrue(YearRebuilt.Enabled);
            Assert.AreEqual(YearRebuilt.Text, "Year Rebuilt");
            Assert.AreEqual(YearRebuilt.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(YearRebuilt.GetAttribute("aria-label"), "Year Rebuilt: activate to sort column ascending");
            //YearRebuilt.Click();

            var FuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[14]"));
            Assert.IsTrue(FuelType.Displayed);
            Assert.IsTrue(FuelType.Enabled);
            Assert.AreEqual(FuelType.Text, "Fuel Type");
            Assert.AreEqual(FuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FuelType.GetAttribute("aria-label"), "Fuel Type: activate to sort column ascending");
            //FuelType.Click();

            var OtherFuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[15]"));
            Assert.IsTrue(OtherFuelType.Displayed);
            Assert.IsTrue(OtherFuelType.Enabled);
            Assert.AreEqual(OtherFuelType.Text, "Other Fuel Type");
            Assert.AreEqual(OtherFuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherFuelType.GetAttribute("aria-label"), "Other Fuel Type: activate to sort column ascending");
            //OtherFuelType.Click();

            var DuelFuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[16]"));
            Assert.IsTrue(DuelFuelType.Displayed);
            Assert.IsTrue(DuelFuelType.Enabled);
            Assert.AreEqual(DuelFuelType.Text, "Duel Fuel Type");
            Assert.AreEqual(DuelFuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(DuelFuelType.GetAttribute("aria-label"), "Duel Fuel Type: activate to sort column ascending");
            //DuelFuelType.Click();

            var VehicleLength = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[17]"));
            Assert.IsTrue(VehicleLength.Displayed);
            Assert.IsTrue(VehicleLength.Enabled);
            Assert.AreEqual(VehicleLength.Text, "Vehicle Length");
            Assert.AreEqual(VehicleLength.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(VehicleLength.GetAttribute("aria-label"), "Vehicle Length: activate to sort column ascending");
            //VehicleLength.Click();

            var SeatingCapacity = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[18]"));
            Assert.IsTrue(SeatingCapacity.Displayed);
            Assert.IsTrue(SeatingCapacity.Enabled);
            Assert.AreEqual(SeatingCapacity.Text, "Seating Capacity");
            Assert.AreEqual(SeatingCapacity.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(SeatingCapacity.GetAttribute("aria-label"), "Seating Capacity: activate to sort column ascending");
            //SeatingCapacity.Click();

            var StandingCapacity = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[19]"));
            Assert.IsTrue(StandingCapacity.Displayed);
            Assert.IsTrue(StandingCapacity.Enabled);
            Assert.AreEqual(StandingCapacity.Text, "Standing Capacity");
            Assert.AreEqual(StandingCapacity.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(StandingCapacity.GetAttribute("aria-label"), "Standing Capacity: activate to sort column ascending");
            //StandingCapacity.Click();

            var OwnershipType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[20]"));
            Assert.IsTrue(OwnershipType.Displayed);
            Assert.IsTrue(OwnershipType.Enabled);
            Assert.AreEqual(OwnershipType.Text, "Ownership Type");
            Assert.AreEqual(OwnershipType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OwnershipType.GetAttribute("aria-label"), "Ownership Type: activate to sort column ascending");
            //OwnershipType.Click();

            var OtherOwnershipType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[21]"));
            Assert.IsTrue(OtherOwnershipType.Displayed);
            Assert.IsTrue(OtherOwnershipType.Enabled);
            Assert.AreEqual(OtherOwnershipType.Text, "Other Ownership Type");
            Assert.AreEqual(OtherOwnershipType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherOwnershipType.GetAttribute("aria-label"), "Other Ownership Type: activate to sort column ascending");
            //OtherOwnershipType.Click();

            var FundingType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[22]"));
            Assert.IsTrue(FundingType.Displayed);
            Assert.IsTrue(FundingType.Enabled);
            Assert.AreEqual(FundingType.Text, "Funding Type");
            Assert.AreEqual(FundingType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FundingType.GetAttribute("aria-label"), "Funding Type: activate to sort column ascending");
            //FundingType.Click();

            var AccessibleVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[23]"));
            Assert.IsTrue(AccessibleVehicle.Displayed);
            Assert.IsTrue(AccessibleVehicle.Enabled);
            Assert.AreEqual(AccessibleVehicle.Text, "Accessible Vehicle");
            Assert.AreEqual(AccessibleVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AccessibleVehicle.GetAttribute("aria-label"), "Accessible Vehicle: activate to sort column ascending");
            //AccessibleVehicle.Click();

            var EmergencyVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[24]"));
            Assert.IsTrue(EmergencyVehicle.Displayed);
            Assert.IsTrue(EmergencyVehicle.Enabled);
            Assert.AreEqual(EmergencyVehicle.Text, "Emergency Vehicle");
            Assert.AreEqual(EmergencyVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(EmergencyVehicle.GetAttribute("aria-label"), "Emergency Vehicle: activate to sort column ascending");
            //EmergencyVehicle.Click();

            var TypeLastRenewel = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[25]"));
            Assert.IsTrue(TypeLastRenewel.Displayed);
            Assert.IsTrue(TypeLastRenewel.Enabled);
            Assert.AreEqual(TypeLastRenewel.Text, "Type Last Renewel");
            Assert.AreEqual(TypeLastRenewel.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(TypeLastRenewel.GetAttribute("aria-label"), "Type Last Renewel: activate to sort column ascending");
            //TypeLastRenewel.Click();

            var UsefulLifeBenchmark = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[26]"));
            Assert.IsTrue(UsefulLifeBenchmark.Displayed);
            Assert.IsTrue(UsefulLifeBenchmark.Enabled);
            Assert.AreEqual(UsefulLifeBenchmark.Text, "Useful Life Benchmark");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-label"), "Useful Life Benchmark: activate to sort column ascending");
            //UsefulLifeBenchmark.Click();

            var UsefulLifeRemaining = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[27]"));
            Assert.IsTrue(UsefulLifeRemaining.Displayed);
            Assert.IsTrue(UsefulLifeRemaining.Enabled);
            Assert.AreEqual(UsefulLifeRemaining.Text, "Useful Life Remaining");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-label"), "Useful Life Remaining: activate to sort column ascending");
            //UsefulLifeRemaining.Click();

            var AvgLifetimeMiles = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[28]"));
            Assert.IsTrue(AvgLifetimeMiles.Displayed);
            Assert.IsTrue(AvgLifetimeMiles.Enabled);
            Assert.AreEqual(AvgLifetimeMiles.Text, "Avg Lifetime Miles");
            Assert.AreEqual(AvgLifetimeMiles.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AvgLifetimeMiles.GetAttribute("aria-label"), "Avg Lifetime Miles: activate to sort column ascending");
            //AvgLifetimeMiles.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[29]"));
            Assert.IsTrue(Mileage.Displayed);
            Assert.IsTrue(Mileage.Enabled);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var Status = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[30]"));
            Assert.IsTrue(Status.Displayed);
            Assert.IsTrue(Status.Enabled);
            Assert.AreEqual(Status.Text, "Status");
            Assert.AreEqual(Status.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Status.GetAttribute("aria-label"), "Status: activate to sort column ascending");
            //Status.Click();

            var Notes = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[31]"));
            Assert.IsTrue(Notes.Displayed);
            Assert.IsTrue(Notes.Enabled);
            Assert.AreEqual(Notes.Text, "Notes");
            Assert.AreEqual(Notes.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Notes.GetAttribute("aria-label"), "Notes: activate to sort column ascending");
            //Notes.Click();

            var TransitMode = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[32]"));
            Assert.IsTrue(TransitMode.Displayed);
            Assert.IsTrue(TransitMode.Enabled);
            Assert.AreEqual(TransitMode.Text, "Transit Mode");
            Assert.AreEqual(TransitMode.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(TransitMode.GetAttribute("aria-label"), "Transit Mode: activate to sort column ascending");
            //TransitMode.Click();

            var SecondTransitMode = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[33]"));
            Assert.IsTrue(SecondTransitMode.Displayed);
            Assert.IsTrue(SecondTransitMode.Enabled);
            Assert.AreEqual(SecondTransitMode.Text, "Second Transit Mode");
            Assert.AreEqual(SecondTransitMode.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(SecondTransitMode.GetAttribute("aria-label"), "Second Transit Mode: activate to sort column ascending");
            //SecondTransitMode.Click();

            var NTDTypeService = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[34]"));
            Assert.IsTrue(NTDTypeService.Displayed);
            Assert.IsTrue(NTDTypeService.Enabled);
            Assert.AreEqual(NTDTypeService.Text, "NTD Type Service");
            Assert.AreEqual(NTDTypeService.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(NTDTypeService.GetAttribute("aria-label"), "NTD Type Service: activate to sort column ascending");
            //NTDTypeService.Click();
        }

        [Test]
        public void A30Page_PaginateTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var previousBtn = driver.FindElement(By.Id("a30Details_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a30Details_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void A30Page_ExportBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void A30Page_SideLeftMinimizeToggle()
        {
            // to open A30 page
            A30Page_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
