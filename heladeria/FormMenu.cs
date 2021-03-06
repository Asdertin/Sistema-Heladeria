using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heladeria
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login();

        }

        private void login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();


            toolStripStatusLabel2.Text = "Usuario: matrix";
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProductos = new FormProductos();
            formProductos.MdiParent = this;
            formProductos.Show();
        }

                private void accesoRapidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

              private void FormMenu_Load(object sender, EventArgs e)
        {
            login();
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void heladeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteProductos = new FormReporteProductos();
            formReporteProductos.MdiParent = this;
            formReporteProductos.Show();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFacturas = new FormReporteFacturas();
            formReporteFacturas.MdiParent = this;
            formReporteFacturas.Show();
        }
    }
}
