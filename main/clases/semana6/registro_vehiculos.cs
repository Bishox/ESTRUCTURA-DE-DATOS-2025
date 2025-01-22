public class registroVehiculos
{
    public static void registro()
    {

        Estacionamiento estacionamiento = new Estacionamiento();
        bool continuar = true;

        Titulo.encabezado();
        while (continuar)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Eliminar vehículo registrado");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Agregar vehículo
                    Console.Write("Ingrese la placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Ingrese la marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese el modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Ingrese el año: ");
                    int año = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el precio: ");
                    double precio = double.Parse(Console.ReadLine());

                    estacionamiento.AgregarVehiculo(placa, marca, modelo, año, precio);
                    break;

                case 2:
                    // Buscar vehículo por placa
                    Console.Write("Ingrese la placa a buscar: ");
                    string placaBuscar = Console.ReadLine();
                    Vehiculo vehiculo = estacionamiento.BuscarPorPlaca(placaBuscar);
                    if (vehiculo != null)
                    {
                        Console.WriteLine($"Vehículo encontrado: {vehiculo.Placa}, {vehiculo.Marca}, {vehiculo.Modelo}, {vehiculo.Año}, {vehiculo.Precio}");
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado.");
                    }
                    break;

                case 3:
                    // Ver vehículos por año
                    Console.Write("Ingrese el año de los vehículos a mostrar: ");
                    int añoBuscar = int.Parse(Console.ReadLine());
                    estacionamiento.VerPorAño(añoBuscar);
                    break;

                case 4:
                    // Ver todos los vehículos registrados
                    Console.WriteLine("Vehículos registrados:");
                    estacionamiento.VerTodos();
                    break;

                case 5:
                    // Eliminar vehículo por placa
                    Console.Write("Ingrese la placa del vehículo a eliminar: ");
                    string placaEliminar = Console.ReadLine();
                    estacionamiento.EliminarPorPlaca(placaEliminar);
                    break;

                case 0:
                    // Salir
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        Console.WriteLine("Programa finalizado.");
    }

    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public double Precio { get; set; }
        public Vehiculo Siguiente { get; set; } // Referencia al siguiente vehículo

        // Constructor de la clase Vehiculo
        public Vehiculo(string placa, string marca, string modelo, int año, double precio)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;
            Siguiente = null; // Inicialmente no hay siguiente vehículo
        }
    }

    public class Estacionamiento
    {
        public Vehiculo Primero { get; set; } // El primer vehículo de la lista

        public Estacionamiento()
        {
            Primero = null; // Inicialmente la lista está vacía
        }

        // Método para agregar un vehículo
        public void AgregarVehiculo(string placa, string marca, string modelo, int año, double precio)
        {
            Vehiculo nuevoVehiculo = new Vehiculo(placa, marca, modelo, año, precio);

            if (Primero == null)
            {
                Primero = nuevoVehiculo; // Si la lista está vacía, el nuevo vehículo es el primero
            }
            else
            {
                Vehiculo actual = Primero;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; // Llegar al final de la lista
                }
                actual.Siguiente = nuevoVehiculo; // Agregar el nuevo vehículo al final de la lista
            }
            Console.WriteLine("Vehículo agregado exitosamente.");
        }

        // Método para buscar un vehículo por placa
        public Vehiculo BuscarPorPlaca(string placa)
        {
            Vehiculo actual = Primero;
            while (actual != null)
            {
                if (actual.Placa == placa)
                    return actual; // Vehículo encontrado
                actual = actual.Siguiente;
            }
            return null; // Vehículo no encontrado
        }

        // Método para ver vehículos por año
        public void VerPorAño(int año)
        {
            Vehiculo actual = Primero;
            bool encontrado = false;
            Console.WriteLine("\nVehículos encontrados:");
            Console.WriteLine("=======================================================");
            Console.WriteLine("| Placa     | Marca     | Modelo    | Año   | Precio  |");
            Console.WriteLine("=======================================================");
            while (actual != null)
            {
                if (actual.Año == año)
                {
                    Console.WriteLine($"| {actual.Placa,-10} | {actual.Marca,-10} | {actual.Modelo,-10} | {actual.Año,-5} | {actual.Precio,-8} |");
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine("=======================================================");
            if (!encontrado)
            {
                Console.WriteLine("No se encontraron vehículos de ese año.");
            }
        }

        // Método para ver todos los vehículos registrados
        public void VerTodos()
        {
            Vehiculo actual = Primero;
            if (actual == null)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            // Ordenar los vehículos por año antes de mostrarlos
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            while (actual != null)
            {
                listaVehiculos.Add(actual);
                actual = actual.Siguiente;
            }

            listaVehiculos.Sort((v1, v2) => v1.Año.CompareTo(v2.Año)); // Ordenar por año

            Console.WriteLine("\nVehículos registrados:");
            Console.WriteLine("========================================================");
            Console.WriteLine("| Placa     | Marca     | Modelo    | Año   | Precio  |");
            Console.WriteLine("========================================================");
            foreach (var vehiculo in listaVehiculos)
            {
                Console.WriteLine($"| {vehiculo.Placa,-9} | {vehiculo.Marca,-9} | {vehiculo.Modelo,-9} | {vehiculo.Año,-5} | {vehiculo.Precio,-8:C} |");
            }
            Console.WriteLine("========================================================");
        }

        // Método para eliminar un vehículo por placa
        public void EliminarPorPlaca(string placa)
        {
            if (Primero == null)
            {
                Console.WriteLine("No hay vehículos para eliminar.");
                return;
            }

            if (Primero.Placa == placa)
            {
                Primero = Primero.Siguiente; // Eliminar el primer vehículo
                Console.WriteLine("Vehículo eliminado exitosamente.");
                return;
            }

            Vehiculo actual = Primero;
            while (actual.Siguiente != null && actual.Siguiente.Placa != placa)
            {
                actual = actual.Siguiente; // Buscar el vehículo antes del que se quiere eliminar
            }

            if (actual.Siguiente == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
            else
            {
                actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar el vehículo
                Console.WriteLine("Vehículo eliminado exitosamente.");
            }
        }
    }
}
