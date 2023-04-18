using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInRegister
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            conectionDB conexion = new conectionDB();
            conexion.Open();
            string name = boxName.Text;
            string lastName = boxLastName.Text;
            string username = boxUsername.Text;
            string email = boxEmail.Text;
            string password = boxPassword.Text;

            if (name == "" || lastName == "" || username == "" || email == "" || password == "")
            {
                MessageBox.Show("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (rbStudent.Checked == true)
            {
                string cadena = "insert into Student values ('" + name + "','" + lastName + "','" + username + "','" + email + "','" + password + "')";
                conexion.comando = new SqlCommand(cadena, conexion.conection);

                try
                {
                    conexion.comando.ExecuteNonQuery();
                    MessageBox.Show("¡Usuario creado exitosamente!");
                    boxName.Clear();
                    boxLastName.Clear();
                    boxUsername.Clear();
                    boxEmail.Clear();
                    boxPassword.Clear();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado, intentelo de nuevo.");
                    conexion.Close();
                }
            }
            else 
            {
                string cadena = "insert into Teacher values ('" + name + "','" + lastName + "','" + username + "','" + email + "','" + password + "')";
                conexion.comando = new SqlCommand(cadena, conexion.conection);

                try
                {
                    conexion.comando.ExecuteNonQuery();
                    MessageBox.Show("¡Usuario creado exitosamente!");
                    boxName.Clear();
                    boxLastName.Clear();
                    boxUsername.Clear();
                    boxEmail.Clear();
                    boxPassword.Clear();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado, intentelo de nuevo.");
                    conexion.Close();
                }
            }

                
           this.Hide();
        }
    }
}
