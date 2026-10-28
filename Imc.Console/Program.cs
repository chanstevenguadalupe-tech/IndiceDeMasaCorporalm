using Imc.Models;

Console.WriteLine("Aplicación que calcula el indice de masa corporal de una persona");
Console.WriteLine();


decimal peso = ReadDecimal("Proporcione el peso en kilogramos de la persona :");
decimal estatura = ReadDecimal("Proporcione la altura en metros de la persona :");

decimal imc = CalculadoraImc.IndiceDeMasaCorporal(peso, estatura);
var estadoNutricional = CalculadoraImc.EstadoNutricional(imc);
string entrada;
bool entradaEsValida;

    Console.WriteLine($"El indice de masa corporal de la persona es: {imc:F4}");
    Console.WriteLine($"El estado nutricional es: {estadoNutricional}");

static decimal ReadDecimal(string indication)
{
    string entrada;
    bool entradaEsValida;
    decimal valor;
    do
    {
        Console.WriteLine(indication);
        entrada = Console.ReadLine();
        entradaEsValida = decimal.TryParse(entrada, out valor);
        if (!entradaEsValida)
        {
            Console.WriteLine("Error: La entrada debe de ser numérica");

        }

    } while (!entradaEsValida);
    return valor;
}

