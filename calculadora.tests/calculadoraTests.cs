using NUnit.Framework; // Usamos o NUnit para escrever testes unitários.
using Calc; // Importamos o namespace da classe que queremos testar.

namespace Calc.Tests
{
    [TestFixture] // Indicamos que esta classe contém testes.
    public class CalculadoraTests
    {
        [Test]
        public void TestSomarDoisNumeros()
        {
            // Preparamos os valores de entrada e chamamos a função somarDoisNumeros.
            int resultado = Calculadora.somarDoisNumeros(5, 7);
            
            // Usamos a asserção Assert.AreEqual para verificar se o resultado é igual ao valor esperado.
            // No caso, esperamos que a soma de 5 e 7 seja igual a 12.
            Assert.AreEqual(12, resultado);
        }

        [Test]
        public void TestSubtrairDoisNumeros()
        {
            // Preparamos os valores de entrada e chamamos a função subtrairDoisNumeros.
            int resultado = Calculadora.subtrairDoisNumeros(7, 5);
            
            // Usamos a asserção Assert.AreEqual para verificar se o resultado é igual ao valor esperado.
            // No caso, esperamos que a subtração de 7 por 5 seja igual a 2.
            Assert.AreEqual(2, resultado);
        }

        [Test]
        public void TestMultiplicarDoisNumeros()
        {
            // Preparamos os valores de entrada e chamamos a função multiplicarDoisNumeros.
            int resultado = Calculadora.multiplicarDoisNumeros(5, 7);
            
            // Usamos a asserção Assert.AreEqual para verificar se o resultado é igual ao valor esperado.
            // No caso, esperamos que a multiplicação de 5 por 7 seja igual a 35.
            Assert.AreEqual(35, resultado);
        }

        [Test]
        public void TestDividirDoisNumeros()
        {
            // Preparamos os valores de entrada e chamamos a função dividirDoisNumeros.
            double resultado = Calculadora.dividirDoisNumeros(10, 2);
            
            // Usamos a asserção Assert.AreEqual para verificar se o resultado é igual ao valor esperado.
            // No caso, esperamos que a divisão de 10 por 2 seja igual a 5.0.
            Assert.AreEqual(5.0, resultado);
        }
    }
}
