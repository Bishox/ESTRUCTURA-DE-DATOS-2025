
public class ArbolbinarioBusqueda
{
    private Nodo raiz;

    public ArbolbinarioBusqueda()
    {
        raiz = null;
    }

    // Insertar un nuevo título al árbol
    public void insertarRevista(string nombreRevista)
    {
        raiz = InsertarRecursivamente(raiz, nombreRevista);
    }

    // Método recursivo para insertar un nodo en el árbol
    private Nodo InsertarRecursivamente(Nodo nodo, string nombreRevista)
    {
        if (nodo == null)
        {
            return new Nodo(nombreRevista);
        }

        int comparador = nombreRevista.CompareTo(nodo.nombreRevista);

        if (comparador < 0)
        {
            nodo.izquierdo = InsertarRecursivamente(nodo.izquierdo, nombreRevista);
        }
        else if (comparador > 0)
        {
            nodo.derecho = InsertarRecursivamente(nodo.derecho, nombreRevista);
        }

        return nodo;
    }

    // Buscar un título de revista (Búsqueda recursiva)
    public bool Buscar(string nombreRevista)
    {
        return BuscarRecursivamente(raiz, nombreRevista);
    }

    // Búsqueda recursiva
    private bool BuscarRecursivamente(Nodo nodo, string nombreRevista)
    {
        if (nodo == null)
        {
            return false;
        }

        int comparador = nombreRevista.CompareTo(nodo.nombreRevista);

        if (comparador == 0)
        {
            return true; // Encontrado
        }
        else if (comparador < 0)
        {
            return BuscarRecursivamente(nodo.izquierdo, nombreRevista); // Buscar en la izquierda
        }
        else
        {
            return BuscarRecursivamente(nodo.derecho, nombreRevista); // Buscar en la derecha
        }
    }

    // Buscar un título de revista (Búsqueda iterativa)
    public bool BuscarIterativo(string nombreRevista)
    {
        Nodo nodo = raiz;
        while (nodo != null)
        {
            int comparador = nombreRevista.CompareTo(nodo.nombreRevista);
            if (comparador == 0)
            {
                return true; // Encontrado
            }
            else if (comparador < 0)
            {
                nodo = nodo.izquierdo; // Ir a la izquierda
            }
            else
            {
                nodo = nodo.derecho; // Ir a la derecha
            }
        }
        return false; // No encontrado
    }
}

public class Nodo
{
    public string nombreRevista;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(string nombre)
    {
        nombreRevista = nombre;
        izquierdo = null;
        derecho = null;
    }
}

public class Revistas
{
    public static void RevistasMenu()
    {
        ArbolbinarioBusqueda catalogo = new ArbolbinarioBusqueda();

        // Insertar 10 títulos de revistas al catálogo
        catalogo.insertarRevista("National Geographic");
        catalogo.insertarRevista("Time");
        catalogo.insertarRevista("Scientific American");
        catalogo.insertarRevista("Vogue");
        catalogo.insertarRevista("The New Yorker");
        catalogo.insertarRevista("The Economist");
        catalogo.insertarRevista("Nature");
        catalogo.insertarRevista("Forbes");
        catalogo.insertarRevista("Wired");
        catalogo.insertarRevista("Popular Science");
        
    
        // Menú interactivo
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Catálogo de Revistas");
            Console.WriteLine("1. Buscar un título (recursivo)");
            Console.WriteLine("2. Buscar un título (iterativo)");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título de la revista a buscar (búsqueda recursiva): ");
                    string tituloRecursivo = Console.ReadLine();
                    if (catalogo.Buscar(tituloRecursivo))
                    {
                        Console.WriteLine("Resultado: Título encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Resultado: Título no encontrado");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese el título de la revista a buscar (búsqueda iterativa): ");
                    string tituloIterativo = Console.ReadLine();
                    if (catalogo.BuscarIterativo(tituloIterativo))
                    {
                        Console.WriteLine("Resultado: Título encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Resultado: Título no encontrado");
                    }
                    break;

                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        } while (opcion != 0);
    }
}
