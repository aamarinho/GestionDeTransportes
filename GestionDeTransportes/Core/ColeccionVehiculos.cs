﻿using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GestionFlotaProject.UI
{
    public class ColeccionVehiculos
    {
        public ColeccionVehiculos()
        {
            Vehiculos = new List<Vehiculo>();
        }

        public void Inserta(Vehiculo v)
        {
            Vehiculos.Add(v);
        }
        
        public void Elimina(Vehiculo v) {
            if (Vehiculos.Contains(v)) {
                foreach (Vehiculo actual in Vehiculos) {
                    if (actual.Matricula.Equals(v.Matricula)) {
                        Vehiculos.Remove(v);
                        break;
                    }
                }
            }
        }
        
        public int Posicion(Vehiculo v)
        {
            int i = 0; //ver en que posición está el vehiculo que se desea modificar
            if(Vehiculos.Contains(v)){
                foreach(Vehiculo actual in Vehiculos){
                    if(actual.Matricula.Equals(v.Matricula)){
                        break;
                    }
                    i++;
                }
            }
            return i;
        }

        public string VuelcaXML()
        {
            using (var xw = new XmlTextWriter("vehiculos.xml", Encoding.UTF8))
            {
                xw.WriteStartElement("vehiculos");

                foreach(Vehiculo v in Vehiculos)
                {
                    string matricula = v.Matricula;
                    string tipo = v.Tipo;
                    string marca = v.Marca;
                    string modelo = v.Modelo;
                    string consumo = v.Consumo;
                    string fechaAdquisicion = v.FechaAdquisicion;
                    string fechaFabricacion = v.FechaFabricacion;
                    List<string> comodidades = v.Comodidades;
                    xw.WriteStartElement("vehiculo");
                    
                    xw.WriteStartElement("matricula");
                    xw.WriteString(matricula);
                    xw.WriteEndElement();
                    xw.WriteStartElement("tipo");
                    xw.WriteString(tipo);
                    xw.WriteEndElement();
                    xw.WriteStartElement("marca");
                    xw.WriteString(marca);
                    xw.WriteEndElement();
                    xw.WriteStartElement("modelo");
                    xw.WriteString(modelo);
                    xw.WriteEndElement();
                    xw.WriteStartElement("consumo");
                    xw.WriteString(consumo);
                    xw.WriteEndElement();
                    xw.WriteStartElement("fecha_adquisicion");
                    xw.WriteString(fechaAdquisicion);
                    xw.WriteEndElement();
                    xw.WriteStartElement("fecha_fabricacion");
                    xw.WriteString(fechaFabricacion);
                    xw.WriteEndElement();
                    xw.WriteStartElement("comodidades");
                    foreach (string c in comodidades) {
                        xw.WriteStartElement("comodidad");
                        xw.WriteString(c);
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();

                    xw.WriteEndElement();
                }

                xw.WriteEndElement();
                xw.Close();
                return xw.ToString();
            }
        }
        
        public Vehiculo[] LeerVehiculosXmlDom()
        {
            var doc = new XmlDocument();
            var toret = new List<Vehiculo>();

            doc.Load("vehiculos.xml");

            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string matricula = "";
                string tipo = "";
                string marca= "";
                string modelo= "";
                string consumo= "";
                string fechaAdquisicion= "";
                string fechaFabricacion= "";
                List<string> comodidades=new List<string>();

                foreach(XmlNode subnode in node)
                {
                    if(subnode.Name == "matricula")
                    {
                        matricula = subnode.InnerText;
                    } else if(subnode.Name == "tipo")
                    {
                        tipo = subnode.InnerText;
                    } else if(subnode.Name == "marca")
                    {
                        marca = subnode.InnerText;
                    } else if(subnode.Name == "modelo")
                    {
                        modelo = subnode.InnerText;
                    } else if(subnode.Name == "consumo")
                    {
                        consumo = subnode.InnerText;
                    } else if(subnode.Name == "fecha_adquisicion")
                    {
                        fechaAdquisicion = subnode.InnerText;
                    } else if(subnode.Name == "fecha_fabricacion")
                    {
                        fechaFabricacion = subnode.InnerText;
                    }
                    foreach (XmlNode comodidad in subnode)
                    {
                        if(comodidad.Name == "comodidad")
                        {
                            comodidades.Add(comodidad.InnerText);
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(matricula))
                {
                    toret.Add(new Vehiculo(matricula,tipo,marca,modelo,consumo,fechaAdquisicion,fechaFabricacion,comodidades));
                }
            }
            return toret.ToArray();
        }
        
        public List<Vehiculo> Vehiculos { get; set; }
    }
}