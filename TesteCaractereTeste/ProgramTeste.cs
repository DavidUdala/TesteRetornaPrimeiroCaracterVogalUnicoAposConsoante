using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeiraVogalPosConsoanteNaoRepetido;

namespace TesteCaractereTeste
{
    [TestClass]
    public class ProgramTeste
    {

        [TestMethod]
        public void RetornaPrimeiraVogalUnicaPosConsoante()
        {
            Stream input = new Stream("jajejijuj");

            Assert.AreEqual('a', Program.firstChar(input));
        }

        [TestMethod]
        public void RetornaNadaPoisNaoExisteCarcterVogalUnica()
        {
            Stream input = new Stream("AAEEIIOOUUaaeeiioouu");

            Assert.AreEqual(' ', Program.firstChar(input));
        }

        [TestMethod]
        public void RetornaSegundaCaracterVogalUnicaPoisPrimeiraCaracerVogalVemDepoisDeOutraVogal()
        {
            Stream input = new Stream("AAiJE");

            Assert.AreEqual('E', Program.firstChar(input));
        }

        [TestMethod]
        public void DiferenteCaracterMesmaVogal()
        {
            {
                Stream input = new Stream("EEeejAjaIIii");

                Assert.AreEqual('A', Program.firstChar(input));
            }
        }
    }
}
