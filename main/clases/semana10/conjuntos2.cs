using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class Ciudadanos
{
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public HashSet<string> Vacunas { get; set; }
    public List<Tuple<string, string, DateTime>> DosisVacunacion { get; set; }

    public Ciudadanos(string nombre, string cedula, HashSet<string> vacunas, List<Tuple<string, string, DateTime>> dosisVacunacion)
    {
        Nombre = nombre;
        Cedula = cedula;
        Vacunas = vacunas;
        DosisVacunacion = dosisVacunacion;
    }
}

public class Conjuntos
{
    public static void CrearConjuntosFicticios()
    {
        List<Ciudadanos> ciudadanoss = new List<Ciudadanos>();
        Random rand = new Random();

        // Generamos los 500 ciudadanos, asegurándonos de crear 75 vacunados con Pfizer y 75 con AstraZeneca
        for (int i = 0; i < 500; i++)
        {
            string nombre = $"Ciudadano{i + 1}";
            string cedula = (1500237000 + i).ToString();  // Cédulas ficticias

            HashSet<string> vacunas = new HashSet<string>();
            List<Tuple<string, string, DateTime>> dosisVacunacion = new List<Tuple<string, string, DateTime>>();

            // Determinar qué vacuna asignar
            string vacunaPrimera = "";
            string vacunaSegunda = "";
            DateTime primeraFecha = DateTime.Now.AddDays(-rand.Next(30, 60));  // Primera dosis en el último mes
            DateTime segundaFecha = primeraFecha.AddDays(21 + rand.Next(10, 14));  // Segunda dosis 21-35 días después

            if (i < 75)
            {
                vacunaPrimera = "Pfizer";
                vacunaSegunda = "Pfizer";
            }
            else if (i < 150)
            {
                vacunaPrimera = "AstraZeneca";
                vacunaSegunda = "AstraZeneca";
            }
            else
            {
                if (rand.Next(2) == 0)
                {
                    vacunaPrimera = "Pfizer";
                    vacunaSegunda = "AstraZeneca";
                }
                else
                {
                    vacunaPrimera = "AstraZeneca";
                    vacunaSegunda = "Pfizer";
                }
            }

            // Agregar la información de las dosis
            vacunas.Add(vacunaPrimera);
            vacunas.Add(vacunaSegunda);
            dosisVacunacion.Add(new Tuple<string, string, DateTime>(vacunaPrimera, "Primera Dosis", primeraFecha));
            dosisVacunacion.Add(new Tuple<string, string, DateTime>(vacunaSegunda, "Segunda Dosis", segundaFecha));

            ciudadanoss.Add(new Ciudadanos(nombre, cedula, vacunas, dosisVacunacion));
        }

        // Crear conjuntos para los diferentes grupos
        HashSet<string> ciudadanossConAmbasDosis = new HashSet<string>();
        HashSet<string> ciudadanossConSoloPfizer = new HashSet<string>();
        HashSet<string> ciudadanossConSoloAstraZeneca = new HashSet<string>();

        foreach (var ciudadano in ciudadanoss)
        {
            bool tienePfizer = ciudadano.Vacunas.Contains("Pfizer");
            bool tieneAstraZeneca = ciudadano.Vacunas.Contains("AstraZeneca");

            if (ciudadano.Vacunas.Count == 2)
            {
                string detalles = $"{ciudadano.Nombre} - {ciudadano.Cedula}";
                foreach (var dosis in ciudadano.DosisVacunacion)
                {
                    detalles += $" | {dosis.Item1} - {dosis.Item2}: {dosis.Item3:dd/MM/yyyy}";
                }
                ciudadanossConAmbasDosis.Add(detalles);
            }
            else if (tienePfizer)
            {
                string detalles = $"{ciudadano.Nombre} - {ciudadano.Cedula}";
                foreach (var dosis in ciudadano.DosisVacunacion)
                {
                    if (dosis.Item1 == "Pfizer")
                        detalles += $" | {dosis.Item1} - {dosis.Item2}: {dosis.Item3:dd/MM/yyyy}";
                }
                ciudadanossConSoloPfizer.Add(detalles);
            }
            else if (tieneAstraZeneca)
            {
                string detalles = $"{ciudadano.Nombre} - {ciudadano.Cedula}";
                foreach (var dosis in ciudadano.DosisVacunacion)
                {
                    if (dosis.Item1 == "AstraZeneca")
                        detalles += $" | {dosis.Item1} - {dosis.Item2}: {dosis.Item3:dd/MM/yyyy}";
                }
                ciudadanossConSoloAstraZeneca.Add(detalles);
            }
        }

        // Mostrar resultados en consola
        Console.WriteLine("\nCiudadanos con ambas dosis:");
        foreach (var nombre in ciudadanossConAmbasDosis)
        {
            Console.WriteLine(nombre);
        }

        Console.WriteLine("\nCiudadanos con solo Pfizer:");
        foreach (var nombre in ciudadanossConSoloPfizer)
        {
            Console.WriteLine(nombre);
        }

        Console.WriteLine("\nCiudadanos con solo AstraZeneca:");
        foreach (var nombre in ciudadanossConSoloAstraZeneca)
        {
            Console.WriteLine(nombre);
        }

        // Preguntar si desea generar el reporte en PDF
        Console.WriteLine("\n¿Desea generar el reporte en PDF? (si/no)");
        string respuesta = Console.ReadLine().ToLower();

        if (respuesta == "si")
        {
            GenerarReportePDF(ciudadanossConAmbasDosis, ciudadanossConSoloPfizer, ciudadanossConSoloAstraZeneca);
            Console.WriteLine("El reporte ha sido generado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se generó el reporte.");
        }
    }

    // Función para generar el reporte en PDF usando iTextSharp
    private static void GenerarReportePDF(HashSet<string> ambasDosis, HashSet<string> soloPfizer, HashSet<string> soloAstraZeneca)
    {
        // Obtener la ruta actual del directorio donde se ejecuta el programa
        string currentDirectory = Directory.GetCurrentDirectory();
        
        // Definir el archivo PDF de salida en la ruta actual
        string pdfPath = Path.Combine(currentDirectory, "Reporte.pdf");
        

        using (var fs = new FileStream(pdfPath, FileMode.Create))
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, fs);
            document.Open();

            // Título del reporte
            document.Add(new Paragraph("Reporte de Ciudadanos Vacunados"));
            document.Add(new Paragraph("\n"));

            // Ciudadanos con ambas dosis
            document.Add(new Paragraph("Ciudadanos con Ambas Dosis:"));
            foreach (var ciudadano in ambasDosis)
            {
                document.Add(new Paragraph(ciudadano));
            }

            document.Add(new Paragraph("\nCiudadanos con Solo Pfizer:"));
            foreach (var ciudadano in soloPfizer)
            {
                document.Add(new Paragraph(ciudadano));
            }

            document.Add(new Paragraph("\nCiudadanos con Solo AstraZeneca:"));
            foreach (var ciudadano in soloAstraZeneca)
            {
                document.Add(new Paragraph(ciudadano));
            }

            document.Close();
        }

        // Mensaje de confirmación con la ruta del archivo generado
        Console.WriteLine($"El reporte ha sido generado exitosamente en: {pdfPath}");
    }
}
