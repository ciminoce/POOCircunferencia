using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POOCircunferencia.Entidades;

namespace POOCircunferencia.Datos
{
    public static class ManejadorArchivoSecuencial
    {
        private static string archivo = "Circunferencias.txt";
        public static void GuardarEnArchivoSecuencia(List<Circunferencia> lista)
        {
            //Creo el objeto que va a escribir en el archivo secuencial
            using (var escritor = new StreamWriter(archivo))
            {
                //Recorro la lista de circunferencias
                foreach (var circunferencia in lista)
                {
                    //creo la linea a escribir
                    string linea = ConstruirLinea(circunferencia);
                    escritor.WriteLine(linea);

                }
            }
        }
        public static List<Circunferencia> LeerArchivoSecuencia()
        {
            List<Circunferencia> lista = new List<Circunferencia>();
            using (var lector=new StreamReader(archivo))
            {

                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    Circunferencia circ = ConstuirCircunferencia(linea);
                    lista.Add(circ);
                }

            }
            return lista;
        }

        private static Circunferencia ConstuirCircunferencia(string linea)
        {
            //Descomponer la linea en un array de string con los campos
            return new Circunferencia() { Radio = int.Parse(linea) };
        }

        private static string ConstruirLinea(Circunferencia circunferencia)
        {
            return $"{circunferencia.Radio}";
        }
    }
}
