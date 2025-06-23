using ProyectoTaller.CModelos;
using ProyectoTaller.CNegocio;
using ProyectoTaller.DTO;
using ProyectoTaller.Questpdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace ProyectoTaller.Views.Vendedor
{
    public partial class ConfirmarVenta : Form
    {
        private int _dniUsuario;

        private CarritoNegocio carritoNegocio;
        private ClienteNegocio clienteNegocio;
        private VentaNegocio ventaNegocio;
        private bool clienteActivo;
        public ConfirmarVenta(int dniUsuario)
        {
            InitializeComponent();
            _dniUsuario = dniUsuario;
            cargarCarrito();
            clienteActivo = false;

        }

        public void cargarCarrito()
        {
            carritoNegocio = new CarritoNegocio();
            DGCarrito.DataSource = carritoNegocio.cargarCarito(_dniUsuario).detalles;
            decimal totalFinalizarCompra = carritoNegocio.cargarCarito(_dniUsuario).total;
            LTotalFinalizarCompra.Text = totalFinalizarCompra.ToString() + " $";
            DGCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }


        private void ConfirmarVenta_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BConfirmarCompraFinalizarCompra_Click(object sender, EventArgs e)
        {
            bool bandera = true;
            if (!clienteActivo == true)
            {
                MessageBox.Show("Seleccione el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
                return;

            }
            if (!(CBTarjetaDeCredito.Checked || CBTarjetaDeDebito.Checked || CBBilleteraVirtual.Checked || CBEfectivo.Checked))
            {
                MessageBox.Show("Debes elegir el metodo de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
                return;
            }
            if (DGCarrito.Rows.Count == 0) // Verifica si no hay filas en el DataGridView
            {
                MessageBox.Show("El carrito debe tener al menos un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
                return;
            }

            if (bandera == true)
            {
                DialogResult resultado = MessageBox.Show("¿Desea terminar la venta?.", "Finalizacion de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    List<CarritoDetalleDTO> carritoDetalle = new List<CarritoDetalleDTO>();
                    decimal totalCompra = 0;
                    foreach (DataGridViewRow row in DGCarrito.Rows)
                    {
                        if (row.DataBoundItem is CarritoDetalleDTO detalle)
                        {

                            carritoDetalle.Add(detalle);
                        }
                    }

                    decimal.TryParse(LTotalFinalizarCompra.Text, out totalCompra);

                    CarritoDTO carritoParaVender = new CarritoDTO
                    {
                        total = carritoNegocio.cargarCarito(_dniUsuario).total,
                        detalles = carritoDetalle

                    };
                    int dniCliente;
                    int.TryParse(LDNICompraFinCompra.Text, out dniCliente);
                    ventaNegocio = new VentaNegocio();
                    int idventa = ventaNegocio.rigistrarVenta(carritoParaVender, ObtenerMetodoPagoSeleccionado(), dniCliente, _dniUsuario);
                    var venta = ventaNegocio.buscarVentaPorId(idventa);
                    MessageBox.Show("La venta se registró correctamente.", "Venta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DGCarrito.DataSource = null;



                    Carrito carrito = new Carrito(_dniUsuario);
                    carrito.cargarCarrito();
                }




            }





        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Configurar el tamaño de la hoja A4
            float pageWidth = e.MarginBounds.Width;  // Ancho útil
            int margin = 20; // Márgenes

            // Fuentes
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 12);

            // Brochas
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush headerBrush = new SolidBrush(Color.LightGray);

            // Logo de la empresa
            g.FillRectangle(Brushes.Blue, margin, margin, 160, 50); // Logo representado como un rectángulo
            g.DrawString("TECNO PUNTA", new Font("Arial", 14, FontStyle.Bold), Brushes.White, margin + 5, margin + 15);

            // Información del cliente
            g.DrawString("Información del Cliente", titleFont, brush, margin, margin + 70);
            g.FillRectangle(headerBrush, new Rectangle(margin, margin + 100, (int)(pageWidth - margin * 2), 30));
            g.DrawString("Nombre", headerFont, brush, margin + 10, margin + 105);
            g.DrawString("Apellido", headerFont, brush, margin + 150, margin + 105);
            g.DrawString("DNI", headerFont, brush, margin + 300, margin + 105);
            g.DrawString("Teléfono", headerFont, brush, margin + 400, margin + 105);

            g.DrawString("Julian", contentFont, brush, margin + 10, margin + 135);
            g.DrawString("Perez", contentFont, brush, margin + 150, margin + 135);
            g.DrawString("37890275", contentFont, brush, margin + 300, margin + 135);
            g.DrawString("3794090344", contentFont, brush, margin + 400, margin + 135);



            // Método de pago
            g.DrawString("Método de Pago", titleFont, brush, margin, margin + 230);
            g.FillRectangle(headerBrush, new Rectangle(margin, margin + 260, (int)(pageWidth - margin * 2), 30));
            g.DrawString("Pago", headerFont, brush, margin + 10, margin + 265);
            g.DrawString("Fecha de Facturación", headerFont, brush, margin + 200, margin + 265);

            g.DrawString("Efectivo", contentFont, brush, margin + 10, margin + 295);
            g.DrawString(DateTime.Now.ToShortDateString(), contentFont, brush, margin + 200, margin + 295);

            // Detalle de la compra
            g.DrawString("Detalle de la Compra", titleFont, brush, margin, margin + 320);
            g.FillRectangle(headerBrush, new Rectangle(margin, margin + 350, (int)(pageWidth - margin * 2), 30));
            g.DrawString("Descripción", headerFont, brush, margin + 10, margin + 355);
            g.DrawString("Cantidad", headerFont, brush, margin + 300, margin + 355);
            g.DrawString("Precio", headerFont, brush, margin + 400, margin + 355);

            // Líneas de la factura
            g.DrawLine(Pens.Black, margin, margin + 390, pageWidth - margin, margin + 390);

            // Detalles de productos
            g.DrawString("Producto A", contentFont, brush, margin + 10, margin + 400);
            g.DrawString("2", contentFont, brush, margin + 300, margin + 400);
            g.DrawString("$20.00", contentFont, brush, margin + 400, margin + 400);

            g.DrawString("Producto B", contentFont, brush, margin + 10, margin + 430);
            g.DrawString("1", contentFont, brush, margin + 300, margin + 430);
            g.DrawString("$10.00", contentFont, brush, margin + 400, margin + 430);

            // Línea de separación
            g.DrawLine(Pens.Black, margin, margin + 460, pageWidth - margin, margin + 460);

            // Total
            g.DrawString("Total: $50.00", headerFont, brush, margin + 300, margin + 480);

            // Agrega un pie de página
            g.DrawString("Gracias por su compra!", contentFont, brush, margin + 100, margin + 520);

        }

        private void LDNICompraFinCompra_Click(object sender, EventArgs e)
        {

        }

        private void BBuscarClienteFinalizarCompra_Click(object sender, EventArgs e)
        {
            if ((int.TryParse(BXDNIClienteFinalizarCompra.Text, out int numero)))
            {
                string dniText = BXDNIClienteFinalizarCompra.Text;
                int dniCliente;
                int.TryParse(dniText, out dniCliente);
                clienteNegocio = new ClienteNegocio();
                Clientes cliente = new Clientes();

                cliente = clienteNegocio.buscarCliente(dniCliente);

                if (!(cliente == null))
                {
                    LNombreCompraFinCompra.Text = cliente.Nombre_Cliente;
                    LApellidosCompraFinCompra.Text = cliente.Apellido_Cliente;
                    LDNICompraFinCompra.Text = cliente.DNI_Cliente.ToString();
                    LTelefonoCompraFinCompra.Text = cliente.Telefono_Cliente;
                    LDireccionCompraFinCompra.Text = cliente.Direccion_Cliente;
                    LCorreoCompraFinCompra.Text = cliente.Correo_Cliente;
                    LValiBuscarCliente.Text = "";
                    clienteActivo = true;
                }
                else
                {
                    LValiBuscarCliente.Text = "Cliente no existe";
                    LValiBuscarCliente.ForeColor = Color.Red;
                }
            }
            else
            {
                LValiBuscarCliente.Text = "Ingrese un numero";
                LValiBuscarCliente.ForeColor = Color.Red;
            }





        }

        private void CBTarjetaDeCredito_CheckedChanged(object sender, EventArgs e)
        {
            cambiosEstadoCB(CBTarjetaDeCredito);
        }

        private void CBTarjetaDeDebito_CheckedChanged(object sender, EventArgs e)
        {
            cambiosEstadoCB(CBTarjetaDeDebito);
        }

        private void CBBilleteraVirtual_CheckedChanged(object sender, EventArgs e)
        {
            cambiosEstadoCB(CBBilleteraVirtual);
        }

        private void CBEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            cambiosEstadoCB(CBEfectivo);
        }

        private void cambiosEstadoCB(CheckBox checkBoxSeleccionado)
        {
            CheckBox[] checkBoxes = { CBTarjetaDeCredito, CBTarjetaDeDebito, CBBilleteraVirtual, CBEfectivo };

            foreach (var checkBox in checkBoxes)
            {

                if (checkBox != checkBoxSeleccionado)
                {
                    checkBox.Enabled = !checkBoxSeleccionado.Checked;
                }
            }
        }
        private int ObtenerMetodoPagoSeleccionado()
        {
            if (CBTarjetaDeCredito.Checked)
            {
                return 1;
            }
            else if (CBTarjetaDeDebito.Checked)
            {
                return 2;
            }
            else if (CBBilleteraVirtual.Checked)
            {
                return 3;
            }
            else if (CBEfectivo.Checked)
            {
                return 4;
            }

            return 0;
        }

        private void LTituloCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}