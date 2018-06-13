using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntMayo_Ejercicio4
{
    class Program
    {
        static void EstadisticasNBA()
        {
            //Variables
            double puntos;
            double media;
            int cantidad;
            string nombre;
            List<string> listaNombres = new List<string>();
            List<double> listaPuntos = new List<double>();
            //Get the files
            string[] archivos;
            archivos = Directory.GetFiles(".", "*.stat");
            for (int i = 0; i < archivos.Length; i++)
            {
                puntos = 0;
                cantidad = 0;
                //Reading the file and making the loop
                FileStream fs = new FileStream(archivos[i], FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                while (fs.Position < fs.Length)
                {
                    puntos = puntos + br.ReadInt32();
                    cantidad++;
                }
                nombre = Path.GetFileNameWithoutExtension(archivos[i]);
                media = puntos / cantidad;
                media = Math.Round(media, 2);
                br.Close();
                fs.Close();
                //Add the stats to the list
                listaNombres.Add(nombre);
                listaPuntos.Add(media);
                //End of the loop
            }
            //Sort the list, by score and name
            int cont = 0;
            int posicionMax;
            double maximo;
            while (0 < listaNombres.Count)
            {
                maximo = listaPuntos.Max();
                posicionMax = listaPuntos.IndexOf(maximo);
                Console.WriteLine(listaNombres[posicionMax].PadRight(30) + listaPuntos[posicionMax].ToString("f2").PadLeft(5));
                listaPuntos.RemoveAt(posicionMax);
                listaNombres.RemoveAt(posicionMax);
            }
        }
        static void Main(string[] args)
        {
            EstadisticasNBA();
            Console.ReadKey();
        }
    }
}
