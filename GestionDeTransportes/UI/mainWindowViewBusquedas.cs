﻿using System;
 using System.Drawing;

 namespace Busquedas_DIA6
{
    using WFrms = System.Windows.Forms;
    public class mainWindowViewBusquedas : WFrms.Form
    {
        public mainWindowViewBusquedas()
        {
            this.Build();
            this.MinimumSize = new Size(900, 500);
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
			mainPanel.Controls.Add(this.buildOpr());
            mainPanel.Controls.Add(this.BuildOpl());
            mainPanel.Controls.Add(this.BuildOp2());
            mainPanel.Controls.Add(this.BuildRes());

            this.Controls.Add(mainPanel);
        }

        WFrms.Panel BuildOpl()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblOpl = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Parámetro de busqueda"
            };

            this.EdOpl = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = ""
            };

            pnl.Controls.Add(this.EdOpl);
            pnl.Controls.Add(lblOpl);
            return pnl;
        }



        WFrms.Panel BuildOp2()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblOp2 = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Año (si es necesario)"
            };

            this.EdOp2 = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = ""
            };
   
            pnl.Controls.Add(this.EdOp2);
            pnl.Controls.Add(lblOp2);
            return pnl;
        }

        WFrms.Panel BuildRes()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblRes = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Resultado de la busqueda"
            };

            this.EdRes = new WFrms.TextBox
            {
                ScrollBars = WFrms.ScrollBars.Vertical,
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = ""
            };

			this.EdRes.Multiline = true;
            pnl.Controls.Add(this.EdRes);
            pnl.Controls.Add(lblRes);
            return pnl;
        }

        WFrms.Panel buildOpr()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            this.ButtonBuscar = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Right,
                BackColor = Color.Turquoise,
                Text = "BUSCAR"
            };

			//this.ButtonBuscar.Items.AddRange(new string[] { "Reservas por cliente", "Reservas por cliente y año", "Reservas por camion" , "Reservas por camion y año", "Ocupacion fecha", "Ocupacion año" , "Transportes pendientes" , "Disponibilidad" });
            //this.ButtonBuscar.SelectedIndex = 0;         
            pnl.Controls.Add(this.ButtonBuscar);

            return pnl;
        }

        public WFrms.TextBox EdOpl
        {
            get; private set;
        }

        public WFrms.TextBox EdOp2
        {
            get; private set;
        }

        public WFrms.TextBox EdRes
        {
            get; private set;
        }

        public WFrms.Button ButtonBuscar
        {
            get; private set;
        }

    }
}