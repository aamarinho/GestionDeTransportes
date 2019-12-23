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
    public class GraficoComodidad:Form
    {
      public const int ChartCanvasSize = 512;
        int Wifi;
        int Blue;
        int Aire;
        int Litera;
        int Tv;
        

        public GraficoComodidad()
        {
            this.Build();

            this.Chart.LegendY = "Transportes";
            this.Chart.LegendX = "Wifi     Bluetooth     Aire       Litera           TV";


            //StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("vehiculos.xml").Elements("vehiculo"))
            {
                foreach (XElement sublevel in level1Element.Elements("comodidades"))
                {
                    
                    foreach (XElement split in sublevel.Elements("comodidad"))
                    {

                        if (split.Value.Equals("wifi"))
                            Wifi++;
                        if (split.Value.Equals("bluetooth"))
                            Blue++;
                        if (split.Value.Equals("aire acondicionado"))
                            Aire++;
                        if (split.Value.Equals("litera"))
                            Litera++;
                        if (split.Value.Equals("tv"))
                            Tv++;
                    }
                }
            }



            this.Chart.Values = new[] { Wifi, Blue, Aire, Litera, Tv };
            this.Chart.Draw();
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