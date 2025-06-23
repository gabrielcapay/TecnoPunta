using ProyectoTaller.CDatos;
using ProyectoTaller.CModelos;
using ProyectoTaller.CNegocio;
using ProyectoTaller.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoTaller.Views.Administradores
{
        public partial class AgregarProducto : Form
        {
            private bool editando = false;
            private int filaSeleccionadaIndex = -1;
            private ProductoNegocio productoNegocio;

        public AgregarProducto()
        {
            InitializeComponent();
            productoNegocio = new ProductoNegocio();
            cargarMarcas();
            CargarCondicion();
            CargarProductos();
           
        }

        private void cargarMarcas()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> marcas = marcaNegocio.ListarMarca();
            CBMarca.DataSource = marcas;
            CBMarca.DisplayMember = "Nombre_Marca";
            CBMarca.ValueMember = "Id_Marca";
        }

        private void CargarCondicion()
        {
            CondicionNegocio condicionNegocio = new CondicionNegocio();
            List<Condicion> conciones = condicionNegocio.ListarCondiciones();
            CBEstado.DataSource = conciones;
            CBEstado.DisplayMember = "Descripcion_Condicion";
            CBEstado.ValueMember = "Id_Condicion";
        }
        private void BAgregar_Click(object sender, EventArgs e)
        {
            BAgregar.Text = "Agregar";

            string marca = CBMarca.SelectedItem?.ToString();
            string nombreProducto = TNombreProducto.Text;
            string modelo = TModelo.Text;
            string sistemaOperativo = TSo.Text;
            string almacenamientoTexto = TAlmacenamiento.Text;
            string ramTexto = TRam.Text;
            string estado = CBEstado.SelectedItem?.ToString();
            string stockTexto = TStock.Text;
            string precioTexto = TPrecio.Text;

            string mensaje = editando ? "¿Está seguro que desea modificar el producto?" : "¿Está seguro que desea agregar el producto?";
            var result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (editando)
                {
                    if (filaSeleccionadaIndex >= 0)
                    {
                        Producto productoActualizar = new Producto
                        {
                            Modelo_Producto = modelo,
                            Nombre_Producto = nombreProducto,
                            SistemaOperativo_Producto = sistemaOperativo,
                            Almacenamiento_Producto = almacenamientoTexto,
                            Ram_Producto = ramTexto,
                            Stock_Producto = int.Parse(stockTexto),
                            Precio_Producto = decimal.Parse(precioTexto),
                            Marca = CBMarca.SelectedItem as Marca,
                            Condicion = CBEstado.SelectedItem as Condicion
                        };

                        try
                        {
                            productoNegocio = new ProductoNegocio();
                            productoNegocio.validarDatos(productoActualizar); // Validar en base de datos
                            productoNegocio.actualizarProducto(productoActualizar); // Actualizar si valida

                            LValido.Text = "Producto editado exitosamente.";
                            CargarCondicion();
                            cargarMarcas();
                            CargarProductos();
                            TModelo.ReadOnly = false;
                            TModelo.BackColor = Color.White;
                            LimpiarCampos();
                            editando = true;
                        }
                        catch (SqlException ex)
                        {
                            this.seleccionandDatos();
                            MessageBox.Show("Error al validar el producto: " + ex.Message, "Validación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.seleccionandDatos();
                        }
                    }
                    filaSeleccionadaIndex = -1;
                    editando = false;



                }
                else
                {
                    Producto productoGuardar = new Producto
                    {
                        Modelo_Producto = modelo,
                        Nombre_Producto = nombreProducto,
                        SistemaOperativo_Producto = sistemaOperativo,
                        Almacenamiento_Producto = almacenamientoTexto,
                        Ram_Producto = ramTexto,
                        Stock_Producto = int.TryParse(TStock.Text, out var s) ? s : 0,
                        Precio_Producto = decimal.TryParse(TPrecio.Text, out var p) ? p : 0m,
                        Marca = CBMarca.SelectedItem as Marca,
                        Condicion = CBEstado.SelectedItem as Condicion
                    };

                    try
                    {
                        productoNegocio = new ProductoNegocio();
                        productoNegocio.validarDatos(productoGuardar); // Validar en base de datos
                        productoNegocio.guardarProducto(productoGuardar); // Guardar si valida

                        LValido.Text = "Producto agregado exitosamente.";
                        LimpiarCampos();
                        CargarCondicion();
                        CargarProductos();
                        cargarMarcas();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al validar el producto: " + ex.Message, "Validación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
            }
        }


        private void LimpiarCampos()
        {
            CBMarca.SelectedIndex = -1;
            TNombreProducto.Clear();
            TModelo.Clear();
            TAlmacenamiento.Clear();
            TRam.Clear();
            TStock.Clear();
            CBEstado.SelectedIndex = -1;
            TSo.Clear();
            TPrecio.Clear();
        }

        private bool ValidarModelo(string modelo)
        {
            int filaSeleccionadaIndex = DGProductos.SelectedCells.Count > 0
                ? DGProductos.SelectedCells[0].RowIndex
                : -1;

            foreach (DataGridViewRow fila in DGProductos.Rows)
            {
                if (fila.Index != filaSeleccionadaIndex &&
                    fila.Cells["Modelo"].Value != null &&
                    fila.Cells["Modelo"].Value.ToString() == modelo)
                {
                    LValiModelo.ForeColor = Color.Red;
                    LValiModelo.Text = "El Modelo ya está registrado.";
                    return false;
                }
            }

            LValiModelo.Text = string.Empty;
            return true;
        }

        private void BBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea borrar todos los datos?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (editando)
                {
                    CBMarca.SelectedIndex = -1;
                    TNombreProducto.Clear();
                    TSo.Clear();
                    TAlmacenamiento.Clear();
                    TRam.Clear();
                    CBEstado.SelectedIndex = -1;
                    TStock.Clear();
                    TPrecio.Clear();
                    MessageBox.Show("Datos Borrados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {



                    CBMarca.SelectedIndex = -1;
                    TNombreProducto.Clear();
                    TModelo.Clear();
                    TSo.Clear();
                    TAlmacenamiento.Clear();
                    TRam.Clear();
                    CBEstado.SelectedIndex = -1;
                    MessageBox.Show("Datos Borrados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LValido.Text = string.Empty;
                TModelo.ReadOnly = false;
                TModelo.BackColor = Color.White;
                TModelo.Clear();
                LimpiarMensajesDeValidacion();
                cargarMarcas();
                
            }
        }

        private void LimpiarMensajesDeValidacion()
        {
            LValiMarca.Text = string.Empty;
            LValiNombre.Text = string.Empty;
            LValiModelo.Text = string.Empty;
            LValiSo.Text = string.Empty;
            LValiAlmacenamiento.Text = string.Empty;
            LValiRam.Text = string.Empty;
            LValiEstado.Text = string.Empty;
            LValiStock.Text = string.Empty;
            LValiPrecio.Text = string.Empty;
        }

        private void CBMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMarca.SelectedIndex != -1)
            {
                LValiMarca.Text = string.Empty;
            }
        }

        private void TNombreProducto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TNombreProducto.Text))
            {
                LValiNombre.Text = string.Empty;
            }
        }

        private void TModeloTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TModelo.Text))
            {
                LModelo.Text = string.Empty;
            }
        }

        private void TSo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TSo.Text))
            {
                LSo.Text = string.Empty;
            }
        }

        private void TAlmacenamiento_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TAlmacenamiento.Text))
            {
                LAlmacenamiento.Text = string.Empty;
            }
        }

        private void TRam_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TRam.Text))
            {
                LRam.Text = string.Empty;
            }
        }

        private void TPrecio_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TPrecio.Text, out decimal precio) && precio > 0)
            {
                LValiPrecio.Text = string.Empty;
            }
        }

        private void TStock_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TStock.Text, out int stock) && stock >= 0)
            {
                LValiStock.Text = string.Empty;
            }
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEstado.SelectedIndex != -1)
            {
                LValiEstado.Text = string.Empty;
            }
        }

     
        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            LimpiarMensajesDeValidacion();

            if (DGProductos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea editar el producto seleccionado?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    this.seleccionandDatos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error de edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void seleccionandDatos() {
            filaSeleccionadaIndex = DGProductos.SelectedRows[0].Index;

            string marcaNombre = DGProductos.Rows[filaSeleccionadaIndex].Cells["Marca"].Value.ToString();
            string condicionDescripcion = DGProductos.Rows[filaSeleccionadaIndex].Cells["Condicion"].Value.ToString();


            CBMarca.SelectedItem = DGProductos.Rows[filaSeleccionadaIndex].Cells["Marca"].Value.ToString();
            TNombreProducto.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Nombre"].Value.ToString();
            TModelo.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Modelo"].Value.ToString();
            TSo.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["SistemaOperativo"].Value.ToString();
            TAlmacenamiento.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Almacenamiento"].Value.ToString().Replace("GB", ""); ;
            TRam.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Ram"].Value.ToString().Replace("GB", "");
            TStock.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Stock"].Value.ToString();
            TPrecio.Text = DGProductos.Rows[filaSeleccionadaIndex].Cells["Precio"].Value.ToString();
            CBEstado.SelectedItem = DGProductos.Rows[filaSeleccionadaIndex].Cells["Condicion"].Value.ToString();

            CBMarca.SelectedItem = CBMarca.Items.Cast<Marca>().FirstOrDefault(m => m.Nombre_Marca == marcaNombre);


            CBEstado.SelectedItem = CBEstado.Items.Cast<Condicion>().FirstOrDefault(c => c.Descripcion_Condicion == condicionDescripcion);

            TModelo.ReadOnly = true;
            TModelo.BackColor = Color.LightGray;
            editando = true;

            BAgregar.Text = "Modificar";

        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (DGProductos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea cambiar el estado del producto seleccionado?", "Confirmar cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var modeloCell = DGProductos.SelectedRows[0].Cells["Modelo"].Value;

                    if (modeloCell != null && !string.IsNullOrEmpty(modeloCell.ToString()))
                    {
                        string modeloProducto = modeloCell.ToString();

                        try
                        {
                            ProductoNegocio productoNegocio = new ProductoNegocio();
                            productoNegocio.modificarEstadoProducto(modeloProducto);

                            MessageBox.Show("Estado del producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                            CargarProductos();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error al cambiar estado del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El modelo del producto seleccionado está vacío o no se pudo obtener.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para cambiar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string filtro = TBuscarProducto.Text.ToLower();
            foreach (DataGridViewRow fila in DGProductos.Rows)
            {
                if (fila.Cells["Nombre"].Value != null)
                {
                    string nombreProducto = fila.Cells["Nombre"].Value.ToString().ToLower();
                    string modeloProducto = fila.Cells["Modelo"].Value.ToString().ToLower();
                    string marcaProducto = fila.Cells["Marca"].Value.ToString().ToLower();
                    string soProducto = fila.Cells["SistemaOperativo"].Value.ToString().ToLower();

                    if (nombreProducto.Contains(filtro) || modeloProducto.Contains(filtro) || marcaProducto.Contains(filtro) || soProducto.Contains(filtro))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        DGProductos.CurrentCell = null;
                        fila.Visible = false;
                    }
                }
            }
        }

        private void CargarProductos()
        {
            List <ProductoDTO> productos = productoNegocio.cargarProductos();
            DGProductos.DataSource = productos;
        }

        private void CBNuevo_CheckedChanged(object sender, EventArgs e)
        {
            // Desmarcar otros CheckBoxes si CBNuevo está seleccionado
            if (CBNuevo.Checked)
            {
                CBReacondicionado.Checked = false;
                
            }

            FiltrarPorEstado();
        }

        private void CBReacondicionado_CheckedChanged(object sender, EventArgs e)
        {
            // Desmarcar otros CheckBoxes si CBReacondicionado está seleccionado
            if (CBReacondicionado.Checked)
            {
                CBNuevo.Checked = false;
                
            }

            FiltrarPorEstado();
        }

 

        private void FiltrarPorEstado()
        {
            bool hayFiltroActivo = CBNuevo.Checked || CBReacondicionado.Checked ;

            foreach (DataGridViewRow fila in DGProductos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    if (!hayFiltroActivo)
                    {
                        fila.Visible = true;
                    }
                    else if (CBNuevo.Checked && fila.Cells["Condicion"].Value.ToString() == "ACTIVO")
                    {
                        fila.Visible = true;
                    }
                    else if (CBReacondicionado.Checked && fila.Cells["Condicion"].Value.ToString() == "BAJA")
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        DGProductos.CurrentCell = null;
                        fila.Visible = false;
                    }
                }
            }
        }
    }
}