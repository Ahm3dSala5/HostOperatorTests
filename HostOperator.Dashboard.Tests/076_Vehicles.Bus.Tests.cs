using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace HostOperator.Tests
{
    public class HostOperatorVehiclesBusTests : IDisposable
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
        public void BusPage_ReportsOptionTest()
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
        public void BusPage_VehicleOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var vehicleOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            Assert.IsTrue(vehicleOption.Enabled);
            Assert.IsTrue(vehicleOption.Displayed);
            Assert.AreEqual(vehicleOption.Text,"Vehicle");
            Assert.AreEqual(vehicleOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(vehicleOption.GetAttribute("custom-data"),"Vehicle");
            Assert.AreEqual(vehicleOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(vehicleOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var vehicleOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a/i[1]"));
            Assert.IsTrue(vehicleOptionIcon.Enabled);
            Assert.IsTrue(vehicleOptionIcon.Displayed);
            Assert.AreEqual(vehicleOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var vehicleOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a/i[2]"));
            Assert.IsTrue(vehicleOptionArrow.Enabled);
            Assert.IsTrue(vehicleOptionArrow.Displayed);
            Assert.AreEqual(vehicleOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var vehicleOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a/span/span"));
            Assert.IsTrue(vehicleOptionText.Enabled);
            Assert.IsTrue(vehicleOptionText.Displayed);
            Assert.AreEqual(vehicleOptionText.Text,"Vehicle");
            Assert.AreEqual(vehicleOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void BusPage_BusOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var vehicleOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            vehicleOption.Click();

            var busOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            Assert.IsTrue(busOption.Enabled);
            Assert.IsTrue(busOption.Displayed);
            Assert.AreEqual(busOption.Text,"Bus");
            Assert.AreEqual(busOption.GetAttribute("target"),"_self");
            Assert.AreEqual(busOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(busOption.GetAttribute("custom-data"),"Bus");
            Assert.AreEqual(busOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            Assert.AreEqual(busOption.GetAttribute("href"), $"http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/BusDetails");

            var busOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a/i"));
            Assert.IsTrue(busOptionIcon.Enabled);
            Assert.IsTrue(busOptionIcon.Displayed);
            Assert.AreEqual(busOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var busOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a/span/span"));
            Assert.IsTrue(busOptionText.Enabled);
            Assert.IsTrue(busOptionText.Displayed);
            Assert.AreEqual(busOptionText.Text,"Bus");
            Assert.AreEqual(busOptionText.GetAttribute("class"),"title");
        }

        // to open page
        [Test]
        public void BusPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/BusDetails");
        }

        [Test]
        public void BusPage_TopUserNameTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPag_LogoutBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_NotificationIconTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_SubHeaderTitleTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Bus Details");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void BusPage_ReportNavigationLinkTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(reportsNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        // must be enabled and when click must open same page
        [Test]
        public void BusPage_VehiclesNavigationLinkTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var NTDNaviLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(NTDNaviLink.Enabled);
            Assert.IsTrue(NTDNaviLink.Displayed);
            Assert.AreEqual(NTDNaviLink.Text, "Vehicle");
            Assert.AreEqual(NTDNaviLink.GetAttribute("class"), "m-nav__link");
        }

        // this button also must opne same page
        [Test]
        public void BusPage_BusDetailsNavigationLinkTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var BusDetailsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(BusDetailsNavLink.Enabled);
            Assert.IsTrue(BusDetailsNavLink.Displayed);
            Assert.AreEqual(BusDetailsNavLink.Text, "Bus Details");
            Assert.AreEqual(BusDetailsNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void BusPage_DataTableLengthTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"busDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("busDetails_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "busDetails");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void BusPage_DataTableFilterTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("busDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"busDetails_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "busDetails");
        }

        [Test]
        public void BusPage_AssetClassDropdownListTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
            Assert.AreEqual(assetClassInput.Text, "Revenue Vehicle");
        }

        [Test]
        public void BusPage_AssetSubClassDropdownListTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
            Assert.AreEqual(assetSubClassValue.Text, "Bus");
        }


        // asset type label linked with asset subclass
        // but it must linked with asset type
        [Test]
        public void BusPage_AssetTypeDropdownlistTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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

            var selectedAssetSubClass = new SelectElement(assetTypeValue);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Select Asset Type");
        }

        [Test]
        public void BusPage_BusTableTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var table = driver.FindElement(By.Id("busDetails"));
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");


            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Enabled);
            Assert.IsTrue(Year.Displayed);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Veh = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Veh.Enabled);
            Assert.IsTrue(Veh.Displayed);
            Assert.AreEqual(Veh.Text, "Veh #");
            Assert.AreEqual(Veh.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Veh.GetAttribute("aria-label"), "Veh #: activate to sort column ascending");
            //Veh.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Enabled);
            Assert.IsTrue(Make.Displayed);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Enabled);
            Assert.IsTrue(Model.Displayed);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Enabled);
            Assert.IsTrue(Type.Displayed);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var SeatsWC = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(SeatsWC.Enabled);
            Assert.IsTrue(SeatsWC.Displayed);
            Assert.AreEqual(SeatsWC.Text, "#Seats/WC");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-label"), "#Seats/WC: activate to sort column ascending");
            //SeatsWC.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(Mileage.Enabled);
            Assert.IsTrue(Mileage.Displayed);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var DateMileageRecorded = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(DateMileageRecorded.Enabled);
            Assert.IsTrue(DateMileageRecorded.Displayed);
            Assert.AreEqual(DateMileageRecorded.Text, "Date Mileage Recorded");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-label"), "Date Mileage Recorded: activate to sort column ascending");
            //DateMileageRecorded.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Vin.Enabled);
            Assert.IsTrue(Vin.Displayed);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(Reg.Enabled);
            Assert.IsTrue(Reg.Displayed);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //ServiceType.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(serviceType.Enabled);
            Assert.IsTrue(serviceType.Displayed);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(Grant.Enabled);
            Assert.IsTrue(Grant.Displayed);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(Comments.Enabled);
            Assert.IsTrue(Comments.Displayed);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[21]"));
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();
            
            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[22]"));
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[23]"));
            Assert.IsTrue(ColorCode3.Enabled);
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.AreEqual(ColorCode3.Text, "Color Code 3");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-label"), "Color Code 3: activate to sort column ascending");
            //ColorCode3.Click();
        }

        [Test]
        public void BusPage_PaginateTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("busDetails_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"),"busDetails");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("busDetails_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void BusPage_ExportBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void BusMessagePage_SideLeftMinimizeToggle()
        {
            // to open Bus page
            BusPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void BusPage_DataTableInfoTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("busDetails_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void BusPage_CopyRightTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
