using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

Console.WriteLine("**** INICIO ****");
Console.WriteLine(" ");
string rutaDirectorio = @"c:\prueba\";
if (Directory.Exists(rutaDirectorio))
{
    Console.WriteLine("**** Carpetas en el directorio ****");
    var rutaDirectorioConvertida = new DirectoryInfo(rutaDirectorio);
    DirectoryInfo[] arregloDeDirectorios = rutaDirectorioConvertida.GetDirectories();

    foreach (DirectoryInfo carpeta in arregloDeDirectorios)
    {
        Console.WriteLine(carpeta.Name);
    }
    Console.WriteLine(" ");
    Console.WriteLine("**** Archivos en el directorio ****");
    foreach (var archivo in rutaDirectorioConvertida.GetFiles())
    {
        Console.WriteLine(archivo.Name + "                      " + archivo.Length + "kb");
    }
    Console.WriteLine(" ");

    string rutaArchivoCsv = $"{rutaDirectorio}reporte_archivos.csv";
    if (!File.Exists(rutaArchivoCsv))
    {
        // File.Create(rutaArchivoCsv);
        List<string> lineasCsv = new List<string>();
        lineasCsv.Add("Nombre del archivo, Tamaño (KB), Fecha de ultima modificacion"); //inicializo la cabecera
        foreach (var archivo in rutaDirectorioConvertida.GetFiles())
        {
            string linea = $"{archivo.Name},{archivo.Length},{archivo.LastWriteTime}"; //concateno los datos del archivo
            lineasCsv.Add(linea);
        }
        File.WriteAllLines(rutaArchivoCsv, lineasCsv); //otra forma 
        
    }
}
else
{
    Console.WriteLine("El directorio ingresado no existe. Ingrese nuevamente");
}