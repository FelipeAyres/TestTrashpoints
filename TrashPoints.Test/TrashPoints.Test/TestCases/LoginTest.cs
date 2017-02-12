using NUnit.Framework;
using TrashPoints.Test.Commom;

namespace TrashPoints.Test.TestCases
{
    [TestFixture]
    public class LoginTest : BaseTest
    {

        [Test]
        public void TesteLogarComoEmpresaColeta()
        {            
            Login.LogarComoEmpresaColeta(Driver);

            Assert.AreEqual("http://localhost:8080/Trashpoints/", Driver.Url);
        }

        [Test]
        public void TesteLogarComoColaborador()
        {
            Login.LogarComoColaborador(Driver);

            Assert.AreEqual("http://localhost:8080/Trashpoints/", Driver.Url);
        }

    }
}
