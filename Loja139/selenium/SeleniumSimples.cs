using System;

using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
//  1- NameSpace ~ Pacote ~ Grupo de classes ~ WorkSpace
namespace SeleniumSimples;

// 2- Bibliotecas ~ Dependências
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.IO;

// 3- Classe

public class AdiconarProdutoNoCarrinhoTest{

    // 3.1- Atributos ~ Características ~ Campos
    private IWebDriver driver; // Objeto do Selenium WebDriver
    /* private object builder; */



    // 3.2- Função ou Método de Apoio

    public static IEnumerable<TestCaseData> lerDadosDeTeste(){
        using (var reader = new StreamReader(@"C:\Users\Usuario\Documents\QA-Trilha\Iterasys\Loja139\data\login.csv")){
            reader.ReadLine(); // vai ler a linha só que não fazer nada, como se estivesse pulando linha. que é o objetivo agr no caso, pular a primeira linha.
            while (!reader.EndOfStream)
            {
                var linha = reader.ReadLine();
                var valores = linha.Split(", ");

                yield return new TestCaseData(valores[0], valores[1], valores[2]);
            }
        };
        {
            
        }

    }

    // 3.3- Configutações Antes do Teste
    [SetUp] // Configura um método para ser executado antes dos testes
    public void Before(){
        
        new DriverManager().SetUpDriver(new ChromeConfig()); // Faz o download e instalação da versão mais recente do ChromeDriver
        driver = new ChromeDriver();  // Instancia o objeto do selenium no chrome
        driver.Manage().Window.Maximize(); // Maximiza a janela do navegador
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);  //Configura um tempo se espera
        

    } // Fim do Before
    
    // 3.4- Configutações depois do Teste
    [TearDown] // Configura um método para ser usado depois dos testes
    public void After(){
        driver.Quit(); 


    }

    // 3.5- O(s) Teste(s)
    [Test] // Indica que é o inicio do método de teste
    public void Login(){
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();
        Thread.Sleep(2000);

        Assert.AreEqual(driver.FindElement(By.CssSelector("span.title")).Text, "Products");
/* 
        Thread.Sleep(2000);
        driver.Navigate().GoToUrl("https://www.google.com/");
        string texto = "Patrick Batista Leandro";

        foreach (char letra in texto)
        {
            driver.FindElement(By.Id("APjFqb")).SendKeys(letra.ToString());
            Thread.Sleep(200); // Aguarde 0.2 segundos entre as letras.
        }
        //driver.FindElement(By.Id("APjFqb")).SendKeys("Patrick Batista Leandro");
        Thread.Sleep(1500);
        driver.FindElement(By.Id("APjFqb")).SendKeys(Keys.Enter); // Apertar a tecla enter

        Thread.Sleep(1800); */
    }

    [Test, TestCaseSource("lerDadosDeTeste")]
    // Indica que é o inicio do método de teste
    public void LoginPositivoDDT(String username, String password, String resultadoEsperado){
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.FindElement(By.Id("user-name")).SendKeys(username);
        driver.FindElement(By.Id("password")).SendKeys(password);
        driver.FindElement(By.Id("login-button")).Click();
        Thread.Sleep(2000);

        Assert.AreEqual(driver.FindElement(By.CssSelector("span.title")).Text, resultadoEsperado);

    }

} // Fim da classes 
