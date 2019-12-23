﻿using System;
namespace Busquedas_DIA6
{
    using WFrms = System.Windows.Forms;
    public class mainWindowControllerBusquedas
    {
        public mainWindowControllerBusquedas(string opcion)
        {
	        this.ViewBusquedas = new mainWindowViewBusquedas();
	        this.ViewBusquedas2 = new mainWindowViewBusquedas2();
	        this.ViewBusquedas3 = new mainWindowViewBusquedas3();
	        this.ViewBusquedas4 = new mainWindowViewBusquedas4();
	        this.ViewBusquedas5 = new mainWindowViewBusquedas5();
	        this.Opcion = opcion;
            this.ViewBusquedas.ButtonBuscar.Click += (sender, e) => this.Busqueda();
            this.ViewBusquedas2.ButtonBuscar.Click += (sender, e) => this.Busqueda();
            this.ViewBusquedas3.ButtonBuscar.Click += (sender, e) => this.Busqueda();
            this.ViewBusquedas4.ButtonBuscar.Click += (sender, e) => this.Busqueda();
            this.ViewBusquedas5.ButtonBuscar.Click += (sender, e) => this.Busqueda();
            //this.View.CbOpr.SelectedIndexChanged += this.listenerOperar;
        }      
        public void Busqueda()
        {
			String opr = this.Opcion;
			Console.WriteLine(opr);
            string strOp1 = this.ViewBusquedas.EdOpl.Text;
            string strOp2 = this.ViewBusquedas.EdOp2.Text;
			String op1 = strOp1;
			String op2 = strOp2;
			string strOp5 = this.ViewBusquedas5.EdOpl.Text;
			string strOp6 = this.ViewBusquedas5.EdOp2.Text;
			String op5 = strOp5;
			String op6 = strOp6;
			string strOp3 = this.ViewBusquedas2.EdOpl.Text;
			String op3 = strOp3;
			string strOp4 = this.ViewBusquedas3.EdOpl.Text;
			String op4 = strOp4;
            String res = "";

            try
            {
				var busqueda = new Busquedas();
				switch(opr)
				{
					case "Reservas por cliente":
						Console.WriteLine("algo 1");
						res = busqueda.ReservasPorCliente(op1,op2);
						Console.WriteLine("algo 2" + op1 + op2);
						break;
					case "Reservas por camión":
						res = busqueda.ReservasPorCamion(op1,op2);
						Console.WriteLine("algo 2" + op1 + op2);
                        break;
					case "Ocupación por fecha":
						res = busqueda.Ocupacion(op3);
                        break;
					case "Ocupación por año":
						res = busqueda.Ocupacion2(op4);
						break;
					case "Reservas pendientes":
						res = busqueda.TransportesPendientes();
                        break;
					case "Vehículos disponibles":
						res = busqueda.Disponibilidad(op5,op6);
                        break;
				}
            }
            catch (System.ArgumentException exc)
            {
                res = "";
                WFrms.MessageBox.Show("Operador incorrecto" + exc);
            }

            this.ViewBusquedas.EdRes.Text = res.ToString();
            this.ViewBusquedas2.EdRes.Text = res.ToString();
            this.ViewBusquedas3.EdRes.Text = res.ToString();
            this.ViewBusquedas4.EdRes.Text = res.ToString();
            this.ViewBusquedas5.EdRes.Text = res.ToString();
        }

        public string Opcion { get; set; }

        public mainWindowViewBusquedas ViewBusquedas
        {
            get; private set;
        }
        
        public mainWindowViewBusquedas2 ViewBusquedas2
        {
	        get; private set;
        }
        
        public mainWindowViewBusquedas3 ViewBusquedas3
        {
	        get; private set;
        }
        
        public mainWindowViewBusquedas4 ViewBusquedas4
        {
	        get; private set;
        }
        
        public mainWindowViewBusquedas5 ViewBusquedas5
        {
	        get; private set;
        }
    }
}