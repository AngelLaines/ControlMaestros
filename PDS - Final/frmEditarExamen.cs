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
    public partial class frmEditarExamen : Form
    {
        private string id;
        private string nombre;
        public frmEditarExamen(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            InitializeComponent();
        }

        private void frmEditarExamen_Load(object sender, EventArgs e)
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
            actualizarGrid();
        }
        private void actualizarGrid()
        {
            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"select * from examenes where numero_grupo=" + cmbGrupo.SelectedItem.ToString();

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string grupo = cmbGrupo.SelectedItem.ToString();
            string nombreTarea = txtExamen.Text;
            string estado = cmbEstado.SelectedItem.ToString();

            // Create connection 
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=proyecto_final_pds");

            // Create Scalar query 
            string sql = @"update examenes set estado='" + cmbEstado.SelectedItem.ToString() + "' where unidad='" + txtExamen.Text + "' and numero_grupo=" + cmbGrupo.SelectedItem.ToString(); ;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Examen editado con exito");

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
            cmbEstado.ResetText();
        }

        private void gridExamenes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clave = gridExamenes.CurrentRow.Cells["unidad"].Value.ToString();
            txtExamen.Text = clave;
        }
    }
}