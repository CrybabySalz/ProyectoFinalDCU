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
    public partial class FORMMAESTRO : Form
    {
        public FORMMAESTRO()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string conet = ("server=JOHNDYSTANY22\\MSSQLSERVER01 ; database = DB_Multicapas ; integrated security = true");

            using (SqlConnection connection = new SqlConnection(conet))
            {
                connection.Open();

                string Resq = "SELECT * FROM Maestros";

                using (SqlCommand command = new SqlCommand(Resq, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    data.DataSource = dt;
                }

                connection.Close();
            }






        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            SqlConnection conn = new SqlConnection("Data Source=JOHNDYSTANY22\\MSSQLSERVER01;Initial Catalog=DB_Multicapas;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Maestros WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
            {
                MessageBox.Show("Maestros eliminado correctamente");
            }
            else
            {
                MessageBox.Show("No se encontró ningún Maestros con ese ID");
            }


        }

        private void FORMMAESTRO_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtid.Text);
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;

            SqlConnection conn = new SqlConnection("Data Source=JOHNDYSTANY22\\MSSQLSERVER01;Initial Catalog=DB_Multicapas;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Maestros (id, nombre, apellido) VALUES (@id, @nombre, @apellido)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Maestro agregado correctamente");

        }
    }
}
