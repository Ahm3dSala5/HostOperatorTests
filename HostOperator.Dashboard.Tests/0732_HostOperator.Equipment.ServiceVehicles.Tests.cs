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
        public void ServiceVehiclesPage_TestReportOption()
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
            Assert.AreEqual(URLBeforeClick,$"{URLAfterClick}");
        }

        [Test]
        public void ServiceVehiclesPage_TestEquipmentOption()
        {
            // to click on report option 
            ServiceVehiclesPage_TestReportOption();

            var EquipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            Assert.AreEqual(EquipmentOption.Text, "Equipment");
            Assert.AreEqual(EquipmentOption.GetAttribute("custom-data"), "Equipment");
            var currentUrl = driver.Url;
            Assert.AreEqual(EquipmentOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(EquipmentOption.Displayed);
            Assert.IsTrue(EquipmentOption.Enabled);
            EquipmentOption.Click();
        }

        [Test]
        public void ServiceVehiclesPage_TestServiceVehiclesOption()
        {
            // to click on report option 
            ServiceVehiclesPage_TestReportOption();
            // to click on equipment option
            var equipmentOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var serviceVehiclesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[2]/a"));
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("custom-data"), "Service Vehicles");
            var serviceVehiclesPage = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/ServiceVehiclesDetails";
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("href"), $"{serviceVehiclesPage}");
            Assert.AreEqual(serviceVehiclesOption.GetAttribute("target"), "_self");
            Assert.IsTrue(serviceVehiclesOption.Enabled);
            serviceVehiclesOption.Click();
        }

        // to open page
        [Test]
        public void ServiceVehiclesPage_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var serviceVehiclesOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[2]/a"));
            serviceVehiclesOption.Click();
        }

        [Test]
        public void ServicesVehiclesPage_HiHostOperatorTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

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
        public void ServiceVehiclesPage_LogoutBtn()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

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
        public void ServiceVehiclesPage_NotificationTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

      
        [Test]
        public void ServiceVehivlePage_TestPageTitle()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Service Vehicles Details");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        // this button must be named as Dashboard no Reports
        [Test]
        public void ServiceVehiclesPage_ReportsBtnTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var reportsBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(reportsBtn.Text, "Reports");
            Assert.IsTrue(reportsBtn.Displayed);
            Assert.IsTrue(reportsBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            reportsBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        // must be enabled and when click must open same page
        [Test]
        public void ServiceVehiclesPage_EquipmentBtnTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var equipmentBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.AreEqual(equipmentBtn.Text, "Equipment");
            Assert.IsTrue(equipmentBtn.Displayed);
            Assert.IsTrue(equipmentBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            equipmentBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void ServiceVehiclesPage_ServiceVehiclesBtnTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var serviceVehiclesDetails = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.AreEqual(serviceVehiclesDetails.Text, "Service Vehicles Details");
            Assert.IsTrue(serviceVehiclesDetails.Displayed);
            Assert.IsTrue(serviceVehiclesDetails.Enabled);
            var UrlBeforeClick = driver.Url;
            serviceVehiclesDetails.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void OtherEquipemtPage_AssetClassDropdownlistTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

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
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Service Vehicles");
        }

        [Test]
        public void OtherEquipmentPage_AssetTypeDropdownlistTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeValue = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);

            var selectedAssetType = new SelectElement(assetTypeValue);
            selectedAssetType.SelectByIndex(0);
        }

        [Test]
        public void ServiceVehiclesPage_DataTableLengthTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("serviceVehiclesDetails_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void ServiceVehcilesPage_DataTableFilterTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("serviceVehiclesDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"serviceVehiclesDetails_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void ServiceVehiclesPage_ReOrderTableTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var columns = driver.FindElements(By.Id("serviceVehiclesDetails"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Displayed);
            Assert.IsTrue(Year.Enabled);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Veh = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Veh.Displayed);
            Assert.IsTrue(Veh.Enabled);
            Assert.AreEqual(Veh.Text, "Veh #");
            Assert.AreEqual(Veh.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Veh.GetAttribute("aria-label"), "Veh #: activate to sort column ascending");
            //Veh.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Displayed);
            Assert.IsTrue(Make.Enabled);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Displayed);
            Assert.IsTrue(Model.Enabled);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Displayed);
            Assert.IsTrue(Type.Enabled);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var SeatsWC = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(SeatsWC.Displayed);
            Assert.IsTrue(SeatsWC.Enabled);
            Assert.AreEqual(SeatsWC.Text, "#Seats/WC");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-label"), "#Seats/WC: activate to sort column ascending");
            //SeatsWC.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(Mileage.Displayed);
            Assert.IsTrue(Mileage.Enabled);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var DateMileageRecorded = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(DateMileageRecorded.Displayed);
            Assert.IsTrue(DateMileageRecorded.Enabled);
            Assert.AreEqual(DateMileageRecorded.Text, "Date Mileage Recorded");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-label"), "Date Mileage Recorded: activate to sort column ascending");
            //DateMileageRecorded.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Vin.Displayed);
            Assert.IsTrue(Vin.Enabled);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(Reg.Displayed);
            Assert.IsTrue(Reg.Enabled);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //ServiceType.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(serviceType.Displayed);
            Assert.IsTrue(serviceType.Enabled);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(Grant.Displayed);
            Assert.IsTrue(Grant.Enabled);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(Comments.Displayed);
            Assert.IsTrue(Comments.Enabled);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[21]"));
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();

            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[22]"));
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"serviceVehiclesDetails\"]/thead/tr/th[23]"));
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.IsTrue(ColorCode3.Enabled);
            Assert.AreEqual(ColorCode3.Text, "Color Code 3");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-controls"), "serviceVehiclesDetails");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-label"), "Color Code 3: activate to sort column ascending");
            //ColorCode3.Click();
            ;
        }

        [Test]
        public void ServiceVehiclesPage_PaginateTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("serviceVehiclesDetails_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("serviceVehiclesDetails_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void ServiceVehiclesPage_ExportBtnTest()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void ServiceVehiclesPage_SideLeftMinimizeToggle()
        {
            // to open Service Vehicle Page
            ServiceVehiclesPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
