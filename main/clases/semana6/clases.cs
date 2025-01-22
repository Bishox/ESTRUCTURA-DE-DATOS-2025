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
        while (actual != null)
        {
            if (actual.Año == año)
            {
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Año}, Precio: {actual.Precio}");
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
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

        while (actual != null)
        {
            Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Año}, Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
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
