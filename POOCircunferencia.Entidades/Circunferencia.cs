using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOCircunferencia.Entidades
{
    public class Circunferencia
    {
        public int Radio { get; set; }

        //Constructores

        //Constructor por defecto
        public Circunferencia()
        {

        }
        //Constructor sobrecargado
        public Circunferencia(int radio)
        {
            Radio = radio;
        }
        //Métodos
        public double GetPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
        public double GetSuperficie() => Math.PI * Math.Pow(Radio, 2);
        public bool Validar()
        {
            return Radio > 0;
        }

    }
}
