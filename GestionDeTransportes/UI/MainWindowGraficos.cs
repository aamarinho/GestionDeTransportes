﻿using System;
using System.Windows.Forms;
using System.Drawing;


namespace Proyecto.Properties
{
    public class MainWindowGraficos : Form
    {
        public MainWindowGraficos()
        {
            this.Build();
        }

        private void OnQuit()
        {
            this.Close();
        }


        public void ViewDemoChart()
        {
            new DemoChart().Show();
        }

        /*private void ViewGraficoCliente()
        {
            new GraficoCliente().Show();
        }*/

        public void ViewDoblePanel()
        {
            new DoblePanel().Show();
        }

        /*private void ViewGraficoCamion()
        {
            new GraficoCamion().Show();
        }*/

        public void ViewDoblePanel2()
        {
            new DoblePanel2().Show();
        }
        
        public void ViewGraficoComodidad()
        {
            new GraficoComodidad().Show();
        }
        
        private void BuildMenu()
        {
            this.Menu = new MainMenu();

            // Quit
            var opQuit = new MenuItem("&Quit")
            {
                Shortcut = Shortcut.CtrlQ
            };

            opQuit.Click += (sender, args) => {
                this.OnQuit();
            };

            // View grafico camion

            var opDoblePanel2 = new MenuItem("&Grafico camion")
            {
                Shortcut = Shortcut.CtrlF5
            };

            opDoblePanel2.Click += (sender, args) => this.ViewDoblePanel2();

            // View grafico cliente

            var opDoblePanel = new MenuItem("&Grafico cliente")
            {
                Shortcut = Shortcut.CtrlF6
            };

            opDoblePanel.Click += (sender, args) => this.ViewDoblePanel();

            // View chart demo
            var opChartDemo = new MenuItem("&Chart demo")
            {
                Shortcut = Shortcut.CtrlF11
            };

            opChartDemo.Click += (sender, args) => this.ViewDemoChart();

            // View grafico comodidades
            var opGraficoComodidad = new MenuItem("&Chart demo")
            {
                Shortcut = Shortcut.CtrlF7
            };

            opGraficoComodidad.Click += (sender, args) => this.ViewGraficoComodidad();
            
            // Main menus
            var mFile = new MenuItem("&File");
            var mView = new MenuItem("&View");

            // Add options to menus
            mFile.MenuItems.Add(opQuit);


            mView.MenuItems.Add(opChartDemo);
            mView.MenuItems.Add(opDoblePanel);
            mView.MenuItems.Add(opDoblePanel2);
            mView.MenuItems.Add(opGraficoComodidad);

            this.Menu.MenuItems.Add(mFile);
            this.Menu.MenuItems.Add(mView);
        }

        private void Build()
        {
            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;

            this.btFirst = new Button
            {
                Text = "Grafico general",
                Dock = DockStyle.Top
            };

            var btSecond = new Button
            {
                Text = "Grafico por cliente",
                Dock = DockStyle.Top
            };

            var btThird = new Button
            {
                Text = "Grafico por camion",
                Dock = DockStyle.Top
            };
            
            var btFour = new Button
            {
                Text = "Grafico por comodidad",
                Dock = DockStyle.Top
            };
            
            btFirst.Click += (sender, args) => ViewDemoChart();
            btSecond.Click += (sender, args) => ViewDoblePanel();
            btThird.Click += (sender, args) => ViewDoblePanel2();
            btFour.Click += (sender, args) => ViewGraficoComodidad();

            pnlTable.Controls.Add(btFirst);
            pnlTable.Controls.Add(btSecond);
            pnlTable.Controls.Add(btThird);
            pnlTable.Controls.Add(btFour);

            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

            this.BuildMenu();
            this.MinimumSize = new Size(320, 240);
            this.Text = "WinFormsDemo";
        }
        
        public Button btFirst { get; set; }
    }
}
