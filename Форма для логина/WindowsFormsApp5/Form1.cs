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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sql sl = new Sql();
            Hash h = new Hash();
            string log = h.SHA(textBox1.Text).ToLower();
            string pas = h.SHA(textBox2.Text).ToLower();
            if (textBox1.Text.Length > 0)
            {
                if (textBox2.Text.Length > 0)
                {
                    try
                    {
                        DataTable dataTable = new DataTable("dataBase");
                        using (SqlConnection sqlConnection = new SqlConnection(sl.Connect()))
                        {

                            sqlConnection.Open();
                            string selectSQL = "SELECT * FROM [dbo].[Users] WHERE [login] = @login AND [password] = @password";
                            using (SqlCommand sqlCommand = new SqlCommand(selectSQL, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@login", log);
                                sqlCommand.Parameters.AddWithValue("@password", pas);

                                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                                {
                                    sqlDataAdapter.Fill(dataTable);
                                }
                            }


                        }
                        if (dataTable.Rows.Count > 0)
                        {
                            using (SqlConnection connection = new SqlConnection(sl.Connect()))
                            {
                                connection.Open();

                                string query = @"SELECT Сотрудники.Фамилия, Сотрудники.Имя
                                 FROM Сотрудники
                                 JOIN Users ON Сотрудники.ID= Users.ID_Сотрудника
                                 WHERE Users.login = @Login";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@Login", log);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string surname = reader.GetString(0);
                                            string name= reader.GetString(1);
                                            if (Convert.ToString(dataTable.Rows[0]["role"]) == "User")
                                            {
                                                User_form us  = new User_form(this);
                                                us.Name = name;
                                                us.Surname = surname;
                                                us.Show();
                                                this.Hide();
                                            }
                                            else if (Convert.ToString(dataTable.Rows[0]["role"]) == "Admin")
                                            {
                                                Admin_form admin = new Admin_form(this);
                                                admin.Name = name;
                                                admin.Surname = surname;
                                                admin.Show();
                                                admin.Show();
                                                this.Hide();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else MessageBox.Show("Неверный логин или пароль"); textBox2.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обратитесь к администратору БД");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        public void Show_form()
        {
            this.Show();
        }
    }
}