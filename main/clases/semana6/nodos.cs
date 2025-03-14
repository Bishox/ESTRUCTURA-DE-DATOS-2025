namespace EstructuraDeDatos.Semana6
{
    

class Nodo
    {
        public int Valor;
        public Nodo? Siguiente;  // Ahora 'Siguiente' es un tipo anulable (Nodo?)

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;  // Inicializamos Siguiente como null
        }
    }


    class ListaEnlazada
    {
        public Nodo? Cabeza;  // Cabeza también es un tipo anulable (Nodo?)

        public ListaEnlazada()
        {
            Cabeza = null;  // Inicializamos Cabeza como null
        }

        // Método para agregar un nuevo nodo al final de la lista
        public void Agregar(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                Nodo? nodoActual = Cabeza;
                while (nodoActual?.Siguiente != null)
                {
                    nodoActual = nodoActual.Siguiente;
                }
                nodoActual!.Siguiente = nuevoNodo; // Usamos '!' para indicar que nodoActual no es null en este punto
            }
        }

        // Método para imprimir la lista
        public void Imprimir()
        {
            Nodo? nodoActual = Cabeza;
            while (nodoActual != null)
            {
                Console.Write(nodoActual.Valor + " -> ");
                nodoActual = nodoActual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // Método para eliminar nodos fuera de un rango
        public void EliminarFueraDeRango(int minimo, int maximo)
        {
            // Eliminar nodos fuera del rango al principio de la lista
            while (Cabeza != null && (Cabeza.Valor < minimo || Cabeza.Valor > maximo))
            {
                Cabeza = Cabeza.Siguiente;
            }

            // Eliminar nodos fuera del rango en el resto de la lista
            Nodo? nodoActual = Cabeza;
            while (nodoActual != null && nodoActual.Siguiente != null)
            {
                if (nodoActual.Siguiente.Valor < minimo || nodoActual.Siguiente.Valor > maximo)
                {
                    nodoActual.Siguiente = nodoActual.Siguiente.Siguiente;
                }
                else
                {
                    nodoActual = nodoActual.Siguiente;
                }
            }
        }
    }

    class Nodos
    {
        public static void nodos()
        {
            Random random = new Random();
            ListaEnlazada lista = new ListaEnlazada();

            // Crear la lista enlazada con 50 números aleatorios del 1 al 999
            for (int i = 0; i < 50; i++)
            {
                lista.Agregar(random.Next(1, 1000));  // Random entre 1 y 999
            }


            Titulo.encabezado();
            // Mostrar la lista original
            Console.WriteLine("Lista original:");
            lista.Imprimir();

            // Leer el rango de valores
            int minimo, maximo;
            Console.Write("Introduce el valor mínimo del rango: ");
            while (!int.TryParse(Console.ReadLine(), out minimo) || minimo < 1 || minimo > 999)
            {
                Console.WriteLine("Por favor, ingresa un valor válido para el mínimo (entre 1 y 999):");
            }

            Console.Write("Introduce el valor máximo del rango: ");
            while (!int.TryParse(Console.ReadLine(), out maximo) || maximo < 1 || maximo > 999 || maximo < minimo)
            {
                Console.WriteLine("Por favor, ingresa un valor válido para el máximo (debe ser mayor que el mínimo y entre 1 y 999):");
            }

            // Eliminar nodos fuera del rango
            lista.EliminarFueraDeRango(minimo, maximo);

            // Mostrar la lista después de eliminar los nodos fuera del rango
            Console.WriteLine("\nLista después de eliminar nodos fuera del rango:");
            lista.Imprimir();
        }
    }
}