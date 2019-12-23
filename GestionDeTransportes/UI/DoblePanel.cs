﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto.Properties
{
    public class DoblePanel : Form
    {

		TextBox tbCliente = new TextBox();
		string nombre;

        public DoblePanel()
        {
            this.Build();
        }
        

        
        private void ViewGraficoCliente()
        {
			nombre = tbCliente.Text;
            new GraficoCliente(nombre).Show();
        }




        private void Build()
        {
            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;
            pnlTable.Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);


            var btFirst = new Button();
            //var tbCliente = new TextBox();

            //string nombre;
            //nombre = tbCliente.Text;




            btFirst.Text = "Ver grafico(insertar antes NIF cliente)";
            btFirst.BackColor = Color.Turquoise;
            btFirst.Dock = DockStyle.Top;
            tbCliente.Text = "NIF del cliente";
            tbCliente.BackColor = Color.Turquoise;
            tbCliente.Dock = DockStyle.Bottom;

            
            btFirst.Click += (sender, args) => ViewGraficoCliente();
            



            pnlTable.Controls.Add(btFirst);
            pnlTable.Controls.Add(tbCliente);





            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

            this.Text = this.GetType().Name;
            this.MinimumSize = new Size(320, 240);
        }







    }
}