using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeClientes.UI
{
    using WFrms = System.Windows.Forms;
    using System.Drawing;
    public partial class ClientesMainView : WFrms.Form
    {
        public ClientesMainView()
        {
            this.MinimumSize = new Size(400, 200);
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                AutoScroll = true,
                Dock=WFrms.DockStyle.Fill,
                BackColor = Color.Black,
                Text = "GESTION DE CLIENTES"
            };
            
            mainPanel.Controls.Add(this.buildListaYBoton());
            
            this.Controls.Add(mainPanel);
        }

        private WFrms.Panel buildListaYBoton()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Fill
            };

            this.Lista = new WFrms.ListView
            {
                Dock = WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                BackColor = Color.White,
                Margin = new WFrms.Padding(3, 5, 3, 5),
                Columns = { "Item","item2","item3"},
            };
            Lista.Columns.Add("Item column",-2, WFrms.HorizontalAlignment.Left);
            Lista.Columns.Add("Item column2",-2, WFrms.HorizontalAlignment.Left);
            Lista.Columns.Add("Item column3",-2, WFrms.HorizontalAlignment.Left);
            Lista.Columns.Add("Item column4",-2, WFrms.HorizontalAlignment.Center);
            pnl.Controls.Add(this.Lista);
            
            return pnl;
        }

        public WFrms.ListView Lista { get; private set; }

        public WFrms.Button BotonInsertar { get; private set; }
        
        public WFrms.Button BotonGuardar { get; private set; }
        
        public WFrms.Button BotonRecuperar { get; private set; }
    }
}