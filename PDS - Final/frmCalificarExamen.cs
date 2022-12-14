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
    public partial class frmCalificarExamen : Form
    {
        private string id;
        private string nombre;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public frmCalificarExamen(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmCalificarExamen_Load(object sender, EventArgs e)
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
            cmbUnidad.Items.Clear();
            cmbUnidad.ResetText();
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            cmbMateria.Items.Clear();
            cmbMateria.ResetText();
            dict.Clear();
            
            txtClave.Clear();
             
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

        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
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

        private void cmbAlumno_TextChanged(object sender, EventArgs e)
        {
            lblPromedio.Text = "Promedio de examenes: ";
            cmbUnidad.Items.Clear();
            cmbUnidad.ResetText();
            if (cmbAlumno.Text != "")
            {
                examen();
                calif();
            }
        }
        private void examen()
        {
             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select unidad from examenes where estado='activo' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();

                while (datos.Read())
                {
                    cmbUnidad.Items.Add(datos["unidad"].ToString());
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
             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select calificacion from alumnos_examenes where numero_grupo=" + cmbGrupo.SelectedItem.ToString() + " and expediente_alumno=" + dict[cmbAlumno.SelectedItem.ToString()].ToString();
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();

                int n = 0;
                double promCalif = 0;
                while (datos.Read())
                {
                    promCalif += double.Parse(datos["calificacion"].ToString());
                    n += 1;
                }
                promCalif = Math.Round((promCalif / n), 2);
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

        private void cmbUnidad_TextChanged(object sender, EventArgs e)
        {
            if (cmbUnidad.Items.Count > 0)
            {
                string unidad = cmbUnidad.SelectedItem.ToString();
                 
                MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

                  
                string sql = @"select id_examen from examenes where unidad=" + unidad + " and estado='activo' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();
                  
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                try
                {
                      
                    conn.Open();

                      
                    MySqlDataReader datos = cmd.ExecuteReader();

                    datos.Read();

                    txtClave.Text = datos["id_examen"].ToString();


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

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"insert into alumnos_examenes values(" + dict[cmbAlumno.SelectedItem.ToString()].ToString() + "," + txtClave.Text + "," + float.Parse(txtCalif.Text) + "," + cmbGrupo.Text + ")";
              
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Examen calificado con exito");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            
            txtClave.Clear();
            txtCalif.Clear();
            cmbUnidad.Items.Clear();
            cmbUnidad.ResetText();
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            cmbGrupo.ResetText();
            cmbMateria.Items.Clear();
            cmbMateria.ResetText();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }

        private void txtCalif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }
    }
}
