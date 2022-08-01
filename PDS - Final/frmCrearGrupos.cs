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
    public partial class frmCrearGrupos : Form
    {
        private string id;
        private string nombre;
        private int idGrupo;
        Dictionary<string, string> matt = new Dictionary<string, string>();
        Dictionary<string, string> carrer = new Dictionary<string, string>();
        public frmCrearGrupos(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmCrearGrupos_Load(object sender, EventArgs e)
        {
            materias();
            carreras();
            idGrupoAuto();
        }
        private void idGrupoAuto()
        {
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select max(numero) as numero from grupos";
            // Create command 
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Open connection 
                conn.Open();

                // Execute Scalar query with ExecuteScalar method 
                MySqlDataReader datos = cmd.ExecuteReader();

                datos.Read();
                if (datos["numero"].ToString().Equals(""))
                {
                    idGrupo = 1;
                }
                else
                {
                    idGrupo = int.Parse(datos["numero"].ToString()) + 1;
                }

                lblNumGrupo.Text += idGrupo.ToString();

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
        private void carreras()
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select id_carrera, nombre from carreras";
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
                    carrer.Add(datos["nombre"].ToString(), datos["id_carrera"].ToString());
                    cmbCarrera.Items.Add(datos["nombre"].ToString());
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
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select id_materia, nombre from materias";
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
                    matt.Add(datos["nombre"].ToString(), datos["id_materia"].ToString());
                    cmbMateria.Items.Add(datos["nombre"].ToString());
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(id, nombre);
            this.Close();
            menu.Show();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int examen = int.Parse(numExamen.Value.ToString());
            int tareas = int.Parse(numTareas.Value.ToString());
            int practicas = int.Parse(numPracticas.Value.ToString());
            int asistencia = int.Parse(numAsistencia.Value.ToString());

            int ponderado = examen + tareas + practicas + asistencia;
            if (ponderado != 100)
            {
                MessageBox.Show("Los valores tienen que sumar 100%.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cmbMateria.Text.ToString() == "" || cmbCarrera.Text.ToString() == "")
                {
                    MessageBox.Show("Elige una materia o un grupo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    grupo();
                    maestro_grupo();
                    MessageBox.Show("Grupo creado exitosamente.");
                    cmbCarrera.ResetText();
                    cmbMateria.ResetText();
                    numTamañoGrupo.Value = 20;
                    numExamen.Value = 0;
                    numTareas.Value = 0;
                    numAsistencia.Value = 0;
                    numPracticas.Value = 0;
                    lblNumGrupo.Text = "Numero de grupo: ";
                    idGrupoAuto();
                }
            }
        }

        private void grupo()
        {
            string tamaño = numTamañoGrupo.Value.ToString();

            string id_materia = matt[cmbMateria.Text.ToString()].ToString();
            string id_carrera = carrer[cmbCarrera.Text.ToString()].ToString();
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"insert into grupos (numero,tamano,id_materia,id_carrera) values(" + idGrupo.ToString() + "," + tamaño + "," + id_materia + "," + id_carrera + ")";
            // Create command 
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
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

        private void maestro_grupo()
        {
            string examen = numExamen.Value.ToString();
            string tareas = numTareas.Value.ToString();
            string practicas = numPracticas.Value.ToString();
            string asistencia = numAsistencia.Value.ToString();

            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"insert into maestros_grupos (id_maestro,numero_grupo,examenes,tareas,practicas,asistencia) values ("+id+","+idGrupo+","+examen+","+tareas+","+practicas+","+asistencia+")";
            // Create command 
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

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
