namespace EstructuraDeDatos.Semana14
{
    class Nodo
    {
        public double Temperatura;
        public Nodo Izquierda;
        public Nodo Derecha;

        public Nodo(double temperatura)
        {
            Temperatura = temperatura;
            Izquierda = null;
            Derecha = null;
        }
    }

    class ArbolTemperaturas
    {
        private Nodo raiz;

        public ArbolTemperaturas()
        {
            raiz = null;
        }

        public void Insertar(double temperatura)
        {
            if (raiz == null)
            {
                raiz = new Nodo(temperatura);
            }
            else
            {
                InsertarRecursivo(raiz, temperatura);
            }
        }

        private void InsertarRecursivo(Nodo nodo, double temperatura)
        {
            if (temperatura < nodo.Temperatura)
            {
                if (nodo.Izquierda == null)
                {
                    nodo.Izquierda = new Nodo(temperatura);
                }
                else
                {
                    InsertarRecursivo(nodo.Izquierda, temperatura);
                }
            }
            else
            {
                if (nodo.Derecha == null)
                {
                    nodo.Derecha = new Nodo(temperatura);
                }
                else
                {
                    InsertarRecursivo(nodo.Derecha, temperatura);
                }
            }
        }

        public Nodo Buscar(double temperatura)
        {
            return BuscarRecursivo(raiz, temperatura);
        }

        private Nodo BuscarRecursivo(Nodo nodo, double temperatura)
        {
            if (nodo == null || nodo.Temperatura == temperatura)
            {
                return nodo;
            }
            else if (temperatura < nodo.Temperatura)
            {
                return BuscarRecursivo(nodo.Izquierda, temperatura);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecha, temperatura);
            }
        }

        public void Eliminar(double temperatura)
        {
            raiz = EliminarRecursivo(raiz, temperatura);
        }

        private Nodo EliminarRecursivo(Nodo nodo, double temperatura)
        {
            if (nodo == null)
                return nodo;

            if (temperatura < nodo.Temperatura)
            {
                nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, temperatura);
            }
            else if (temperatura > nodo.Temperatura)
            {
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, temperatura);
            }
            else
            {
                if (nodo.Izquierda == null)
                    return nodo.Derecha;
                else if (nodo.Derecha == null)
                    return nodo.Izquierda;

                nodo.Temperatura = ObtenerMinimo(nodo.Derecha);
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Temperatura);
            }
            return nodo;
        }

        private double ObtenerMinimo(Nodo nodo)
        {
            double minTemp = nodo.Temperatura;
            while (nodo.Izquierda != null)
            {
                minTemp = nodo.Izquierda.Temperatura;
                nodo = nodo.Izquierda;
            }
            return minTemp;
        }

        public void RecorridoInorden()
        {
            RecorridoInordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void RecorridoInordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoInordenRecursivo(nodo.Izquierda);
                Console.Write(nodo.Temperatura + " °C ");
                RecorridoInordenRecursivo(nodo.Derecha);
            }
        }

        public void RecorridoPreorden()
        {
            RecorridoPreordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void RecorridoPreordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Temperatura + " °C ");
                RecorridoPreordenRecursivo(nodo.Izquierda);
                RecorridoPreordenRecursivo(nodo.Derecha);
            }
        }

        public void RecorridoPostorden()
        {
            RecorridoPostordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void RecorridoPostordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoPostordenRecursivo(nodo.Izquierda);
                RecorridoPostordenRecursivo(nodo.Derecha);
                Console.Write(nodo.Temperatura + " °C ");
            }
        }

        public void ImprimirArbol()
        {
            ImprimirArbolRecursivo(raiz, "", true);
        }

        private void ImprimirArbolRecursivo(Nodo nodo, string espacio, bool esIzquierda)
        {
            if (nodo != null)
            {
                Console.WriteLine(espacio + (esIzquierda ? "├── " : "└── ") + nodo.Temperatura + " °C");
                ImprimirArbolRecursivo(nodo.Izquierda, espacio + (esIzquierda ? "│   " : "    "), true);
                ImprimirArbolRecursivo(nodo.Derecha, espacio + (esIzquierda ? "│   " : "    "), false);
            }
        }
    }

    class MenuTemperaturas
    {
        public static void EjecutarMenu()
        {
            ArbolTemperaturas arbol = new ArbolTemperaturas();
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menú de Temperaturas ---");
                Console.WriteLine("1. Insertar una temperatura");
                Console.WriteLine("2. Buscar una temperatura");
                Console.WriteLine("3. Eliminar una temperatura");
                Console.WriteLine("4. Mostrar temperaturas en orden");
                Console.WriteLine("5. Mostrar recorrido Preorden");
                Console.WriteLine("6. Mostrar recorrido Postorden");
                Console.WriteLine("7. Imprimir árbol");
                Console.WriteLine("8. Salir");
                Console.Write("Elija una opción (1-8): ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la temperatura a insertar: ");
                        double tempInsertar = double.Parse(Console.ReadLine());
                        arbol.Insertar(tempInsertar);
                        break;
                    case 2:
                        Console.Write("Ingrese la temperatura a buscar: ");
                        double tempBuscar = double.Parse(Console.ReadLine());
                        Nodo resultado = arbol.Buscar(tempBuscar);
                        Console.WriteLine(resultado != null ? $"La temperatura {tempBuscar} °C está en el árbol." : "No encontrada.");
                        break;
                    case 3:
                        Console.Write("Ingrese la temperatura a eliminar: ");
                        double tempEliminar = double.Parse(Console.ReadLine());
                        arbol.Eliminar(tempEliminar);
                        break;
                    case 4:
                        arbol.RecorridoInorden();
                        break;
                    case 5:
                        arbol.RecorridoPreorden();
                        break;
                    case 6:
                        arbol.RecorridoPostorden();
                        break;
                    case 7:
                        arbol.ImprimirArbol();
                        break;
                    case 8:
                        Console.WriteLine("Saliendo...");
                        break;
                }
            } while (opcion != 8);
        }
    }
}
