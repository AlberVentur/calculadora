using System;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            // Mostrar el menú
            Console.Clear();
            Console.WriteLine("Calculadora");
            Console.WriteLine("1 - Suma");
            Console.WriteLine("2 - Resta");
            Console.WriteLine("3 - Multiplicación");
            Console.WriteLine("4 - División");
            Console.WriteLine("5 - Elevar un número a la potencia");
            Console.WriteLine("6 - Salir");
            Console.Write("Elige una opción: ");
            
            string input = Console.ReadLine();
            int option;
            
            // Validar entrada
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Opción inválida. Por favor, elige un número del 1 al 6.");
                Console.ReadKey();
                continue;
            }

            // Procesar la opción seleccionada
            switch (option)
            {
                case 1: // Suma
                    PerformOperation("suma", (a, b) => a + b);
                    break;
                case 2: // Resta
                    PerformOperation("resta", (a, b) => a - b);
                    break;
                case 3: // Multiplicación
                    PerformOperation("multiplicación", (a, b) => a * b);
                    break;
                case 4: // División
                    PerformOperation("división", (a, b) => b != 0 ? a / b : double.NaN);
                    break;
                case 5: // Elevar a la potencia
                    Console.Write("Ingresa la base: ");
                    double baseNum = GetNumber();
                    Console.Write("Ingresa el exponente: ");
                    double exponent = GetNumber();
                    double result = Math.Pow(baseNum, exponent);
                    Console.WriteLine($"El resultado de {baseNum} elevado a {exponent} es {result}");
                    break;
                case 6: // Salir
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, elige un número del 1 al 6.");
                    break;
            }

            if (option != 6)
            {
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void PerformOperation(string operation, Func<double, double, double> op)
    {
        Console.Write($"Ingresa el primer número para la {operation}: ");
        double num1 = GetNumber();
        Console.Write($"Ingresa el segundo número para la {operation}: ");
        double num2 = GetNumber();
        
        double result = op(num1, num2);

        if (double.IsNaN(result))
        {
            Console.WriteLine("Error: División por cero.");
        }
        else
        {
            Console.WriteLine($"El resultado de la {operation} es {result}");
        }
    }

    static double GetNumber()
    {
        double number;
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Entrada inválida. Por favor, ingresa un número: ");
        }
        return number;
    }
}
