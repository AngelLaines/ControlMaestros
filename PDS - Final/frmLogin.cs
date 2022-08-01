using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PDS___Final
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string id_maestro=idMaestro();

            if (id_maestro== "Contraseña o usuario incorrecto")
            {
                MessageBox.Show("Contraseña o usuario incorrecto", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string nombre_maestro = Nombre(id_maestro);
                frmMenu menu = new frmMenu(id_maestro,nombre_maestro);
                this.Hide();
                menu.Show();
            }

        }

        public string Nombre(string id)
        {
            string nombreMaestro = "";

             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select nombres from maestros where id_maestro="+id;
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();
                datos.Read();
                nombreMaestro = datos["nombres"].ToString();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return nombreMaestro;
        }
         public string idMaestro()
        {
            string id = "";

             
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

              
            string sql = @"select id_maestro from usuarios where nombre_usuario='" + txtUser.Text + "' and contrasena='" + txtPassword.Text + "'";
              
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                  
                conn.Open();

                  
                MySqlDataReader datos = cmd.ExecuteReader();

                
                if (datos.Read())
                {
                    id = datos["id_maestro"].ToString();
                }
                else
                {
                    return id = "Contraseña o usuario incorrecto";
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


            return id;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
                checkBox1.Text = "Ocultar";
            }
            if (!checkBox1.Checked)
            {
                txtPassword.PasswordChar = '•';
                checkBox1.Text = "Mostrar";
            }
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string mensaje = "Este proyecto fue elaborado por:\n Leon Saenz Jaime Jesus\n Moreno Laines Angel Roberto\n Rountree Robles Carlos Macoy\n Vazquez Rojas Victor Hugo\n\n Un proyecto de desarrollo para la materia de\n Practicas de Desarrollo de Sistemas 1";
            MessageBox.Show(mensaje, "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
