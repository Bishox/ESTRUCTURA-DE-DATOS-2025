using System;
using System.Collections.Generic;

public class Vuelo
{
    public string Destino { get; set; }
    public int Costo { get; set; }

    public Vuelo(string destino, int costo)
    {
        Destino = destino;
        Costo = costo;
    }
}

public class CalculadorDeVuelos
{
    private static Dictionary<string, List<Vuelo>> grafo = new();

    public static void AgregarVuelo(string origen, string destino, int costo)
    {
        if (!grafo.ContainsKey(origen))
            grafo[origen] = new List<Vuelo>();

        grafo[origen].Add(new Vuelo(destino, costo));
    }

    // Método principal con parámetros (usa Dijkstra)
    public static void vuelos(string origen, string destino)
    {
        var costos = new Dictionary<string, int>();
        var padres = new Dictionary<string, string>();
        var visitados = new HashSet<string>();
        var cola = new PriorityQueue<(string, int), int>();

        foreach (var nodo in grafo.Keys)
            costos[nodo] = int.MaxValue;

        costos[origen] = 0;
        cola.Enqueue((origen, 0), 0);

        while (cola.Count > 0)
        {
            var (nodoActual, costoActual) = cola.Dequeue();
            if (visitados.Contains(nodoActual)) continue;
            visitados.Add(nodoActual);

            if (grafo.ContainsKey(nodoActual))
            {
                foreach (var vecino in grafo[nodoActual])
                {
                    int nuevoCosto = costoActual + vecino.Costo;
                    if (nuevoCosto < costos.GetValueOrDefault(vecino.Destino, int.MaxValue))
                    {
                        costos[vecino.Destino] = nuevoCosto;
                        padres[vecino.Destino] = nodoActual;
                        cola.Enqueue((vecino.Destino, nuevoCosto), nuevoCosto);
                    }
                }
            }
        }

        if (!costos.ContainsKey(destino) || costos[destino] == int.MaxValue)
        {
            Console.WriteLine($"No hay ruta de {origen} a {destino}.");
            return;
        }

        Console.WriteLine($"Costo mínimo de {origen} a {destino}: {costos[destino]}");

        var ruta = new List<string>();
        string actual = destino;
        while (actual != origen)
        {
            ruta.Add(actual);
            actual = padres[actual];
        }
        ruta.Add(origen);
        ruta.Reverse();

        Console.WriteLine("Ruta más barata: " + string.Join(" --> ", ruta));
    }

    // 👇 Método sobrecargado SIN PARÁMETROS, pide datos al usuario
    public static void vuelos()
    {
        Console.WriteLine("Aeropuertos disponibles:");
        foreach (var origen in grafo.Keys)
        {
            Console.Write($"Desde {origen} → ");
            foreach (var vuelo in grafo[origen])
            {
                Console.Write($"{vuelo.Destino}({vuelo.Costo}) ");
            }
            Console.WriteLine();
        }

        Console.Write("\nIngrese aeropuerto origen: ");
        string origenInput = Console.ReadLine();

        Console.Write("Ingrese aeropuerto destino: ");
        string destinoInput = Console.ReadLine();

        vuelos(origenInput, destinoInput);
    }
}
