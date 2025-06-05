using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorServiceVehiclesTests : IDisposable
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
        public void ServiceVehiclesPage_ReportsOptionTest()
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
        public void ServiceVehiclesPage_EquipmentOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            Assert.IsTrue(equipmentOption.Enabled);
            Assert.IsTrue(equipmentOption.Displayed);
            Assert.AreEqual(equipmentOption.Text, "Equipment");
            Assert.AreEqual(equipmentOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(equipmentOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(equipmentOption.GetAttribute("custom-data"), "Equipment");
            Assert.AreEqual(equipmentOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var equipmentOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[2]"));
            Assert.IsTrue(equipmentOptionArrow.Enabled);
            Assert.IsTrue(equipmentOptionArrow.Displayed);
            Assert.AreEqual(equipmentOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var equipmentOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[1]"));
            Assert.IsTrue(equipmentOptionIcon.Enabled);
            Assert.IsTrue(equipmentOptionIcon.Displayed);
            Assert.AreEqual(equipmentOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var equipmentOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(equipmentOptionText.Enabled);
            Assert.IsTrue(equipmentOptionText.Displayed);
            Assert.AreEqual(equipmentOptionText.Text, "Equipment");
            Assert.AreEqual(equipmentOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void ServicesVehiclesPage_ServiceVehicesOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var serviceVehiclesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[2]/a"));
            Assert.IsTrue(serviceVehiclesOption.Enabled);
            Assert.IsTrue(serviceVehiclesOption.Displayed);
            Assert.AreEqual(serviceVehiclesOption.Text, "Service Vehicles");
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("custom-data"), "Service Vehicles");
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/OtherEquipmentDetails");

            var serviceVehicleOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(serviceVehicleOptionIcon.Enabled);
            Assert.IsTrue(serviceVehicleOptionIcon.Displayed);
            Assert.AreEqual(serviceVehicleOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var serviceVehiclesOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(serviceVehiclesOptionText.Enabled);
            Assert.IsTrue(serviceVehiclesOptionText.Displayed);
            Assert.AreEqual(serviceVehiclesOptionText.Text, "Service Vehicles");
            Assert.AreEqual(serviceVehiclesOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void ServiceVehiclesPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/ServiceVehiclesDetails");
        }

        [Test]
        public void ServicesVehiclesPage_TopUserNameTest()
        {
            // to open report other equipment page
            ServiceVehiclesPage_OpenPage();

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
        public void ServicesVehiclesPage_LogoutBtn()
        {
            // to open report other equipment page
            ServiceVehiclesPage_OpenPage();

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
        public void ServicesVehiclesPage_NotificationIconTest()
        {
            // to open report other equipment page
            ServiceVehiclesPage_OpenPage();

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
        public void ServicesVehiclesPage_SubHeaderTitleTest()
        {
            // to open report other equipment page
            ServiceVehiclesPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Service Vehicles Details");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void ServiceVehiclesPage_ReportsNavigationLinkTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void ServiceVehiclesPage_Seperator1Test()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void ServiceVehiclesPage_EquipmentNavigationLinkTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var equipmentNavLinkTest = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(equipmentNavLinkTest.Enabled);
            Assert.IsTrue(equipmentNavLinkTest.Displayed);
            Assert.AreEqual(equipmentNavLinkTest.Text, "Equipment");
            Assert.AreEqual(equipmentNavLinkTest.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            equipmentNavLinkTest.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void ServiceVehiclesPage_Seperator2Test()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void ServiceVehiclesPage_ServiceVehiclesDetailsNavigationLinkTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var equipmentNavLinkTest = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(equipmentNavLinkTest.Enabled);
            Assert.IsTrue(equipmentNavLinkTest.Displayed);
            Assert.AreEqual(equipmentNavLinkTest.Text, "Service Vehicles Details");
            Assert.AreEqual(equipmentNavLinkTest.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void ServiceVehiclesPage_AssetClassDropdownlistTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

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
            Assert.AreEqual(assetClassInput.Text, "Equipment");
        }

        [Test]
        public void OtherEquipmentPage_AssetSubClassDropdownlistTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

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
            Assert.AreEqual(assetSubClassValue.Text, "Service Vehicles");
        }

        // this pice contains error in asset type label it linked with asset subclass
        // but must be linked with asset type
        [Test]
        public void OtherEquipmentPage_AssetTypeDropdownlistTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeValue = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.GetAttribute("class"),"form-control");

            var selectedAssetType = new SelectElement(assetTypeValue);
            selectedAssetType.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Type");
        }

        [Test]
        public void ServiceVehiclesPage_DataTableLengthTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("serviceVehiclesDetails_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "serviceVehiclesDetails");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void ServiceVehcilesPage_DataTableFilterTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("serviceVehiclesDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"serviceVehiclesDetails_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "serviceVehiclesDetails");
        }

        [Test]
        public void ServiceVehiclesPage_ServiceVehiclesTableTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var table = driver.FindElement(By.Id("serviceVehiclesDetails"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "serviceVehiclesDetails_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Enabled);
            Assert.IsTrue(Year.Displayed);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Veh = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Veh.Enabled);
            Assert.IsTrue(Veh.Displayed);
            Assert.AreEqual(Veh.Text, "Veh #");
            Assert.AreEqual(Veh.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Veh.GetAttribute("aria-label"), "Veh #: activate to sort column ascending");
            //Veh.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Enabled);
            Assert.IsTrue(Make.Displayed);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Enabled);
            Assert.IsTrue(Model.Displayed);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Enabled);
            Assert.IsTrue(Type.Displayed);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var SeatsWC = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(SeatsWC.Enabled);
            Assert.IsTrue(SeatsWC.Displayed);
            Assert.AreEqual(SeatsWC.Text, "#Seats/WC");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-label"), "#Seats/WC: activate to sort column ascending");
            //SeatsWC.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(Mileage.Enabled);
            Assert.IsTrue(Mileage.Displayed);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var DateMileageRecorded = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(DateMileageRecorded.Enabled);
            Assert.IsTrue(DateMileageRecorded.Displayed);
            Assert.AreEqual(DateMileageRecorded.Text, "Date Mileage Recorded");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-label"), "Date Mileage Recorded: activate to sort column ascending");
            //DateMileageRecorded.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Vin.Enabled);
            Assert.IsTrue(Vin.Displayed);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(Reg.Enabled);
            Assert.IsTrue(Reg.Displayed);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //ServiceType.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(serviceType.Enabled);
            Assert.IsTrue(serviceType.Displayed);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(Grant.Enabled);
            Assert.IsTrue(Grant.Displayed);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(Comments.Enabled);
            Assert.IsTrue(Comments.Displayed);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[21]"));
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();

            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[22]"));
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[23]"));
            Assert.IsTrue(ColorCode3.Enabled);
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.AreEqual(ColorCode3.Text, "Color Code 3");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-label"), "Color Code 3: activate to sort column ascending");
            //ColorCode3.Click();
        }

        [Test]
        public void ServiceVehiclesPage_PaginateTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("serviceVehiclesDetails_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("serviceVehiclesDetails_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            nextBtn.Click();
        }

        [Test]
        public void ServiceVehiclesPage_ExportBtnTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void ServiceVehiclesPage_SideLeftMinimizeToggle()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void ServiceVehiclesPage_DataTableInfoTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("serviceVehiclesDetails_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.IsTrue(tableInfo.Text.Contains("Showing")  && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void ServiceVehiclesPage_CopyRightTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
