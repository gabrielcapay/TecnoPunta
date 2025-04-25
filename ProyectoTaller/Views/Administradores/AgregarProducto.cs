using ProyectoTaller.CDatos;
using ProyectoTaller.CModelos;
using ProyectoTaller.CNegocio;
using ProyectoTaller.DTO;
using System;
using System.Collections.Generic;
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
            LimpiarMensajesDeValidacion();
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

            // Validaciones
            bool valido = true;

            if (string.IsNullOrEmpty(marca))
            {
                LValiMarca.ForeColor = Color.Red;
                LValiMarca.Text = "Seleccione una Marca.";
                valido = false;
            }
            else
            {
                LValiMarca.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                LValiNombre.ForeColor = Color.Red;
                LValiNombre.Text = "Ingrese el nombre del producto.";
                valido = false;
            }
            else if (nombreProducto.Length < 5)
            {
                LValiNombre.ForeColor = Color.Red;
                LValiNombre.Text = "Al menos 5 caracteres.";
                valido = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(nombreProducto, @"^[a-zA-Z0-9]"))
            {
                LValiNombre.ForeColor = Color.Red;
                LValiNombre.Text = "El Nombre debe contener solo letras y números.";
                valido = false;
            }
            else
            {
                LValiNombre.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                LValiModelo.ForeColor = Color.Red;
                LValiModelo.Text = "Ingrese un modelo.";
                valido = false;
            }
            else if (modelo.Length < 3 || modelo.Length > 12)
            {
                LValiModelo.ForeColor = Color.Red;
                LValiModelo.Text = "Modelo de 3 a 12 caracteres.";
                valido = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(modelo, @"^[a-zA-Z0-9]"))
            {
                LValiModelo.ForeColor = Color.Red;
                LValiModelo.Text = "El modelo debe contener solo letras y números.";
                valido = false;
            }
            else
            {
                LValiModelo.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(sistemaOperativo))
            {
                LValiSo.ForeColor = Color.Red;
                LValiSo.Text = "Ingrese un Sistema Operativo.";
                valido = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(sistemaOperativo, @"^[a-zA-Z0-9]"))
            {
                LValiSo.ForeColor = Color.Red;
                LValiSo.Text = "El S.O debe contener solo letras y números.";
                valido = false;
            }
            else if (sistemaOperativo.Length < 2 || sistemaOperativo.Length > 20)
            {
                LValiSo.ForeColor = Color.Red;
                LValiSo.Text = "S.O de 2 a 20 caracteres.";
                valido = false;
            }
            else
            {
                LValiSo.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(almacenamientoTexto))
            {
                LValiAlmacenamiento.ForeColor = Color.Red;
                LValiAlmacenamiento.Text = "Ingrese un almacenamiento.";
                valido = false;
            }
            else if (!int.TryParse(almacenamientoTexto, out int almacenamiento))
            {
                LValiAlmacenamiento.ForeColor = Color.Red;
                LValiAlmacenamiento.Text = "El almacenamiento debe ser un número entero.";
                valido = false;
            }
            else if (almacenamiento <= 32 || almacenamiento > 1024)
            {
                LValiAlmacenamiento.ForeColor = Color.Red;
                LValiAlmacenamiento.Text = "El almacenamiento debe estar entre 32 y 1024 GB.";
                valido = false;
            }
            else
            {
                LValiAlmacenamiento.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(ramTexto))
            {
                LValiRam.ForeColor = Color.Red;
                LValiRam.Text = "Ingrese una Ram";
                valido = false;
            }
            else if (!int.TryParse(ramTexto, out int ram))
            {
                LValiRam.ForeColor = Color.Red;
                LValiRam.Text = "La Ram debe ser un número entero.";
                valido = false;
            }
            else if (ram <= 1 || ram > 32)
            {
                LValiRam.ForeColor = Color.Red;
                LValiRam.Text = "La Ram debe estar entre 1 y 32 GB.";
                valido = false;
            }
            else
            {
                LValiRam.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(stockTexto))
            {
                LValiStock.ForeColor = Color.Red;
                LValiStock.Text = "Ingrese un stock.";
                valido = false;
            }
            else if (!int.TryParse(stockTexto, out int stock))
            {
                LValiStock.ForeColor = Color.Red;
                LValiStock.Text = "El Stock debe ser un número entero.";
                valido = false;
            }
            else if (stock <= 1 || stock > 1500)
            {
                LValiStock.ForeColor = Color.Red;
                LValiStock.Text = "Stock hasta 1500 unidades.";
                valido = false;
            }
            else
            {
                LValiStock.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(precioTexto))
            {
                LValiPrecio.ForeColor = Color.Red;
                LValiPrecio.Text = "Ingrese un precio.";
                valido = false;
            }
            else if (!decimal.TryParse(precioTexto, out decimal precio))
            {
                LValiPrecio.ForeColor = Color.Red;
                LValiPrecio.Text = "El Precio debe ser un número decimal.";
                valido = false;
            }
            else
            {
                LValiPrecio.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(estado))
            {
                LValiEstado.ForeColor = Color.Red;
                LValiEstado.Text = "Seleccione un Estado.";
                valido = false;
            }
            else
            {
                LValiEstado.Text = string.Empty;
            }

            if (valido)
            {
                LimpiarMensajesDeValidacion();

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
                                Modelo_Producto = TModelo.Text,
                                Nombre_Producto = TNombreProducto.Text,
                                SistemaOperativo_Producto = TSo.Text,
                                Almacenamiento_Producto = TAlmacenamiento.Text,
                                Ram_Producto = TRam.Text,
                                Stock_Producto = int.Parse(TStock.Text),
                                Precio_Producto = decimal.Parse(TPrecio.Text),
                                Marca = CBMarca.SelectedItem as Marca,
                                Condicion = CBEstado.SelectedItem as Condicion
                            };
                            productoNegocio = new ProductoNegocio();
                            productoNegocio.actualizarProducto(productoActualizar);

                            LValido.Text = "Producto editado exitosamente.";
                            CargarCondicion();
                            cargarMarcas();
                            CargarProductos();
                            TModelo.ReadOnly = false;
                            TModelo.BackColor = Color.White;
                        }

                        editando = false;
                        filaSeleccionadaIndex = -1;

                        LimpiarCampos();
                    }
                    else
                    {
                        if (!ValidarModelo(TModelo.Text))
                        {
                            return;
                        }

                        Producto productoGuardar = new Producto
                        {
                            Modelo_Producto = TModelo.Text,
                            Nombre_Producto = TNombreProducto.Text,
                            SistemaOperativo_Producto = TSo.Text,
                            Almacenamiento_Producto = TAlmacenamiento.Text,
                            Ram_Producto = TRam.Text,
                            Stock_Producto = int.Parse(TStock.Text), 
                            Precio_Producto = decimal.Parse(TPrecio.Text), 
                            Marca = CBMarca.SelectedItem as Marca, 
                            Condicion = CBEstado.SelectedItem as Condicion 
                        };

                        productoNegocio = new ProductoNegocio();
                        productoNegocio.guardarProducto(productoGuardar);


                        LValido.Text = "Producto agregado exitosamente.";

                        LimpiarCampos();
                        CargarCondicion();
                        CargarProductos();
                        cargarMarcas();
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
                LimpiarMensajesDeValidacion();
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
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error de edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (DGProductos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in DGProductos.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DGProductos.Rows.Remove(row);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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