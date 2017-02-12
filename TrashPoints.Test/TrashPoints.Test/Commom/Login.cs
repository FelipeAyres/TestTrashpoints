using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TrashPoints.Test.Commom
{
    public static class Login
    {
        public static void LogarComoEmpresaColeta(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:8080/Trashpoints/userManager/login");

            IWebElement userName = driver.FindElement(By.Name("j_username"));
            IWebElement password = driver.FindElement(By.Name("j_password"));
            IWebElement submit = driver.FindElement(By.Name("submit"));

            userName.SendKeys("ccoleta@trashpoints.com.br");
            password.SendKeys("coleta");
            submit.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlContains("http://localhost:8080/Trashpoints/"));
        }

        public static void LogarComoColaborador(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:8080/Trashpoints/userManager/login");

            IWebElement userName = driver.FindElement(By.Name("j_username"));
            IWebElement password = driver.FindElement(By.Name("j_password"));
            IWebElement submit = driver.FindElement(By.Name("submit"));

            userName.SendKeys("colaborador@trashpoints.com.br");
            password.SendKeys("colaborador");
            submit.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlContains("http://localhost:8080/Trashpoints/"));            
        }

        public static string GerarEmailUsuario()
        {
            string email = string.Empty;
            string user = Guid.NewGuid().ToString().Substring(0, 13);
            string host = "@gmail.com";

            return email = user + host;
        }

    }
}
