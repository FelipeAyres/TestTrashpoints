using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TrashPoints.Test.Commom;

namespace TrashPoints.Test.TestCases
{
    [TestFixture]
    public class CompanyTest : BaseTest
    {
        [Test]
        public void CadastrarEmpresaColeta()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/Trashpoints/Company/Create");

            #region Get WebElements
            IWebElement companyName = Driver.FindElement(By.Id("companyName"));
            IWebElement tradingName = Driver.FindElement(By.Id("tradingName"));
            IWebElement identificationNumber = Driver.FindElement(By.Id("identificationNumber"));
            IWebElement segment = Driver.FindElement(By.Id("segment"));
            IWebElement recyclingCompanyLabel = Driver.FindElement(By.CssSelector("label[for=recyclingCompany]"));

            IWebElement phone = Driver.FindElement(By.Id("phone"));
            IWebElement site = Driver.FindElement(By.Id("site"));

            IWebElement userName = Driver.FindElement(By.Name("j_username"));
            IWebElement password = Driver.FindElement(By.Name("j_password"));

            IWebElement zipCode = Driver.FindElement(By.Id("zipCode"));
            IWebElement number = Driver.FindElement(By.Id("number"));
            IWebElement submit = Driver.FindElement(By.CssSelector("button[type=submit]"));
            #endregion

            companyName.SendKeys("Empresa de coleta");
            tradingName.SendKeys("Empresa de coleta LTDA");
            identificationNumber.Click();
            identificationNumber.SendKeys("25554892000102");
            segment.SendKeys("Coleta seletiva");
            recyclingCompanyLabel.Click();
            phone.Click();
            phone.SendKeys("1231335678");
            site.SendKeys("http://www.coleta.com.br");

            userName.SendKeys(Login.GerarEmailUsuario());
            password.SendKeys("123456");

            zipCode.Click();
            zipCode.SendKeys("12602010");
            number.SendKeys("457");

            Thread.Sleep(TimeSpan.FromSeconds(8));
            submit.Submit();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.UrlContains("http://localhost:8080/Trashpoints/userManager/login"));
            Assert.AreEqual("http://localhost:8080/Trashpoints/userManager/login", Driver.Url);
        }

    }
}
