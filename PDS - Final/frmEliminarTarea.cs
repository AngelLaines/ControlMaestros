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
    public partial class frmEliminarTarea : Form
    {
        private string id;
        private string nombre;
        public frmEliminarTarea(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmEliminarTarea_Load(object sender, EventArgs e)
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

              
            string sql = @"select * from tareas where numero_grupo=" + cmbGrupo.SelectedItem.ToString();

            try
            {
                  
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string grupo = cmbGrupo.SelectedItem.ToString();
            string nombreTarea = txtTarea.Text;
            

             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"delete from alumnos_tareas where id_tarea = '" + gridTareas.CurrentRow.Cells["id_tarea"].Value.ToString() + "' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();

            

            DialogResult dg=MessageBox.Show("Esta seguro de que desea eliminar la tarea?","Eliminar tarea",MessageBoxButtons.YesNo);

            if (dg == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    sql = @"delete from tareas where nombre='" + txtTarea.Text + "' and numero_grupo=" + cmbGrupo.SelectedItem.ToString();

                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tarea eliminada con exito");

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
                txtTarea.Clear();
            }
        }

        private void gridTareas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clave = gridTareas.CurrentRow.Cells["nombre"].Value.ToString();
            txtTarea.Text = clave;
        }
    }
}
