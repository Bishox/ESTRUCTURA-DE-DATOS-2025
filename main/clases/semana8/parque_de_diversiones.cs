using System;
using System.Collections.Generic;



    // Clase para representar una persona
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase para gestionar los asientos y la cola de espera
    public class Atraccion
    {
        private Queue<Persona> colaEspera;  // Cola de espera para los asientos
        private int totalAsientos;          // Total de asientos disponibles
        private int asientosVendidos;       // Contador de los asientos vendidos

        public Atraccion(int totalAsientos)
        {
            this.totalAsientos = totalAsientos;
            this.asientosVendidos = 0;
            colaEspera = new Queue<Persona>();
        }

        // Método para agregar a una persona a la cola
        public void AgregarPersonaACola(Persona persona)
        {
            if (asientosVendidos < totalAsientos)
            {
                colaEspera.Enqueue(persona);  // Añadir a la cola
                Console.WriteLine($"{persona.Nombre} se ha añadido a la cola.");
            }
            else
            {
                Console.WriteLine("Todos los asientos han sido vendidos. No hay más lugar en la cola.");
            }
        }

        // Método para hacer subir a la siguiente persona a la atracción
        public void SubirAlSiguiente()
        {
            if (colaEspera.Count > 0 && asientosVendidos < totalAsientos)
            {
                Persona persona = colaEspera.Dequeue();  // Remover a la persona de la cola
                asientosVendidos++;
                Console.WriteLine($"{persona.Nombre} ha subido a la atracción. Asiento número {asientosVendidos}");
            }
            else
            {
                Console.WriteLine("No hay más personas en la cola o los asientos están llenos.");
            }
        }

        // Verificar si hay asientos disponibles
        public bool HayAsientosDisponibles()
        {
            return asientosVendidos < totalAsientos;
        }
    }

    // Puedes cambiar el nombre de esta clase o método como desees
    public class Parque_de_diversiones
    {
        public static void parque_de_diversiones()
        {
            // Crear una atracción con 30 asientos
            Atraccion atraccion = new Atraccion(30);

            // Crear algunas personas
            Persona p1 = new Persona("Carlos");
            Persona p2 = new Persona("Ana");
            Persona p3 = new Persona("Luis");
            Persona p4 = new Persona("Marta");
            Persona p5 = new Persona("Javier");

            // Agregar personas a la cola
            atraccion.AgregarPersonaACola(p1);
            atraccion.AgregarPersonaACola(p2);
            atraccion.AgregarPersonaACola(p3);
            atraccion.AgregarPersonaACola(p4);
            atraccion.AgregarPersonaACola(p5);

            // Hacer que suban a la atracción
            atraccion.SubirAlSiguiente();
            atraccion.SubirAlSiguiente();
            atraccion.SubirAlSiguiente();
            atraccion.SubirAlSiguiente();
            atraccion.SubirAlSiguiente();

            // Intentar agregar más personas después de que todos los asientos están ocupados
            if (!atraccion.HayAsientosDisponibles())
            {
                Console.WriteLine("Los asientos ya están llenos.");
            }
        }
    }
