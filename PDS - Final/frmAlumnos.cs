using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PDS___Final
{
    public partial class frmAlumnos : Form
    {
        private string id;
        private string nombre;
        public frmAlumnos(string id, string nombre)
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

        private void frmAlumnos_Load(object sender, EventArgs e)
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
                    comboBox1.Items.Add(datos["grupo"].ToString());
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select alumnos.nombres as nombres, alumnos.apellido_paterno as apellido_paterno, alumnos.apellido_materno apellido_materno, alumnos_grupos.numero_grupo as grupo from alumnos join alumnos_grupos on alumnos.expediente = alumnos_grupos.expediente_alumno where alumnos_grupos.numero_grupo=" + comboBox1.SelectedItem.ToString();
            
            
                
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

                gridAlumnos.DataSource = bSource;

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
