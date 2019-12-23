﻿using System;
using System.Collections.Generic;
using WFrm = System.Windows.Forms;

namespace GestionFlotaProject.UI
{
    public class VehiculosController
    {
        public VehiculosController()
        {
            this.VehiculosMainView = new VehiculosMainView();
            this.FormInsertarVehiculo=new FormInsertarVehiculo(); 
            this.Vehiculos=new ColeccionVehiculos();
            this.VistaDetalladaVehiculo=new VistaDetalladaVehiculo(new Vehiculo("","","","","","","",new List<string>()));
            //this.VehiculosMainView.BotonInsertar.Click += this.MostrarForm;
            this.FormInsertarVehiculo.botonAceptar.Click +=this.Insertar;
            this.VehiculosMainView.Lista.Click += this.Visualizar;
            this.VistaDetalladaVehiculo.botonModificar.Click += this.Modificar;
            this.VistaDetalladaVehiculo.botonEliminar.Click += this.Eliminar;
            //this.VehiculosMainView.BotonGuardar.Click += this.Guardar;
            //this.VehiculosMainView.BotonRecuperar.Click += this.Recuperar;
            this.Recuperar(null, null);
        }

        void MostrarForm(Object sender, EventArgs e)
        {
            FormInsertarVehiculo.ShowDialog();
        }

        void Insertar(Object sender, EventArgs e)
        {
            String txtMatricula = FormInsertarVehiculo.EdMadricula.Text;
            String txtTipo = FormInsertarVehiculo.CbTipo.Text;
            String txtMarca = FormInsertarVehiculo.EdMarca.Text;
            String txtModelo = FormInsertarVehiculo.EdModelo.Text;
            String txtConsumo = FormInsertarVehiculo.EdConsumo.Text;
            String txtFechaAdquisicion = FormInsertarVehiculo.EdFechaAdquisicion.Text;
            String txtFechaFabricacion = FormInsertarVehiculo.EdFechaFabricacion.Text;
            bool wifi = FormInsertarVehiculo.EdWifi.Checked;
            bool bluetooth = FormInsertarVehiculo.EdBluetooth.Checked;
            bool acc = FormInsertarVehiculo.EdAcc.Checked;
            bool litera = FormInsertarVehiculo.EdLitera.Checked;
            bool tv = FormInsertarVehiculo.EdTV.Checked;
            List<string> comodidades = new List<string>();
            
            if (wifi) {
                comodidades.Add("wifi");
            }
            if (bluetooth) {
                comodidades.Add("bluetooth");
            }
            if (acc) {
                comodidades.Add("aire acondicionado");
            }
            if (litera) {
                comodidades.Add("litera");
            }
            if (tv) {
                comodidades.Add("tv");
            }
                
            Vehiculo v = new Vehiculo(txtMatricula, txtTipo, txtMarca, txtModelo, txtConsumo, txtFechaAdquisicion, txtFechaFabricacion,comodidades);

            Vehiculos.Inserta(v);
            VehiculosMainView.Lista.Items.Add(v.ToString());
            FormInsertarVehiculo.Close();
            this.Guardar(null,null);
            
        }

        Vehiculo encontrarVehiculo(String matricula)
        {
            Vehiculo toret = new Vehiculo("","","","","","","",new List<string>());

            foreach (Vehiculo v in Vehiculos.Vehiculos) {
                if (v.Matricula.Equals(matricula)) {
                    toret = v;
                    break;
                }
            }
            return toret;
        }
        
        void Visualizar(Object sender, EventArgs e)
        {
            Vehiculo vehiculoActual = new Vehiculo("","","","","","","",new List<string>());
            String matricula = VehiculosMainView.Lista.SelectedItems[0].Text.Substring(0, 7);
            vehiculoActual = encontrarVehiculo(matricula);
            VistaDetalladaVehiculo.Vehiculo = vehiculoActual;
            VistaDetalladaVehiculo.ShowDialog();
        }
        
