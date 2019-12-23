﻿﻿using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
 using GestionDeClientes.Core;
 using GestionFlotaProject.UI;

 namespace InterfazTransporte.Core
{
    public class AddWindowTransporte: Form
    {
        private List<Transporte> transportes = new List<Transporte>();
        private ColeccionClientes Clientes;
        private ColeccionVehiculos Vehiculos;
        private MainWindow _mainWindow;
        public AddWindowTransporte(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            this.transportes = leerXML();
            this.Clientes = new ColeccionClientes();
            this.Vehiculos = new ColeccionVehiculos();
            this.Build();
        }



        private void Build()
        {
            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;
            pnlTable.Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

            
            pnlTable.Controls.Add(BuildMatricula());
            pnlTable.Controls.Add(BuildTipo());
            pnlTable.Controls.Add(BuildCliente());
            pnlTable.Controls.Add(BuildFechaContrato());
            pnlTable.Controls.Add(BuildKm());
            pnlTable.Controls.Add(BuildFechaSalida());
            pnlTable.Controls.Add(BuildFechaEntrega());
            pnlTable.Controls.Add(BuildImporteDia());
            pnlTable.Controls.Add(BuildImporteKm());
            pnlTable.Controls.Add(BuildIva());
            pnlTable.Controls.Add(BuildbtAdd());
           

            pnlTable.ResumeLayout( false );
            this.Controls.Add( pnlTable );

            this.Text = this.GetType().Name;
            this.MinimumSize = new Size( 900, 750 );
        }
        
        private List<Transporte> leerXML()
        {
            List<Transporte> transportes = new List<Transporte>();
            XElement raiz = XElement.Load("Transportes.xml");
            foreach (XElement transporte in raiz.Elements("transporte"))
            {
                string[] fecha = transporte.Element("fechaContrato").Value.Split('/');
                string[] fecha2 = transporte.Element("fechaSalida").Value.Split('/');
                string[] fecha3 = transporte.Element("fechaEntrega").Value.Split('/');
                Transporte t = new Transporte((transporte.Element("vehiculo").Value), 
                    transporte.Element("tipo").Value,
                    (transporte.Element("cliente").Value),
                    new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0])),
                    Double.Parse(transporte.Element("kilometros").Value),
                    new DateTime(int.Parse(fecha2[2]), int.Parse(fecha2[1]), int.Parse(fecha2[0])),
                    new DateTime(int.Parse(fecha3[2]), int.Parse(fecha3[1]), int.Parse(fecha3[0])),
                    Double.Parse(transporte.Element("importeDia").Value),
                    Double.Parse(transporte.Element("importeKm").Value),
                    Double.Parse(transporte.Element("iva").Value));
                
