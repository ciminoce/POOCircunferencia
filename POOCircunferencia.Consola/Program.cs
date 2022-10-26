using POOCircunferencia.Datos;
using POOCircunferencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOCircunferencia.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioDeCircunferencias repo = new RepositorioDeCircunferencias();
            Circunferencia circ = new Circunferencia(20);
            repo.Agregar(circ);
            Console.WriteLine(circ.Radio.ToString());
            Console.WriteLine(circ.GetPerimetro());
            Console.WriteLine(circ.GetSuperficie());
            Circunferencia circ2 = new Circunferencia() { Radio=4};
            repo.Agregar(circ2);
            var circ3 = new Circunferencia();
            circ3.Radio = -10;
            if (circ3.Validar())
            {
                repo.Agregar(circ3);

            }
            else
            {
                Console.WriteLine("Circunferencia no válida");
            }
            var lista = repo.GetLista();
            MostrarListaCirc(lista);
            Console.ReadLine();
        }

        private static void MostrarListaCirc(List<Circunferencia> lista)
        {
            foreach (var circ in lista)
            {
                Console.WriteLine(circ.Radio);
            }
        }
    }
}
