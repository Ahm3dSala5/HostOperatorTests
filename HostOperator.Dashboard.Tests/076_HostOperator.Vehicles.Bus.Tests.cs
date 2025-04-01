using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
        public void BusPage_TestReportOption()
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
        public void BusPage_TesVehiclesOption()
        {
            // to click on report option 
            BusPage_TestReportOption();

            var VehicleOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a"));
            Assert.AreEqual(VehicleOption.GetAttribute("custom-data"), "Vehicle");
            var currentUrl = driver.Url;
            Assert.AreEqual(VehicleOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(VehicleOption.Enabled);
            VehicleOption.Click();
        }

        [Test]
        public void BusPage_TestBusBtn()
        {
            // to click on report option 
            BusPage_TestReportOption();
            // to click on Vehicles option
            var VehicleOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a"));
            VehicleOption.Click();

            var BusOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            Assert.AreEqual(BusOption.GetAttribute("custom-data"), "Bus");
            var BusURl = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/BusDetails";
            Assert.AreEqual(BusOption.GetAttribute("href"), $"{BusURl}");
            Assert.AreEqual(BusOption.GetAttribute("target"), "_self");
            Assert.IsTrue(BusOption.Enabled);
            BusOption.Click();
        }


        // to open page
        [Test]
        public void BusPage_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var VehicleOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a"));
            VehicleOption.Click();

            var BusOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            BusOption.Click();
        }

        [Test]
        public void BusPage_TableBarTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_LogoutBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_NotificationTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void BusPage_TestPageTitle()
        {
            // to open Bus page
            BusPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Bus Details");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void BusPage_ReportBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_VehiclesBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var NTDBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(NTDBtn.Text, "Vehicle");
            Assert.IsTrue(NTDBtn.Displayed);
            Assert.IsTrue(NTDBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            NTDBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void BusPage_BusDetailsBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var BusDetailsBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a/span"));
            Assert.AreEqual(BusDetailsBtn.Text, "Bus Details");
            Assert.IsTrue(BusDetailsBtn.Displayed);
            Assert.IsTrue(BusDetailsBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            BusDetailsBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void BusPage_DataTableLengthTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"busDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("busDetails_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void BusPage_DataTableFilterTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("busDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"busDetails_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void BusPage_AssetClassParagraphTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_AssetSubClassDropdownlistTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Bus");
        }

        [Test]
        public void BusPage_AssetTypeDropdownlistTest()
        {
            // to open Bus page
            BusPage_OpenPage();

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
        public void BusPage_ReOrderTableTest()
        {
            // to open Bus page
            /////////////////////////////////////
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var VehicleOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/a"));
            VehicleOption.Click();

            var BusOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[6]/nav/ul/li/a"));
            BusOption.Click();
            ///////////////////////////////////

            var columns = driver.FindElements(By.Id("busDetails"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Displayed);
            Assert.IsTrue(Year.Enabled);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Veh = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Veh.Displayed);
            Assert.IsTrue(Veh.Enabled);
            Assert.AreEqual(Veh.Text, "Veh #");
            Assert.AreEqual(Veh.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Veh.GetAttribute("aria-label"), "Veh #: activate to sort column ascending");
            //Veh.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Displayed);
            Assert.IsTrue(Make.Enabled);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Displayed);
            Assert.IsTrue(Model.Enabled);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Displayed);
            Assert.IsTrue(Type.Enabled);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var SeatsWC = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(SeatsWC.Displayed);
            Assert.IsTrue(SeatsWC.Enabled);
            Assert.AreEqual(SeatsWC.Text, "#Seats/WC");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(SeatsWC.GetAttribute("aria-label"), "#Seats/WC: activate to sort column ascending");
            //SeatsWC.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Mileage = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(Mileage.Displayed);
            Assert.IsTrue(Mileage.Enabled);
            Assert.AreEqual(Mileage.Text, "Mileage");
            Assert.AreEqual(Mileage.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Mileage.GetAttribute("aria-label"), "Mileage: activate to sort column ascending");
            //Mileage.Click();

            var DateMileageRecorded = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(DateMileageRecorded.Displayed);
            Assert.IsTrue(DateMileageRecorded.Enabled);
            Assert.AreEqual(DateMileageRecorded.Text, "Date Mileage Recorded");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(DateMileageRecorded.GetAttribute("aria-label"), "Date Mileage Recorded: activate to sort column ascending");
            //DateMileageRecorded.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Vin.Displayed);
            Assert.IsTrue(Vin.Enabled);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(Reg.Displayed);
            Assert.IsTrue(Reg.Enabled);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //ServiceType.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(serviceType.Displayed);
            Assert.IsTrue(serviceType.Enabled);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(Grant.Displayed);
            Assert.IsTrue(Grant.Enabled);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(Comments.Displayed);
            Assert.IsTrue(Comments.Enabled);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[21]"));
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();
            
            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[22]"));
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "busDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"busDetails\"]/thead/tr/th[23]"));
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.IsTrue(ColorCode3.Enabled);
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
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("busDetails_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void BusPage_ExportBtnTest()
        {
            // to open Bus page
            BusPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void BusMessage_SideLeftMinimizeToggle()
        {
            // to open Bus page
            BusPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
