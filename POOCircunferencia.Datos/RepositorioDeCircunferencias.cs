﻿using POOCircunferencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOCircunferencia.Datos
{
    public class RepositorioDeCircunferencias
    {
        private List<Circunferencia> listaCircunferencia;
        public RepositorioDeCircunferencias()
        {
            listaCircunferencia = new List<Circunferencia>();
            //Se agregan circ hardcodeadas a los efectos de
            //probar métodos
            var circ = new Circunferencia(20);
            var circ2 = new Circunferencia(5);
            var circ3 = new Circunferencia(17);
            var circ4 = new Circunferencia(24);
            Agregar(circ);
            Agregar(circ2);
            Agregar(circ3);
            Agregar(circ4);
        }
        /// <summary>
        /// Método para agregar un obj Circunferencia a la lista
        /// </summary>
        /// <param name="c1">Parámetro de tipo Circunferencia</param>
        public void Agregar(Circunferencia c1)
        {
            listaCircunferencia.Add(c1);
        }
        /// <summary>
        /// Método para retornar la cantidad de elementos de la lista
        /// </summary>
        public int GetCantidad()
        {
            return listaCircunferencia.Count;
        }
        /// <summary>
        /// Método para devolver la lista de circunferencia del repositorio
        /// </summary>
        /// <returns></returns>
        public List<Circunferencia> GetLista()
        {
            return listaCircunferencia;
        }
    }
}