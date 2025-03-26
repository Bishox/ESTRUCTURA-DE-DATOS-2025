class Grafos

{
    public static void grafos()
    {
        Console.WriteLine(" GGG   RRRR   AAAAA  FFFFF  OOO   SSSSS");
        Console.WriteLine("G   G  R   R  A   A  F      O   O  S");
        Console.WriteLine("G      RRRR   AAAAA  FFFF   O   O  SSSSS");
        Console.WriteLine("G   G  R  R   A   A  F      O   O     S");
        Console.WriteLine(" GGG   R   R  A   A  F       OOO   SSSSS");

        // Definición de nodos
        string[] estaciones = { "A", "B", "C", "D", "E" };
        
        // Matriz de adyacencia
        int[,] grafo = {
            { 0, 1, 1, 1, 0 }, // A
            { 0, 0, 0, 1, 1 }, // B
            { 0, 0, 0, 1, 0 }, // C
            { 0, 0, 0, 0, 1 }, // D
            { 1, 0, 0, 0, 0 }  // E
        };
        
        // Mostrar la matriz de adyacencia
        Console.WriteLine("");
        Console.WriteLine("Matriz de Adyacencia:");
        Console.Write("    ");
        
        foreach (var estacion in estaciones)
        {
            Console.Write(estacion + " ");
        }
        Console.WriteLine();
        
        for (int i = 0; i < grafo.GetLength(0); i++)
        {
            Console.Write(estaciones[i] + " ");
            for (int j = 0; j < grafo.GetLength(1); j++)
            {
                Console.Write(" " + grafo[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Mostrar las conexiones de manera visual
        Console.WriteLine("\nConexiones del Grafo:");
        for (int i = 0; i < grafo.GetLength(0); i++)
        {
            for (int j = 0; j < grafo.GetLength(1); j++)
            {
                if (grafo[i, j] == 1)
                {
                    Console.WriteLine($"{estaciones[i]} -> {estaciones[j]}");
                }
            }
        }
    }
}