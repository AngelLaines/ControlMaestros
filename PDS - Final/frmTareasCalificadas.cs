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
    public partial class frmTareasCalificadas : Form
    {
        private string id;
        private string nombre;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public frmTareasCalificadas(string id,string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }

        private void frmTareasCalificadas_Load(object sender, EventArgs e)
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
            cmbAlumno.Items.Clear();
            cmbAlumno.ResetText();
            
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
            alumnos();
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

        private void cmbAlumno_TextChanged(object sender, EventArgs e)
        {
            actualizarGrid();
        }
        private void actualizarGrid()
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            // select al.nombres, al.apellido_paterno,al.apellido_materno, t.nombre, ata.calificacion from alumnos_tareas ata join tareas t on t.id_tarea=ata.id_tarea join alumnos al on al.expediente=ata.expediente_alumno where ata.numero_grupo=1 and ata.expediente_alumno=1
            string sql = @"select al.nombres, al.apellido_paterno,al.apellido_materno, t.nombre as nombre_tarea, ata.calificacion from alumnos_tareas ata join tareas t on t.id_tarea=ata.id_tarea join alumnos al on al.expediente=ata.expediente_alumno where ata.numero_grupo="+cmbGrupo.SelectedItem.ToString()+" and ata.expediente_alumno="+dict[cmbAlumno.SelectedItem.ToString()].ToString();

            try
            {
                // Open connection 
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
                DataTable table = new DataTable();

                dataAdapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                gridTareas.DataSource = bSource;

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
