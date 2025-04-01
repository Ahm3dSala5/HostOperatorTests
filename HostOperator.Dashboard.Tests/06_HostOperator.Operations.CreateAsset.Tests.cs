using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorOperationsTests : IDisposable
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
        public void OperationOtion_Test()
        {
            var operationsOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a/span/span"));

            operationsOptions.Click();
            Assert.AreEqual("Operations", operationsOptions.Text);
            Assert.IsTrue(operationsOptions.Enabled);
            Assert.IsTrue(operationsOptions.Displayed);
        }

        [Test]
        public void CreateAssetOption_Test()
        {
            // to click on operations option
            OperationOtion_Test();

            var createAssetOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a"));
            Assert.IsTrue(createAssetOption.Displayed);
            Assert.IsTrue(createAssetOption.Enabled);
            Assert.AreEqual("Create Asset", createAssetOption.Text);
            Assert.AreEqual(createAssetOption.GetAttribute("target"),"_self");
            Assert.AreEqual(createAssetOption.GetAttribute("custom-data"),"Create Asset");
            Assert.AreEqual(createAssetOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Create");   
        }

        [Test]
        public void CreateAssetPage_OpenCreateAssetPage()
        {
            var OperationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a"));
            OperationOption.Click();

            var operationsOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a"));
            operationsOptions.Click();
        }

        [Test]
        public void CreateAssetPage_HiHostOperatorTest()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

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
        public void CreateAssetPage_LogoutBtn()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

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
        public void CreateAssetPage_NotificationTest()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void CreateAssetPage_DashboardBtnTest()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(dashboardBtn.Text, "Dashboard");
            Assert.IsTrue(dashboardBtn.Displayed);
            Assert.IsTrue(dashboardBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            dashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void CreateAssetPage_PageTitleTest()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Create Asset");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void CreateAssetPage_CreateAssetWithValidDataTest()
        {
            // to open create asset page
            CreateAssetPage_OpenCreateAssetPage();

            var assetNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.IsTrue(assetNameLabel.Enabled);
            Assert.IsTrue(assetNameLabel.Displayed);
            Assert.AreEqual(assetNameLabel.Text, "Asset Name");
            assetNameLabel.Click();

            var assetNameValue = driver.FindElement(By.Id("AssetDes"));
            var requiredNameLength = "The field AssetDesc must be a string with a maximum length of 500.";
            Assert.IsTrue(assetNameValue.Displayed);
            Assert.IsTrue(assetNameValue.Enabled);
            assetNameValue.SendKeys("Test Name");
            Assert.AreEqual(requiredNameLength, assetNameValue.GetAttribute("data-val-length"));
            Assert.AreEqual(assetNameValue.GetAttribute("required"),"true");
            Assert.AreEqual(assetNameValue.GetAttribute("maxlength"), "500");

            var assetDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[2]/div/div/div/label"));

            Assert.IsTrue(assetDescriptionLabel.Enabled);
            Assert.IsTrue(assetDescriptionLabel.Displayed);
            Assert.AreEqual(assetDescriptionLabel.Text, "Asset Description");
            //assetDescriptionLabel.Click();

            var assetDescriptionValue = driver.FindElement(By.Id("AssetTypesDesc"));
            var requiredDescriptionLength = "The field AssetNote must be a string with a maximum length of 255.";
            Assert.IsTrue(assetDescriptionValue.Displayed);
            Assert.IsTrue(assetDescriptionValue.Enabled);
            assetDescriptionValue.SendKeys("Test Name");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length"),requiredDescriptionLength);
            //Assert.AreEqual(assetDescriptionValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("maxlength"), "255");

            var assetImageLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[3]/div/div/div[1]/label"));
            Assert.AreEqual(assetImageLabel.Text,"Asset Image");
            Assert.IsTrue(assetImageLabel.Displayed);
            Assert.IsTrue(assetImageLabel.Enabled);

            var assetImageValue = driver.FindElement(By.Id("ImagePath"));
            Assert.IsTrue(assetImageValue.Displayed);
            Assert.IsTrue(assetImageValue.Enabled);
            Assert.AreEqual(assetImageValue.GetAttribute("accept"), "image/*,.pdf");
            Assert.AreEqual(assetImageValue.GetAttribute("type"),"file");

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");

            var assetClassInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");

            var assetSubclassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[5]/div/div/div/label"));
            Assert.IsTrue(assetSubclassLabel.Enabled);
            Assert.IsTrue(assetSubclassLabel.Displayed);
            Assert.AreEqual(assetSubclassLabel.Text, "Asset Subclass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.AreEqual(assetSubClassInput.GetAttribute("required"), "true");

            var assetTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[6]/div/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");

            var assetTypeInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetType = new SelectElement(assetTypeInput);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.AreEqual(assetTypeInput.GetAttribute("required"), "true");
        }

        [Test]
        public void CreateAssetPage_CreateAssetWithAssociatedAttributes()
        {
            // to open create attributes page
            var OperationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a"));
            OperationOption.Click();

            var operationsOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a"));
            operationsOptions.Click();

            var header = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[7]/div[1]/div/div/h3"));
            Assert.IsTrue(header.Displayed);
            Assert.IsTrue(header.Enabled);
            Assert.AreEqual(header.Text, "Please Add Associate Attribute");

            var addBtn = driver.FindElement(By.Id("btnAdd"));
            Assert.IsTrue(addBtn.Displayed);
            Assert.IsTrue(addBtn.Enabled);
            Assert.AreEqual(addBtn.Text,"ADD");
            addBtn.Click();

            var attribute = driver.FindElement(By.Id("selectListItem1"));
            var selectedAttribute = new SelectElement(attribute);
            selectedAttribute.SelectByIndex(0);
            Assert.IsTrue(attribute.Displayed);
            Assert.IsTrue(attribute.Enabled);

            var attributeValeBox = driver.FindElement(By.XPath("//*[@id=\"asstibuteValueBox1\"]"));
            Assert.IsTrue(attributeValeBox.Displayed);
            Assert.IsTrue(attributeValeBox.Enabled);
            attributeValeBox.SendKeys("associated Infirmation");

            var closeAssociatedAttribute = driver.FindElement(By.Id("deleteButton1"));
            Assert.IsTrue(closeAssociatedAttribute.Displayed);  
            Assert.IsTrue(closeAssociatedAttribute.Enabled);
            Assert.AreEqual(closeAssociatedAttribute.GetAttribute("type"),"button");
            Assert.AreEqual(closeAssociatedAttribute.GetAttribute("onclick"), "closeButtonForDelete(1)");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[9]/button[1]"));
            Assert.IsTrue(saveBtn.Displayed);
            Assert.IsTrue(saveBtn.Enabled);
            Assert.AreEqual(saveBtn.Text,"Save");

            var cancelBtn = driver.FindElement(By.Id("cancle"));
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.IsTrue(cancelBtn.Enabled);
        }
    }
}
