using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDS___Final
{
    public partial class frmMenu : Form
    {
        private string id;
        private string nombre;
        public frmMenu(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            label1.Text += nombre;
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos alumnos = new frmAlumnos(id, nombre);
            this.Close();
            alumnos.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateriasGrupo matGrup = new frmMateriasGrupo(id, nombre);
            this.Close();
            matGrup.Show();
        }

        private void añadirTareaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAñadirTarea tareas = new frmAñadirTarea(id, nombre);
            this.Close();
            tareas.Show();
        }

        private void calificarTareaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTareasAlumnos tareas = new frmTareasAlumnos(id, nombre);
            this.Close();
            tareas.Show();
        }

        private void editarTareaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEditarTarea tareas = new frmEditarTarea(id, nombre);
            this.Close();
            tareas.Show();
        }

        private void eliminarTareaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEliminarTarea tareas = new frmEliminarTarea(id, nombre);
            this.Close();
            tareas.Show();
        }

        private void tareasCalificadasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTareasCalificadas tareas = new frmTareasCalificadas(id, nombre);
            this.Close();
            tareas.Show();
        }

        private void añadirExamenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAñadirExamen examen = new frmAñadirExamen(id, nombre);
            this.Close();
            examen.Show();
        }

        private void calificarExamenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCalificarExamen examen = new frmCalificarExamen(id, nombre);
            this.Close();
            examen.Show();
        }

        private void examenesCalificadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmExamenesCalificados examen = new frmExamenesCalificados(id, nombre);
            this.Close();
            examen.Show();
        }

        private void inscribirAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInscribirAlumnos alumnos = new frmInscribirAlumnos(id, nombre);
            this.Close();
            alumnos.Show();
        }

        private void crearGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearGrupos grupos = new frmCrearGrupos(id,nombre);
            this.Close();
            grupos.Show();
        }

        private void editarExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarExamen examen = new frmEditarExamen(id, nombre);
            this.Close();
            examen.Show();
        }

        private void eliminarExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEliminarExamen examen = new frmEliminarExamen(id,nombre);
            this.Close();
            examen.Show();
        }

        private void añadirPracticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAñadirPractica practica = new frmAñadirPractica(id, nombre);
            this.Close();
            practica.Show();
        }

        private void calificarPracticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalificarPractica practica = new frmCalificarPractica(id, nombre);
            this.Close();
            practica.Show();
        }

        private void modificarPracticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarPractica practica = new frmEditarPractica(id, nombre);
            this.Close();
            practica.Show();
        }

        private void eliminarPracticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEliminarPractica practica = new frmEliminarPractica(id, nombre);
            this.Close();
            practica.Show();
        }

        private void practicasCalificadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPracticasCalificadas practica = new frmPracticasCalificadas(id, nombre);
            this.Close();
            practica.Show();
        }

        private void promedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromedioAlumno promedio = new frmPromedioAlumno(id, nombre);
            this.Close();
            promedio.Show();
        }
    }
}
