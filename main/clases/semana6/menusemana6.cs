public class semana6
{
    public static void menu6()
    {
        Titulo.encabezado();
        while (true)
        {
            Console.WriteLine("\nSeleccione un ejercicio para la Semana 6:");
            Console.WriteLine("1. Ejercicio 1 registro de Vehiculos");
            Console.WriteLine("2. Ejercicio 2");
            Console.WriteLine("0. Volver al menú principal");

            Console.Write("Ingrese su opción: ");
            string input = Console.ReadLine();
            int seleccionEjercicio;

            if (int.TryParse(input, out seleccionEjercicio))
            {
                switch (seleccionEjercicio)
                {
                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        return;  // Vuelve al menú principal

                    case 1:
                        Console.WriteLine("Has seleccionado el Ejercicio 1");
                        registroVehiculos.registro();  // Llamada al método del Ejercicio 7
                        break;

                    case 2:
                        Console.WriteLine("Has seleccionado el Ejercicio 2");
                        Nodos.nodos();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número entre 0 y 8.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    
}