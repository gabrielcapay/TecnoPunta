using ProyectoTaller.CNegocio;
using ProyectoTaller.Questpdf;
using System;
using System.Windows.Forms;

namespace ProyectoTaller.Views.Gerentes
{
    public partial class ReporteInformeGeneral : Form
    {
        private bool CBListaPreciosActivo = false;
        private bool CBListaClientesActivo = false;
        private bool CBReporteVentasActivo = false;
        public ReporteInformeGeneral()
        {
            InitializeComponent();
            DTPDesde.Enabled = false;
            DTPHasta.Enabled = false;

           
            CBReporteVentas.Click += CBReporteVentas_Click;
        }

        private void CBReporteVentas_Click(object sender, EventArgs e)
        {
            
            bool habilitar = !DTPDesde.Enabled;

            DTPDesde.Enabled = habilitar;
            DTPHasta.Enabled = habilitar;
        }

        private void LTituloReporteVentas_Click(object sender, System.EventArgs e)
        {

        }


        private void CBReporteStock_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void CBReporteProducto_CheckedChanged(object sender, System.EventArgs e)
        {
            CBListaPreciosActivo = !CBListaPreciosActivo;

            
            CBListaClientes.Enabled = !CBListaPreciosActivo;
            CBReporteVentas.Enabled = !CBListaPreciosActivo;
        }

        private void CBReporteVentas_CheckedChanged(object sender, System.EventArgs e)
        {
            CBReporteVentasActivo = !CBReporteVentasActivo;

            
            CBListaPrecios.Enabled = !CBReporteVentasActivo;
            CBListaClientes.Enabled = !CBReporteVentasActivo;
        }

        private void CBReporteCliente_CheckedChanged(object sender, System.EventArgs e)
        {
            CBListaClientesActivo = !CBListaClientesActivo;

            
            CBListaPrecios.Enabled = !CBListaClientesActivo;
            CBReporteVentas.Enabled = !CBListaClientesActivo;
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void BImprimir_Click(object sender, System.EventArgs e)
        {
            
            if (CBListaClientes.Enabled == true && CBListaPrecios.Enabled == false && CBReporteVentas.Enabled == false)
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                var documento = new ListaDeClientes(clienteNegocio.ObtenerClientes());
                documento.crearDocumento();

            }
           
            else if (CBListaPrecios.Enabled == true && CBListaClientes.Enabled == false && CBReporteVentas.Enabled == false)
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                var documento = new ListaDePrecio(productoNegocio.cargarProductos());
                documento.crearDocumento();
            }
            else if (CBReporteVentas.Enabled == true && CBListaPrecios.Enabled == false && CBListaClientes.Enabled == false)
            {
               VentaNegocio ventaNegocio = new VentaNegocio();

                DateTime fechaDesde = DTPDesde.Value;
                DateTime fechaHasta = DTPHasta.Value;

                var documento = new ListaDeVenta(ventaNegocio.ObtenerVentasPorRangoDeFechas(DTPDesde.Value, DTPHasta.Value));
                documento.crearDocumento();
            }
            else
            {
               
                MessageBox.Show("Por favor, seleccione una opción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BLimpiar_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea limpiar todos los filtros?", "Confirmar limpieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                
                CBListaPrecios.Checked = false;
                CBReporteVentas.Checked = false;
                CBListaClientes.Checked = false;

                DTPDesde.Value = DateTime.Now;
                DTPHasta.Value = DateTime.Now;

                MessageBox.Show("Los filtros han sido limpiados.", "Filtros Restablecidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
