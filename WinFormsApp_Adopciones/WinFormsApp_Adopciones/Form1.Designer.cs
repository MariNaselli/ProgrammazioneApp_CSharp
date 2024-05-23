namespace WinFormsApp_Adopciones
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxResult = new ListBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            label1 = new Label();
            lblAnimalId = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtDescripcion = new TextBox();
            label6 = new Label();
            label7 = new Label();
            dateTimeFechaNacimiento = new DateTimePicker();
            dateTimeFechaIngreso = new DateTimePicker();
            cmbGenero = new ComboBox();
            cmbAnimalTipo = new ComboBox();
            tabControlAnimal = new TabControl();
            tabPage1 = new TabPage();
            btnEliminar = new Button();
            btnGuardar = new Button();
            tabPage2 = new TabPage();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            nuevoAnimalToolStripMenuItem = new ToolStripMenuItem();
            btnCancelar = new Button();
            tabControlAnimal.SuspendLayout();
            tabPage1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxResult
            // 
            listBoxResult.FormattingEnabled = true;
            listBoxResult.ItemHeight = 15;
            listBoxResult.Location = new Point(11, 63);
            listBoxResult.Name = "listBoxResult";
            listBoxResult.Size = new Size(217, 394);
            listBoxResult.TabIndex = 1;
            listBoxResult.SelectedIndexChanged += listBoxResult_SelectedIndexChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(11, 34);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(136, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(153, 34);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 4;
            label1.Text = "ID:";
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new Point(33, 5);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new Size(13, 15);
            lblAnimalId.TabIndex = 5;
            lblAnimalId.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 73);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(6, 93);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(149, 23);
            txtNombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 119);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 8;
            label3.Text = "Fecha de nacimiento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 164);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 9;
            label4.Text = "Genero:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 208);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 10;
            label5.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(6, 226);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(244, 50);
            txtDescripcion.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 279);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 12;
            label6.Text = "Fecha Ingreso:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 29);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 14;
            label7.Text = "Tipo Animal";
            // 
            // dateTimeFechaNacimiento
            // 
            dateTimeFechaNacimiento.Location = new Point(6, 138);
            dateTimeFechaNacimiento.Name = "dateTimeFechaNacimiento";
            dateTimeFechaNacimiento.Size = new Size(244, 23);
            dateTimeFechaNacimiento.TabIndex = 3;
            // 
            // dateTimeFechaIngreso
            // 
            dateTimeFechaIngreso.Location = new Point(6, 297);
            dateTimeFechaIngreso.Name = "dateTimeFechaIngreso";
            dateTimeFechaIngreso.Size = new Size(244, 23);
            dateTimeFechaIngreso.TabIndex = 6;
            // 
            // cmbGenero
            // 
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Items.AddRange(new object[] { "F", "M" });
            cmbGenero.Location = new Point(6, 182);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(121, 23);
            cmbGenero.TabIndex = 4;
            // 
            // cmbAnimalTipo
            // 
            cmbAnimalTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimalTipo.FormattingEnabled = true;
            cmbAnimalTipo.Location = new Point(6, 47);
            cmbAnimalTipo.Name = "cmbAnimalTipo";
            cmbAnimalTipo.Size = new Size(148, 23);
            cmbAnimalTipo.TabIndex = 1;
            // 
            // tabControlAnimal
            // 
            tabControlAnimal.Controls.Add(tabPage1);
            tabControlAnimal.Controls.Add(tabPage2);
            tabControlAnimal.Location = new Point(239, 63);
            tabControlAnimal.Name = "tabControlAnimal";
            tabControlAnimal.SelectedIndex = 0;
            tabControlAnimal.Size = new Size(269, 399);
            tabControlAnimal.TabIndex = 19;
            tabControlAnimal.Visible = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnCancelar);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnGuardar);
            tabPage1.Controls.Add(txtDescripcion);
            tabPage1.Controls.Add(cmbAnimalTipo);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cmbGenero);
            tabPage1.Controls.Add(lblAnimalId);
            tabPage1.Controls.Add(dateTimeFechaIngreso);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dateTimeFechaNacimiento);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(261, 371);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Animal";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(6, 342);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(101, 342);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(460, 351);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Atenciones Médicas";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(515, 24);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoAnimalToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoAnimalToolStripMenuItem
            // 
            nuevoAnimalToolStripMenuItem.Name = "nuevoAnimalToolStripMenuItem";
            nuevoAnimalToolStripMenuItem.Size = new Size(180, 22);
            nuevoAnimalToolStripMenuItem.Text = "Nuevo Animal";
            nuevoAnimalToolStripMenuItem.Click += nuevoAnimalToolStripMenuItem_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(180, 342);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 474);
            Controls.Add(tabControlAnimal);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(listBoxResult);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            tabControlAnimal.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBoxResult;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label label1;
        private Label lblAnimalId;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtDescripcion;
        private Label label6;
        private Label label7;
        private DateTimePicker dateTimeFechaNacimiento;
        private DateTimePicker dateTimeFechaIngreso;
        private ComboBox cmbGenero;
        private ComboBox cmbAnimalTipo;
        private TabControl tabControlAnimal;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnGuardar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem nuevoAnimalToolStripMenuItem;
        private Button btnEliminar;
        private Button btnCancelar;
    }
}
