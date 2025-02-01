public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

public class Atraccion
{
    private Queue<Persona> colaEspera;  // Cola de espera para los asientos
    private int totalAsientos;          // Total de asientos disponibles
    private int asientosVendidos;       // Contador de los asientos vendidos

    public Atraccion(int totalAsientos)
    {
        this.totalAsientos = totalAsientos;
        this.asientosVendidos = 0;
        colaEspera = new Queue<Persona>();
    }

    // Método para agregar a una persona a la cola
    public void AgregarPersonaACola(Persona persona)
    {
        if (asientosVendidos < totalAsientos)
        {
            colaEspera.Enqueue(persona);  // Añadir a la cola
            Console.WriteLine($"{persona.Nombre} se ha añadido a la cola.");
        }
        else
        {
            Console.WriteLine("Todos los asientos han sido vendidos. No hay más lugar en la cola.");
        }
    }

    // Método para hacer subir a la siguiente persona a la atracción
    public void SubirAlSiguiente()
    {
        if (colaEspera.Count > 0 && asientosVendidos < totalAsientos)
        {
            Persona persona = colaEspera.Dequeue();  // Remover a la persona de la cola
            asientosVendidos++;
            Console.WriteLine($"{persona.Nombre} ha subido a la atracción. Asiento número {asientosVendidos}");
        }
        else
        {
            Console.WriteLine("No hay más personas en la cola o los asientos están llenos.");
        }
    }

    // Verificar si hay asientos disponibles
    public bool HayAsientosDisponibles()
    {
        return asientosVendidos < totalAsientos;
    }

    // Reportería: Ver el número de personas en la cola
    public void MostrarColaEspera()
    {
        Console.WriteLine("\nPersonas en la cola de espera:");
        if (colaEspera.Count > 0)
        {
            foreach (var persona in colaEspera)
            {
                Console.WriteLine($"- {persona.Nombre}");
            }
        }
        else
        {
            Console.WriteLine("La cola está vacía.");
        }
    }

    // Reportería: Ver el número de asientos vendidos
    public void MostrarAsientosVendidos()
    {
        Console.WriteLine($"\nAsientos vendidos: {asientosVendidos} de {totalAsientos}");
    }
}

public class Parque_de_diversiones
{
    public static void Menu(Atraccion atraccion)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú de Reportería ---");
            Console.WriteLine("1. Ver cola de espera");
            Console.WriteLine("2. Ver asientos vendidos");
            Console.WriteLine("3. Agregar persona a la cola");
            Console.WriteLine("4. Subir al siguiente a la atracción");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    atraccion.MostrarColaEspera();
                    break;
                case 2:
                    atraccion.MostrarAsientosVendidos();
                    break;
                case 3:
                    Console.Write("Ingrese el nombre de la persona: ");
                    string nombre = Console.ReadLine();
                    Persona persona = new Persona(nombre);
                    atraccion.AgregarPersonaACola(persona);
                    break;
                case 4:
                    atraccion.SubirAlSiguiente();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor intente nuevamente.");
                    break;
            }
        } while (opcion != 5);
    }

    public static void parque_de_diversiones()
    {
        // Crear una atracción con 30 asientos
        Atraccion atraccion = new Atraccion(30);

        // Ejecutar el menú
        Menu(atraccion);
    }
}

