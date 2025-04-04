public class menusemana16
{
    public static void menu16()
    {
        Titulo.encabezado();
        while (true)
        {
            Console.WriteLine("\nSeleccione un ejercicio para la Semana 16:");
            Console.WriteLine("1.Calculador de Vuelos");
                
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
                        Console.WriteLine("Has seleccionado el Arbol genealógico");
                        CalculadorDeVuelos.AgregarVuelo("A", "B", 100);
                        CalculadorDeVuelos.AgregarVuelo("A", "C", 300);
                        CalculadorDeVuelos.AgregarVuelo("B", "C", 100);
                        CalculadorDeVuelos.AgregarVuelo("B", "D", 200);
                        CalculadorDeVuelos.AgregarVuelo("C", "D", 100);
                        CalculadorDeVuelos.vuelos(); 
                        break;

                    case 2:
                        Console.WriteLine("Has seleccionado el Agenda de Contactos");
                           
                        break;

                    

                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número entre 0 y 1.");
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