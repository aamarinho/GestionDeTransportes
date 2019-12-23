using System;
using System.ComponentModel;
using WFrm =System.Windows.Forms;
using GestionDeClientes.Core;

namespace GestionDeClientes.UI
{
    public class ClientesController
    {
        public ClientesController()
        {
            this.ClientesMainView = new ClientesMainView();
            this.FormInsertarCliente=new FormInsertarCliente(); 
            this.Clientes=new ColeccionClientes();
            this.VistaDetalladaCliente = new VistaDetalladaCliente(new Cliente("","","","",""));
            //this.ClientesMainView.BotonInsertar.Click += this.Operar;
            this.FormInsertarCliente.botonAceptar.Click +=this.Insertar;
            this.ClientesMainView.Lista.Click +=this.Visualizar;
            this.VistaDetalladaCliente.botonModificar.Click += this.Modificar;
            this.VistaDetalladaCliente.botonEliminar.Click += this.Eliminar;
            //this.ClientesMainView.BotonGuardar.Click += this.Guardar;
            //this.ClientesMainView.BotonRecuperar.Click += this.Recuperar;
            this.Recuperar(null,null);
        }

        void Operar(Object sender, EventArgs e)
        {
            FormInsertarCliente.ShowDialog();
        }

        void Insertar(Object sender, EventArgs e)
        {
            
            String textNIF = FormInsertarCliente.EdNIF.Text;
            String textNombre = FormInsertarCliente.EdNombre.Text;
            String textTelefono = FormInsertarCliente.EdTelefono.Text;
            String textEmail = FormInsertarCliente.EdEmail.Text;
            String textDireccion = FormInsertarCliente.EdDireccion.Text;
            
            Cliente c = new Cliente(textNIF,textNombre,textTelefono,textEmail,textDireccion);

            Clientes.Inserta(c);
            ClientesMainView.Lista.Items.Add(c.ToString());
            FormInsertarCliente.Close();
            this.Guardar(null,null);
        }

        Cliente encontrarCliente(String NIF)
        {
            Cliente toret = new Cliente("","","","","");
            
            foreach (Cliente c in Clientes.Clientes) {
                if (c.NIF.Equals(NIF)) {
                    toret = c;
                    break;
                }
            }
            return toret;
        }
        
        void Visualizar(Object sender, EventArgs e)
        {
            String NIF = ClientesMainView.Lista.SelectedItems[0].Text.Substring(0, 9);
            Cliente clienteActual = encontrarCliente(NIF);
            VistaDetalladaCliente.Cliente = clienteActual;
            VistaDetalladaCliente.ShowDialog();
        }

        void Modificar(Object sender, EventArgs e)
        {
            String textNIF = VistaDetalladaCliente.EdNIF.Text;
            String textNombre = VistaDetalladaCliente.EdNombre.Text;
            String textTelefono = VistaDetalladaCliente.EdTelefono.Text;
            String textEmail = VistaDetalladaCliente.EdEmail.Text;
            String textDireccion = VistaDetalladaCliente.EdDireccion.Text;
            
            Cliente clienteActual = encontrarCliente(textNIF);
            
            clienteActual.Nombre = textNombre;
            clienteActual.Telefono = textTelefono;
            clienteActual.Email = textEmail;
            clienteActual.Direccion = textDireccion;

            int pos = Clientes.Posicion(clienteActual);
            
            ClientesMainView.Lista.Items.RemoveAt(pos);
            ClientesMainView.Lista.Items.Insert(pos, clienteActual.ToString());
            VistaDetalladaCliente.Close();
            this.Guardar(null,null);
        }

        void Eliminar(Object sender, EventArgs e)
        {
            String textNIF = VistaDetalladaCliente.EdNIF.Text;
            Cliente clienteActual = this.encontrarCliente(textNIF);
            int pos = Clientes.Posicion(clienteActual);
            Clientes.Elimina(clienteActual);
            ClientesMainView.Lista.Items.RemoveAt(pos);
            VistaDetalladaCliente.Close();
            this.Guardar(null,null);
        }

        void Guardar(Object sender, EventArgs e)
        {
            Clientes.VuelcaXML();
        }

        void Recuperar(Object sender, EventArgs e)
        {
            Cliente[] clientesRecuperar = Clientes.LeerClientesXmlDom();
            ClientesMainView.Lista.Items.Clear();
            for (int i = 0; i < clientesRecuperar.Length; i++)
            {
                ClientesMainView.Lista.Items.Add(clientesRecuperar[i].ToString());
                Clientes.Inserta(clientesRecuperar[i]);
            }
            ClientesMainView.Lista.Refresh();
        }

        public ClientesMainView ClientesMainView { get; set; }
        
        public ColeccionClientes Clientes { get; set; }

        public FormInsertarCliente FormInsertarCliente { get; set; }
        
        public VistaDetalladaCliente VistaDetalladaCliente { get; set; }
    }
}