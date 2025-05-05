using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace WindowsFormsApp5
{
    public partial class Admin_form : Form
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private Form1 form1;
        private bool flag;
        private int Id_zay;
        private string temp;
        private Dictionary<string,int> Zayvki = new Dictionary<string,int>();
        private System.Windows.Forms.TextBox FirstName = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox LastName = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox Patronymic = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox Passport = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox Address = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.ComboBox Position = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox Education = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox Department = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox cm = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.TextBox Login = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox Password = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox Email = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.RadioButton r1 = new System.Windows.Forms.RadioButton();
        private System.Windows.Forms.RadioButton r2 = new System.Windows.Forms.RadioButton();
        private System.Windows.Forms.TextBox priem = new System.Windows.Forms.TextBox();
        private Label lbel = new Label();
        private System.Windows.Forms.RadioButton r3 = new System.Windows.Forms.RadioButton();
        private System.Windows.Forms.ComboBox Role = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox Zayv = new System.Windows.Forms.ComboBox();
        private TextBox Stoim = new TextBox();
        public Admin_form(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Admin_form_Load(object sender, EventArgs e)
        {
            label1.Text = Name + " " + Surname;
            Label lbl = new Label();
            lbl.Size = new Size(500, 500);
            lbl.Font = new Font("Impact", 15, FontStyle.Regular);
            lbl.Location = new Point(0, 0);
            lbl.Text = $"Приветвую вас администратор {Name}.\nНе ну тут я точно не зная что писать,веселитесь с полным доступом к БД.\n@Ivanus.INC";
            flowLayoutPanel1.Controls.Add(lbl);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            flag = true;
            this.Close();
        }

        private void Admin_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                form1.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("Закрыть приложение полностью?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else if (result == DialogResult.No)
                {
                    form1.Show();
                }
            }
        }

        private void оборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Заполните данные о новом сотруднике";
            Sql sl = new Sql();
            flowLayoutPanel1.Controls.Clear();
            Label lbl = new Label();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();
            Label lbl4 = new Label();
            Label lbl5 = new Label();
            Label lbl6 = new Label();
            Label lbl7 = new Label();
            lbl.Text = "Имя";
            lbl1.Text = "Фамилия";
            lbl2.Text = "Отчество";
            lbl3.Text = "Паспорт";
            lbl4.Text = "Адрес";
            lbl5.Text = "Отдел";
            lbl6.Text = "Образование";
            lbl7.Text = "Должность";
            lbl.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl1.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl2.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl3.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl4.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl5.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl6.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl7.Font = new Font("Impact", 11, FontStyle.Regular);
            string createEmployeeQuery = @"
            INSERT INTO Сотрудники (Имя, Фамилия, Отчество, ID_Должности, Паспорт, ID_образования, Место_жительства, ID_отдела)
            VALUES (@FirstName, @LastName, @Patronymic, @PositionID, @Passport, @EducationID, @Address, @DepartmentID);
        ";
            string query = "SELECT Наименование_отдела FROM Отдел";
            string query1 = "SELECT Должность FROM Должности";
            string query2 = "SELECT Образование FROM Образование";
            try
            {

                System.Windows.Forms.Button Dob_sotr = new System.Windows.Forms.Button();

                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string departmentName = reader.GetString(0);
                                Department.Items.Add(departmentName);
                            }
                        }
                    }
                }
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string educationName = reader.GetString(0);
                                Education.Items.Add(educationName);
                            }
                        }
                    }
                }
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string positionName = reader.GetString(0);
                                Position.Items.Add(positionName);
                            }
                        }
                    }
                }

                Dob_sotr.Click += Button_Click;
                Position.Size = new Size(200, 20);
                Education.Size = new Size(200, 20);
                Department.Size = new Size(200, 20);
                FirstName.Size = new Size(150, 20);
                LastName.Size = new Size(150, 20);
                Patronymic.Size = new Size(150, 20);
                Passport.Size = new Size(100, 20);
                Address.Size = new Size(150, 20);
                FirstName.KeyPress += No_Num;
                LastName.KeyPress += No_Num;
                Patronymic.KeyPress += No_Num;
                Passport.KeyPress += No_abc;
                Position.DropDownStyle = ComboBoxStyle.DropDownList;
                Education.DropDownStyle = ComboBoxStyle.DropDownList;
                Department.DropDownStyle = ComboBoxStyle.DropDownList;
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                Position.Margin = new Padding(5);
                Education.Margin = new Padding(5);
                Department.Margin = new Padding(5);
                FirstName.Margin = new Padding(5);
                LastName.Margin = new Padding(5);
                Patronymic.Margin = new Padding(5);
                Passport.Margin = new Padding(5);
                Address.Margin = new Padding(5);
                Dob_sotr.Text = "Добавить сотрудника";
                Dob_sotr.AutoSize = true;
                Dob_sotr.BackColor = Color.SandyBrown;
                Dob_sotr.Font = new Font("Impact", 11, FontStyle.Regular);
                flowLayoutPanel1.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(FirstName);
                flowLayoutPanel1.Controls.Add(lbl1);
                flowLayoutPanel1.Controls.Add(LastName);
                flowLayoutPanel1.Controls.Add(lbl2);
                flowLayoutPanel1.Controls.Add(Patronymic);
                flowLayoutPanel1.Controls.Add(lbl6);
                flowLayoutPanel1.Controls.Add(Education);
                flowLayoutPanel1.Controls.Add(lbl3);
                flowLayoutPanel1.Controls.Add(Passport);
                flowLayoutPanel1.Controls.Add(lbl4);
                flowLayoutPanel1.Controls.Add(Address);
                flowLayoutPanel1.Controls.Add(lbl5);
                flowLayoutPanel1.Controls.Add(Department);
                flowLayoutPanel1.Controls.Add(lbl7);
                flowLayoutPanel1.Controls.Add(Position);
                flowLayoutPanel1.Controls.Add(Dob_sotr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sl = new Sql();
                string createEmployeeQuery = @"
                INSERT INTO Сотрудники (Имя, Фамилия, Отчество, ID_Должности, Паспорт, ID_образования, Место_жительства, ID_отдела)
                VALUES (@FirstName, @LastName, @Patronymic, @PositionID, @Passport, @EducationID, @Address, @DepartmentID);
            ";
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand createEmployeeCommand = new SqlCommand(createEmployeeQuery, connection))
                    {
                        createEmployeeCommand.Parameters.AddWithValue("@FirstName", FirstName.Text);
                        createEmployeeCommand.Parameters.AddWithValue("@LastName", LastName.Text);
                        createEmployeeCommand.Parameters.AddWithValue("@Patronymic", Patronymic.Text);
                        createEmployeeCommand.Parameters.AddWithValue("@PositionID", Position.SelectedIndex + 1);
                        createEmployeeCommand.Parameters.AddWithValue("@Passport", Passport.Text);
                        createEmployeeCommand.Parameters.AddWithValue("@EducationID", Education.SelectedIndex + 1);
                        createEmployeeCommand.Parameters.AddWithValue("@Address", Address.Text);
                        createEmployeeCommand.Parameters.AddWithValue("@DepartmentID", Department.SelectedIndex + 1);

                        createEmployeeCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void добовлениеИИзмененияПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Выберите пользователя для изменения или для добовления данных";
            Sql sl = new Sql();
            flowLayoutPanel1.Controls.Clear();
            Label lbl = new Label();
            lbl.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl.Text = "Выберите сотрудника для дальнейших действий";
            try
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();
                    string quer = @"
                    SELECT Имя, Фамилия,Отчество
                    FROM Сотрудники";

                    using (SqlCommand command = new SqlCommand(quer, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader.GetString(0);
                                string Surname = reader.GetString(1);
                                string Oth = reader.GetString(2);
                                string FIO = Name + " " + Surname + " " + Oth;
                                cm.Items.Add(FIO);
                            }
                        }
                    }
                    cm.Size = new Size(200, 20);
                    cm.DropDownStyle = ComboBoxStyle.DropDownList;
                    cm.SelectedIndexChanged += vibr_cheliks;
                    flowLayoutPanel1.Controls.Add(cm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void No_Num(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void No_abc(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void vibr_cheliks(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(cm);
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex + 1;
            List<int> ID_down = new List<int>();
            Sql sl = new Sql();
            string query = @"
                    SELECT ID,Имя, Фамилия,Отчество
                    FROM Сотрудники
                    WHERE ID NOT IN (SELECT ID_Сотрудника FROM Users)";
            using (SqlConnection connection = new SqlConnection(sl.Connect()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            string Surname = reader.GetString(2);
                            string Oth = reader.GetString(3);
                            ID_down.Add(ID);
                        }
                    }
                }
            }
            if (ID_down.Contains(selectedIndex))
            {
                label4.Text = "Введите данные для создания нового пользователя";
                Label lbl = new Label();
                Label lbl1 = new Label();
                Label lbl2 = new Label();
                Label lbl3 = new Label();
                System.Windows.Forms.Button but = new System.Windows.Forms.Button();            
                but.Text = "Добавить пользователя";
                but.AutoSize = true;
                but.Margin = new Padding(5);
                but.Click += Dob_polz;
                but.BackColor = Color.SandyBrown;
                lbl.Text = "Введите логин";
                lbl1.Text = "Введите пароль";
                lbl2.Text = "Введите почту";
                lbl3.Text = "Выберите роль";
                Role.Items.Add("Admin");
                Role.Items.Add("User");
                lbl.Font =  new Font("Impact", 11, FontStyle.Regular);
                lbl1.Font = new Font("Impact", 11, FontStyle.Regular);
                lbl2.Font = new Font("Impact", 11, FontStyle.Regular);
                lbl3.Font = new Font("Impact", 11, FontStyle.Regular);
                lbl .Size = new Size(200,20);
                lbl1.Size = new Size(200,20);
                lbl2.Size = new Size(200,20);
                lbl3.Size = new Size(200, 20);
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(Login);
                flowLayoutPanel1.Controls.Add(lbl1);
                flowLayoutPanel1.Controls.Add(Password);
                flowLayoutPanel1.Controls.Add(lbl2);
                flowLayoutPanel1.Controls.Add(Email);
                flowLayoutPanel1.Controls.Add(lbl3);
                flowLayoutPanel1.Controls.Add(Role);
                flowLayoutPanel1.Controls.Add(but);
            }
            else
            {
                label4.Text = "Выберите что хотите изменить у данного пользователя и введите новые данные";
                System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                but.Text = "Изменить данные";
                but.AutoSize = true;
                but.Margin = new Padding(5);
                but.Click += Izm_dann;
                but.BackColor = Color.SandyBrown;
                priem.Size = new Size(200, 20);
                priem.Margin = new Padding(15);
                lbel.Font = new Font("Impact", 11, FontStyle.Regular);
                lbel.Size = new Size(200, 20);
                lbel.Text = "Введите новый пароль";
                r1.Text = "Сменить пароль";
                r1.Font = new Font("Impact", 11, FontStyle.Regular);
                r1.Checked = true;
                r2.Text = "Сменить логин";
                r2.Font = new Font("Impact", 11, FontStyle.Regular);
                r2.Checked = false;
                r3.Text = "Сменить почту";
                r3.Font = new Font("Impact", 11, FontStyle.Regular);
                r3.Checked = false;
                r1.Size = new Size(200, 30);
                r2.Size = new Size(200, 30);
                r3.Size = new Size(200, 30);
                r1.Margin = new Padding(5);
                r2.Margin = new Padding(5);
                r3.Margin = new Padding(5);
                r1.CheckedChanged += check;
                r2.CheckedChanged += check;
                r3.CheckedChanged += check;
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.Controls.Add(lbel);
                flowLayoutPanel1.Controls.Add(priem);
                flowLayoutPanel1.Controls.Add(r1);
                flowLayoutPanel1.Controls.Add(r2);
                flowLayoutPanel1.Controls.Add(r3);
                flowLayoutPanel1.Controls.Add(but);
            }

        }
        private void check(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = sender as System.Windows.Forms.RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                if (radioButton == r1)
                {
                    lbel.Text = "Введите новый пароль";
                }
                else if (radioButton == r2)
                {
                    lbel.Text = "Введите новый логин";
                }
                else if (radioButton == r3)
                {
                    lbel.Text = "Введите новую почту";
                }
            }
        }
        private void Izm_dann(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(priem.Text))
                {

                    Sql sl = new Sql();
                    Hash hs = new Hash();
                    if (r1.Checked)
                    {
                        string updatePasswordQuery = @"
                        UPDATE Users
                        SET password = @NewPassword
                        WHERE ID_Сотрудника = @EmployeeID;
                    ";

                        int employeeID = cm.SelectedIndex + 1;
                        string newPassword = hs.SHA(priem.Text);
                        using (SqlConnection connection = new SqlConnection(sl.Connect()))
                        {
                            connection.Open();

                            using (SqlCommand updatePasswordCommand = new SqlCommand(updatePasswordQuery, connection))
                            {
                                updatePasswordCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                                updatePasswordCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

                                updatePasswordCommand.ExecuteNonQuery();
                            }
                        }
                        priem.Clear();
                    }
                    else if (r1.Checked)
                    {
                        string updateLoginQuery = @"
                        UPDATE Users
                        SET login = @NewLogin
                        WHERE ID_Сотрудника = @EmployeeID;
                    ";
                        string newLogin = hs.SHA(priem.Text); ;
                        int employeeID = cm.SelectedIndex + 1;
                        using (SqlConnection connection = new SqlConnection(sl.Connect()))
                        {
                            connection.Open();

                            using (SqlCommand updateLoginCommand = new SqlCommand(updateLoginQuery, connection))
                            {
                                updateLoginCommand.Parameters.AddWithValue("@NewLogin", newLogin);
                                updateLoginCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

                                updateLoginCommand.ExecuteNonQuery();
                            }
                        }
                        priem.Clear();
                    }
                    else if (r1.Checked)
                    {
                        string updateEmailQuery = @"
                        UPDATE Users
                        SET mail = @NewEmail
                        WHERE ID_Сотрудника = @EmployeeID;
                    ";
                        string newEmail = hs.SHA(priem.Text);
                        int employeeID = cm.SelectedIndex + 1;
                        using (SqlConnection connection = new SqlConnection(sl.Connect()))
                        {
                            connection.Open();

                            using (SqlCommand updateEmailCommand = new SqlCommand(updateEmailQuery, connection))
                            {
                                updateEmailCommand.Parameters.AddWithValue("@NewEmail", newEmail);
                                updateEmailCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

                                updateEmailCommand.ExecuteNonQuery();
                            }
                        }
                        priem.Clear();
                    }
                }
                else MessageBox.Show("Не оставляйте TextBox пустым");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Dob_polz(object sender, EventArgs e)
        {
            try
            {

                Sql sl = new Sql();
                Hash hs = new Hash();
                string addUserQuery = @"
                INSERT INTO Users (ID_Сотрудника, login, password, mail, role)
                VALUES (@EmployeeID, @Login, HASHBYTES('SHA1', @Password), @Email, @Role);
                ";
                int employeeID = cm.SelectedIndex + 1;
                string login = hs.SHA(Login.Text);
                string password = hs.SHA(Password.Text);
                string email = Email.Text;
                string role = Role.Text;
                if (employeeID != 0 && login != "" && password != "" && email != "" && role != "")
                {

                    using (SqlConnection connection = new SqlConnection(sl.Connect()))
                    {
                        connection.Open();

                        using (SqlCommand addUserCommand = new SqlCommand(addUserQuery, connection))
                        {
                            addUserCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                            addUserCommand.Parameters.AddWithValue("@Login", login);
                            addUserCommand.Parameters.AddWithValue("@Password", password);
                            addUserCommand.Parameters.AddWithValue("@Email", email);
                            addUserCommand.Parameters.AddWithValue("@Role", role);

                            addUserCommand.ExecuteNonQuery();
                        }
                    }
                    cm.SelectedIndex = -1;
                    Login.Clear();
                    Password.Clear();
                    Email.Clear();
                    Role.SelectedIndex = -1;
                }
                else MessageBox.Show("Заполните все поля");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void сертификатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            label4.Text = "Выберите название оборудования заявка которого требует заполнения стоймости";
            Sql sl = new Sql();
            string query = @"
            SELECT Заявки_на_закупку_оборудования.ID, Заявки_на_закупку_оборудования.ID_оборудования, Средства_Защиты.Наименование, Заявки_на_закупку_оборудования.ID_Сотрудника, Заявки_на_закупку_оборудования.ID_Отдела, Заявки_на_закупку_оборудования.Дата_подачи_заявки, Заявки_на_закупку_оборудования.Стоймость_оборуд
            FROM Заявки_на_закупку_оборудования
            JOIN Средства_Защиты ON Заявки_на_закупку_оборудования.ID_оборудования = Средства_Защиты.ID
            WHERE Заявки_на_закупку_оборудования.Стоймость_оборуд = 0;
        ";

            try
            {

                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Id_zay = reader.GetInt32(0);      
                                string equipmentName = reader.GetString(2); 
                                Zayv.Items.Add(equipmentName);
                                Zayvki.Add(equipmentName,Id_zay);

                            }
                        }
                    }
                }
                Zayv.Size = new Size(200, 20);
                Zayv.DropDownStyle = ComboBoxStyle.DropDownList;
                Zayv.SelectedIndexChanged += vibr_obor;
                flowLayoutPanel1.Controls.Add(Zayv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void vibr_obor(object sender, EventArgs e)
        {
            temp = Zayv.SelectedItem.ToString();
            Label lbl = new Label();
            lbl.Size = new Size(200, 20);
            lbl.Text = "Введите стоймость оборудования";
            lbl.Font = new Font("Impact", 11, FontStyle.Regular);
            lbl.Margin = new Padding(5);
            Stoim.KeyPress += No_abc;
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn.Text = "Добавить стоймость";
            btn.Click += Dob_stoim;
            btn.BackColor = Color.SandyBrown;
            btn.AutoSize = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Controls.Add(lbl);
            flowLayoutPanel1.Controls.Add(Stoim);
            flowLayoutPanel1.Controls.Add(btn);
        }
        private void Dob_stoim(object sender, EventArgs e)
        {
            int requestId = Zayvki[Zayv.SelectedItem.ToString()]; 
            int newCost = Convert.ToInt32(Stoim.Text); 
            Sql sl = new Sql();
            string query = @"
            UPDATE Заявки_на_закупку_оборудования
            SET Стоймость_оборуд = @NewCost
            WHERE ID = @RequestId;
        ";
            if (Stoim.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewCost", newCost);
                        command.Parameters.AddWithValue("@RequestId", requestId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Стоймость оборудования в заявке успешно изменена.");
                        }
                        else
                        {
                            MessageBox.Show("Заявка с указанным ID не найдена.");
                        }
                    }
                }
                flowLayoutPanel1.Controls.Clear();
                Zayv.Items.Remove(temp);
                flowLayoutPanel1.Controls.Add(Zayv);

            }
            else
                MessageBox.Show("Введите стоимсоть");

        }
    }
}
