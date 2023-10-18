/* // See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
 */

// 1- NameSpace = Conjunto de classes
namespace  Calc;


// 2- Bibliotecas = Conjunto de funções prontas


// 3- Classe = Entidade que iremos criar (programa)
public class Calculadora
{

    // 3.1- Atributos = Características / Campos


    // 3.2 Funções e Métodos
    public static int somarDoisNumeros(int num1, int num2)
    {
        
        return num1 + num2;
    }

    public static int subtrairDoisNumeros(int num1, int num2)
    {
        
        return num1 - num2;
    }

    public static int multiplicarDoisNumeros(int num1, int num2)
    {
        
        return num1 * num2;
    }

    public static double dividirDoisNumeros(int num1, int num2)
{
    double resultado = (double)num1 / num2;
    return Math.Round(resultado, 2); // Arredonda o resultado para duas casas decimais
}

    public static void Main()
    {
        
        
        Console.WriteLine("Soma= " + somarDoisNumeros(5,7) + " Subitração= " + subtrairDoisNumeros(5,7) + " Multiplicação= " + multiplicarDoisNumeros(5,7) + " Divisão= " +  dividirDoisNumeros(5,7));

    }

} // fim da classe