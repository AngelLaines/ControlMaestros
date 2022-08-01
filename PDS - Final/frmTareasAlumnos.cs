﻿using MySql.Data.MySqlClient;
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
    public partial class frmTareasAlumnos : Form
    {
        private string id;
        private string nombre;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public frmTareasAlumnos(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmTareas_Load(object sender, EventArgs e)
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select g.numero as grupo from maestros_grupos mg join grupos g on g.numero=mg.numero_grupo join materias m on m.id_materia=g.id_materia where mg.id_maestro=" + id;
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
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
            cmbMateria.Items.Clear();
            cmbMateria.ResetText();
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            cmbTareas.Items.Clear();
            txtClave.Clear();
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select m.nombre as materia from maestros_grupos mg join grupos g on g.numero=mg.numero_grupo join materias m on m.id_materia=g.id_materia where mg.id_maestro=" + id + " and g.numero=" + cmbGrupo.SelectedItem.ToString();
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
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

        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            alumnos();
        }

        private void tareas()
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select nombre from tareas where estado='activa' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
                MySqlDataReader datos = cmd.ExecuteReader();

                while (datos.Read())
                {
                    cmbTareas.Items.Add(datos["nombre"].ToString());
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

        private void alumnos()
        {
            // Create connection
            dict.Clear();
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select alumnos.expediente, alumnos.nombres, alumnos.apellido_paterno, alumnos.apellido_materno, alumnos_grupos.numero_grupo from alumnos join alumnos_grupos on alumnos.expediente = alumnos_grupos.expediente_alumno where alumnos_grupos.numero_grupo=" + cmbGrupo.SelectedItem.ToString();
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
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

        private void calif()
        {
            // Create connection
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select calificacion from alumnos_tareas where numero_grupo=" + cmbGrupo.SelectedItem.ToString()+" and expediente_alumno="+dict[cmbAlumno.SelectedItem.ToString()].ToString();
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
                MySqlDataReader datos = cmd.ExecuteReader();

                int n = 0;
                double promCalif = 0;
                while (datos.Read())
                {
                    promCalif += double.Parse(datos["calificacion"].ToString());
                    n += 1;
                }
                promCalif = Math.Round((promCalif / n),2);
                string labelProm = lblPromedio.Text + promCalif.ToString();
                lblPromedio.Text = labelProm;
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"insert into alumnos_tareas values("+dict[cmbAlumno.SelectedItem.ToString()].ToString()+","+txtClave.Text+","+float.Parse(txtCalif.Text)+","+cmbGrupo.Text+")";
            // Create command 
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tarea calificada con exito");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            cmbTareas.Items.Clear();
            cmbTareas.ResetText();
            txtClave.Clear();
            txtCalif.Clear();
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            cmbMateria.Items.Clear();
            cmbMateria.ResetText();
            cmbGrupo.ResetText();
        }

        private void cmbAlumno_TextChanged(object sender, EventArgs e)
        {
            lblPromedio.Text = "Promedio de tareas: ";
            cmbTareas.Items.Clear();
            if (cmbAlumno.Text != "")
            {
                tareas();
                calif();
            }
        }

        private void txtCalif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }

        private void cmbTareas_TextChanged(object sender, EventArgs e)
        {
            if (cmbTareas.Items.Count > 0)
            {
                string nombreTarea = cmbTareas.SelectedItem.ToString();
                // Create connection 
                MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

                // Create Scalar query 
                string sql = @"select id_tarea from tareas where nombre='" + nombreTarea + "' and estado='activa' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
                // Create command 
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                try
                {
                    // Open connection 
                    conn.Open();

                    // Execute Scalar query with ExecuteScalar method 
                    MySqlDataReader datos = cmd.ExecuteReader();

                    datos.Read();

                    txtClave.Text = datos["id_tarea"].ToString();


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
            
        }
    }
}
