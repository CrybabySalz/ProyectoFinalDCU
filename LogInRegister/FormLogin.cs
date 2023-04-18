using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInRegister
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            Font myFont = new Font("SquareFont", 16.2f, FontStyle.Underline|FontStyle.Bold);
            
            lblRegister.Font = myFont;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
              conectionDB conexion = new conectionDB();

            string Username = boxUser.Text;
            string Password = boxPassword.Text;

            if (Username == "" || Password == "")
            {
                MessageBox.Show("Existen campos vacios, favor llenarlos todos.");
                return;
            }

            string stringStudent = "SELECT * FROM Student where UsernameStudent = @USERNAME AND PasswordStudent = @PASSWORD";
            

            conexion.comando = new SqlCommand(stringStudent, conexion.conection);
            conexion.comando.Parameters.Add("@USERNAME",SqlDbType.VarChar,30).Value = Username;
            conexion.comando.Parameters.Add("@PASSWORD",SqlDbType.VarChar,30).Value = Password;

            conexion.Open();
            SqlDataReader reader = conexion.comando.ExecuteReader();

            if (reader.Read())
            {
                FORMESTUDIANTE formStudent = new FORMESTUDIANTE();
                formStudent.Show();
                this.Hide();
                reader.Close();
                conexion.Close();
            }
            else
            {
                reader.Close();
            }

            string stringTeacher = "SELECT * FROM Teacher where UsernameTeacher = @USERNAME AND PasswordTeacher = @PASSWORD";

            conexion.comando = new SqlCommand(stringTeacher, conexion.conection);
            conexion.comando.Parameters.Add("@USERNAME", SqlDbType.VarChar, 30).Value = Username;
            conexion.comando.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 30).Value = Password;

            reader = conexion.comando.ExecuteReader();

            if (reader.Read())
            {
                FORMMAESTRO formTeacher = new FORMMAESTRO();
                formTeacher.Show();
                this.Hide();
                reader.Close();
                conexion.Close();
            }
            else
            {
                reader.Close();
                MessageBox.Show("Usuario y/o contraseña incorrectos.");
                conexion.Close();
            }
        }


        private void lblRegister_Click(object sender, EventArgs e)
        {
            FormRegister FormRegister = new FormRegister();

            FormRegister.Show();
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            Font myFont = new Font("SquareFont", 16.2f, FontStyle.Bold);

            lblRegister.Font = myFont;
        }
    }
}
