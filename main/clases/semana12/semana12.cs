public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public string Categoria { get; set; }  // Nueva propiedad Categoria

    public Libro(string titulo, string autor, string isbn, string categoria)
    {
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        Categoria = categoria;  // Inicializamos la categoría
    }

    public override string ToString()
    {
        return $"{Titulo} - {Autor} - ISBN: {ISBN} - Categoría: {Categoria}";
    }
}

public class Biblioteca
{
    private HashSet<Libro> libros;

    public Biblioteca()
    {
        libros = new HashSet<Libro>();
    }

    // Método para agregar un libro
    public void AgregarLibro(Libro libro)
    {
        if (libros.Add(libro))
        {
            Console.WriteLine("Libro agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Este libro ya está registrado en la biblioteca.");
        }
    }

    // Método para mostrar todos los libros
    public void MostrarLibros()
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados en la biblioteca.");
        }
        else
        {
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
        }
    }

    // Método para buscar un libro por ISBN
    public void BuscarLibroPorISBN(string isbn)
    {
        foreach (var libro in libros)
        {
            if (libro.ISBN == isbn)
            {
                Console.WriteLine("Libro encontrado: ");
                Console.WriteLine(libro);
                return;
            }
        }
        Console.WriteLine("Libro no encontrado con el ISBN proporcionado.");
    }

    // Método para buscar libros por autor
    public void BuscarLibroPorAutor(string autor)
    {
        bool encontrado = false;
        foreach (var libro in libros)
        {
            if (libro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(libro);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron libros de ese autor.");
        }
    }

    // Método para buscar libros por categoría
    public void BuscarLibroPorCategoria(string categoria)
    {
        bool encontrado = false;
        foreach (var libro in libros)
        {
            if (libro.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(libro);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron libros en esa categoría.");
        }
    }
}

class Libreria
{
    public static void libros()
    {
        Biblioteca biblioteca = new Biblioteca();

        // Menú interactivo
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar un nuevo libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Buscar un libro por ISBN");
            Console.WriteLine("4. Buscar libros por autor");
            Console.WriteLine("5. Buscar libros por categoría");
            Console.WriteLine("6. Salir");
            Console.Write("\nElige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarLibro(biblioteca);
                    break;
                case "2":
                    biblioteca.MostrarLibros();
                    break;
                case "3":
                    BuscarLibroPorISBN(biblioteca);
                    break;
                case "4":
                    BuscarLibroPorAutor(biblioteca);
                    break;
                case "5":
                    BuscarLibroPorCategoria(biblioteca);
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida, presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para registrar un nuevo libro
    static void RegistrarLibro(Biblioteca biblioteca)
    {
        Console.Clear();
        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();
        Console.Write("Ingrese el autor del libro: ");
        string autor = Console.ReadLine();
        Console.Write("Ingrese el ISBN del libro: ");
        string isbn = Console.ReadLine();
        Console.Write("Ingrese la categoría del libro: ");
        string categoria = Console.ReadLine();

        // Crear un nuevo libro
        Libro nuevoLibro = new Libro(titulo, autor, isbn, categoria);

        // Agregar el libro a la biblioteca
        biblioteca.AgregarLibro(nuevoLibro);
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Método para buscar un libro por su ISBN
    static void BuscarLibroPorISBN(Biblioteca biblioteca)
    {
        Console.Clear();
        Console.Write("Ingrese el ISBN del libro a buscar: ");
        string isbn = Console.ReadLine();
        biblioteca.BuscarLibroPorISBN(isbn);
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Método para buscar libros por autor
    static void BuscarLibroPorAutor(Biblioteca biblioteca)
    {
        Console.Clear();
        Console.Write("Ingrese el nombre del autor: ");
        string autor = Console.ReadLine();
        biblioteca.BuscarLibroPorAutor(autor);
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Método para buscar libros por categoría
    static void BuscarLibroPorCategoria(Biblioteca biblioteca)
    {
        Console.Clear();
        Console.Write("Ingrese la categoría del libro: ");
        string categoria = Console.ReadLine();
        biblioteca.BuscarLibroPorCategoria(categoria);
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
