using System.Data;
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
        public void A30Page_ReportsOptionTest()
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
        public void A30Page_NTDOptionTest()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            Assert.IsTrue(NTDOption.Enabled);
            Assert.IsTrue(NTDOption.Displayed);
            Assert.AreEqual(NTDOption.Text, "NTD");
            Assert.AreEqual(NTDOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(NTDOption.GetAttribute("custom-data"), "NTD");
            Assert.AreEqual(NTDOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(NTDOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var NTDOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/i[1]"));
            Assert.IsTrue(NTDOptionIcon.Enabled);
            Assert.IsTrue(NTDOptionIcon.Displayed);
            Assert.AreEqual(NTDOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var NTDOptionArrwo = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/i[2]"));
            Assert.IsTrue(NTDOptionArrwo.Enabled);
            Assert.IsTrue(NTDOptionArrwo.Displayed);
            Assert.AreEqual(NTDOptionArrwo.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var NTDOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(NTDOptionText.Enabled);
            Assert.IsTrue(NTDOptionText.Displayed);
            Assert.AreEqual(NTDOptionText.Text, "NTD");
            Assert.AreEqual(NTDOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void A30Page_A30OptionTest()
        {
            var reportOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var a30Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a"));
            Assert.IsTrue(a30Option.Enabled);
            Assert.IsTrue(a30Option.Displayed);
            Assert.AreEqual(a30Option.Text,"A-30");
            Assert.AreEqual(a30Option.GetAttribute("target"),"_self");
            Assert.AreEqual(a30Option.GetAttribute("role"), "menuitem");
            Assert.AreEqual(a30Option.GetAttribute("custom-data"),"A-30");
            Assert.AreEqual(a30Option.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(a30Option.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A30Details");

            var a30OptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(a30Option.Enabled);
            Assert.IsTrue(a30Option.Displayed);
            Assert.AreEqual(a30OptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var a30OptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(a30OptionIcon.Enabled);
            Assert.IsTrue(a30OptionIcon.Displayed);
            Assert.AreEqual(a30OptionText.Text,"A-30");
            Assert.AreEqual(a30OptionText.GetAttribute("class"),"title");
        }

        // to open page
        [Test]
        public void A30Page_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A30Details");
        }

        [Test]
        public void A30Pag_TopUserNameTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30Pag_LogoutBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30Pag_NotificationIconTest()
        {
            // to open A30 page
            A30Page_OpenPage();

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
        public void A30Pag_SubHeaderTitleTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "A-30");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void A30Page_ReportNavigationLinkTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var reportNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportNavLink.Enabled);
            Assert.IsTrue(reportNavLink.Displayed);
            Assert.AreEqual(reportNavLink.Text, "Reports");
            Assert.AreEqual(reportNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(reportNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        // must be enabled and when click must open same page
        [Test]
        public void A30Page_NTDNavigationLinkTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var NTDNavLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(NTDNavLink.Enabled);
            Assert.IsTrue(NTDNavLink.Displayed);
            Assert.AreEqual(NTDNavLink.Text, "NTD");
            Assert.AreEqual(NTDNavLink.GetAttribute("class"), "m-nav__link");
        }

        // this button also must opne same page
        [Test]
        public void A30Page_A30NavigationLinkTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var A30NavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(A30NavLink.Enabled);
            Assert.IsTrue(A30NavLink.Displayed);
            Assert.AreEqual(A30NavLink.Text, "A-30");
            Assert.AreEqual(A30NavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void A30Page_DataTableLengthTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a30Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a30Details_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "a30Details");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void A30Page_DataTableFilterTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a30Details_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a30Details_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "a30Details");
        }

        [Test]
        public void A30Page_AssetClassDropdownListTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"), "form-label");

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
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"), "form-label");

            var assetSubClassValue = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.GetAttribute("class"), "form-control");

            var selectedAssetSubClass = new SelectElement(assetSubClassValue);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Subclass");
        }

        // asset type label linked with asset sub class
        // but it must linked with asset type
        [Test]
        public void A30Page_AssetTypeDropdownlistTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeValue = driver.FindElement
            (By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.GetAttribute("class"), "form-control");

            var selectedAssetSubClass = new SelectElement(assetTypeValue);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Type");
        }

        [Test]
        public void A30Page_A30TableTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var table = driver.FindElement(By.Id("a30Details"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "a30Details_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in  columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var NTDId = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[2]"));
            Assert.IsTrue(NTDId.Enabled);
            Assert.IsTrue(NTDId.Displayed);
            Assert.AreEqual(NTDId.Text, "NTD Id");
            Assert.AreEqual(NTDId.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(NTDId.GetAttribute("aria-label"), "NTD Id: activate to sort column ascending");
            //NTDId.Click();

            var FleetId = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[3]"));
            Assert.IsTrue(FleetId.Enabled);
            Assert.IsTrue(FleetId.Displayed);
            Assert.AreEqual(FleetId.Text, "Fleet Id");
            Assert.AreEqual(FleetId.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FleetId.GetAttribute("aria-label"), "Fleet Id: activate to sort column ascending");
            //FleetId.Click();

            var VehicleType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[4]"));
            Assert.IsTrue(VehicleType.Enabled);
            Assert.IsTrue(VehicleType.Displayed);
            Assert.AreEqual(VehicleType.Text, "Vehicle Type");
            Assert.AreEqual(VehicleType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(VehicleType.GetAttribute("aria-label"), "Vehicle Type: activate to sort column ascending");
            //VehicleType.Click();

            var ActiveVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[5]"));
            Assert.IsTrue(ActiveVehicle.Enabled);
            Assert.IsTrue(ActiveVehicle.Displayed);
            Assert.AreEqual(ActiveVehicle.Text, "Active Vehicle");
            Assert.AreEqual(ActiveVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(ActiveVehicle.GetAttribute("aria-label"), "Active Vehicle: activate to sort column ascending");
            //ActiveVehicle.Click();

            var DedicatedVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[6]"));
            Assert.IsTrue(DedicatedVehicle.Enabled);
            Assert.IsTrue(DedicatedVehicle.Displayed);
            Assert.AreEqual(DedicatedVehicle.Text, "Dedicated Vehicle");
            Assert.AreEqual(DedicatedVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(DedicatedVehicle.GetAttribute("aria-label"), "Dedicated Vehicle: activate to sort column ascending");
            //DedicatedVehicle.Click();

            var ReplacementResponsibility = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[7]"));
            Assert.IsTrue(ReplacementResponsibility.Enabled);
            Assert.IsTrue(ReplacementResponsibility.Displayed);
            Assert.AreEqual(ReplacementResponsibility.Text, "Replacement Responsibility");
            Assert.AreEqual(ReplacementResponsibility.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(ReplacementResponsibility.GetAttribute("aria-label"), "Replacement Responsibility: activate to sort column ascending");
            //ReplacementResponsibility.Click();

            var AutonomousVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[8]"));
            Assert.IsTrue(AutonomousVehicle.Enabled);
            Assert.IsTrue(AutonomousVehicle.Displayed);
            Assert.AreEqual(AutonomousVehicle.Text, "Autonomous Vehicle");
            Assert.AreEqual(AutonomousVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AutonomousVehicle.GetAttribute("aria-label"), "Autonomous Vehicle: activate to sort column ascending");
            //AutonomousVehicle.Click();

            var Manufacturer = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[9]"));
            Assert.IsTrue(Manufacturer.Enabled);
            Assert.IsTrue(Manufacturer.Displayed);
            Assert.AreEqual(Manufacturer.Text, "Manufacturer");
            Assert.AreEqual(Manufacturer.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Manufacturer.GetAttribute("aria-label"), "Manufacturer: activate to sort column ascending");
            //Manufacturer.Click();

            var OtherManufacturer = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[10]"));
            Assert.IsTrue(OtherManufacturer.Enabled);
            Assert.IsTrue(OtherManufacturer.Displayed);
            Assert.AreEqual(OtherManufacturer.Text, "Other Manufacturer");
            Assert.AreEqual(OtherManufacturer.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherManufacturer.GetAttribute("aria-label"), "Other Manufacturer: activate to sort column ascending");
            //OtherManufacturer.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[11]"));
            Assert.IsTrue(Model.Enabled);
            Assert.IsTrue(Model.Displayed);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var YearManufactured = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[12]"));
            Assert.IsTrue(YearManufactured.Enabled);
            Assert.IsTrue(YearManufactured.Displayed);
            Assert.AreEqual(YearManufactured.Text, "Year Manufactured");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-label"), "Year Manufactured: activate to sort column ascending");
            //YearManufactured.Click();

            var YearRebuilt = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[13]"));
            Assert.IsTrue(YearRebuilt.Enabled);
            Assert.IsTrue(YearRebuilt.Displayed);
            Assert.AreEqual(YearRebuilt.Text, "Year Rebuilt");
            Assert.AreEqual(YearRebuilt.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(YearRebuilt.GetAttribute("aria-label"), "Year Rebuilt: activate to sort column ascending");
            //YearRebuilt.Click();

            var FuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[14]"));
            Assert.IsTrue(FuelType.Enabled);
            Assert.IsTrue(FuelType.Displayed);
            Assert.AreEqual(FuelType.Text, "Fuel Type");
            Assert.AreEqual(FuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FuelType.GetAttribute("aria-label"), "Fuel Type: activate to sort column ascending");
            //FuelType.Click();

            var OtherFuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[15]"));
            Assert.IsTrue(OtherFuelType.Enabled);
            Assert.IsTrue(OtherFuelType.Displayed);
            Assert.AreEqual(OtherFuelType.Text, "Other Fuel Type");
            Assert.AreEqual(OtherFuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherFuelType.GetAttribute("aria-label"), "Other Fuel Type: activate to sort column ascending");
            //OtherFuelType.Click();

            var DuelFuelType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[16]"));
            Assert.IsTrue(DuelFuelType.Enabled);
            Assert.IsTrue(DuelFuelType.Displayed);
            Assert.AreEqual(DuelFuelType.Text, "Duel Fuel Type");
            Assert.AreEqual(DuelFuelType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(DuelFuelType.GetAttribute("aria-label"), "Duel Fuel Type: activate to sort column ascending");
            //DuelFuelType.Click();

            var VehicleLength = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[17]"));
            Assert.IsTrue(VehicleLength.Enabled);
            Assert.IsTrue(VehicleLength.Displayed);
            Assert.AreEqual(VehicleLength.Text, "Vehicle Length");
            Assert.AreEqual(VehicleLength.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(VehicleLength.GetAttribute("aria-label"), "Vehicle Length: activate to sort column ascending");
            //VehicleLength.Click();

            var SeatingCapacity = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[18]"));
            Assert.IsTrue(SeatingCapacity.Enabled);
            Assert.IsTrue(SeatingCapacity.Displayed);
            Assert.AreEqual(SeatingCapacity.Text, "Seating Capacity");
            Assert.AreEqual(SeatingCapacity.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(SeatingCapacity.GetAttribute("aria-label"), "Seating Capacity: activate to sort column ascending");
            //SeatingCapacity.Click();

            var StandingCapacity = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[19]"));
            Assert.IsTrue(StandingCapacity.Enabled);
            Assert.IsTrue(StandingCapacity.Displayed);
            Assert.AreEqual(StandingCapacity.Text, "Standing Capacity");
            Assert.AreEqual(StandingCapacity.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(StandingCapacity.GetAttribute("aria-label"), "Standing Capacity: activate to sort column ascending");
            //StandingCapacity.Click();

            var OwnershipType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[20]"));
            Assert.IsTrue(OwnershipType.Enabled);
            Assert.IsTrue(OwnershipType.Displayed);
            Assert.AreEqual(OwnershipType.Text, "Ownership Type");
            Assert.AreEqual(OwnershipType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OwnershipType.GetAttribute("aria-label"), "Ownership Type: activate to sort column ascending");
            //OwnershipType.Click();

            var OtherOwnershipType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[21]"));
            Assert.IsTrue(OtherOwnershipType.Enabled);
            Assert.IsTrue(OtherOwnershipType.Displayed);
            Assert.AreEqual(OtherOwnershipType.Text, "Other Ownership Type");
            Assert.AreEqual(OtherOwnershipType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(OtherOwnershipType.GetAttribute("aria-label"), "Other Ownership Type: activate to sort column ascending");
            //OtherOwnershipType.Click();

            var FundingType = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[22]"));
            Assert.IsTrue(FundingType.Enabled);
            Assert.IsTrue(FundingType.Displayed);
            Assert.AreEqual(FundingType.Text, "Funding Type");
            Assert.AreEqual(FundingType.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(FundingType.GetAttribute("aria-label"), "Funding Type: activate to sort column ascending");
            //FundingType.Click();

            var AccessibleVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[23]"));
            Assert.IsTrue(AccessibleVehicle.Enabled);
            Assert.IsTrue(AccessibleVehicle.Displayed);
            Assert.AreEqual(AccessibleVehicle.Text, "Accessible Vehicle");
            Assert.AreEqual(AccessibleVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AccessibleVehicle.GetAttribute("aria-label"), "Accessible Vehicle: activate to sort column ascending");
            //AccessibleVehicle.Click();

            var EmergencyVehicle = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[24]"));
            Assert.IsTrue(EmergencyVehicle.Enabled);
            Assert.IsTrue(EmergencyVehicle.Displayed);
            Assert.AreEqual(EmergencyVehicle.Text, "Emergency Vehicle");
            Assert.AreEqual(EmergencyVehicle.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(EmergencyVehicle.GetAttribute("aria-label"), "Emergency Vehicle: activate to sort column ascending");
            //EmergencyVehicle.Click();

            var TypeLastRenewel = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[25]"));
            Assert.IsTrue(TypeLastRenewel.Enabled);
            Assert.IsTrue(TypeLastRenewel.Displayed);
            Assert.AreEqual(TypeLastRenewel.Text, "Type Last Renewel");
            Assert.AreEqual(TypeLastRenewel.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(TypeLastRenewel.GetAttribute("aria-label"), "Type Last Renewel: activate to sort column ascending");
            //TypeLastRenewel.Click();

            var UsefulLifeBenchmark = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[26]"));
            Assert.IsTrue(UsefulLifeBenchmark.Enabled);
            Assert.IsTrue(UsefulLifeBenchmark.Displayed);
            Assert.AreEqual(UsefulLifeBenchmark.Text, "Useful Life Benchmark");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-label"), "Useful Life Benchmark: activate to sort column ascending");
            //UsefulLifeBenchmark.Click();

            var UsefulLifeRemaining = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[27]"));
            Assert.IsTrue(UsefulLifeRemaining.Enabled);
            Assert.IsTrue(UsefulLifeRemaining.Displayed);
            Assert.AreEqual(UsefulLifeRemaining.Text, "Useful Life Remaining");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-label"), "Useful Life Remaining: activate to sort column ascending");
            //UsefulLifeRemaining.Click();

            var AvgLifetimeMiles = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[28]"));
            Assert.IsTrue(AvgLifetimeMiles.Enabled);
            Assert.IsTrue(AvgLifetimeMiles.Displayed);
            Assert.AreEqual(AvgLifetimeMiles.Text, "Avg Lifetime Miles");
            Assert.AreEqual(AvgLifetimeMiles.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(AvgLifetimeMiles.GetAttribute("aria-label"), "Avg Lifetime Miles: activate to sort column ascending");
            //AvgLifetimeMiles.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[29]"));
            Assert.IsTrue(Mileage.Enabled);
            Assert.IsTrue(Mileage.Displayed);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var Status = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[30]"));
            Assert.IsTrue(Status.Enabled);
            Assert.IsTrue(Status.Displayed);
            Assert.AreEqual(Status.Text, "Status");
            Assert.AreEqual(Status.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Status.GetAttribute("aria-label"), "Status: activate to sort column ascending");
            //Status.Click();

            var Notes = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[31]"));
            Assert.IsTrue(Notes.Enabled);
            Assert.IsTrue(Notes.Displayed);
            Assert.AreEqual(Notes.Text, "Notes");
            Assert.AreEqual(Notes.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(Notes.GetAttribute("aria-label"), "Notes: activate to sort column ascending");
            //Notes.Click();

            var TransitMode = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[32]"));
            Assert.IsTrue(TransitMode.Enabled);
            Assert.IsTrue(TransitMode.Displayed);
            Assert.AreEqual(TransitMode.Text, "Transit Mode");
            Assert.AreEqual(TransitMode.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(TransitMode.GetAttribute("aria-label"), "Transit Mode: activate to sort column ascending");
            //TransitMode.Click();

            var SecondTransitMode = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[33]"));
            Assert.IsTrue(SecondTransitMode.Enabled);
            Assert.IsTrue(SecondTransitMode.Displayed);
            Assert.AreEqual(SecondTransitMode.Text, "Second Transit Mode");
            Assert.AreEqual(SecondTransitMode.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(SecondTransitMode.GetAttribute("aria-label"), "Second Transit Mode: activate to sort column ascending");
            //SecondTransitMode.Click();

            var NTDTypeService = driver.FindElement(By.XPath("//*[@id=\"a30Details\"]/thead/tr/th[34]"));
            Assert.IsTrue(NTDTypeService.Enabled);
            Assert.IsTrue(NTDTypeService.Displayed);
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
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a30Details_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "a30Details");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void A30Page_ExportBtnTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
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

        [Test]
        public void A30Page_DataTableInfoTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var tableInfo = driver.FindElement(By.Id("a30Details_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void A30Page_CopyRightTest()
        {
            // to open A30 page
            A30Page_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
