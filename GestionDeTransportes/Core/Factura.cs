﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace GestionTransporte.Core
{
    public class Factura
    {

        //No disponible todavia
        //Cliente cli;

        private const double IVA = 0.21;

        private double Ppd; //Precio por dia (sueldo*hora)*8 
        private int Numd; //Numero de dias
        private double Ppkm; //Precio por kilometro 
        private double Km; //Numero kilometros

        private double Gas; //Total de la gasolina consumida

        //Datos
        private int Suplencia = 1; //Si el numd es >1 entonces es 2
        private double PrecioCombustibleKm; // Precio combustible por km





        string id;
        string clienteid;
        string precioLcom;
        string numd;
        string ppd;
        string suplencia;
        string km;
        string ppkm;
        string gas;
        string total;

       




        public Factura(double Ppd, int Numd, double Km, double Gas, double PrecioCombustibleKm, double importekm)
        {

            this.Ppd = Ppd;
            this.Numd = Numd;
            this.PrecioCombustibleKm = PrecioCombustibleKm;
            //this.Ppkm = 3 * PrecioCombustibleKm;
            this.Ppkm =  importekm;
            this.Km = Km;
            if (Numd > 1)
            {
                this.Suplencia = 2;
            }
            this.Gas = Gas;

        }


        public Factura(string id, string clienteid, string precioLcom, string numd, string ppd, string suplencia, string km, string ppkm, string gas, string total) {

            this.id = id;
            this.clienteid = clienteid;
            this.precioLcom = precioLcom;
            this.numd = numd;
            this.ppd = ppd;
            this.suplencia = suplencia;
            this.km = km;
            this.ppkm = ppkm;
            this.gas = gas;
            this.total = total;

        
        }


        public double getPrecioFactura()
        {

            double PrecioTotal = (Numd * Ppd * Suplencia) + (Km * Ppkm) + Gas;

            double PrecioTotalIVA = PrecioTotal * IVA + PrecioTotal;


            return PrecioTotalIVA;
        }
        //No se usa
        public string toString()
        {
            StringBuilder toret = new StringBuilder();


            toret.Append("Cliente");
            toret.AppendLine("Precio por día:      ");
            toret.Append(this.Ppd);
            toret.AppendLine("Número de días:      ");
            toret.Append(this.Numd);
            toret.AppendLine("Km:      ");
            toret.Append(this.Km);
            toret.AppendLine("IVA:      ");
            toret.Append(IVA);
            toret.Append("------------------------------");
            toret.Append("Precio Total:      ");
            toret.Append(getPrecioFactura());


            return toret.ToString();
        }

        
        public void toXml()
        {

            var doc = XElement.Load("facturas.xml");



            doc.Add(new XElement("factura",
                new XElement("ID", id),
                new XElement("Cliente", clienteid),
                new XElement("PrecioLporKilometro", precioLcom),
                new XElement("NumeroDias", numd),
                new XElement("PrecioDia", ppd),
                new XElement("Suplencia", suplencia),
                new XElement("Km", km),
                new XElement("PrecioKm", ppkm),
                new XElement("Gas", gas),
                new XElement("Total", total)));





            doc.Save("facturas.xml");

        }




        public static void crearFacturaXml(string id,string clienteid,string precioLcom,string numd,string ppd,string suplencia,string km,string ppkm,string gas,string total) {
            
            var doc = XElement.Load("facturas.xml");


            
            doc.Add(new XElement("factura",
                new XElement("ID", id),
                new XElement("Cliente", clienteid),
                new XElement("PrecioLporKilometro", precioLcom),
                new XElement("NumeroDias",numd),
                new XElement("PrecioDia",ppd),
                new XElement("Suplencia",suplencia),
                new XElement("Km",km),
                new XElement("PrecioKm",ppkm),
                new XElement("Gas",gas),
                new XElement("Total",total)));
            
            



            doc.Save("facturas.xml");

        }


        public static string buscarClienteID(string transporte)
        {
            string error = "No encontrado";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("cliente");

            foreach (string el in facturadatos)
            {


                
                return el;

            }
            return error;
        }

        public static string buscarClienteNom(string nif)
        {
            string error = "No encontrado";

            XElement raiz = XElement.Load("clientes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("cliente")
                where (string)el.Element("NIF") == nif
                select (string)el.Element("Nombre");

            foreach (string el in facturadatos)
            {


               
                return el;

            }
            return error;
        }

        public static string buscarClienteTel(string nif)
        {
            string error = "No encontrado";

            XElement raiz = XElement.Load("clientes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("cliente")
                where (string)el.Element("NIF") == nif
                select (string)el.Element("Telefono");

            foreach (string el in facturadatos)
            {


                
                return el;

            }
            return error;
        }

        public static string buscarClienteEmail(string nif)
        {
            string error = "No encontrado";

            XElement raiz = XElement.Load("clientes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("cliente")
                where (string)el.Element("NIF") == nif
                select (string)el.Element("Email");

            foreach (string el in facturadatos)
            {


               
                return el;

            }
            return error;
        }

        public static string buscarClienteDir(string nif)
        {
            string error = "No encontrado";

            XElement raiz = XElement.Load("clientes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("cliente")
                where (string)el.Element("NIF") == nif
                select (string)el.Element("Direccion");

            foreach (string el in facturadatos)
            {


                
                return el;

            }
            return error;
        }






        public static void buscarTransporteLinqImprimir(string transporte) {

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el;

        foreach(string el in facturadatos) {


                System.Console.WriteLine(el);

        
        }
        }


        public static string buscarTransporteLinqFechaSalida(string transporte)
        {
            string toret = "01/01/2019";
            toret = "22/10/2019";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("fechaSalida");

            foreach (string el in facturadatos)
            {


                
                return el;


            }
            return toret;
        }

        public static string buscarTransporteLinqFechaEntrega(string transporte)
        {
            string toret = "01/01/2019";
            toret = "22/10/2019";


            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("fechaEntrega");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }

        public static string buscarTransporteLinqImporteDia(string transporte)
        {
            string toret = "0";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("importeDia");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }
        
        
        public static string buscarTransporteLinqImportekm(string transporte)
        {
            string toret = "0";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("importeKm");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }

        public static string buscarTransporteLinqKm(string transporte)
        {
            string toret = "0";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("kilometros");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }

        //Pendiente de que se cree el IVA
        public static string buscarTransporteLinqIVA(string transporte)
        {
            string toret = "21";

            XElement raiz = XElement.Load("Transportes.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("transporte")
                where (string)el.Element("id") == transporte
                select (string)el.Element("iva");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }

        //Pendiente de recortar el dato consumo, formato actual ej: 8.0L/100KM
        public static string buscarTransporteLinqConsumoKm(string matriculaid)
        {
            string toret = "0000";

            XElement raiz = XElement.Load("vehiculos.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("vehiculo")
                where (string)el.Element("matricula") == matriculaid
                select (string)el.Element("consumo");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }



        public static string buscarFacturaPrecioLcon(string id)
        {
            string toret = "0";

            XElement raiz = XElement.Load("facturas.xml");

            IEnumerable<string> facturadatos =
                from el in raiz.Elements("factura")
                where (string)el.Element("ID") == id
                select (string)el.Element("PrecioLporKilometro");

            foreach (string el in facturadatos)
            {


                return el;


            }

            return toret;
        }



        

    }
}