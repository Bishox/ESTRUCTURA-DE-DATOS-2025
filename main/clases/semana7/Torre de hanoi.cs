using System;
using System.Collections.Generic;

public class TorresDeHanoi
{
    // Método para resolver el problema de las Torres de Hanoi
    public static void ResolverTorres(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            // Mover el disco de la torre de origen a la torre de destino
            if (origen.Count > 0)  // Verifica que la pila de origen no esté vacía
            {
                destino.Push(origen.Pop());
                Console.WriteLine($"Mover disco 1 de torre Origen a torre Destino");
                ImprimirEstado(origen, destino, auxiliar); // Mostrar estado de las torres
            }
            return;
        }

        // Mover n-1 discos a la torre auxiliar
        ResolverTorres(n - 1, origen, auxiliar, destino);

        // Mover el disco más grande a la torre de destino
        if (origen.Count > 0)  // Verifica que la pila de origen no esté vacía
        {
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco {n} de torre Origen a torre Destino");
            ImprimirEstado(origen, destino, auxiliar); // Mostrar estado de las torres
        }

        // Mover los discos de la torre auxiliar a la torre de destino
        ResolverTorres(n - 1, auxiliar, destino, origen);
    }

    // Método para imprimir el estado actual de las torres
    public static void ImprimirEstado(Stack<int> torreOrigen, Stack<int> torreDestino, Stack<int> torreAuxiliar)
    {
        Console.WriteLine("\nEstado actual de las torres:");
        Console.WriteLine("Torre Origen: " + MostrarTorre(torreOrigen));
        Console.WriteLine("Torre Destino: " + MostrarTorre(torreDestino));
        Console.WriteLine("Torre Auxiliar: " + MostrarTorre(torreAuxiliar));
        Console.WriteLine(); // Espacio entre pasos
    }

    // Método para convertir el contenido de una torre a una cadena legible
    public static string MostrarTorre(Stack<int> torre)
    {
        // Convertir la pila a un arreglo para mostrarla de arriba a abajo
        var array = torre.ToArray();
        Array.Reverse(array);  // Para mostrar de arriba a abajo
        return string.Join(" ", array);
    }

    public static void resolver()
    {
        int numDiscos = 3;  // Número de discos
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();

        // Llenar la torre de origen con los discos (de mayor a menor)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Imprimir el estado inicial de las torres
        ImprimirEstado(torreOrigen, torreDestino, torreAuxiliar);

        // Resolver el problema
        ResolverTorres(numDiscos, torreOrigen, torreDestino, torreAuxiliar);

        // Mensaje de éxito una vez que todos los discos están en la torre de destino
        if (torreDestino.Count == numDiscos)
        {
            Console.WriteLine("\n¡Felicidades! El problema de las Torres de Hanoi se resolvió exitosamente.");
        }
    }
}
