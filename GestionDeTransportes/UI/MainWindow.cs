﻿using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
 using Busquedas_DIA6;
 using GestionDeClientes.Core;
 using GestionDeClientes.UI;
 using GestionFlotaProject.UI;
 using GestionTransporte.IU;
 using Proyecto.Properties;

 namespace InterfazTransporte.Core
{
    public class MainWindow: Form
    {
        private List<Transporte> transportes = new List<Transporte>();
        
        private DataGridView transportesDataGridView;

        public ClientesController Clientes { get; set; }

        public VehiculosController Vehiculos { get; set; }
        
        public mainWindowControllerBusquedas Busquedas { get; set; }
        
        public MainWindowGraficos Graficos { get; set; }
        public MainWindow()
        {
            
            this.transportes = leerXML();
            this.Clientes=new ClientesController();
            this.Vehiculos=new VehiculosController();
            this.Busquedas=new mainWindowControllerBusquedas("");
            this.Graficos=new MainWindowGraficos();
            this.Build();
        }


        private void Build()
        {
            var pnlTable = new TableLayoutPanel();
            
            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;
            pnlTable.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);

            var btAdd = new Button
            {
                Text = "AGREGAR TRANSPORTE",
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.Turquoise,
                Dock = DockStyle.Top
            };
            
            var btDel = new Button
            {
                Text = "ELIMINAR TRANSPORTE",
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.Turquoise,
                Dock = DockStyle.Top
            };
            
            var btMod = new Button
            {
                Text = "MODIFICAR TRANSPORTE",
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.Turquoise,
                Dock = DockStyle.Top
            };
            
            var btFactura = new Button
            {
                Text = "GENERAR FACTURA",
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.Turquoise,
                Dock = DockStyle.Top
            };


            //Nuevo NES
            var btMostrar = new Button
            {
                Text = "MOSTRAR FACTURA",
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.Turquoise,
                Dock = DockStyle.Top
            };

            btAdd.Click += (sender, args) => AddTransporte();
            btDel.Click += (sender, args) => DelTransporte();
            btMod.Click += (sender, args) => ModTransporte();

            //Nuevo NES
            //Cambiar la funcion a invocar , pasar parametro al controller
            //ID
            btFactura.Click += (sender, args) => new FacturaWindowController(GenerarFacturagetIDTransporte()).View.Show();
            //Array IDS
            btMostrar.Click += (sender, args) => new FacturaWindowController(MostrarIDTransporte()).View.Show();

            this.SetUpDataGridView();
            
            pnlTable.Controls.Add(btAdd);
            pnlTable.Controls.Add(btDel);
            pnlTable.Controls.Add(btMod);
            pnlTable.Controls.Add(btFactura);
            pnlTable.Controls.Add(btMostrar);
            pnlTable.Controls.Add(transportesDataGridView);
            
            pnlTable.ResumeLayout( false );
            this.Controls.Add( pnlTable );

            this.BuildMenu();
            this.MinimumSize = new Size( 1400, 900 );
            this.Text = "GESTIÓN DE EMPRESA DE TRANSPORTES";
        }


        
        

        private void SetUpDataGridView()
        {
            transportesDataGridView = new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Dock = DockStyle.Top,
                ReadOnly = true,
                ColumnCount = 10,
                Size = new Size(1200,470)
            };
            
          

            transportesDataGridView.Columns[0].Name = "ID";
            transportesDataGridView.Columns[1].Name = "Tipo";
            transportesDataGridView.Columns[2].Name = "Cliente";
            transportesDataGridView.Columns[3].Name = "Fecha contrato";
            transportesDataGridView.Columns[4].Name = "Km recorridos";
            transportesDataGridView.Columns[5].Name = "Fecha salida";
            transportesDataGridView.Columns[6].Name = "Fecha entrega";
            transportesDataGridView.Columns[7].Name = "Importe dia";
            transportesDataGridView.Columns[8].Name = "Importe km";
            transportesDataGridView.Columns[9].Name = "IVA";

          
            
