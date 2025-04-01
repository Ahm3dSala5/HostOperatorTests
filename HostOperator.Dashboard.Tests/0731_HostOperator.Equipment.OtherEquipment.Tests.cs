using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorOhterEquipmentTests : IDisposable
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
        public void OtherEquipmentPage_ReportOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
            Assert.IsTrue(reportOption.Displayed);
            Assert.IsTrue(reportOption.Enabled);
            reportOption.Click();
        }

        [Test]
        public void OtherEquipmentPage_EquipmentOptionTest()
        {
            // to click on report option 
            OtherEquipmentPage_ReportOptionTest();

            var EquipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            Assert.AreEqual(EquipmentOption.Text, "Equipment");
            Assert.AreEqual(EquipmentOption.GetAttribute("custom-data"), "Equipment");
            var currentUrl = driver.Url;
            Assert.AreEqual(EquipmentOption.GetAttribute("href"),$"{currentUrl}#");
            Assert.IsTrue(EquipmentOption.Displayed);
            Assert.IsTrue(EquipmentOption.Enabled);
            EquipmentOption.Click();
        }

        [Test]
        public void OtherEquipemtnPage_OtherEquipmentOptionTest()
        {
            // to click on report option 
            OtherEquipmentPage_ReportOptionTest();
            // to click on equipment option
            var equipmentOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var otherEquipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a"));
            Assert.AreEqual(otherEquipmentOption.Text, "Other Equipment");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("custom-data"), "Other Equipment");
            var OtherEquipmentUrl = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/OtherEquipmentDetails";
            Assert.AreEqual(otherEquipmentOption.GetAttribute("href"), $"{OtherEquipmentUrl}");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("target"), "_self");
            Assert.IsTrue(otherEquipmentOption.Displayed);
            Assert.IsTrue(otherEquipmentOption.Enabled);
            otherEquipmentOption.Click();
        }

        // to open page
        [Test]
        public void OtherEquipmentPage_OpenOtherEquipmentPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var otherEquiomentOption = driver.FindElement
            (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a"));
            otherEquiomentOption.Click();
        }

        [Test]
        public void OtherEquipmentPage_HiHostOperatorTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

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
        public void OtherEquipmentPage_LogoutBtn()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

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
        public void OtherEquipmentPage_NotificationTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        // this button must be named as Dashboard no Reports
        [Test]
        public void OtherEquipmentPage_ReportBtnTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

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

        [Test]
        public void OtherEquipmentPage_PageTitleTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Other Equipment Details");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        // must be enabled and when click must open same page
        [Test]
        public void OtherEquipmentPage_EquipmentBtnTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var equipmentBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.AreEqual(equipmentBtn.Text,"Equipment");
            Assert.IsTrue(equipmentBtn.Displayed);
            Assert.IsTrue(equipmentBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            equipmentBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void OtherEquimentPage_OtherEquimentBtnTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var otherEquipmentBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.AreEqual(otherEquipmentBtn.Text, "Other Equipment Details");
            Assert.IsTrue(otherEquipmentBtn.Displayed);
            Assert.IsTrue(otherEquipmentBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            otherEquipmentBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void OtherEquipemtPage_AssetClassDropdownlistTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

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
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Other Equipment");
        }

        [Test]
        public void OtherEquipmentPage_AssetTypeDropdownlistTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var assetTypeLabel
                = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.Text, "Equipment - Other");
        }

        [Test]
        public void OtherEquipmentPage_DataTableLengthTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("otherEquipmentDetails_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void OtherEquipmentPage_DataTableFilterTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("otherEquipmentDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"otherEquipmentDetails_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void OtherEquipemtPage_ReOrderTableTest()
        {
            // to open equipment page
            var reportOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var otherEquiomentOption = driver.FindElement
            (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a"));
            otherEquiomentOption.Click();

            var columns = driver.FindElements(By.Id("otherEquipmentDetails"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Displayed);
            Assert.IsTrue(Year.Enabled);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Equipment = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Equipment.Displayed);
            Assert.IsTrue(Equipment.Enabled);
            Assert.AreEqual(Equipment.Text, "Equipment #");
            Assert.AreEqual(Equipment.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Equipment.GetAttribute("aria-label"), "Equipment #: activate to sort column ascending");
            //Equipment.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Displayed);
            Assert.IsTrue(Make.Enabled);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Displayed);
            Assert.IsTrue(Model.Enabled);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Displayed);
            Assert.IsTrue(Type.Enabled);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(Vin.Displayed);
            Assert.IsTrue(Vin.Enabled);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(Reg.Displayed);
            Assert.IsTrue(Reg.Enabled);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //Reg.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(serviceType.Displayed);
            Assert.IsTrue(serviceType.Enabled);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Grant.Displayed);
            Assert.IsTrue(Grant.Enabled);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(Comments.Displayed);
            Assert.IsTrue(Comments.Enabled);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();

            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.IsTrue(ColorCode3.Enabled);
            Assert.AreEqual(ColorCode3.Text, "Color Code 3");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-label"), "Color Code 3: activate to sort column ascending");
            //ColorCode3.Click();
        }

        [Test]
        public void OtherEquipmentPage_PaginateTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var previousBtn = driver.FindElement(By.Id("otherEquipmentDetails_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("otherEquipmentDetails_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("messageTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Enabled);
                page.Click();
            }
        }

        [Test]
        public void OtherEquipmentPage_ExportBtnTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void OtherEquipmentsPage_SideLeftMinimizeToggle()
        {
            // to open equipment page
            OtherEquipmentPage_OpenOtherEquipmentPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
