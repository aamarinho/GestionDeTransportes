
using System;
using GestionDeClientes.UI;
using InterfazTransporte.Core;

namespace GestionDeClientes
{
	using WFrms = System.Windows.Forms;
    class MainClass
    {
        public static void Main(string[] args) { 
	        //WFrms.Application.Run( new ClientesController().ClientesMainView);
            var form = new MainWindow();
            try
            {
                form.Show();
                WFrms.Application.Run(form);
            }
            catch (Exception e)
            {
                WFrms.MessageBox.Show("Error" + e.Message, "Error transportes",
                    WFrms.MessageBoxButtons.OK, WFrms.MessageBoxIcon.Error);
            }
        }
    }
}