            rellenarDatos();
            /*
            transportesDataGridView.AutoResizeColumns();
            transportesDataGridView.AutoResizeRows();
*/
            
        }

        public void actualizarDatos(List<Transporte> transportes)
        {
            transportesDataGridView.Rows.Clear();
            this.transportes.Clear();
            foreach (Transporte t in transportes)
            {
                transportesDataGridView.Rows.Add(t.Id, t.Tipo, t.Cliente, 
                    t.FechaContrato,t.Km,t.FechaSalida,t.FechaEntrega,t.ImporteDia,t.ImporteKm,t.Iva);
                this.transportes.Add(t);
            }
        }

        
        private void rellenarDatos()
        {
            
            
            transportes = leerXML();

            foreach (Transporte t in transportes)
            {
                transportesDataGridView.Rows.Add(t.Id, t.Tipo, t.Cliente, 
                    t.FechaContrato,t.Km,t.FechaSalida,t.FechaEntrega,t.ImporteDia,t.ImporteKm,t.Iva);
            }
            
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

        private void OnQuit()
        {
            this.Close();
        }

        private void BuildMenu()
        {
            this.Menu = new MainMenu();

            var opQuit = new MenuItem("Cerrar")
            {
                Shortcut = Shortcut.CtrlQ
            };

            opQuit.Click += (sender, args) => { this.OnQuit(); };
            
            
            var opAddClientes = new MenuItem("Cliente")
            {
               
            };
            
            opAddClientes.Click += (sender, args) => new ClientesController().FormInsertarCliente.Show();

            var oppAddVehiculos = new MenuItem("Vehiculo")
            {
               
            };

            oppAddVehiculos.Click += (sender, args) => new VehiculosController().FormInsertarVehiculo.Show();
            
            var oppVistaClientes = new MenuItem("Clientes")
            {
               
            };

            oppVistaClientes.Click += (sender, args) => new ClientesController().ClientesMainView.Show();
            
            var oppVistaVehiculos = new MenuItem("Vehiculos")
            {
                
            };

            oppVistaVehiculos.Click += (sender, args) => new VehiculosController().VehiculosMainView.Show();

            var oppBusquedas1 = new MenuItem("Reservas por cliente")
            {
                
            };

            oppBusquedas1.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas1.Text).ViewBusquedas.Show();
            
            var oppBusquedas2 = new MenuItem("Reservas por camión")
            {
                
            };

            oppBusquedas2.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas2.Text).ViewBusquedas.Show();
            
            var oppBusquedas3 = new MenuItem("Ocupación por fecha")
            {
               
            };

            oppBusquedas3.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas3.Text).ViewBusquedas2.Show();
            
            var oppBusquedas6 = new MenuItem("Ocupación por año")
            {
               
            };

            oppBusquedas6.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas6.Text).ViewBusquedas3.Show();
            
            var oppBusquedas4 = new MenuItem("Reservas pendientes")
            {
                
            };

            oppBusquedas4.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas4.Text).ViewBusquedas4.Show();
            
            var oppBusquedas5 = new MenuItem("Vehículos disponibles")
            {
                
            };

            oppBusquedas5.Click += (sender, args) => new mainWindowControllerBusquedas(oppBusquedas5.Text).ViewBusquedas5.Show();
            
            var oppGraficos1 = new MenuItem("Grafico general")
            {
                
            };

            oppGraficos1.Click += (sender, args) => new MainWindowGraficos().ViewDemoChart();
            
            var oppGraficos2 = new MenuItem("Grafico clientes")
            {
                
            };

            oppGraficos2.Click += (sender, args) => new MainWindowGraficos().ViewDoblePanel();
            
            var oppGraficos3 = new MenuItem("Grafico vehiculos")
            {
                
            };

            oppGraficos3.Click += (sender, args) => new MainWindowGraficos().ViewDoblePanel2();
            
            var oppGraficos4 = new MenuItem("Grafico comodidad")
            {
               
            };

            oppGraficos4.Click += (sender, args) => new MainWindowGraficos().ViewGraficoComodidad();
            
            var mFile = new MenuItem("Insertar");
            var mBusquedas = new MenuItem("Búsquedas");
            var mGraficos = new MenuItem("Gráficos");
            var mVista = new MenuItem("Ver");
            var mOpciones = new MenuItem("Opciones");
            
            mFile.MenuItems.Add(opAddClientes);
            mFile.MenuItems.Add(oppAddVehiculos);
            
            mOpciones.MenuItems.Add(opQuit);

            mVista.MenuItems.Add(oppVistaClientes);
            mVista.MenuItems.Add(oppVistaVehiculos);

            mBusquedas.MenuItems.Add(oppBusquedas1);
            mBusquedas.MenuItems.Add(oppBusquedas2);
            mBusquedas.MenuItems.Add(oppBusquedas3);
            mBusquedas.MenuItems.Add(oppBusquedas6);
            mBusquedas.MenuItems.Add(oppBusquedas4);
            mBusquedas.MenuItems.Add(oppBusquedas5);

            mGraficos.MenuItems.Add(oppGraficos1);
            mGraficos.MenuItems.Add(oppGraficos2);
            mGraficos.MenuItems.Add(oppGraficos3);
            mGraficos.MenuItems.Add(oppGraficos4);
            
            this.Menu.MenuItems.Add(mVista);
            this.Menu.MenuItems.Add(mFile);
            this.Menu.MenuItems.Add(mBusquedas);
            this.Menu.MenuItems.Add(mGraficos);
            this.Menu.MenuItems.Add(mOpciones);
        }

        private void AddTransporte()
        {
            new AddWindowTransporte(this).Show();
            
        }

        private void DelTransporte()
        {
            if (transportesDataGridView.CurrentRow != null)
            {
                transportes.RemoveAt(transportesDataGridView.CurrentRow.Index);
                transportesDataGridView.Rows.Remove(transportesDataGridView.CurrentRow);
                crearXML(transportes);
            }
        }

        private void ModTransporte()
        {
            if (transportesDataGridView.CurrentRow != null)
            {
                new ModWindowTransporte(transportesDataGridView.CurrentRow.Index, this).Show();
            }
        }


        //Devuelve el id del transporte de la fila seleccionada
        private string GenerarFacturagetIDTransporte()
        {
            string toret = "No se encontro el id";
            if (transportesDataGridView.CurrentRow != null)
            {
                toret = transportesDataGridView.CurrentRow.Cells[0].Value.ToString();
                //Console.WriteLine("El id seleccionado es: " + toret);
            }

            return toret;
        }

        //Devuelve array de string de los idtransporte
        private string[] MostrarIDTransporte()
        {
            int tam = transportes.Count;

            string[] toret = new string[tam];

            for (int i = 0; i < tam; i++) {

                toret[i] = transportes[i].Id;

            }

            return toret;
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

        
        }
}