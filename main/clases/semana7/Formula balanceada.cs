using System;
using System.Collections.Generic;

public class BalanceoOperaciones
{
    public static bool EsBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);  // Apilar los paréntesis de apertura
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                // Verificar si la pila está vacía o si el último elemento no es el par correspondiente
                if (pila.Count == 0) return false;

                char apertura = pila.Pop();
                if (!Coinciden(apertura, c))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0;  // Si la pila está vacía, significa que todos los paréntesis se cerraron correctamente
    }

    private static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    public static void formulaBalanceada()
    {
        // Solicitar al usuario que ingrese una fórmula
        Console.WriteLine("Por favor ingresa una fórmula para verificar si está balanceada:");
        string expresion = Console.ReadLine();  // Lee la entrada del usuario

        if (EsBalanceada(expresion))
        {
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            Console.WriteLine("La fórmula NO está balanceada.");
        }
    }
}
