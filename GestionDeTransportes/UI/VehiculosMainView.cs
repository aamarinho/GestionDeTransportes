﻿using System.Windows.Forms;

namespace GestionFlotaProject.UI
{
    using WFrms = System.Windows.Forms;
    using System.Drawing;
    public partial class VehiculosMainView : WFrms.Form
    {
        public VehiculosMainView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock=DockStyle.Fill,
                Location = new Point(0,0),
                BackColor = Color.Black,
                Text = "GESTION DE FLOTA"
            };
            //mainPanel.Controls.Add(this.buildXML());
            mainPanel.Controls.Add(this.buildListaYBoton());
            
            
            this.Controls.Add(mainPanel);
        }

        private WFrms.Panel buildXML(){
            
                var pnl = new WFrms.Panel
                {
                    Dock = WFrms.DockStyle.Top
                };
            
                this.BotonGuardar = new WFrms.Button
                {
                    Dock = WFrms.DockStyle.Left,
                    Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Size = new Size(120, 30),
                    BackColor = Color.Azure,
                    Margin = new WFrms.Padding(3, 2, 3, 2),
                    Text = "GUARDAR"
                };
            
                this.BotonRecuperar = new WFrms.Button()
                {
                    Dock = WFrms.DockStyle.Right,
                    Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Size = new Size(120, 30),
                    BackColor = Color.Azure,
                    Margin = new WFrms.Padding(3, 2, 3, 2),
                    Text = "RECUPERAR"
                };
            
                pnl.Controls.Add(this.BotonGuardar);
                pnl.Controls.Add(this.BotonRecuperar);
            
                return pnl;
        }

        private WFrms.Panel buildListaYBoton()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Fill
            };
            
            /*this.BotonInsertar = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Left,
                Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Size = new Size(120, 60),
                BackColor = Color.Turquoise,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "INSERTAR VEHICULO"
            };*/
            
            this.Lista = new WFrms.ListView
            {
                Dock = WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.White,
                Margin = new WFrms.Padding(3, 5, 3, 5)
            };

            //pnl.Controls.Add(this.BotonInsertar);
            pnl.Controls.Add(this.Lista);
            
            return pnl;
        }

       

        public WFrms.ListView Lista { get; private set; }

        public WFrms.Button BotonInsertar { get; private set; }
        
        public WFrms.Button BotonGuardar { get; private set; }
        
        public WFrms.Button BotonRecuperar { get; private set; }
        
    }
}