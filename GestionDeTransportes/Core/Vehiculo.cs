﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFlotaProject.UI
{
    public class Vehiculo
    {
        public Vehiculo(string matricula, string tipo, string marca,string modelo, string consumo, string fechaAdquisicion, string fechaFabricacion, List<string> comodidades)
        {
            Matricula = matricula;
            Tipo = tipo;
            Marca = marca;
            Modelo = modelo;
            Consumo = consumo;
            FechaAdquisicion = fechaAdquisicion;
            FechaFabricacion = fechaFabricacion;
            Comodidades = comodidades;
        }

        public Vehiculo(string matricula)
        {
            this.Matricula = matricula;
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();

            toret.Append(Matricula)
                .Append(", ")
                .Append(Tipo);

            return toret.ToString();
        }
        
        public string Matricula { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        
        public string Modelo { get; set; }
        
        public string Consumo { get; set; }
        public string FechaAdquisicion { get; set; }
        
        public string FechaFabricacion { get; set; }
        public List<string> Comodidades { get; set; }
    }
}