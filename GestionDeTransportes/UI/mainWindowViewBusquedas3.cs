﻿using System;
 using System.Drawing;
namespace Busquedas_DIA6
{
    using WFrms = System.Windows.Forms;
    public class mainWindowViewBusquedas3 : WFrms.Form
    {
        public mainWindowViewBusquedas3()
        {
            this.Build();
            this.MinimumSize = new Size(900, 400);
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
                Text = "Año"
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
            pnl.Controls.Add(this.ButtonBuscar);

            return pnl;
        }

        public WFrms.TextBox EdOpl
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