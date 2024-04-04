namespace FiscalWinFormsApp
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
            btnCreateCodice = new Button();
            txtFirstName = new TextBox();
            label1 = new Label();
            dateTimePickerDateOfBirth = new DateTimePicker();
            txtLastName = new TextBox();
            label2 = new Label();
            txtPlaceOfBirth = new TextBox();
            label3 = new Label();
            label4 = new Label();
            radioButtonMale = new RadioButton();
            radioButtonFemale = new RadioButton();
            comboBoxMaritalStatus = new ComboBox();
            label5 = new Label();
            comboBox1Opciones = new ComboBox();
            SuspendLayout();
            // 
            // btnCreateCodice
            // 
            btnCreateCodice.Location = new Point(311, 225);
            btnCreateCodice.Name = "btnCreateCodice";
            btnCreateCodice.Size = new Size(75, 23);
            btnCreateCodice.TabIndex = 0;
            btnCreateCodice.Text = "Create Codice";
            btnCreateCodice.UseVisualStyleBackColor = true;
            btnCreateCodice.Click += btnCreateCodice_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(12, 38);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "First Name";
            // 
            // dateTimePickerDateOfBirth
            // 
            dateTimePickerDateOfBirth.Location = new Point(145, 94);
            dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
            dateTimePickerDateOfBirth.Size = new Size(237, 23);
            dateTimePickerDateOfBirth.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(145, 38);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 20);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 5;
            label2.Text = "Last Name";
            // 
            // txtPlaceOfBirth
            // 
            txtPlaceOfBirth.Location = new Point(12, 94);
            txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            txtPlaceOfBirth.Size = new Size(100, 23);
            txtPlaceOfBirth.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 7;
            label3.Text = "Place Of Birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(146, 74);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 8;
            label4.Text = "Date Of Birth";
            // 
            // radioButtonMale
            // 
            radioButtonMale.AutoSize = true;
            radioButtonMale.Checked = true;
            radioButtonMale.Location = new Point(12, 136);
            radioButtonMale.Name = "radioButtonMale";
            radioButtonMale.Size = new Size(51, 19);
            radioButtonMale.TabIndex = 9;
            radioButtonMale.TabStop = true;
            radioButtonMale.Text = "Male";
            radioButtonMale.UseVisualStyleBackColor = true;
            radioButtonMale.Click += radioButtonMale_Click;
            // 
            // radioButtonFemale
            // 
            radioButtonFemale.AutoSize = true;
            radioButtonFemale.Location = new Point(12, 161);
            radioButtonFemale.Name = "radioButtonFemale";
            radioButtonFemale.Size = new Size(63, 19);
            radioButtonFemale.TabIndex = 10;
            radioButtonFemale.Text = "Female";
            radioButtonFemale.UseVisualStyleBackColor = true;
            radioButtonFemale.Click += radioButtonFemale_Click;
            // 
            // comboBoxMaritalStatus
            // 
            comboBoxMaritalStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaritalStatus.FormattingEnabled = true;
            comboBoxMaritalStatus.Items.AddRange(new object[] { "Married", "Unmarried", "Divorced" });
            comboBoxMaritalStatus.Location = new Point(145, 157);
            comboBoxMaritalStatus.Name = "comboBoxMaritalStatus";
            comboBoxMaritalStatus.Size = new Size(237, 23);
            comboBoxMaritalStatus.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(146, 136);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 12;
            label5.Text = "Marital Status";
            // 
            // comboBox1Opciones
            // 
            comboBox1Opciones.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1Opciones.FormattingEnabled = true;
            comboBox1Opciones.Items.AddRange(new object[] { "Saludar", "Saludar Formalmente", "Create Fiscal Code" });
            comboBox1Opciones.Location = new Point(106, 225);
            comboBox1Opciones.Name = "comboBox1Opciones";
            comboBox1Opciones.Size = new Size(199, 23);
            comboBox1Opciones.TabIndex = 13;
            comboBox1Opciones.SelectedIndexChanged += comboBox1Opciones_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 260);
            Controls.Add(comboBox1Opciones);
            Controls.Add(label5);
            Controls.Add(comboBoxMaritalStatus);
            Controls.Add(radioButtonFemale);
            Controls.Add(radioButtonMale);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPlaceOfBirth);
            Controls.Add(label2);
            Controls.Add(txtLastName);
            Controls.Add(dateTimePickerDateOfBirth);
            Controls.Add(label1);
            Controls.Add(txtFirstName);
            Controls.Add(btnCreateCodice);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateCodice;
        private TextBox txtFirstName;
        private Label label1;
        private DateTimePicker dateTimePickerDateOfBirth;
        private TextBox txtLastName;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private RadioButton radioButtonFemale;
        private RadioButton radioButton2;
        private TextBox txtPlaceOfBirth;
        private RadioButton radioButtonMale;
        private ComboBox comboBoxMaritalStatus;
        private Label label5;
        private ComboBox comboBox1Opciones;
    }
}