                transportes.Add(t);
            }
            return transportes;
        }
        private void AddTransporte()
        {
            
            string matricula = this.Matricula.Text;
            string tipo = this.Tipo.Text;
            string cliente = this.Cliente.Text;
            string fechaC = this.FechaContrato.Text;
            string km = this.Km.Text;
            string fechaSalida = this.FechaSalida.Text;
            string fechaEntrega = this.FechaEntrega.Text;
            string iDia = this.ImporteDia.Text;
            string iKm = this.ImporteKm.Text;
            string iva = this.Iva.Text;
            DateTime fc = DateTime.ParseExact(fechaC, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fs = DateTime.ParseExact(fechaSalida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fe = DateTime.ParseExact(fechaEntrega, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Transporte t = new Transporte(matricula, tipo, cliente, 
                fc, double.Parse(km), fs, fe, double.Parse(iDia),
                double.Parse(iKm),Double.Parse(iva));
            
            transportes.Add(t);
            
            crearXML(transportes);
            
            
            this._mainWindow.actualizarDatos(transportes);
            this.Close();
            
        }
        
        public static void crearXML(List<Transporte> transportes)
        {
            XElement doc = new XElement("Transportes");
            foreach(Transporte t in transportes)
            {
                doc.Add(t.ToXML());
            }
            doc.Save("Transportes.xml");
        }
        
        public ComboBox Matricula { get; private set; }
        
        public ComboBox Tipo { get; private set; }
        
        public ComboBox Cliente { get; private set; }
        
        public TextBox FechaContrato { get; private set; }
        
        public TextBox Km { get; private set; }
        
        public TextBox FechaSalida { get; private set; }
        
        public TextBox FechaEntrega { get; private set; }
        
        public TextBox ImporteDia { get; private set; }
        
        public TextBox ImporteKm { get; private set; }

        public TextBox Iva { get; set; }

        public Button BtAdd { get; set; }

        public Panel BuildbtAdd()
        {
            var pnl = new Panel()
            {
                Dock = DockStyle.Top
            };

            BtAdd = new Button
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Turquoise,
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Text = "GUARDAR"
            };
            BtAdd.Click += (sender, args) => this.AddTransporte();
            pnl.Controls.Add(BtAdd);
            return pnl;
        }

        public Panel BuildMatricula()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
                
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Matricula"
            };

            Matricula = new ComboBox
            {
                Dock = DockStyle.Right,
                DropDownStyle = ComboBoxStyle.DropDown
            };
            
            Matricula.Items.AddRange(MostrarMatriculaTransporte());
            Matricula.SelectedIndex = 0;
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(Matricula);


            return pnl;
        }
        
        public Panel BuildTipo()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Tipo"
            };

            Tipo = new ComboBox()
            {
                Dock = DockStyle.Right,
                Size = new Size(225,200),
                DropDownStyle = ComboBoxStyle.DropDown
            };
            
            Tipo.Items.AddRange(new String[] { "Mudanza", "Transporte de mercancias", "Transporte de vehiculos" });
            Tipo.SelectedIndex = 0;
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(Tipo);

            return pnl;
        }
        
        public Panel BuildCliente()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Cliente"
            };

            Cliente = new ComboBox
            {
                Dock = DockStyle.Right,
                DropDownStyle = ComboBoxStyle.DropDown
                
            };
            
            Cliente.Items.AddRange(MostrarNombreCliente());
            Cliente.SelectedIndex = 0;
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(Cliente);


            return pnl;
        }
        
        public Panel BuildFechaContrato()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Fecha contrato"
            };

            FechaContrato = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(FechaContrato);
           

            return pnl;
        }
        
        public Panel BuildKm()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Kilometros"
            };

            Km = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(Km);

            return pnl;
        }
        
        public Panel BuildFechaSalida()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Fecha salida"
            };

            FechaSalida = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(FechaSalida);


            return pnl;
        }
        
        public Panel BuildFechaEntrega()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Fecha entrega"
            };

            FechaEntrega = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(FechaEntrega);

            return pnl;
        }
        
        public Panel BuildImporteDia()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Importe dia"
            };

            ImporteDia = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(ImporteDia);


            return pnl;
        }
        
        public Panel BuildImporteKm()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Importe Km"
            };

            ImporteKm = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(ImporteKm);


            return pnl;
        }
        
        public Panel BuildIva()
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            
            var lbl = new Label
            {
                Dock = DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Iva"
            };

            Iva = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Text = ""
            };
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(Iva);


            return pnl;
        }
        private string[] MostrarMatriculaTransporte()
        {
            var vehiculos = Vehiculos.LeerVehiculosXmlDom();
            int tam = vehiculos.Length;
            
            string[] toret = new string[tam];

            for (int i = 0; i < tam; i++) {

                toret[i] = vehiculos[i].Matricula;

            }

            return toret;
        }
        
        private string[] MostrarNombreCliente()
        {
            var clientes = Clientes.LeerClientesXmlDom();
            int tam = clientes.Length;
            
            string[] toret = new string[tam];

            for (int i = 0; i < tam; i++) {

                toret[i] = clientes[i].NIF;

            }

            return toret;
        }
    }
}