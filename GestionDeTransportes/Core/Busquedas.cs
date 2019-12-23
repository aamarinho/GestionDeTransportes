using System;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Busquedas_DIA6
{
    public class Busquedas
    {
        public Busquedas()
        {
        }

        public string ReservasPorCliente(String cliente, String year)
        {

            StringBuilder result = new StringBuilder();
            Console.WriteLine("test");
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                Console.WriteLine(level1Element.Element("cliente").Value + "test2");
                if (level1Element.Element("cliente").Value == cliente)
                {
                    String split = level1Element.Element("id").Value.Substring(7, 4); 
                    if(Regex.IsMatch(year, "^(19|20)[0-9][0-9]")){
                        Console.WriteLine("por aqui");
                        if (split == year)
                    {
                        result.AppendLine("id: " + level1Element.Element("id").Value);
                        result.AppendLine(" ");
                        result.AppendLine("tipo: " + level1Element.Element("tipo").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaContrato: " + level1Element.Element("fechaContrato").Value);
                        result.AppendLine(" ");
                        result.AppendLine("km: " + level1Element.Element("kilometros").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaSalida: " + level1Element.Element("fechaSalida").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaEntrega: " + level1Element.Element("fechaEntrega").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeDia: " + level1Element.Element("importeDia").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeKm: " + level1Element.Element("importeKm").Value);
                        result.AppendLine(" ");
                        result.AppendLine("iva: " + level1Element.Element("iva").Value);
                        result.AppendLine(" ");
                    }

                    }else{
	                    
                        result.AppendLine("id: " + level1Element.Element("id").Value);
                        result.AppendLine(" ");
                        result.AppendLine("tipo: " + level1Element.Element("tipo").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaContrato: " + level1Element.Element("fechaContrato").Value);
                        result.AppendLine(" ");
                        result.AppendLine("km: " + level1Element.Element("kilometros").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaSalida: " + level1Element.Element("fechaSalida").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaEntrega: " + level1Element.Element("fechaEntrega").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeDia: " + level1Element.Element("importeDia").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeKm: " + level1Element.Element("importeKm").Value);
                        result.AppendLine(" ");
                        result.AppendLine("iva: " + level1Element.Element("iva").Value);
                        result.AppendLine(" ");
                        

                    }
                    
                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

        public string ReservasPorCamion(String camion, String year)
        {

            StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                String split = level1Element.Element("id").Value.Substring(0, 7);
                if (split == camion)
                {
                    String split2 = level1Element.Element("id").Value.Substring(7, 4);
                    if(Regex.IsMatch(year, "^(19|20)[0-9][0-9]")){
	                    if (split2 == year)
                        {
                            result.AppendLine("id: " + level1Element.Element("id").Value);
                            result.AppendLine(" ");
                            result.AppendLine("tipo: " + level1Element.Element("tipo").Value);
                            result.AppendLine(" ");
                            result.AppendLine("cliente: " + level1Element.Element("cliente").Value);
                            result.AppendLine(" ");
                            result.AppendLine("fechaContrato: " + level1Element.Element("fechaContrato").Value);
                            result.AppendLine(" ");
                            result.AppendLine("kilometros: " + level1Element.Element("kilometros").Value);
                            result.AppendLine(" ");
                            result.AppendLine("fechaSalida: " + level1Element.Element("fechaSalida").Value);
                            result.AppendLine(" ");
                            result.AppendLine("fechaEntrega: " + level1Element.Element("fechaEntrega").Value);
                            result.AppendLine(" ");
                            result.AppendLine("importeDia: " + level1Element.Element("importeDia").Value);
                            result.AppendLine(" ");
                            result.AppendLine("importeKm: " + level1Element.Element("importeKm").Value);
                            result.AppendLine(" ");
                            result.AppendLine("IVA: " + level1Element.Element("iva").Value);
                            result.AppendLine(" ");
                        } 
                    }else{
                        result.AppendLine("id: " + level1Element.Element("id").Value);
                        result.AppendLine(" ");
                        result.AppendLine("tipo: " + level1Element.Element("tipo").Value);
                        result.AppendLine(" ");
                        result.AppendLine("cliente: " + level1Element.Element("cliente").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaContrato: " + level1Element.Element("fechaContrato").Value);
                        result.AppendLine(" ");
                        result.AppendLine("kilometros: " + level1Element.Element("kilometros").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaSalida: " + level1Element.Element("fechaSalida").Value);
                        result.AppendLine(" ");
                        result.AppendLine("fechaEntrega: " + level1Element.Element("fechaEntrega").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeDia: " + level1Element.Element("importeDia").Value);
                        result.AppendLine(" ");
                        result.AppendLine("importeKm: " + level1Element.Element("importeKm").Value);
                        result.AppendLine(" ");
                        result.AppendLine("IVA: " + level1Element.Element("iva").Value);
                        result.AppendLine(" ");
                    }
                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

		

        public string Ocupacion(String fecha)
        {

            StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                if (level1Element.Element("fechaSalida").Value.Equals(fecha))
                {
                    result.AppendLine("id: " + level1Element.Element("id").Value);
                    result.AppendLine(" ");
                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

        public string Ocupacion2(String year)
        {

            StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                String split = level1Element.Element("id").Value.Substring(7, 4);
                if (split == year)
                {
                    result.AppendLine("id: " + level1Element.Element("id").Value);
                    result.AppendLine(" ");
                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

        public string TransportesPendientes()
        {
            var hoy = DateTime.Now;
            var tmrrw = hoy.AddDays(1);
            var pasado = hoy.AddDays(2);
            var cuatro = hoy.AddDays(3);
            var cinco = hoy.AddDays(4);

            StringBuilder result = new StringBuilder();

            String dia = hoy.ToString().Substring(0, 2);
            String mes = hoy.ToString().Substring(3, 2);
            String year = hoy.ToString().Substring(6, 4);

            String dia2 = tmrrw.ToString().Substring(0, 2);
            String mes2 = tmrrw.ToString().Substring(3, 2);
            String year2 = tmrrw.ToString().Substring(6, 4);

            String dia3 = pasado.ToString().Substring(0, 2);
            String mes3 = pasado.ToString().Substring(3, 2);
            String year3 = pasado.ToString().Substring(6, 4);

            String dia4 = cuatro.ToString().Substring(0, 2);
            String mes4 = cuatro.ToString().Substring(3, 2);
            String year4 = cuatro.ToString().Substring(6, 4);

            String dia5 = cinco.ToString().Substring(0, 2);
            String mes5 = cinco.ToString().Substring(3, 2);
            String year5 = cinco.ToString().Substring(6, 4);


            String comprobar = dia + "/" + mes + "/" + year;
            String comprobar2 = dia2 + "/" + mes2 + "/" + year2;
            String comprobar3 = dia3 + "/" + mes3 + "/" + year3;
            String comprobar4 = dia4 + "/" + mes4 + "/" + year4;
            String comprobar5 = dia5 + "/" + mes5 + "/" + year5;
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                if (level1Element.Element("fechaSalida").Value.Equals(comprobar) || level1Element.Element("fechaSalida").Value.Equals(comprobar2) || level1Element.Element("fechaSalida").Value.Equals(comprobar3) || level1Element.Element("fechaSalida").Value.Equals(comprobar4) || level1Element.Element("fechaSalida").Value.Equals(comprobar5))
                {
                    result.AppendLine("id: " + level1Element.Element("id").Value);
                    result.AppendLine(" ");
                    result.AppendLine("tipo: " + level1Element.Element("tipo").Value);
                    result.AppendLine(" ");
                    result.AppendLine("cliente: " + level1Element.Element("cliente").Value);
                    result.AppendLine(" ");
                    result.AppendLine("fechaContrato: " + level1Element.Element("fechaContrato").Value);
                    result.AppendLine(" ");
                    result.AppendLine("km: " + level1Element.Element("kilometros").Value);
                    result.AppendLine(" ");
                    result.AppendLine("fechaEntrega: " + level1Element.Element("fechaEntrega").Value);
                    result.AppendLine(" ");
                    result.AppendLine("importeDia: " + level1Element.Element("importeDia").Value);
                    result.AppendLine(" ");
                    result.AppendLine("importeKm: " + level1Element.Element("importeKm").Value);
                    result.AppendLine(" ");
                    result.AppendLine("IVA: " + level1Element.Element("iva").Value);
                    result.AppendLine(" ");
                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

        public string Disponibilidad(String fecha1, String tipo)
        {
            var hoy = DateTime.Now;
            StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
            {
                var comp = DateTime.Parse(level1Element.Element("fechaEntrega").Value);
                if (DateTime.Compare(comp, hoy) > 0)
                {
                    var otr = DateTime.Parse(level1Element.Element("fechaSalida").Value);
                    var fech = DateTime.Parse(fecha1);
                    if (DateTime.Compare(otr, fech) > 0)
                    {
                        if (tipo == "Camion" || tipo == "Camion articulado" || tipo == "Furgoneta") 
                        {
                            foreach (XElement vehiculo in XElement.Load("vehiculos.xml").Elements("vehiculo"))
                            {
                                if (((vehiculo.Element("matricula").Value)==(level1Element.Element("vehiculo").Value)) && tipo==(vehiculo.Element("tipo").Value))
                                {
                                    result.AppendLine("id: " + level1Element.Element("id").Value);
                                    result.AppendLine(" ");
                                }
                            }

                        }
                        else
                        {
                            result.AppendLine("id: " + level1Element.Element("id").Value);
                            result.AppendLine(" ");
                        }
                        
                        
                    }

                }
            }

            Console.WriteLine(result);
			return result.ToString();
        }

    }
}