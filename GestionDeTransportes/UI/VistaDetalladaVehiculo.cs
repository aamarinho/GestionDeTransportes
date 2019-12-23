﻿using System.Collections.Generic;

namespace GestionFlotaProject.UI
{ 
    
using WFrms = System.Windows.Forms;
using System.Drawing;

    public partial class VistaDetalladaVehiculo : WFrms.Form
    {
        public VistaDetalladaVehiculo(Vehiculo v)
        {
            this.MinimumSize = new Size(900, 600);
            this.Build();
            this.Vehiculo = v;
        }

        private void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                AutoScroll = true,
                Dock=WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            
            mainPanel.Controls.Add(this.BuildMatricula());
            mainPanel.Controls.Add(this.BuildTipo());
            mainPanel.Controls.Add(this.BuildMarca());
            mainPanel.Controls.Add(this.BuildModelo());
            mainPanel.Controls.Add(this.BuildConsumo());
            mainPanel.Controls.Add(this.BuildFechaAdquisicion());
            mainPanel.Controls.Add(this.BuildFechaFabricacion());
            mainPanel.Controls.Add(this.BuildComodidades());
            mainPanel.Controls.Add(this.BuildBotones());
            this.Controls.Add(mainPanel);
        }

        private WFrms.Panel BuildMatricula()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblMatricula= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Matricula"
            };
            this.EdMadricula = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                ReadOnly = true,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text=""
            };
            
            pnl.Controls.Add(this.EdMadricula);
            pnl.Controls.Add(lblMatricula);
            return pnl;
        }
        WFrms.Panel BuildTipo()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblTipo= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Tipo"
            };
            this.CbTipo = new WFrms.ComboBox() {
                Dock = WFrms.DockStyle.Fill,
                DropDownStyle = WFrms.ComboBoxStyle.DropDownList,
            };
            this.CbTipo.Items.AddRange(new string[] {"Furgoneta","Camion","Camion articulado"});
            this.CbTipo.SelectedIndex = 0;
            
            pnl.Controls.Add(this.CbTipo);
            pnl.Controls.Add(lblTipo);
            
            return pnl;
        }

        private WFrms.Panel BuildMarca()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblMarca= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Marca"
            };
            this.EdMarca = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = ""
            };
            
            pnl.Controls.Add(this.EdMarca);
            pnl.Controls.Add(lblMarca);
            return pnl;
        }
        
        private WFrms.Panel BuildModelo()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblModelo= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Modelo"
            };
            this.EdModelo = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = ""
            };
            
            pnl.Controls.Add(this.EdModelo);
            pnl.Controls.Add(lblModelo);
            return pnl;
        }
        
        private WFrms.Panel BuildConsumo()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblConsumo= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Consumo"
            };
            this.EdConsumo = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = ""
            };
            
            pnl.Controls.Add(this.EdConsumo);
            pnl.Controls.Add(lblConsumo);
            return pnl;
        }
        
        private WFrms.Panel BuildFechaAdquisicion()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblFechaAdquisicion= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Fecha Adquisicion"
            };
            this.EdFechaAdquisicion = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = ""
            };
            
            pnl.Controls.Add(this.EdFechaAdquisicion);
            pnl.Controls.Add(lblFechaAdquisicion);
            return pnl;
        }

        private WFrms.Panel BuildFechaFabricacion()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblFechaFabricacion= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                Size = new Size(120,70),
                BackColor = Color.Turquoise,
                Text = "Fecha Fabricacion"
            };
            this.EdFechaFabricacion = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = ""
            };
                     
            pnl.Controls.Add(this.EdFechaFabricacion);
            pnl.Controls.Add(lblFechaFabricacion);
            return pnl;
        }
        
        private WFrms.Panel BuildComodidades()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var pnlizq = new WFrms.Panel{
                Dock = WFrms.DockStyle.Left
            };
            var pnlder = new WFrms.Panel{
                Dock = WFrms.DockStyle.Fill
            };
            var lblComodidades= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Size = new Size(120,70),
                Text = "Comodidades"
            };
            this.EdWifi = new WFrms.CheckBox {
                Dock = WFrms.DockStyle.Left,
                BackColor = SystemColors.Window,
                Text = "Wifi"
            };
            this.EdBluetooth = new WFrms.CheckBox {
                Dock = WFrms.DockStyle.Left,
                BackColor = SystemColors.Window,
                Text = "Bluetooth"
            };
            this.EdAcc = new WFrms.CheckBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Text = "Aire acondicionado"
            };
            this.EdLitera = new WFrms.CheckBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Text = "Litera de descanso"
            };
            this.EdTV = new WFrms.CheckBox {
                Dock = WFrms.DockStyle.Right,
                BackColor = SystemColors.Window,
                Text = "TV"
            };
            
            pnlder.Controls.Add(this.EdTV);
            pnlder.Controls.Add(this.EdAcc);
            pnlder.Controls.Add(this.EdWifi);
            
            pnlizq.Controls.Add(this.EdLitera);
            pnlizq.Controls.Add(this.EdBluetooth);
            
            pnl.Controls.Add(pnlder);
            pnl.Controls.Add(pnlizq);
           
            pnl.Controls.Add(lblComodidades);
            return pnl;
        }

        WFrms.Panel BuildBotones()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            this.botonModificar = new WFrms.Button {
                Dock=WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Size = new Size(100, 50),
                Text = "MODIFICAR"
            };
            this.botonEliminar = new WFrms.Button {
                Dock=WFrms.DockStyle.Right,
                BackColor = Color.Turquoise,
                Size = new Size(100, 50),
                Text = "ELIMINAR"
            };
            pnl.Controls.Add(botonModificar);
            pnl.Controls.Add(botonEliminar);
            return pnl;
        }

        public WFrms.TextBox EdMadricula { get; private set; }
        public WFrms.ComboBox CbTipo { get; set; }
        public WFrms.TextBox EdMarca { get; private set; }
        public WFrms.TextBox EdModelo { get; private set; }
        
        public WFrms.TextBox EdConsumo { get; private set; }
        public WFrms.TextBox EdFechaAdquisicion { get; private set; }
        public WFrms.TextBox EdFechaFabricacion { get; private set; }
        public WFrms.CheckBox EdWifi { get; set; }
        public WFrms.CheckBox EdBluetooth { get; set; }
        public WFrms.CheckBox EdAcc { get; set; }
        public WFrms.CheckBox EdLitera { get; set; }
        public WFrms.CheckBox EdTV { get; set; }
        public WFrms.Button botonModificar { get; private set; }
        public WFrms.Button botonEliminar { get; private set; }
        public Vehiculo Vehiculo
        {
            get { return this.vehiculo;}
            set
            {
                this.EdWifi.CheckState = WFrms.CheckState.Unchecked;
                this.EdBluetooth.CheckState = WFrms.CheckState.Unchecked;
                this.EdAcc.CheckState = WFrms.CheckState.Unchecked;
                this.EdLitera.CheckState = WFrms.CheckState.Unchecked;
                this.EdTV.CheckState = WFrms.CheckState.Unchecked;
                this.vehiculo = value;
                this.EdMadricula.Text = vehiculo.Matricula;
                this.CbTipo.Text = vehiculo.Tipo;
                this.EdMarca.Text = vehiculo.Marca;
                this.EdModelo.Text = vehiculo.Modelo;
                this.EdConsumo.Text = vehiculo.Consumo;
                this.EdFechaAdquisicion.Text = vehiculo.FechaAdquisicion;
                this.EdFechaFabricacion.Text = vehiculo.FechaFabricacion;
                List<string> txtComodidades = vehiculo.Comodidades;
                foreach (string comodidad in txtComodidades) {
                    if (comodidad.Equals("wifi")){
                        this.EdWifi.CheckState = WFrms.CheckState.Checked;
                    }
                    if (comodidad.Equals("bluetooth")) {
                        this.EdBluetooth.CheckState = WFrms.CheckState.Checked;
                    }
                    if (comodidad.Equals("aire acondicionado")) {
                        this.EdAcc.CheckState = WFrms.CheckState.Checked;
                    }
                    if (comodidad.Equals("litera")) {
                        this.EdLitera.CheckState = WFrms.CheckState.Checked;
                    }
                    if (comodidad.Equals("tv")) {
                        this.EdTV.CheckState = WFrms.CheckState.Checked;
                    }
                }
            }
        }
        
        Vehiculo vehiculo;
    }
}
