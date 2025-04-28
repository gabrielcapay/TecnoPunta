namespace ProyectoTaller.Views.Administradores
{
    partial class AgregarProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LTituloAgregar = new System.Windows.Forms.Label();
            this.TNombreProducto = new System.Windows.Forms.TextBox();
            this.LNombreProducto = new System.Windows.Forms.Label();
            this.LModelo = new System.Windows.Forms.Label();
            this.LMarca = new System.Windows.Forms.Label();
            this.LStock = new System.Windows.Forms.Label();
            this.TModelo = new System.Windows.Forms.TextBox();
            this.TSo = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LValiNombre = new System.Windows.Forms.Label();
            this.LValiModelo = new System.Windows.Forms.Label();
            this.LValiMarca = new System.Windows.Forms.Label();
            this.LValiStock = new System.Windows.Forms.Label();
            this.LValido = new System.Windows.Forms.Label();
            this.PBImagenTitulo = new System.Windows.Forms.PictureBox();
            this.LValiSo = new System.Windows.Forms.Label();
            this.TAlmacenamiento = new System.Windows.Forms.TextBox();
            this.LSo = new System.Windows.Forms.Label();
            this.LValiAlmacenamiento = new System.Windows.Forms.Label();
            this.TRam = new System.Windows.Forms.TextBox();
            this.LAlmacenamiento = new System.Windows.Forms.Label();
            this.LValiRam = new System.Windows.Forms.Label();
            this.TStock = new System.Windows.Forms.TextBox();
            this.LRam = new System.Windows.Forms.Label();
            this.LValiPrecio = new System.Windows.Forms.Label();
            this.TPrecio = new System.Windows.Forms.TextBox();
            this.LPrecio = new System.Windows.Forms.Label();
            this.LValiEstado = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.BEliminar = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
            this.BBorrar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.DGProductos = new System.Windows.Forms.DataGridView();
            this.TBuscarProducto = new System.Windows.Forms.TextBox();
            this.LBuscarProducto = new System.Windows.Forms.Label();
            this.CBReacondicionado = new System.Windows.Forms.CheckBox();
            this.CBNuevo = new System.Windows.Forms.CheckBox();
            this.CBMarca = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloAgregar
            // 
            this.LTituloAgregar.AutoSize = true;
            this.LTituloAgregar.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloAgregar.Location = new System.Drawing.Point(82, 9);
            this.LTituloAgregar.Name = "LTituloAgregar";
            this.LTituloAgregar.Size = new System.Drawing.Size(155, 36);
            this.LTituloAgregar.TabIndex = 0;
            this.LTituloAgregar.Text = "Productos";
            // 
            // TNombreProducto
            // 
            this.TNombreProducto.Location = new System.Drawing.Point(187, 95);
            this.TNombreProducto.Name = "TNombreProducto";
            this.TNombreProducto.Size = new System.Drawing.Size(205, 20);
            this.TNombreProducto.TabIndex = 1;
            this.TNombreProducto.TextChanged += new System.EventHandler(this.TNombreProducto_TextChanged);
            // 
            // LNombreProducto
            // 
            this.LNombreProducto.AutoSize = true;
            this.LNombreProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombreProducto.Location = new System.Drawing.Point(106, 98);
            this.LNombreProducto.Name = "LNombreProducto";
            this.LNombreProducto.Size = new System.Drawing.Size(61, 17);
            this.LNombreProducto.TabIndex = 2;
            this.LNombreProducto.Text = "Nombre";
            // 
            // LModelo
            // 
            this.LModelo.AutoSize = true;
            this.LModelo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LModelo.Location = new System.Drawing.Point(106, 142);
            this.LModelo.Name = "LModelo";
            this.LModelo.Size = new System.Drawing.Size(57, 17);
            this.LModelo.TabIndex = 3;
            this.LModelo.Text = "Modelo";
            // 
            // LMarca
            // 
            this.LMarca.AutoSize = true;
            this.LMarca.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMarca.Location = new System.Drawing.Point(106, 54);
            this.LMarca.Name = "LMarca";
            this.LMarca.Size = new System.Drawing.Size(49, 17);
            this.LMarca.TabIndex = 4;
            this.LMarca.Text = "Marca";
            // 
            // LStock
            // 
            this.LStock.AutoSize = true;
            this.LStock.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStock.Location = new System.Drawing.Point(420, 98);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(43, 17);
            this.LStock.TabIndex = 5;
            this.LStock.Text = "Stock";
            // 
            // TModelo
            // 
            this.TModelo.Location = new System.Drawing.Point(187, 139);
            this.TModelo.Name = "TModelo";
            this.TModelo.Size = new System.Drawing.Size(205, 20);
            this.TModelo.TabIndex = 6;
            this.TModelo.TextChanged += new System.EventHandler(this.TPrecio_TextChanged);
            // 
            // TSo
            // 
            this.TSo.Location = new System.Drawing.Point(187, 183);
            this.TSo.Name = "TSo";
            this.TSo.Size = new System.Drawing.Size(205, 20);
            this.TSo.TabIndex = 8;
            this.TSo.TextChanged += new System.EventHandler(this.TStock_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LValiNombre
            // 
            this.LValiNombre.AutoSize = true;
            this.LValiNombre.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LValiNombre.ForeColor = System.Drawing.Color.Red;
            this.LValiNombre.Location = new System.Drawing.Point(187, 118);
            this.LValiNombre.Name = "LValiNombre";
            this.LValiNombre.Size = new System.Drawing.Size(0, 13);
            this.LValiNombre.TabIndex = 28;
            // 
            // LValiModelo
            // 
            this.LValiModelo.AutoSize = true;
            this.LValiModelo.ForeColor = System.Drawing.Color.Red;
            this.LValiModelo.Location = new System.Drawing.Point(187, 162);
            this.LValiModelo.Name = "LValiModelo";
            this.LValiModelo.Size = new System.Drawing.Size(0, 13);
            this.LValiModelo.TabIndex = 29;
            // 
            // LValiMarca
            // 
            this.LValiMarca.AutoSize = true;
            this.LValiMarca.ForeColor = System.Drawing.Color.Red;
            this.LValiMarca.Location = new System.Drawing.Point(187, 74);
            this.LValiMarca.Name = "LValiMarca";
            this.LValiMarca.Size = new System.Drawing.Size(0, 13);
            this.LValiMarca.TabIndex = 30;
            // 
            // LValiStock
            // 
            this.LValiStock.AutoSize = true;
            this.LValiStock.ForeColor = System.Drawing.Color.Red;
            this.LValiStock.Location = new System.Drawing.Point(501, 117);
            this.LValiStock.Name = "LValiStock";
            this.LValiStock.Size = new System.Drawing.Size(0, 13);
            this.LValiStock.TabIndex = 31;
            // 
            // LValido
            // 
            this.LValido.AutoSize = true;
            this.LValido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValido.ForeColor = System.Drawing.Color.Green;
            this.LValido.Location = new System.Drawing.Point(295, 24);
            this.LValido.Name = "LValido";
            this.LValido.Size = new System.Drawing.Size(0, 21);
            this.LValido.TabIndex = 33;
            // 
            // PBImagenTitulo
            // 
            this.PBImagenTitulo.Image = global::ProyectoTaller.Properties.Resources.AgregarMenu;
            this.PBImagenTitulo.Location = new System.Drawing.Point(12, 12);
            this.PBImagenTitulo.Name = "PBImagenTitulo";
            this.PBImagenTitulo.Size = new System.Drawing.Size(65, 67);
            this.PBImagenTitulo.TabIndex = 27;
            this.PBImagenTitulo.TabStop = false;
            // 
            // LValiSo
            // 
            this.LValiSo.AutoSize = true;
            this.LValiSo.ForeColor = System.Drawing.Color.Red;
            this.LValiSo.Location = new System.Drawing.Point(187, 204);
            this.LValiSo.Name = "LValiSo";
            this.LValiSo.Size = new System.Drawing.Size(0, 13);
            this.LValiSo.TabIndex = 39;
            // 
            // TAlmacenamiento
            // 
            this.TAlmacenamiento.Location = new System.Drawing.Point(187, 227);
            this.TAlmacenamiento.Name = "TAlmacenamiento";
            this.TAlmacenamiento.Size = new System.Drawing.Size(205, 20);
            this.TAlmacenamiento.TabIndex = 38;
            // 
            // LSo
            // 
            this.LSo.AutoSize = true;
            this.LSo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSo.Location = new System.Drawing.Point(106, 184);
            this.LSo.Name = "LSo";
            this.LSo.Size = new System.Drawing.Size(55, 17);
            this.LSo.TabIndex = 37;
            this.LSo.Text = "Sist. Op";
            // 
            // LValiAlmacenamiento
            // 
            this.LValiAlmacenamiento.AutoSize = true;
            this.LValiAlmacenamiento.ForeColor = System.Drawing.Color.Red;
            this.LValiAlmacenamiento.Location = new System.Drawing.Point(187, 248);
            this.LValiAlmacenamiento.Name = "LValiAlmacenamiento";
            this.LValiAlmacenamiento.Size = new System.Drawing.Size(0, 13);
            this.LValiAlmacenamiento.TabIndex = 42;
            // 
            // TRam
            // 
            this.TRam.Location = new System.Drawing.Point(500, 54);
            this.TRam.Name = "TRam";
            this.TRam.Size = new System.Drawing.Size(205, 20);
            this.TRam.TabIndex = 41;
            // 
            // LAlmacenamiento
            // 
            this.LAlmacenamiento.AutoSize = true;
            this.LAlmacenamiento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAlmacenamiento.Location = new System.Drawing.Point(106, 228);
            this.LAlmacenamiento.Name = "LAlmacenamiento";
            this.LAlmacenamiento.Size = new System.Drawing.Size(79, 17);
            this.LAlmacenamiento.TabIndex = 40;
            this.LAlmacenamiento.Text = "Almacena.";
            // 
            // LValiRam
            // 
            this.LValiRam.AutoSize = true;
            this.LValiRam.ForeColor = System.Drawing.Color.Red;
            this.LValiRam.Location = new System.Drawing.Point(501, 74);
            this.LValiRam.Name = "LValiRam";
            this.LValiRam.Size = new System.Drawing.Size(0, 13);
            this.LValiRam.TabIndex = 45;
            // 
            // TStock
            // 
            this.TStock.Location = new System.Drawing.Point(501, 95);
            this.TStock.Name = "TStock";
            this.TStock.Size = new System.Drawing.Size(205, 20);
            this.TStock.TabIndex = 44;
            // 
            // LRam
            // 
            this.LRam.AutoSize = true;
            this.LRam.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRam.Location = new System.Drawing.Point(420, 54);
            this.LRam.Name = "LRam";
            this.LRam.Size = new System.Drawing.Size(38, 17);
            this.LRam.TabIndex = 43;
            this.LRam.Text = "Ram";
            // 
            // LValiPrecio
            // 
            this.LValiPrecio.AutoSize = true;
            this.LValiPrecio.ForeColor = System.Drawing.Color.Red;
            this.LValiPrecio.Location = new System.Drawing.Point(501, 161);
            this.LValiPrecio.Name = "LValiPrecio";
            this.LValiPrecio.Size = new System.Drawing.Size(0, 13);
            this.LValiPrecio.TabIndex = 48;
            // 
            // TPrecio
            // 
            this.TPrecio.Location = new System.Drawing.Point(501, 138);
            this.TPrecio.Name = "TPrecio";
            this.TPrecio.Size = new System.Drawing.Size(205, 20);
            this.TPrecio.TabIndex = 47;
            // 
            // LPrecio
            // 
            this.LPrecio.AutoSize = true;
            this.LPrecio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecio.Location = new System.Drawing.Point(420, 142);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new System.Drawing.Size(48, 17);
            this.LPrecio.TabIndex = 46;
            this.LPrecio.Text = "Precio";
            // 
            // LValiEstado
            // 
            this.LValiEstado.AutoSize = true;
            this.LValiEstado.ForeColor = System.Drawing.Color.Red;
            this.LValiEstado.Location = new System.Drawing.Point(501, 206);
            this.LValiEstado.Name = "LValiEstado";
            this.LValiEstado.Size = new System.Drawing.Size(0, 13);
            this.LValiEstado.TabIndex = 51;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(420, 186);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(52, 17);
            this.LEstado.TabIndex = 49;
            this.LEstado.Text = "Estado";
            // 
            // BEliminar
            // 
            this.BEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BEliminar.FlatAppearance.BorderSize = 0;
            this.BEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(738, 212);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(123, 52);
            this.BEliminar.TabIndex = 56;
            this.BEliminar.Text = "Baja / Alta";
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // BEditar
            // 
            this.BEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditar.Image = global::ProyectoTaller.Properties.Resources.editar2;
            this.BEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEditar.Location = new System.Drawing.Point(738, 154);
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(123, 52);
            this.BEditar.TabIndex = 55;
            this.BEditar.Text = "Editar    ";
            this.BEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEditar.UseVisualStyleBackColor = true;
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);
            // 
            // BBorrar
            // 
            this.BBorrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBorrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BBorrar.FlatAppearance.BorderSize = 0;
            this.BBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBorrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BBorrar.Image = global::ProyectoTaller.Properties.Resources.Eliminar;
            this.BBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBorrar.Location = new System.Drawing.Point(738, 38);
            this.BBorrar.Name = "BBorrar";
            this.BBorrar.Size = new System.Drawing.Size(123, 52);
            this.BBorrar.TabIndex = 54;
            this.BBorrar.Text = "Borrar Todo";
            this.BBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BBorrar.UseVisualStyleBackColor = true;
            this.BBorrar.Click += new System.EventHandler(this.BBorrar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregar.Image = global::ProyectoTaller.Properties.Resources.GuardarProducto;
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(738, 96);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(123, 52);
            this.BAgregar.TabIndex = 53;
            this.BAgregar.Text = "   Agregar    ";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // DGProductos
            // 
            this.DGProductos.AllowUserToAddRows = false;
            this.DGProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGProductos.Location = new System.Drawing.Point(12, 301);
            this.DGProductos.Name = "DGProductos";
            this.DGProductos.RowHeadersWidth = 51;
            this.DGProductos.Size = new System.Drawing.Size(863, 194);
            this.DGProductos.TabIndex = 58;
            // 
            // TBuscarProducto
            // 
            this.TBuscarProducto.Location = new System.Drawing.Point(176, 277);
            this.TBuscarProducto.Name = "TBuscarProducto";
            this.TBuscarProducto.Size = new System.Drawing.Size(277, 20);
            this.TBuscarProducto.TabIndex = 104;
            this.TBuscarProducto.TextChanged += new System.EventHandler(this.TBuscarProducto_TextChanged);
            // 
            // LBuscarProducto
            // 
            this.LBuscarProducto.AutoSize = true;
            this.LBuscarProducto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarProducto.Location = new System.Drawing.Point(9, 273);
            this.LBuscarProducto.Name = "LBuscarProducto";
            this.LBuscarProducto.Size = new System.Drawing.Size(159, 23);
            this.LBuscarProducto.TabIndex = 105;
            this.LBuscarProducto.Text = "Buscar Producto";
            // 
            // CBReacondicionado
            // 
            this.CBReacondicionado.AutoSize = true;
            this.CBReacondicionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBReacondicionado.Location = new System.Drawing.Point(534, 277);
            this.CBReacondicionado.Name = "CBReacondicionado";
            this.CBReacondicionado.Size = new System.Drawing.Size(54, 19);
            this.CBReacondicionado.TabIndex = 109;
            this.CBReacondicionado.Text = "BAJA";
            this.CBReacondicionado.UseVisualStyleBackColor = true;
            this.CBReacondicionado.CheckedChanged += new System.EventHandler(this.CBReacondicionado_CheckedChanged);
            // 
            // CBNuevo
            // 
            this.CBNuevo.AutoSize = true;
            this.CBNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBNuevo.Location = new System.Drawing.Point(467, 277);
            this.CBNuevo.Name = "CBNuevo";
            this.CBNuevo.Size = new System.Drawing.Size(67, 19);
            this.CBNuevo.TabIndex = 108;
            this.CBNuevo.Text = "ACTIVO";
            this.CBNuevo.UseVisualStyleBackColor = true;
            this.CBNuevo.CheckedChanged += new System.EventHandler(this.CBNuevo_CheckedChanged);
            // 
            // CBMarca
            // 
            this.CBMarca.FormattingEnabled = true;
            this.CBMarca.Location = new System.Drawing.Point(187, 53);
            this.CBMarca.Name = "CBMarca";
            this.CBMarca.Size = new System.Drawing.Size(205, 21);
            this.CBMarca.TabIndex = 111;
            this.CBMarca.Text = "Seleccione la marca";
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(501, 181);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(205, 21);
            this.CBEstado.TabIndex = 52;
            this.CBEstado.Text = "Seleccione el estado";
            // 
            // AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(887, 507);
            this.Controls.Add(this.CBMarca);
            this.Controls.Add(this.CBReacondicionado);
            this.Controls.Add(this.CBNuevo);
            this.Controls.Add(this.LBuscarProducto);
            this.Controls.Add(this.TBuscarProducto);
            this.Controls.Add(this.DGProductos);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BEditar);
            this.Controls.Add(this.BBorrar);
            this.Controls.Add(this.BAgregar);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.LValiEstado);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.LValiPrecio);
            this.Controls.Add(this.TPrecio);
            this.Controls.Add(this.LPrecio);
            this.Controls.Add(this.LValiRam);
            this.Controls.Add(this.TStock);
            this.Controls.Add(this.LRam);
            this.Controls.Add(this.LValiAlmacenamiento);
            this.Controls.Add(this.TRam);
            this.Controls.Add(this.LAlmacenamiento);
            this.Controls.Add(this.LValiSo);
            this.Controls.Add(this.TAlmacenamiento);
            this.Controls.Add(this.LSo);
            this.Controls.Add(this.LValido);
            this.Controls.Add(this.LValiStock);
            this.Controls.Add(this.LValiMarca);
            this.Controls.Add(this.LValiModelo);
            this.Controls.Add(this.LValiNombre);
            this.Controls.Add(this.PBImagenTitulo);
            this.Controls.Add(this.TSo);
            this.Controls.Add(this.TModelo);
            this.Controls.Add(this.LStock);
            this.Controls.Add(this.LMarca);
            this.Controls.Add(this.LModelo);
            this.Controls.Add(this.LNombreProducto);
            this.Controls.Add(this.TNombreProducto);
            this.Controls.Add(this.LTituloAgregar);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "AgregarProducto";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionProductos";
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloAgregar;
        private System.Windows.Forms.TextBox TNombreProducto;
        private System.Windows.Forms.Label LNombreProducto;
        private System.Windows.Forms.Label LModelo;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.Label LStock;
        private System.Windows.Forms.TextBox TModelo;
        private System.Windows.Forms.TextBox TSo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox PBImagenTitulo;
        private System.Windows.Forms.Label LValiNombre;
        private System.Windows.Forms.Label LValiModelo;
        private System.Windows.Forms.Label LValiMarca;
        private System.Windows.Forms.Label LValiStock;
        private System.Windows.Forms.Label LValido;
        private System.Windows.Forms.Label LValiSo;
        private System.Windows.Forms.TextBox TAlmacenamiento;
        private System.Windows.Forms.Label LSo;
        private System.Windows.Forms.Label LValiAlmacenamiento;
        private System.Windows.Forms.TextBox TRam;
        private System.Windows.Forms.Label LAlmacenamiento;
        private System.Windows.Forms.Label LValiRam;
        private System.Windows.Forms.TextBox TStock;
        private System.Windows.Forms.Label LRam;
        private System.Windows.Forms.Label LValiPrecio;
        private System.Windows.Forms.TextBox TPrecio;
        private System.Windows.Forms.Label LPrecio;
        private System.Windows.Forms.Label LValiEstado;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BBorrar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.DataGridView DGProductos;
        private System.Windows.Forms.TextBox TBuscarProducto;
        private System.Windows.Forms.Label LBuscarProducto;
        private System.Windows.Forms.CheckBox CBReacondicionado;
        private System.Windows.Forms.CheckBox CBNuevo;
        private System.Windows.Forms.ComboBox CBMarca;
        private System.Windows.Forms.ComboBox CBEstado;
    }
}