namespace PDS___Final
{
    partial class frmPromedioAlumno
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAlumno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.lblExamenes = new System.Windows.Forms.Label();
            this.lblTareas = new System.Windows.Forms.Label();
            this.lblPracticas = new System.Windows.Forms.Label();
            this.lblAsistencia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPracticaA = new System.Windows.Forms.Label();
            this.lblAsistenciaA = new System.Windows.Forms.Label();
            this.lblExamenA = new System.Windows.Forms.Label();
            this.lblTareaA = new System.Windows.Forms.Label();
            this.txtAsis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Alumno";
            // 
            // cmbAlumno
            // 
            this.cmbAlumno.FormattingEnabled = true;
            this.cmbAlumno.Location = new System.Drawing.Point(67, 69);
            this.cmbAlumno.Name = "cmbAlumno";
            this.cmbAlumno.Size = new System.Drawing.Size(222, 21);
            this.cmbAlumno.TabIndex = 10;
            this.cmbAlumno.TextChanged += new System.EventHandler(this.cmbAlumno_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Materia";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(67, 42);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(222, 21);
            this.cmbMateria.TabIndex = 8;
            this.cmbMateria.TextChanged += new System.EventHandler(this.cmbMateria_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(67, 15);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(222, 21);
            this.cmbGrupo.TabIndex = 6;
            this.cmbGrupo.TextChanged += new System.EventHandler(this.cmbGrupo_TextChanged);
            // 
            // lblExamenes
            // 
            this.lblExamenes.AutoSize = true;
            this.lblExamenes.Location = new System.Drawing.Point(35, 52);
            this.lblExamenes.Name = "lblExamenes";
            this.lblExamenes.Size = new System.Drawing.Size(62, 13);
            this.lblExamenes.TabIndex = 13;
            this.lblExamenes.Text = "Examenes: ";
            // 
            // lblTareas
            // 
            this.lblTareas.AutoSize = true;
            this.lblTareas.Location = new System.Drawing.Point(35, 87);
            this.lblTareas.Name = "lblTareas";
            this.lblTareas.Size = new System.Drawing.Size(46, 13);
            this.lblTareas.TabIndex = 14;
            this.lblTareas.Text = "Tareas: ";
            // 
            // lblPracticas
            // 
            this.lblPracticas.AutoSize = true;
            this.lblPracticas.Location = new System.Drawing.Point(35, 122);
            this.lblPracticas.Name = "lblPracticas";
            this.lblPracticas.Size = new System.Drawing.Size(57, 13);
            this.lblPracticas.TabIndex = 15;
            this.lblPracticas.Text = "Practicas: ";
            // 
            // lblAsistencia
            // 
            this.lblAsistencia.AutoSize = true;
            this.lblAsistencia.Location = new System.Drawing.Point(35, 158);
            this.lblAsistencia.Name = "lblAsistencia";
            this.lblAsistencia.Size = new System.Drawing.Size(61, 13);
            this.lblAsistencia.TabIndex = 16;
            this.lblAsistencia.Text = "Asistencia: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPracticas);
            this.groupBox1.Controls.Add(this.lblAsistencia);
            this.groupBox1.Controls.Add(this.lblExamenes);
            this.groupBox1.Controls.Add(this.lblTareas);
            this.groupBox1.Location = new System.Drawing.Point(17, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 217);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de evaluacion definidos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPracticaA);
            this.groupBox2.Controls.Add(this.lblAsistenciaA);
            this.groupBox2.Controls.Add(this.lblExamenA);
            this.groupBox2.Controls.Add(this.lblTareaA);
            this.groupBox2.Location = new System.Drawing.Point(310, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 217);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterios de evaluacion alcanzados";
            // 
            // lblPracticaA
            // 
            this.lblPracticaA.AutoSize = true;
            this.lblPracticaA.Location = new System.Drawing.Point(35, 122);
            this.lblPracticaA.Name = "lblPracticaA";
            this.lblPracticaA.Size = new System.Drawing.Size(57, 13);
            this.lblPracticaA.TabIndex = 15;
            this.lblPracticaA.Text = "Practicas: ";
            // 
            // lblAsistenciaA
            // 
            this.lblAsistenciaA.AutoSize = true;
            this.lblAsistenciaA.Location = new System.Drawing.Point(35, 158);
            this.lblAsistenciaA.Name = "lblAsistenciaA";
            this.lblAsistenciaA.Size = new System.Drawing.Size(61, 13);
            this.lblAsistenciaA.TabIndex = 16;
            this.lblAsistenciaA.Text = "Asistencia: ";
            // 
            // lblExamenA
            // 
            this.lblExamenA.AutoSize = true;
            this.lblExamenA.Location = new System.Drawing.Point(35, 52);
            this.lblExamenA.Name = "lblExamenA";
            this.lblExamenA.Size = new System.Drawing.Size(62, 13);
            this.lblExamenA.TabIndex = 13;
            this.lblExamenA.Text = "Examenes: ";
            // 
            // lblTareaA
            // 
            this.lblTareaA.AutoSize = true;
            this.lblTareaA.Location = new System.Drawing.Point(35, 87);
            this.lblTareaA.Name = "lblTareaA";
            this.lblTareaA.Size = new System.Drawing.Size(46, 13);
            this.lblTareaA.TabIndex = 14;
            this.lblTareaA.Text = "Tareas: ";
            // 
            // txtAsis
            // 
            this.txtAsis.Location = new System.Drawing.Point(335, 42);
            this.txtAsis.Name = "txtAsis";
            this.txtAsis.Size = new System.Drawing.Size(172, 20);
            this.txtAsis.TabIndex = 19;
            this.txtAsis.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Porcentaje de asistencia alcanzado";
            this.label4.Visible = false;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(348, 69);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(147, 23);
            this.btnCalcular.TabIndex = 21;
            this.btnCalcular.Text = "Calcular promedio";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Visible = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Promedio alcanzado: ";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(713, 18);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 23);
            this.btnMenu.TabIndex = 23;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmPromedioAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAsis);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAlumno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGrupo);
            this.Name = "frmPromedioAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promedio Alumno";
            this.Load += new System.EventHandler(this.frmPromedioAlumno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAlumno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label lblExamenes;
        private System.Windows.Forms.Label lblTareas;
        private System.Windows.Forms.Label lblPracticas;
        private System.Windows.Forms.Label lblAsistencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPracticaA;
        private System.Windows.Forms.Label lblAsistenciaA;
        private System.Windows.Forms.Label lblExamenA;
        private System.Windows.Forms.Label lblTareaA;
        private System.Windows.Forms.TextBox txtAsis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMenu;
    }
}