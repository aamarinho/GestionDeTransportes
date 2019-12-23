﻿using GestionTransporte.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTransporte.IU
{

    using WFrms = System.Windows.Forms;
    class FacturaWindowController
    {

        public FacturaWindowController(string id) {


            this.View = new FacturaWindowView(id);
            
            this.View.EdPrecioLCom.TextChanged += (sender, e) => this.Facturar(0);
            this.View.ButtonOp1.MouseClick += (sender, e) => this.Escribir();
            Facturar(0);
            

        }

        public FacturaWindowController(string[] ids)
        {


            this.View = new FacturaWindowView(ids);
            this.View.CbOp1.SelectedIndexChanged += (sender, e) => this.Facturar(1);
            
            this.View.EdPrecioLCom.TextChanged += (sender, e) => this.Facturar(1);
            
            //Boton mostrar
            this.View.ButtonOp2.MouseClick += (sender, e) => this.Mostrar();

        }

        void Facturar(int op) {
            string id="";
            switch (op) {

                case 0:  id = this.View.EdIDtransportes.Text;
                    break;
                case 1:
                     id = this.View.CbOp1.Text;
                    break;


            }
                
            
            string precioLcom = this.View.EdPrecioLCom.Text;

            
            

            string clienteid = Factura.buscarClienteID(id);
            string clientenom = Factura.buscarClienteNom(clienteid);
            string tel = Factura.buscarClienteTel(clienteid); 
            string email = Factura.buscarClienteEmail(clienteid);
            string dir = Factura.buscarClienteDir(clienteid);




            string salida = Factura.buscarTransporteLinqFechaSalida(id);
            string entrega = Factura.buscarTransporteLinqFechaEntrega(id);


            

            DateTime dsalida = DateTime.ParseExact(salida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dentrega = DateTime.ParseExact(entrega, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            TimeSpan numd = dentrega.Subtract(dsalida);

            

            string ppd = Factura.buscarTransporteLinqImporteDia(id);
            string km = Factura.buscarTransporteLinqKm(id);


            //Se obtiene la matricula
            string copiaid = id;

            string e = copiaid.Remove(7);


            string nummatriculaid = e.Remove(4);
            string letrasmatriculaid = e.Substring(4);
            

            string matriculaid = letrasmatriculaid + nummatriculaid;
            
            string auxconkm = Factura.buscarTransporteLinqConsumoKm(matriculaid);
            
            
            string conkm = auxconkm.Replace("L/100KM","");
            
            
            double ppkm = Convert.ToDouble(precioLcom) * 3;

            if (Factura.buscarTransporteLinqImportekm(id) != "0")
            {
                string auxppkm = Factura.buscarTransporteLinqImportekm(id);

                ppkm = Convert.ToDouble(auxppkm);
            }

            double gas = Convert.ToDouble(conkm) / 100 * Convert.ToDouble(km) * Convert.ToDouble(precioLcom);
            

            string IVA = Factura.buscarTransporteLinqIVA(id);
            


            double total = 30;

            
            string numdcadena = numd.Days.ToString();

            //Le añado un día al numdcadena


            int numddias = Convert.ToInt16(numdcadena) + 1;

            

            Factura f = new Factura(Convert.ToDouble(ppd), numddias, Convert.ToDouble(km), gas, Convert.ToDouble(precioLcom),ppkm);

            total = f.getPrecioFactura();




            this.View.EdNIF.Text = clienteid;
            this.View.EdNom.Text = clientenom;
            /*
            this.View.EdTel.Text = tel;
            this.View.EdEmail.Text = email;
            this.View.EdDir.Text = dir;
            */

            this.View.Edndd.Text = numddias.ToString();
            this.View.Edppd.Text = ppd;
            this.View.Ednkm.Text = km;
            this.View.Edpkm.Text = ppkm.ToString();
            this.View.EdIVA.Text = IVA;

            this.View.Edt.Text = total.ToString();
        }



        void Escribir() {
            
            string id = this.View.EdIDtransportes.Text;
            string clienteid = this.View.EdNIF.Text;
            string precioLcom = this.View.EdPrecioLCom.Text;


            string numd = this.View.Edndd.Text;
            string ppd = this.View.Edppd.Text;
            string suplencia = "1";
            if (Convert.ToInt16(numd) > 1) {
                suplencia = "2";
            }
            string km = this.View.Ednkm.Text;
            string ppkm = this.View.Edpkm.Text;

            string copiaid = id;


            string e = copiaid.Remove(7);



            string nummatriculaid = e.Remove(4);
            string letrasmatriculaid = e.Substring(4);


            



            string matriculaid = letrasmatriculaid + nummatriculaid;

            


            string auxconkm = Factura.buscarTransporteLinqConsumoKm(matriculaid);

            
            string conkm = auxconkm.Replace("L/100KM","");
            
            
            double gasdouble = Convert.ToDouble(conkm) / 100 * Convert.ToDouble(km) * Convert.ToDouble(precioLcom);

            
            
           

            string gas = gasdouble.ToString();

            string total = this.View.Edt.Text;

            Factura f = new Factura(id, clienteid, precioLcom, numd, ppd, suplencia, km, ppkm, gas, total);

            f.toXml();


            this.View.Close();
        }

        void Mostrar()
        {

            //Sobreescribir el fichero
            
            string plantilla = File.ReadAllText("verfactura2.html");
            
            File.WriteAllText("verfactura.html", plantilla);



            //Recoger datos
            
            string id = this.View.CbOp1.Text;
            


            if (Factura.buscarFacturaPrecioLcon(id) != "0")
            {

                //Se llama al método Facturar
            this.View.EdPrecioLCom.Text = Factura.buscarFacturaPrecioLcon(id);



                String[] valores = new string[10];


                string clienteid = this.View.EdNIF.Text;
                string precioLcom = this.View.EdPrecioLCom.Text;
                string nombrecliente = this.View.EdNom.Text;
                string preciopordia = this.View.Edppd.Text;
                string numerodedia = this.View.Edndd.Text;
                string ppk = this.View.Edpkm.Text;
                string nkm = this.View.Ednkm.Text;
                string iva = this.View.EdIVA.Text;
                string preciototal = this.View.Edt.Text;


                valores[0] = id;
                valores[2] = clienteid;
                valores[1] = precioLcom;
                valores[3] = nombrecliente;
                valores[4] = preciopordia;
                valores[5] = numerodedia;
                valores[6] = ppk;
                valores[7] = nkm;
                valores[8] = iva;
                valores[9] = preciototal;


                
                for (int i = 0; i < 10; i++)
                {
                    string text = File.ReadAllText("verfactura.html");
                    string remplazar = "{" + i + "}";
                    text = text.Replace(remplazar, valores[i]);
                    File.WriteAllText("verfactura.html", text);
                }



            
                Process.Start("verfactura.html");

            }
            else
            {
                Process.Start("verfactura2.html");
            }



            this.View.Close();
        }

        public FacturaWindowView View
        {
            get; private set;
        }
    }
}
