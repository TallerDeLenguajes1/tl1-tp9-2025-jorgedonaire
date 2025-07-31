using System;
using System.IO;
using System.Text;

Console.WriteLine("LECTOR DE TAG MP3");
string rutaArchivo = @"C:\Users\jorge\Documents\FACET\TL12025\tp9\tl1-tp9-2025-jorgedonaire\LectorTagMp3\LectorTagMP3_12Alvacio.mp3";
if (File.Exists(rutaArchivo))
{
    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
    using (BinaryReader br = new BinaryReader(fs))
    {
        if (fs.Length >= 128)
        {
            fs.Seek(-128, SeekOrigin.End);
            byte[] tag = br.ReadBytes(128);

            string inicio = System.Text.Encoding.ASCII.GetString(tag, 0, 3);
            if (inicio == "TAG")
            {
                string titulo = System.Text.Encoding.ASCII.GetString(tag, 3, 30).TrimEnd('\0');
                string artista = System.Text.Encoding.ASCII.GetString(tag, 33, 30).TrimEnd('\0');
                string album = System.Text.Encoding.ASCII.GetString(tag, 63, 30).TrimEnd('\0');
                string anio = System.Text.Encoding.ASCII.GetString(tag, 93, 4).TrimEnd('\0');
                string comentario = System.Text.Encoding.ASCII.GetString(tag, 97, 30).TrimEnd('\0');
                byte genero = tag[127];

                Console.WriteLine($"Titulo: {titulo}");
                Console.WriteLine($"Artista: {artista}");
                Console.WriteLine($"Album: {album}");
                Console.WriteLine($"Año: {album}");
                Console.WriteLine($"Comentario: {comentario}");
                Console.WriteLine($"Genero (codigo): {genero}");
            }else
            {
                Console.WriteLine("Sin etiqueta ID3v1");
            }
        }else
        {
            Console.WriteLine("Archivo demasiado pequeño");
        }
    }
}else
{
    Console.WriteLine("No existe el archivo");
}