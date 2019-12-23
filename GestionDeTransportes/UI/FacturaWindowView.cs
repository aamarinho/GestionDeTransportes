﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Drawing;

namespace GestionTransporte.IU
{
    using WFrms = System.Windows.Forms;

    class FacturaWindowView : WFrms.Form
    {


        //Generar Factura
        public FacturaWindowView(String id)
        {
            this.MinimumSize = new Size(900, 650);
            this.Build(id);
        }

        //Mostrar Factura
        public FacturaWindowView(String[] ids)
        {
            this.MinimumSize = new Size(900, 650);
            this.Build(ids);
        }



        //Generar Factura
        void Build(String id)
        {

            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill,
                AutoScroll = true,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            
            var titulo = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Fill,
                BackColor = Color.Turquoise,
                Text = "Gestión Facturas"

            };

            //Titulo
            //mainPanel.Controls.Add(titulo);


            //Paneles de datos
            mainPanel.Controls.Add(this.BuildID(id));


            mainPanel.Controls.Add(this.BuildPrecioLCom());
            //mainPanel.Controls.Add(this.BuildCliente());
            mainPanel.Controls.Add(this.BuildNIF());
            mainPanel.Controls.Add(this.BuildNom());
            //mainPanel.Controls.Add(this.BuildTel());
            //mainPanel.Controls.Add(this.BuildEmail());
            //mainPanel.Controls.Add(this.BuildDir());
            mainPanel.Controls.Add(this.BuildPrecioporDia());
            mainPanel.Controls.Add(this.BuildNumerodeDias());
            mainPanel.Controls.Add(this.BuildPrecioKm());
            mainPanel.Controls.Add(this.BuildNumeroKm());
            mainPanel.Controls.Add(this.BuildIVA());
            mainPanel.Controls.Add(this.BuildTotal());

            //Último panel
            this.Controls.Add(mainPanel);
 
        }


        //Mostrar Factura
        void Build(String []ids)
        {

            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AutoScroll = true
            };


