using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TrashPoints.Test.Commom;

namespace TrashPoints.Test.TestCases
{
    [TestFixture]
    public class CollaboratorTest : BaseTest
    {
        [Test]
        public void CadastrarColaborador()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/Trashpoints/Collaborator/Create");

            IWebElement name = Driver.FindElement(By.Id("name"));
            IWebElement dateOfBirth = Driver.FindElement(By.Name("dateOfBirth"));
            IWebElement userName = Driver.FindElement(By.Name("j_username"));
            IWebElement password = Driver.FindElement(By.Name("j_password"));
            IWebElement zipCode = Driver.FindElement(By.Id("zipCode"));
            IWebElement number = Driver.FindElement(By.Id("number"));
            IWebElement submit = Driver.FindElement(By.CssSelector("button[type=submit]"));

            name.SendKeys("João da Silva");
            dateOfBirth.Click();
            IWebElement btnTodayDatePicker = Driver.FindElement(By.CssSelector("button.btn-flat.picker__today"));
            btnTodayDatePicker.Click();
            IWebElement btnCloseDatePicker = Driver.FindElement(By.CssSelector(".btn-flat.picker__close"));
            btnCloseDatePicker.Click();
            IWebElement phone = Driver.FindElement(By.Id("phone"));
            phone.SendKeys("1231335678");
            userName.SendKeys(Login.GerarEmailUsuario());
            password.SendKeys("123456");
            zipCode.Click();
            zipCode.SendKeys("12602010");
            number.SendKeys("457");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("col-map")));
            submit.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.UrlContains("http://localhost:8080/Trashpoints/userManager/login"));
            Assert.AreEqual("http://localhost:8080/Trashpoints/userManager/login", Driver.Url);
        }

        [Test]
        public void CadastrarColeta()
        {
            Login.LogarComoColaborador(Driver);
            Driver.Navigate().GoToUrl("http://localhost:8080/Trashpoints/Collect/Create");

            IWebElement checkBoxMaterialTypes = Driver.FindElement(By.CssSelector("label[for=PLÁSTICO]"));           
            IWebElement submit = Driver.FindElement(By.CssSelector("button[type=submit]"));

            checkBoxMaterialTypes.Click();
            submit.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("iziToast")));
            IWebElement divSucesso = Driver.FindElement(By.ClassName("iziToast-color-green"));
            Assert.NotNull(divSucesso);
        }        

    }
}
