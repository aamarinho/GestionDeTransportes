﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto.Properties
{
    public class PanelAviso:Form
    {
        public PanelAviso()
        {
            this.Build();
        }
        
        private void Build()
        {
            //var pnlTable = new TableLayoutPanel();

			//var tbAviso = new TextBox();
			string mensaje = "ERROR: DATO INCORRECTO";
			DialogResult toret;
            
            //pnlTable.SuspendLayout();
            //pnlTable.Dock = DockStyle.Fill;

			/*var lblOpl = new Label
            {
                Text = "ERROR: DATO INCORRECTO"
            };*/


			toret = MessageBox.Show(mensaje);
            //tbAviso.Text = "ERROR";


            //pnlTable.Controls.Add(tbAviso);
            //pnlTable.Controls.Add(lblOpl);


            //pnlTable.ResumeLayout(false);
            //this.Controls.Add(pnlTable);

            //this.Text = this.GetType().Name;
            //this.MinimumSize = new Size(320, 240);
        }
    }
}