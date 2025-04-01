using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HostOperator.Tests
{
    public class HostOperatorEditViewEquipmentTests : IDisposable
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
        public void EquipmentPage_ViewEditOptionTest()
        {
            var viewEditOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[4]/a"));

            Assert.IsTrue(viewEditOption.Displayed);
            Assert.IsTrue(viewEditOption.Enabled);
            Assert.AreEqual(viewEditOption.Text, "View/Edit");
            Assert.AreEqual(viewEditOption.GetAttribute("custom-data"), "View/Edit");
            viewEditOption.Click();
        }


        // this for go to viewEdits Page
        [Test]
        public void ViewEditsPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/AssetClass");
        }

        [Test]
        public void ViewEditpage_PageTitleTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
            Assert.AreEqual("View/Edit",title.Text);
        }

        [Test]
        public void ViewEditPage_DashboardBtnTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.AreEqual(dashboardBtn.Text,"Dashboard");
            Assert.IsTrue(dashboardBtn.Enabled);
            Assert.IsTrue(dashboardBtn.Displayed);
            var viewEditUrl = driver.Url;
            dashboardBtn.Click();
            var dashboardUrl = driver.Url;
            Assert.AreNotEqual(viewEditUrl,dashboardUrl);
        }

        [Test]
        public void ViewEditPage_DataTableLengthTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"AssetsTable_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("AssetsTable_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void viewEditPage_DataTableFilterTest()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void ViewEditsPage_AssetClassDropdownlist()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[3]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetSubClass = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            var selectedAssetSubClass = new SelectElement(assetSubClass);
            Assert.IsTrue(assetSubClass.Displayed);
            Assert.IsTrue(assetSubClass.Enabled);
        }

        [Test]
        public void ViewEditPage_AssetTypeDrowdownlist()
        {
            // to open view/edit page
            ViewEditsPage_OpenPage();

            var assstTypeLabel = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[3]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.AreEqual(assstTypeLabel.Text, "Asset Subclass");
            Assert.IsTrue(assstTypeLabel.Enabled);
            Assert.IsTrue(assstTypeLabel.Displayed);

            var assetSubClass = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            var selectedAssetSubClass = new SelectElement(assetSubClass);
            Assert.IsTrue(assetSubClass.Displayed);
            Assert.IsTrue(assetSubClass.Enabled);
        }

        [Test]
        public void EditViewPage_CreateBtnTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.AreEqual("Create",createBtn.Text);
            Assert.AreEqual(createBtn.GetAttribute("type"),"button");
            Assert.IsTrue(createBtn.Displayed);
            Assert.IsTrue(createBtn.Enabled);
            createBtn.Click();
        }

        [Test]
        public void EditViewPage_ConfigurationBtnTest()
        {
            // to open Edit/View Page
            ViewEditsPage_OpenPage();

            var configBtn = driver.FindElement(By.Id("configBtn"));
            Assert.AreEqual(configBtn.Text,"Configuration");
            Assert.AreEqual(configBtn.GetAttribute("type"),"submit");
            Assert.IsTrue(configBtn.Displayed);
            Assert.AreEqual(configBtn.GetAttribute("disabled"),"true");
        }

        [Test]
        public void EditViewPage_ReOrderTable()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/AssetClass");

            var columns = driver.FindElements(By.Id("AssetsTable"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
                column.Click();
            }

            var AssetId = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(AssetId.Displayed);
            Assert.IsTrue(AssetId.Enabled);
            Assert.AreEqual(AssetId.Text,"Asset ID");
            AssetId.Click();

            var AssetClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetClass.Displayed);
            Assert.IsTrue(AssetClass.Enabled);
            Assert.AreEqual(AssetClass.Text,"Asset Class");
            AssetClass.Click();

            var AssetSubClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(AssetSubClass.Displayed);
            Assert.IsTrue(AssetSubClass.Enabled);
            Assert.AreEqual(AssetSubClass.Text, "Asset Subclass");
            AssetSubClass.Click();

            var AssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(AssetType.Displayed);
            Assert.IsTrue(AssetType.Enabled);
            Assert.AreEqual(AssetType.Text, "Asset Type");
            AssetType.Click();

            var Operator = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(Operator.Displayed);
            Assert.IsTrue(Operator.Enabled);
            Assert.AreEqual(Operator.Text, "Operator");
            Operator.Click();

            var Asset = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(Operator.Displayed);
            Assert.IsTrue(Operator.Enabled);
            Assert.AreEqual(Operator.Text, "Operator");
            Operator.Click();

            var State = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Displayed);
            Assert.IsTrue(State.Enabled);
            Assert.AreEqual(State.Text, "State");
            State.Click();

            var createTime = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[8]"));
            Assert.IsTrue(createTime.Displayed);
            Assert.IsTrue(createTime.Enabled);
            Assert.AreEqual(createTime.Text, "Created Time");
            createTime.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[9]"));
            Assert.IsTrue(Actions.Displayed);
            Assert.IsTrue(Actions.Enabled);
            Assert.AreEqual(Actions.Text, "Actions");
            Actions.Click();

            var indexs = driver.FindElements(By.Id("index"));
            foreach(var index in indexs)
            {
                Assert.IsTrue(index.Displayed);
                Assert.IsTrue(index.Enabled);
            }
        }

        [Test]
        public void EditViewPage_SideLeftMinimizeToggle()
        {
            // to open Edit/View Page
            EquipmentPage_ViewEditOptionTest();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}
