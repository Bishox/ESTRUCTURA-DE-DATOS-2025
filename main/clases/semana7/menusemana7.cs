public class menusemana7
{
    public static void menu7()
    {
        Titulo.encabezado();
        while (true)
        {
            Console.WriteLine("\nSeleccione un ejercicio para la Semana 7:");
            Console.WriteLine("1. Ejercicio 1 Pilas conceptos básicos");   
            Console.WriteLine("2. Ejercicio 2");   // to do      
            Console.WriteLine("0. Volver al menú principal");

            Console.Write("Ingrese su opción: ");
            string? input = Console.ReadLine(); // Entrada de tipo string?
            int seleccionEjercicio;

            // Verificamos que la entrada no sea null y si es posible parsearla
            if (input != null && int.TryParse(input, out seleccionEjercicio))
            {
                switch (seleccionEjercicio)
                {
                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        return;  // Vuelve al menú principal

                    case 1:
                        Console.WriteLine("Has seleccionado el Ejercicio 1");
                        semana8.pila();   // Llamada al método del Ejercicio 1 pila
                        break;

                    case 2:
                        Console.WriteLine("Has seleccionado el Ejercicio 2");
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
