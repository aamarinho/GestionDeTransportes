﻿using System;
using System.Drawing;
using System.Windows.Forms;

using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Text;

namespace Proyecto.Properties
{
    public class GraficoCamion : Form
    {
        public const int ChartCanvasSize = 512;
        int Enero;
        int Febrero;
        int Marzo;
        int Abril;
        int Mayo;
        int Junio;
        int Julio;
        int Agosto;
        int Septiembre;
        int Octubre;
        int Noviembre;
        int Diciembre;

		public GraficoCamion(string tipo)
        {

			try
			{

				//Console.WriteLine("dime el tipo de camion");
				//string tipo = Console.ReadLine();

				this.Build();

				this.Chart.LegendY = "Tranportes";
				this.Chart.LegendX = "Meses";


				//StringBuilder result = new StringBuilder();
				foreach (XElement level1Element in XElement.Load("Transportes.xml").Elements("transporte"))
				{

					String split = level1Element.Element("id").Value.Substring(11, 2);
					String toret = level1Element.Element("vehiculo").Value;

					if (toret == tipo)
							{
								switch (split)
								{
									case "01":
										Enero++;
										break;
									case "02":
										Febrero++;
										break;
									case "03":
										Marzo++;
										break;
									case "04":
										Abril++;
										break;
									case "05":
										Mayo++;
										break;
									case "06":
										Junio++;
										break;
									case "07":
										Julio++;
										break;
									case "08":
										Agosto++;
										break;
									case "09":
										Septiembre++;
										break;
									case "10":
										Octubre++;
										break;
									case "11":
										Noviembre++;
										break;
									case "12":
										Diciembre++;
										break;
									default:
										Console.WriteLine("Error");
										break;
								}
							}
						
					

				}



				this.Chart.Values = new[] { Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre };
				this.Chart.Draw();
			}catch(Exception){
				//Console.WriteLine("Error al insertar tipo,poner uno que exista", e);
				//new PanelAviso();
			}
        }

        private void Build()
        {
            this.Chart = new Chart(width: ChartCanvasSize,
                height: ChartCanvasSize)
            {
                Dock = DockStyle.Fill,
            };

            this.Controls.Add(this.Chart);
            this.MinimumSize = new Size(ChartCanvasSize, ChartCanvasSize);
            this.Text = this.GetType().Name;
        }


        public Chart Chart
        {
            get; private set;
        }
    }
}