using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace sysprog_01._02_2_
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            //string connectionString = ("host=localhost; username=postres; port=5432; password=11111; database=prava");
            
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;

            string connectionString = ("host=localhost; username=postgres; port=5432; password=11111; database=prava");

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT role FROM users WHERE Login=@Login AND Password=@Password";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Login", login);
                    command.Parameters.AddWithValue("Password", password);

                    string role = (string)command.ExecuteScalar();


                    if (role == null)
                    {
                        MessageBox.Show("Данные неверны");
                        return;

                    }

                    if (role == "admin")
                    {

                        Admin Admin = new Admin();
                        Admin.Show();
                        this.Hide();
                    }

                    else if (role == "manager")
                    {
                        Manager Manger = new Manager();
                        Manger.Show();
                        this.Hide();
                    }
                }
            }





        }

        private void Password_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
