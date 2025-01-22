using System;
using System.Collections;
public class semana8
{
    public static void pila()
    {
        Stack miPila = new Stack();

        miPila.Push("Luis");
        miPila.Push("Juan");
        miPila.Push("Andres");

        int contadorpila = miPila.Count;

        //transformar la pila a array con To.Array() para poder ver sus elementos
        Console.WriteLine("todos los elementos en mi pila:");
        foreach (var item in miPila.ToArray())
        {
            Console.WriteLine(item);
        }
        //eliminar y obtener el último elemento
        Console.WriteLine($"eliminar ultimo elemento de la pila: {miPila.Pop()}"); 
        // Mostrar el número de elementos en la pila
        Console.WriteLine($"{miPila.Count}");

        // Mostrar los elementos de la pila
        Console.WriteLine("Elemento en la parte superior de la pila: " + miPila.Peek());

    }
        

}