            var titulo = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Fill,
                BackColor = Color.Turquoise,
                Text = "Gestión Facturas"

            };

            //Titulo
            //mainPanel.Controls.Add(titulo);


            //Paneles de datos
            mainPanel.Controls.Add(this.BuildID(ids));


            mainPanel.Controls.Add(this.BuildPrecioLCom());
            //mainPanel.Controls.Add(this.BuildCliente());
            mainPanel.Controls.Add(this.BuildNIF());
            mainPanel.Controls.Add(this.BuildNom());
            //mainPanel.Controls.Add(this.BuildTel());
            //mainPanel.Controls.Add(this.BuildEmail());
            //mainPanel.Controls.Add(this.BuildDir());
            mainPanel.Controls.Add(this.BuildPrecioporDia());
            mainPanel.Controls.Add(this.BuildNumerodeDias());
            mainPanel.Controls.Add(this.BuildPrecioKm());
            mainPanel.Controls.Add(this.BuildNumeroKm());
            mainPanel.Controls.Add(this.BuildIVA());
            mainPanel.Controls.Add(this.BuildTotal());

            //Último panel
            this.Controls.Add(mainPanel);

        }





        //Generar Factura

        WFrms.Panel BuildID(string id) {

            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AutoScroll = true
            };
            var lblOp1 = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Transporte ID "

            };
            


            //En generar factura
            this.EdIDtransportes = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = id,
                ReadOnly = true
            };

            
                



            this.ButtonOp1 = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Right,
                BackColor = Color.Turquoise,
                Size=new Size(100,10),
                Text = "GUARDAR"
            };

            

            pnl.Controls.Add(lblOp1);
            pnl.Controls.Add(this.EdIDtransportes);
            pnl.Controls.Add(this.ButtonOp1);
            

            return pnl;
        }




        //Mostrar Factura

        WFrms.Panel BuildID(string[] ids)
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblOp1 = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Transporte ID "

            };
            
            this.CbOp1 = new WFrms.ComboBox
            {
                Dock = WFrms.DockStyle.Right,
                Size = new Size(200,20),
                DropDownStyle = WFrms.ComboBoxStyle.DropDown
            };

           
            this.CbOp1.Items.AddRange(ids);
            


            

            this.ButtonOp2 = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Right,
                BackColor = Color.Turquoise,
                Size=new Size(100,10),
                Text = "MOSTRAR"
            };

            pnl.Controls.Add(lblOp1);
            pnl.Controls.Add(this.CbOp1);
            
            pnl.Controls.Add(this.ButtonOp2);

            return pnl;
        }

        //Cliente

        WFrms.Panel BuildCliente()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblCliente = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Cliente"

            };


            pnl.Controls.Add(lblCliente);



            return pnl;
        }


        //NIF

        WFrms.Panel BuildNIF()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblNIF = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "NIF"

            };

            this.EdNIF = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "(vacio)",
                ReadOnly = true
            };


            pnl.Controls.Add(lblNIF);
            pnl.Controls.Add(this.EdNIF);


            return pnl;
        }


        WFrms.Panel BuildPrecioLCom()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblPrecioLCom = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Precio Litro de Combustible"

            };

            this.EdPrecioLCom = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "12"
            };


            pnl.Controls.Add(lblPrecioLCom);
            pnl.Controls.Add(this.EdPrecioLCom);


            return pnl;
        }

        //Nombre

        WFrms.Panel BuildNom()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblNom = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Nombre"

            };

            this.EdNom = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "(vacio)",
                ReadOnly = true
            };


            pnl.Controls.Add(lblNom);
            pnl.Controls.Add(this.EdNom);


            return pnl;
        }

        //Telefono

        WFrms.Panel BuildTel()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblTel = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Teléfono"

            };

            this.EdTel = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "(vacio)",
                ReadOnly = true
            };


            pnl.Controls.Add(lblTel);
            pnl.Controls.Add(this.EdTel);


            return pnl;
        }

        //Email

        WFrms.Panel BuildEmail()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblEmail = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Email"

            };

            this.EdEmail = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "(vacio)",
                ReadOnly = true
            };


            pnl.Controls.Add(lblEmail);
            pnl.Controls.Add(this.EdEmail);


            return pnl;
        }

        //Direccion

        WFrms.Panel BuildDir()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblDir = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Dirección Postal"

            };

            this.EdDir = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "(vacio)",
                ReadOnly = true
            };


            pnl.Controls.Add(lblDir);
            pnl.Controls.Add(this.EdDir);


            return pnl;
        }
        //Precio por dia

        WFrms.Panel BuildPrecioporDia()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblppd = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Precio por dia"

            };

            this.Edppd = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "()",
                ReadOnly = true
            };

           
            pnl.Controls.Add(lblppd);
            pnl.Controls.Add(this.Edppd);

            return pnl;
        }


        //Número de días

        WFrms.Panel BuildNumerodeDias()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblndd = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Número de días"

            };

            this.Edndd = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "0",
                ReadOnly = true
            };


            pnl.Controls.Add(lblndd);
            pnl.Controls.Add(this.Edndd);


            return pnl;
        }



        //Precio por kilometro
        WFrms.Panel BuildPrecioKm()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblpkm = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Precio Kilómetro"

            };

            this.Edpkm = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "0",
                ReadOnly = true
            };


            pnl.Controls.Add(lblpkm);
            pnl.Controls.Add(this.Edpkm);


            return pnl;
        }


        //Número de kilometros
        WFrms.Panel BuildNumeroKm()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblnkm = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Número de Kilómetros"

            };

            this.Ednkm = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "0",
                ReadOnly = true
            };


            pnl.Controls.Add(lblnkm);
            pnl.Controls.Add(this.Ednkm);


            return pnl;
        }

        //IVA
        WFrms.Panel BuildIVA()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblIVA = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "IVA"

            };

            this.EdIVA = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "0",
                ReadOnly = true
            };


            pnl.Controls.Add(lblIVA);
            pnl.Controls.Add(this.EdIVA);


            return pnl;
        }
        //Total

        WFrms.Panel BuildTotal()
        {

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };
            var lblt = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Precio Total"

            };

            this.Edt = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Fill,
                TextAlign = WFrms.HorizontalAlignment.Right,
                Text = "0",
                ReadOnly = true
            };


            pnl.Controls.Add(lblt);
            pnl.Controls.Add(this.Edt);


            return pnl;
        }


        public WFrms.ComboBox CbOp1 {
            get;private set;
        }
        public WFrms.TextBox EdNIF { get; private set; }
        public WFrms.TextBox Edppd { get; private set; }
        public WFrms.TextBox EdNom { get; private set; }
        public WFrms.TextBox EdTel { get; private set; }
        public WFrms.TextBox EdEmail { get; private set; }
        public WFrms.TextBox EdDir { get; private set; }
        public WFrms.TextBox Edndd { get; private set; }
        public WFrms.TextBox Edpkm { get; private set; }
        public WFrms.TextBox Ednkm { get; private set; }
        public WFrms.TextBox EdIVA { get; private set; }
        public WFrms.TextBox Edt { get; private set; }
        
        public WFrms.TextBox EdPrecioLCom { get; private set; }
        public WFrms.TextBox EdIDtransportes { get; private set; }
        public WFrms.Button ButtonOp1 { get; private set; }
        public WFrms.Button ButtonOp2 { get; private set; }
    }
}
