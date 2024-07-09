namespace WinFormsApp1
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
            btnGuardar = new Button();
            btnMostrar = new Button();
            btnBorrar = new Button();
            textBox1 = new TextBox();
            notasGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)notasGrid).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(444, 37);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(137, 43);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar nota";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += buttonGuardar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(444, 105);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(137, 43);
            btnMostrar.TabIndex = 1;
            btnMostrar.Text = "Leer notas";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += buttonMostrar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(444, 174);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(137, 43);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar notas";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += buttonBorrar_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(286, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 6;
            // 
            // notasGrid
            // 
            notasGrid.AllowUserToAddRows = false;
            notasGrid.AllowUserToDeleteRows = false;
            notasGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            notasGrid.Location = new Point(633, 12);
            notasGrid.Name = "notasGrid";
            notasGrid.ReadOnly = true;
            notasGrid.RowHeadersWidth = 51;
            notasGrid.RowTemplate.Height = 29;
            notasGrid.Size = new Size(452, 279);
            notasGrid.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 529);
            Controls.Add(notasGrid);
            Controls.Add(textBox1);
            Controls.Add(btnBorrar);
            Controls.Add(btnMostrar);
            Controls.Add(btnGuardar);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)notasGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnMostrar;
        private Button btnBorrar;
        private TextBox textBox1;
        private DataGridView notasGrid;
    }
}
