class Traductor
{



    static Dictionary<string, string> diccionario = new Dictionary<string, string>();
    static string archivoDiccionario = "";

    public static void menu_traductor()
    {


        int opcion;

        do
        {



            Console.Clear();
            string arteASCII = @"
 TTTTT  RRRR    AAAAA  DDDD   U   U  CCCC  TTTTT  OOO   RRRR
   T    R   R   A   A  D   D  U   U  C        T   O   O  R   R
   T    RRRR    AAAAA  D   D  U   U  C        T   O   O  RRRR
   T    R  R    A   A  D   D  U   U  C        T   O   O  R  R
   T    R   R   A   A  DDDD   UUUU  CCCC     T    OOO   R   R   
        
                                                   by: Bishox
                                                   ";


            Console.WriteLine(arteASCII);



            Console.WriteLine("MENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("3. Cargar diccionario desde archivo");
            Console.WriteLine("4. Guardar diccionario en archivo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 3:
                    CargarDiccionario();
                    break;
                case 4:
                    GuardarDiccionario();
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor intente nuevamente.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 0);
    }




    static void TraducirFrase()
{
    Console.Write("Ingrese la frase: ");
    string frase = Console.ReadLine();
    string[] palabras = frase.Split(' ');

    // Crear un diccionario con claves en minúsculas para búsquedas rápidas
    var diccionarioCaseInsensitive = diccionario.ToDictionary(
        kvp => kvp.Key.ToLower(), // Convertir las claves a minúsculas
        kvp => kvp.Value
    );

    for (int i = 0; i < palabras.Length; i++)
    {
        string palabra = palabras[i].Trim();
        string palabraLower = palabra.ToLower();

        if (diccionarioCaseInsensitive.ContainsKey(palabraLower))
        {
            palabras[i] = diccionarioCaseInsensitive[palabraLower];
        }
        else
        {
            palabras[i] = palabra;
        }
    }

    Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
}




    // AGREGAR UNA PALABRA AL DICCIONARIO

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés que desea agregar: ");
        string palabraIngles = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(palabraIngles))
        {
            Console.WriteLine("La palabra en inglés no puede estar vacía.");
            return;
        }

        Console.Write("Ingrese la traducción en español de la palabra: ");
        string palabraEspañol = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(palabraEspañol))
        {
            Console.WriteLine("La traducción no puede estar vacía.");
            return;
        }

        if (!diccionario.ContainsKey(palabraIngles))
        {
            diccionario.Add(palabraIngles, palabraEspañol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }



    // CARGAR EL DICCIONARIO 
    static void CargarDiccionario()
    {
        Console.Write("Ingrese la ruta del archivo de diccionario: ");
        archivoDiccionario = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(archivoDiccionario))
        {
            Console.WriteLine("La ruta del archivo no puede estar vacía.");
            return;
        }

        if (File.Exists(archivoDiccionario))
        {
            var lineas = File.ReadAllLines(archivoDiccionario);

            foreach (var linea in lineas)
            {
                var partes = linea.Split(','); // Dividir por coma
                if (partes.Length == 2)
                {
                    diccionario[partes[0].Trim()] = partes[1].Trim();
                }
            }
            Console.WriteLine("Diccionario cargado correctamente.");
        }
        else
        {
            Console.WriteLine("El archivo de diccionario no existe. Asegúrese de que la ruta sea correcta.");
        }
    }


    // GUARDAR EL DICCIONARIO 

    static void GuardarDiccionario()
    {
        if (string.IsNullOrEmpty(archivoDiccionario))
        {
            Console.WriteLine("No se ha seleccionado un diccionario para guardar.");
            return;
        }

        using (StreamWriter writer = new StreamWriter(archivoDiccionario))
        {
            foreach (var entrada in diccionario)
            {
                writer.WriteLine($"{entrada.Key},{entrada.Value}"); // Usar coma en lugar de espacio
            }
        }
        Console.WriteLine("Diccionario guardado correctamente.");
    }
}

