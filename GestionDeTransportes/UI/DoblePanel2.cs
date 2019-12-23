﻿using System;
using System.Drawing;
using System.Windows.Forms;
 using System.Xml.Linq;
 using System.Collections.Generic;

namespace Proyecto.Properties
{
    public class DoblePanel2 : Form
    {

		//TextBox tbCamion = new TextBox();
		ComboBox tbCamion = new ComboBox();
        string tipo;
        //private string[] array;

        

        public DoblePanel2()
        {
            this.Build();
        }



        private void ViewGraficoCamion()
        {

			tipo = tbCamion.Text;
            new GraficoCamion(tipo).Show();
        }

        public string[] CogerMatriculas()
        {
            
            List<string> lista = new List<string>();
            
            
            foreach (XElement level1Element in XElement.Load("vehiculos.xml").Elements("vehiculo"))
            {

                
                    lista.Add(level1Element.Element("matricula").Value);
                    


            }

            
            return lista.ToArray();
        }


        private void Build()
        {
            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;
            pnlTable.Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

            var btFirst = new Button();
            //var tbCamion = new TextBox();

            //string nombre;
            //nombre = tbCamion.Text;




            btFirst.Text = "Ver grafico(elegir antes matricula camion)";
            btFirst.Dock = DockStyle.Top;
            btFirst.BackColor = Color.Turquoise;
			//tbCamion.Text = "Tipo de camion";
			tbCamion.Items.AddRange(CogerMatriculas());
			tbCamion.SelectedIndex = 0;
            tbCamion.Margin=new Padding(10,10,10,10);
            tbCamion.Dock = DockStyle.Bottom;


            btFirst.Click += (sender, args) => ViewGraficoCamion();




            pnlTable.Controls.Add(btFirst);
            pnlTable.Controls.Add(tbCamion);





            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

            this.Text = this.GetType().Name;
            this.MinimumSize = new Size(320, 240);
        }


    }
}