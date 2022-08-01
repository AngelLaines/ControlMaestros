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
    public partial class frmEliminarExamen : Form
    {
        private string id;
        private string nombre;
        public frmEliminarExamen(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmEliminarExamen_Load(object sender, EventArgs e)
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
            actualizarGrid();
        }
        private void actualizarGrid()
        {
             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select * from examenes where numero_grupo=" + cmbGrupo.SelectedItem.ToString();

            try
            {
                  
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
                DataTable table = new DataTable();

                dataAdapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                gridExamenes.DataSource = bSource;

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

        private void btndelete_Click(object sender, EventArgs e)
        {
            string grupo = cmbGrupo.SelectedItem.ToString();
            string nombreTarea = txtExamen.Text;


             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

             
            string sql = @"delete from alumnos_examenes where id_examen = '"+ gridExamenes.CurrentRow.Cells["id_examen"].Value.ToString() +"' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();

            

            DialogResult dg = MessageBox.Show("Esta seguro de que desea eliminar el examen?", "Eliminar examen", MessageBoxButtons.YesNo);

            if (dg == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    sql = @"delete from examenes where unidad='" + txtExamen.Text + "' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();


                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Examen eliminado con exito");

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
                actualizarGrid();
                txtExamen.Clear();
            }
        }

        private void gridExamenes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clave = gridExamenes.CurrentRow.Cells["unidad"].Value.ToString();
            txtExamen.Text = clave;
        }
    }
}
