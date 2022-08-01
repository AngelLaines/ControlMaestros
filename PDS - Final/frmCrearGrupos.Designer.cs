namespace PDS___Final
{
    partial class frmCrearGrupos
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
            this.label1 = new System.Windows.Forms.Label();
            this.numTamañoGrupo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numExamen = new System.Windows.Forms.NumericUpDown();
            this.numTareas = new System.Windows.Forms.NumericUpDown();
            this.numPracticas = new System.Windows.Forms.NumericUpDown();
            this.numAsistencia = new System.Windows.Forms.NumericUpDown();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lblNumGrupo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTamañoGrupo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPracticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAsistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Definir tamaño de grupo";
            // 
            // numTamañoGrupo
            // 
            this.numTamañoGrupo.Location = new System.Drawing.Point(148, 51);
            this.numTamañoGrupo.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numTamañoGrupo.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTamañoGrupo.Name = "numTamañoGrupo";
            this.numTamañoGrupo.Size = new System.Drawing.Size(120, 20);
            this.numTamañoGrupo.TabIndex = 1;
            this.numTamañoGrupo.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Materia";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(148, 96);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(121, 21);
            this.cmbMateria.TabIndex = 3;
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(148, 141);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(121, 21);
            this.cmbCarrera.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Carrera";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numAsistencia);
            this.groupBox1.Controls.Add(this.numPracticas);
            this.groupBox1.Controls.Add(this.numTareas);
            this.groupBox1.Controls.Add(this.numExamen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 175);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Definir criteros de evaluacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Examen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tareas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Practicas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Asistencia";
            // 
            // numExamen
            // 
            this.numExamen.Location = new System.Drawing.Point(98, 27);
            this.numExamen.Name = "numExamen";
            this.numExamen.Size = new System.Drawing.Size(121, 20);
            this.numExamen.TabIndex = 7;
            // 
            // numTareas
            // 
            this.numTareas.Location = new System.Drawing.Point(98, 63);
            this.numTareas.Name = "numTareas";
            this.numTareas.Size = new System.Drawing.Size(121, 20);
            this.numTareas.TabIndex = 14;
            // 
            // numPracticas
            // 
            this.numPracticas.Location = new System.Drawing.Point(98, 100);
            this.numPracticas.Name = "numPracticas";
            this.numPracticas.Size = new System.Drawing.Size(121, 20);
            this.numPracticas.TabIndex = 15;
            // 
            // numAsistencia
            // 
            this.numAsistencia.Location = new System.Drawing.Point(98, 135);
            this.numAsistencia.Name = "numAsistencia";
            this.numAsistencia.Size = new System.Drawing.Size(121, 20);
            this.numAsistencia.TabIndex = 16;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(294, 343);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 23);
            this.btnMenu.TabIndex = 7;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(294, 305);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 8;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblNumGrupo
            // 
            this.lblNumGrupo.AutoSize = true;
            this.lblNumGrupo.Location = new System.Drawing.Point(12, 20);
            this.lblNumGrupo.Name = "lblNumGrupo";
            this.lblNumGrupo.Size = new System.Drawing.Size(95, 13);
            this.lblNumGrupo.TabIndex = 9;
            this.lblNumGrupo.Text = "Numero de grupo: ";
            // 
            // frmCrearGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 383);
            this.Controls.Add(this.lblNumGrupo);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCarrera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numTamañoGrupo);
            this.Controls.Add(this.label1);
            this.Name = "frmCrearGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Grupos";
            this.Load += new System.EventHandler(this.frmCrearGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTamañoGrupo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPracticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAsistencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTamañoGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numAsistencia;
        private System.Windows.Forms.NumericUpDown numPracticas;
        private System.Windows.Forms.NumericUpDown numTareas;
        private System.Windows.Forms.NumericUpDown numExamen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lblNumGrupo;
    }
}