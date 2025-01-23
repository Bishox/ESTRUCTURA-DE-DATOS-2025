using System;
using System.Collections.Generic;

public class Menu
{   


    public static void Main()
    {
       Titulo.encabezado();

        // Lista de títulos para las semanas
        List<string> semanas = new List<string>
        {
            "Semana 1", "Semana 2", "Semana 3", "Semana 4", "Semana 5", 
            "Semana 6 Ejercicios-propuestos-de-listas-enlazada", "Semana 7 Pilas", "Semana 8" 
        };
        
        while (true)
        {
            // Mostrar el menú con las semanas disponibles
            Console.WriteLine($"\nSeleccione una semana del 1 a {semanas.Count} :");
            for (int i = 0 ; i < semanas.Count; i++)  
            {
                Console.WriteLine($"{i+1}. {semanas[i]}");
                
            }
            Console.WriteLine("0. Salir");

            // Obtener la opción seleccionada por el usuario
            Console.Write("Ingrese su opción: ");
            string input = Console.ReadLine();
            int seleccion;

            // Intentar convertir el input a un número entero
            if (int.TryParse(input, out seleccion))
            {
                switch (seleccion)
                {
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        return;  // Sale del programa

                    case 1:
                        Console.WriteLine("Has seleccionado la Semana 1");
                        break;
                    case 2:
                        Console.WriteLine("Has seleccionado la Semana 2");
                        break;
                    case 3:
                        Console.WriteLine("Has seleccionado la Semana 3");
                        break;
                    case 4:
                        Console.WriteLine("Has seleccionado la Semana 4");
                        break;
                    case 5:
                        Console.WriteLine("Has seleccionado la Semana 5");
                        break;
                    case 6:
                        Console.WriteLine("Has seleccionado la Semana 6");
                        semana6.menu6();
                        EsperarParaRegresar();
                        break;
                    case 7:
                        Console.WriteLine("Has seleccionado la Semana 7");
                        menusemana7.menu7();
                        EsperarParaRegresar();
                        break;
                    case 8:
                        
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

    // Método para esperar a que el usuario presione espacio para regresar al menú
    public static void EsperarParaRegresar()
    {
        Console.WriteLine("\nPresione la tecla espacio para regresar al menú principal...");
        while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
        {
            // Sigue esperando si la tecla presionada no es espacio
        }
        Console.Clear();  // Limpiar la pantalla para el menú
    }
}
