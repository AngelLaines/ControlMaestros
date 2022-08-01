using MySql.Data.MySqlClient;
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
    public partial class frmPromedioAlumno : Form
    {
        private string id;
        private string nombre;
        Dictionary<string, string> criterios = new Dictionary<string, string>();
        Dictionary<string, string> dict = new Dictionary<string, string>();
        private double examenPR;
        private double tareaPR;
        private double practicaPR;
        private double asistenciaPR;
        public frmPromedioAlumno(string id,string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmPromedioAlumno_Load(object sender, EventArgs e)
        {
             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select g.numero as grupo from maestros_grupos mg join grupos g on g.numero=mg.numero_grupo join materias m on m.id_materia=g.id_materia where mg.id_maestro=" + id;
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();


                while (datos.Read())
                {
                    cmbGrupo.Items.Add(datos["grupo"].ToString());
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void cmbGrupo_TextChanged(object sender, EventArgs e)
        {
            materias();
            txtAsis.Visible = false;
            label4.Visible = false;
            btnCalcular.Visible = false;
        }

        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            criteriosEv();
            alumnos();
        }
        private void alumnos()
        {
             
            dict.Clear();
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select alumnos.expediente, alumnos.nombres, alumnos.apellido_paterno, alumnos.apellido_materno, alumnos_grupos.numero_grupo from alumnos join alumnos_grupos on alumnos.expediente = alumnos_grupos.expediente_alumno where alumnos_grupos.numero_grupo=" + cmbGrupo.SelectedItem.ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();

                string nombreAlumno = "";
                while (datos.Read())
                {
                    nombreAlumno = datos["nombres"].ToString() + " " + datos["apellido_paterno"].ToString() + " " + datos["apellido_materno"].ToString();
                    dict.Add(nombreAlumno, datos["expediente"].ToString());
                    cmbAlumno.Items.Add(nombreAlumno);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void materias()
        {
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();

             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select m.nombre as materia from maestros_grupos mg join grupos g on g.numero=mg.numero_grupo join materias m on m.id_materia=g.id_materia where mg.id_maestro=" + id + " and g.numero=" + cmbGrupo.SelectedItem.ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();


                datos.Read();
                cmbMateria.Text = datos["materia"].ToString();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void criteriosEv()
        {
            criterios.Clear();
            lblExamenes.Text = "Examenes: ";
            lblTareas.Text = "Tareas: ";
            lblPracticas.Text = "Practicas: ";
            lblAsistencia.Text = "Asistencia: ";
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select mg.examenes as examenes, mg.tareas as tareas, mg.practicas as practicas, mg.asistencia as asistencia from maestros_grupos mg join maestros ma on ma.id_maestro=mg.id_maestro join grupos gr on gr.numero=mg.numero_grupo where mg.numero_grupo=" + cmbGrupo.SelectedItem.ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();


                datos.Read();
                lblExamenes.Text += datos["examenes"].ToString();
                lblTareas.Text += datos["tareas"].ToString();
                lblPracticas.Text += datos["practicas"].ToString();
                lblAsistencia.Text += datos["asistencia"].ToString();

                criterios.Add("examenes", datos["examenes"].ToString());
                criterios.Add("tareas", datos["tareas"].ToString());
                criterios.Add("practicas", datos["practicas"].ToString());
                criterios.Add("asistencia", datos["asistencia"].ToString());
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void cmbAlumno_TextChanged(object sender, EventArgs e)
        {
            txtAsis.Visible = false;
            label4.Visible = false;
            btnCalcular.Visible = false;
            lblExamenA.Text = "Examenes: ";
            lblTareaA.Text = "Tareas: ";
            lblPracticaA.Text = "Practicas: ";
            lblAsistenciaA.Text = "Asistencia: ";
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select sum(calificacion) as sum, count(calificacion) as con from alumnos_examenes where expediente_alumno="+dict[cmbAlumno.SelectedItem.ToString()].ToString()+" and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            double promedio;
            double n;

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();
                datos.Read();
                n = double.Parse(datos["con"].ToString());
                if (datos.IsDBNull(0))
                {
                    promedio = 0;
                }
                else
                {
                    promedio = double.Parse(datos["sum"].ToString());
                }
                examenPR = ((promedio/n) * double.Parse(criterios["examenes"].ToString())) / 100;

                datos.Close();
                sql = @"select sum(calificacion) as sum, count(calificacion) as con from alumnos_tareas where expediente_alumno=" + dict[cmbAlumno.SelectedItem.ToString()].ToString() + " and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
                cmd = new MySqlCommand(sql, conn);
                datos = cmd.ExecuteReader();
                datos.Read();
                n = double.Parse(datos["con"].ToString());
                if (datos.IsDBNull(0))
                {
                    promedio = 0;
                }
                else
                {
                    promedio = double.Parse(datos["sum"].ToString());
                }
                tareaPR = ((promedio / n) * double.Parse(criterios["tareas"].ToString())) / 100;

                datos.Close();
                sql = @"select sum(calificacion) as sum, count(calificacion) as con from alumnos_practicas where expediente_alumno=" + dict[cmbAlumno.SelectedItem.ToString()].ToString() + " and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
                cmd = new MySqlCommand(sql, conn);
                datos = cmd.ExecuteReader();
                datos.Read();
                n = double.Parse(datos["con"].ToString());
                if (datos.IsDBNull(0))
                {
                    promedio = 0;
                } else
                {
                    promedio = double.Parse(datos["sum"].ToString());
                }
                
                practicaPR = ((promedio / n) * double.Parse(criterios["practicas"].ToString())) / 100;

                if (double.Parse(criterios["asistencia"].ToString()) > 0)
                {
                    txtAsis.Visible = true;
                    label4.Visible = true;
                    btnCalcular.Visible = true;
                } else
                {
                    asistenciaPR = double.Parse(criterios["asistencia"].ToString());
                    lblExamenA.Text += examenPR.ToString();
                    lblTareaA.Text += tareaPR.ToString();
                    lblPracticaA.Text += practicaPR.ToString();
                    lblAsistenciaA.Text += asistenciaPR.ToString();

                    label5.Text += (examenPR + practicaPR + tareaPR + asistenciaPR).ToString();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (double.Parse(criterios["asistencia"].ToString()) < double.Parse(txtAsis.Text))
            {
                MessageBox.Show("El porcentaje de asistencia ingresado es mayo al del criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                asistenciaPR = double.Parse(txtAsis.Text);
                lblExamenA.Text += examenPR.ToString();
                lblTareaA.Text += tareaPR.ToString();
                lblPracticaA.Text += practicaPR.ToString();
                lblAsistenciaA.Text += asistenciaPR.ToString();

                label5.Text += (examenPR + practicaPR + tareaPR + asistenciaPR).ToString();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }
    }
}