        void Modificar(Object sender, EventArgs e)
        {
            String txtMatricula = VistaDetalladaVehiculo.EdMadricula.Text;
            String txtTipo = VistaDetalladaVehiculo.CbTipo.Text;
            String txtMarca = VistaDetalladaVehiculo.EdMarca.Text;
            String txtModelo = VistaDetalladaVehiculo.EdModelo.Text;
            String txtConsumo = VistaDetalladaVehiculo.EdConsumo.Text;
            String txtFechaAdquisicion = VistaDetalladaVehiculo.EdFechaAdquisicion.Text;
            String txtFechaFabricacion = VistaDetalladaVehiculo.EdFechaFabricacion.Text;
            bool wifi = VistaDetalladaVehiculo.EdWifi.Checked;
            bool bluetooth = VistaDetalladaVehiculo.EdBluetooth.Checked;
            bool acc = VistaDetalladaVehiculo.EdAcc.Checked;
            bool litera = VistaDetalladaVehiculo.EdLitera.Checked;
            bool tv = VistaDetalladaVehiculo.EdTV.Checked;
            List<string> comodidades = new List<string>();
            if (wifi) {
                comodidades.Add("wifi");
            }
            if (bluetooth) {
                comodidades.Add("bluetooth");
            }
            if (acc) {
                comodidades.Add("aire acondicionado");
            }
            if (litera) {
                comodidades.Add("litera");
            }
            if (tv) {
                comodidades.Add("tv");
            }
            Vehiculo vehiculoActual = encontrarVehiculo(txtMatricula);

            vehiculoActual.Matricula = txtMatricula;
            vehiculoActual.Tipo = txtTipo;
            vehiculoActual.Marca = txtMarca;
            vehiculoActual.Modelo = txtModelo;
            vehiculoActual.Consumo = txtConsumo;
            vehiculoActual.FechaAdquisicion = txtFechaAdquisicion;
            vehiculoActual.FechaFabricacion = txtFechaFabricacion;
            vehiculoActual.Comodidades = comodidades;
            
            int pos = Vehiculos.Posicion(vehiculoActual);
            
            VehiculosMainView.Lista.Items.RemoveAt(pos);
            VehiculosMainView.Lista.Items.Insert(pos, vehiculoActual.ToString());
            VistaDetalladaVehiculo.Close();
            this.Guardar(null,null);
        }
        
        void Eliminar(Object sender, EventArgs e)
        {
            String textMatricula = VistaDetalladaVehiculo.EdMadricula.Text;
            Vehiculo vehiculoActual = this.encontrarVehiculo(textMatricula);
            int pos = Vehiculos.Posicion(vehiculoActual);
            Vehiculos.Elimina(vehiculoActual);
            VehiculosMainView.Lista.Items.RemoveAt(pos);
            VistaDetalladaVehiculo.Close();
            this.Guardar(null,null);
        }
        
        void Guardar(Object sender, EventArgs e)
        {
            Vehiculos.VuelcaXML();
        }
        
        void Recuperar(Object sender, EventArgs e)
        {    
            Vehiculo[] vehiculosRecuperar = Vehiculos.LeerVehiculosXmlDom();
            VehiculosMainView.Lista.Items.Clear();
            for (int i = 0; i < vehiculosRecuperar.Length; i++)
            {
                VehiculosMainView.Lista.Items.Add(vehiculosRecuperar[i].ToString());
                Vehiculos.Inserta(vehiculosRecuperar[i]);
            }
            VehiculosMainView.Lista.Refresh();
        }
        
        public VehiculosMainView VehiculosMainView { get; set; }
        public ColeccionVehiculos Vehiculos { get; set; }
        public FormInsertarVehiculo FormInsertarVehiculo { get; set; }
        public VistaDetalladaVehiculo VistaDetalladaVehiculo { get; set; }
       
        
        
    }
    }
