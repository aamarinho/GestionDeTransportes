﻿using System;
 using System.Runtime.CompilerServices;
 using System.Text;
using System.Xml;
using System.Xml.Linq;
 using GestionDeClientes.Core;
 using GestionFlotaProject.UI;
 using InterfazTransporte.Core;

namespace InterfazTransporte.Core
{
    public class Transporte
    {
        

        public Transporte(String matricula, string tipo, String cliente, DateTime fechaC, double km, DateTime fechaS, 
            DateTime fechaE, double importeD, double importeK, double iva)
        {
            this.Id = calcularId(matricula, fechaC);
            this.Vehiculo = matricula;
            this.Tipo = tipo;
            this.Cliente = cliente;
            this.FechaContrato = fechaC;
            this.Km = km;
            this.FechaSalida = fechaS;
            this.FechaEntrega = fechaE;
            this.ImporteDia = importeD;
            this.ImporteKm = importeK;
            this.Iva = iva;
        }

        private static string calcularId(string matricula, DateTime fecha)
        {
            StringBuilder toret = new StringBuilder();
            var aux1 = matricula.Substring(0,3);
            var aux2 = matricula.Substring(3, 4);
            var array1 = fecha.ToString().Split(' ');
            var array2 = array1[0].Split('/');
  
            toret.Append(aux2);
            toret.Append(aux1);
            toret.Append(array2[2]);
            toret.Append(array2[1]);
            toret.Append(array2[0]);

            return toret.ToString();
        }

        public XElement ToXML()
        {
  
            string fc = this.FechaContrato.ToString().Split(' ')[0];
            string fs = this.FechaSalida.ToString().Split(' ')[0];
            string fe= this.FechaEntrega.ToString().Split(' ')[0];
  
      
  
            var doc = new XElement("transporte",
                new XElement("id", this.Id),
                new XElement("vehiculo", this.Vehiculo),
                new XElement("tipo", this.Tipo),
                new XElement("cliente", this.Cliente),
                new XElement("fechaContrato",fc),
                new XElement("kilometros", this.Km),
                new XElement("fechaSalida",  fs),
                new XElement("fechaEntrega", fe),
                new XElement("importeDia", this.ImporteDia),
                new XElement("importeKm", this.ImporteKm),
                new XElement("iva", this.Iva));
  
  
  

            return doc;
        }




        public string toString()
        {
            StringBuilder toret = new StringBuilder();

            toret.AppendLine("Transporte: ");
            toret.AppendLine("\tID: " + this.Id);
            toret.AppendLine("\tCliente: " + this.Cliente);
            toret.AppendLine("\tTipo: " + this.Tipo);
            toret.AppendLine("\tFechaContrato: " + this.FechaContrato.Date.ToString());
            toret.AppendLine("\tFechaSalida: " + this.FechaSalida.Date.ToString());
            toret.AppendLine("\tFechaEntrega: " + this.FechaEntrega.Date.ToString());
            toret.AppendLine("\tKms: " + this.Km);
            toret.AppendLine("\tImporteDia: " + this.ImporteDia);
            toret.AppendLine("\tImporteKm: " + this.ImporteKm);
            toret.AppendLine("\tIva: " + this.Iva);

            return toret.ToString();
        }

        public string Id
        {
            get;
            set;
        }

        public string Vehiculo
        {
            get;
            set;
        }

        public string Tipo
        {
            get;
            set;
        }

        public string Cliente
        {
            get;
            set;
        }

        public DateTime FechaContrato
        {
            get;
            set;
        }

        public double Km
        {
            get;
            set;
        }

        public DateTime FechaSalida
        {
            get;
            set;
        }

        public DateTime FechaEntrega
        {
            get;
            set;
        }

        public double ImporteDia
        {
            get;
            set;
        }

        public double ImporteKm
        {
            get;
            set;
        }

        public double Iva { get; set; }
    }
}
