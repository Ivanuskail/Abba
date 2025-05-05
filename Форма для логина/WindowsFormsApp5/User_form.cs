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
using System.Xml.Linq;

namespace WindowsFormsApp5
{
    public partial class User_form : Form
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        private bool flag = false;
        
        private List<SZI> szi = new List<SZI>();
        private Form1 form1;
        private List<Sert_szi> sert_Szis = new List<Sert_szi>();
        private Label lb2;
        private Label lb3;
        private Label lb1;
        public User_form(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void User_form_Load(object sender, EventArgs e)
        {
           label1.Text = Name + " " + Surname;
            Label lbl = new Label();
            lbl.Size = new Size(500, 500);
            lbl.Font = new Font("Impact", 15, FontStyle.Regular);
            lbl.Location = new Point(0, 0);
            lbl.Text = $"Приветвую вас, {Name}.\nНа самом деле,я незнаю что здесь написать,но я пишу это чтобы форма не выглядела пустой.\n@Ivanus.INC";
            flowLayoutPanel1.Controls.Add(lbl);
        }

        private void label2_Click(object sender, EventArgs e)
        {
           flag = true;
            this.Close();
        }

        private void User_form_FormClosing(object sender, FormClosingEventArgs e)
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
            label4.Text = "Выберите оборудование,для просмотра информации о нем";
            flowLayoutPanel1.Controls.Clear();
            Sql sl = new Sql();
            string query = @"SELECT Средства_Защиты.*, Тип_устройства.Название_типа
                        FROM Средства_Защиты
                        JOIN Тип_устройства ON Средства_Защиты.ID_типа = Тип_устройства.ID";
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
                                // Получение данных из каждой записи
                                string name = reader.GetString(1); // Первая колонка
                                string description = reader.GetString(2); // Вторая колонка
                                int service_life = reader.GetInt32(3); // Четвертая колонка
                                string type = reader.GetString(5); // Пятая колонка
                                SZI Szi = new SZI
                                {
                                    Name = name,
                                    Description = description,
                                    Service_life = service_life,
                                    Type = type
                                };
                                szi.Add(Szi);
                            }
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            flowLayoutPanel1.WrapContents = false;
            ComboBox comboBox = new ComboBox();
            comboBox.Font = new Font("Impact", 10, FontStyle.Regular);
            foreach (SZI SZ in szi)
            {
                comboBox.Items.Add(SZ.Name);
            }
            comboBox.Size = new Size(250, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            lb1 = new Label();
            lb2 = new Label();
            lb3 = new Label();
            lb1.Size = new Size(500, 50);
            lb2.Size = new Size(500, 20);
            lb3.Size = new Size(500, 20);
            lb1.Font = new Font("Impact", 14, FontStyle.Regular);
            lb2.Font = new Font("Impact", 14, FontStyle.Regular);
            lb3.Font = new Font("Impact", 14, FontStyle.Regular);
            lb1.Margin = new Padding(10);
            lb2.Margin = new Padding(10);
            lb3.Margin = new Padding(10);
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            flowLayoutPanel1.Controls.Add(comboBox);
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();

            foreach (SZI SZ in szi)
            {
                if (selectedValue == SZ.Name)
                {
                    lb1.Text = "Описание: " + SZ.Description;
                    lb2.Text = "Тип устройства: " + SZ.Type;
                    lb3.Text = "Срок службы: " + SZ.Service_life;
                }
            }
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Controls.Add(lb1);
            flowLayoutPanel1.Controls.Add(lb2);
            flowLayoutPanel1.Controls.Add(lb3);
        }

        private void сертификатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Таблица для просмотра информации о сертификатах на оборудовании";
            flowLayoutPanel1.Controls.Clear();
            Sql sl = new Sql();
            DataGridView data = new DataGridView();
            try
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    string query = @"SELECT SZ.Наименование AS Название_Оборудования, S.Назавание AS Название_Сертификата, ССЗ.Действует_до
                                FROM Сертификаты_Средств_Защиты ССЗ
                                INNER JOIN Средства_Защиты SZ ON ССЗ.Средство_защиты_ID = SZ.ID
                                INNER JOIN Сертификат S ON ССЗ.Сертификат_ID = S.ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name_szi = reader.GetString(0);
                                string name_sert = reader.GetString(1);
                                DateTime valid = reader.GetDateTime(2);
                                Sert_szi ser_sz = new Sert_szi
                                {
                                    Name_szi = name_szi,
                                    Name_sert = name_sert,
                                    Valid = valid
                                };
                                sert_Szis.Add(ser_sz);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            data.DataSource = sert_Szis;
            data.Size = new Size(640, 502);
            data.ReadOnly = true;
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            data.ScrollBars = ScrollBars.Both;
            flowLayoutPanel1.Controls.Add(data);
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Заявки на закупку оборудования";
            flowLayoutPanel1.Controls.Clear();
            Sql sl = new Sql();
            List <Zayvki> zaya = new List <Zayvki>();
            string query = @"
            SELECT
                Заявки_на_закупку_оборудования.Дата_подачи_заявки,
                Заявки_на_закупку_оборудования.Стоймость_оборуд,
                Сотрудники.Фамилия,
                Сотрудники.Имя,
                Отдел.Наименование_отдела,
                Средства_Защиты.Наименование AS Название_оборудования
            FROM
                Заявки_на_закупку_оборудования
                INNER JOIN Сотрудники ON Заявки_на_закупку_оборудования.ID_Сотрудника = Сотрудники.ID
                INNER JOIN Отдел ON Заявки_на_закупку_оборудования.ID_Отдела = Отдел.ID
                INNER JOIN Средства_Защиты ON Заявки_на_закупку_оборудования.ID_Оборудования = Средства_Защиты.ID";
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
                                DateTime date = reader.GetDateTime(0);
                                int cost = reader.GetInt32(1);
                                string surname = reader.GetString(2);
                                string firstName = reader.GetString(3);
                                string departmentName = reader.GetString(4);
                                string name_szi = reader.GetString(5);
                                Zayvki zay = new Zayvki()
                                {
                                    FirstName = firstName,
                                    Surname = surname,
                                    SZI_Name = name_szi,
                                    Cost = cost,
                                    Date = date,
                                    Departament = departmentName
                                };
                                zaya.Add(zay);
                            }
                        }
                    }

                }
                DateTime today = DateTime.Today;
                foreach (Zayvki za in zaya)
                {
                    DateTime date = za.Date;
                    TimeSpan span = today - date;
                    int daysPassed = span.Days;
                    int stoi = za.Cost;
                    string status;
                    if (daysPassed <= 10)
                    {
                        status = "В обработке";
                    }
                    else
                    {
                        status = "Выполненна";
                    }
                    if (stoi == 0)
                    {
                        status = "Создается";
                    }
                    
                    za.Status = status;
                }
                DataGridView data = new DataGridView();
                data.DataSource = zaya;
                data.ReadOnly = true;
                data.AutoSize = true;
                data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                data.ScrollBars = ScrollBars.Both;
                flowLayoutPanel1.Controls.Add(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }
        private void установленноеОборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Таблица установленного оборудования с датой установки";
            flowLayoutPanel1.Controls.Clear();
            Sql sl = new Sql();
            try
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();
                    List <Ust_obor> obor = new List<Ust_obor>();
                    string query = @"
                SELECT
                    Средства_Защиты.Наименование AS Название_оборудования,
                    Отдел.Наименование_отдела AS Название_отдела,
                    Установленное_оборудование.Дата_уст AS Дата_установки
                FROM
                    Установленное_оборудование
                    INNER JOIN Средства_Защиты ON Установленное_оборудование.Оборудование_ID = Средства_Защиты.ID
                    INNER JOIN Отдел ON Установленное_оборудование.Отдел_ID = Отдел.ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name_SZI = reader.GetString(0);
                                string name_Otd = reader.GetString(1);
                                DateTime date_ust = reader.GetDateTime(2);
                                Ust_obor ustobor = new Ust_obor
                                {
                                    Szi = name_SZI,
                                    Otdel = name_Otd,
                                    Date_ust = date_ust
                                };
                                obor.Add(ustobor);
                            }
                        }
                    }
                    DataGridView data = new DataGridView();
                    data.DataSource = obor;
                    data.Size = new Size(440, 270);
                    data.ReadOnly = true;
                    data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    data.ScrollBars = ScrollBars.Vertical;
                    flowLayoutPanel1.Controls.Add(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void формаНаСписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sql sl = new Sql();
            label4.Text = "Оборудование которое нужно списать или замеить сертификат";
            flowLayoutPanel1.Controls.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();
                    string query = @"
                    SELECT
                        SZ.Наименование AS Оборудование,
                        SZ.Срок_служб AS Срок_службы,
                        SSC.Действует_до AS Срок_действия_сертификата,
                        C.Назавание AS Название_сертификата,
                        'Обновить сертификат' AS Действие
                    FROM
                        Средства_Защиты SZ
                    INNER JOIN
                        Сертификаты_Средств_Защиты SSC ON SZ.ID = SSC.Средство_защиты_ID
                    LEFT JOIN
                        Использование_средств_защиты ISZ ON SZ.ID = ISZ.Средство_защиты_ID
                    LEFT JOIN
                        Сертификат C ON SSC.Сертификат_ID = C.ID
                    WHERE
                        SSC.Действует_до <= GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DataGridView data = new DataGridView();
                    data.DataSource = dataTable;
                    data.Size = new Size(540, 200);
                    data.ReadOnly = true;
                    data.AutoSize = true;
                    data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    data.ScrollBars = ScrollBars.Horizontal;
                    data.CellClick += new DataGridViewCellEventHandler(Data_Click);
                    flowLayoutPanel1.Controls.Add(data);
                    string query1 = @"
                    SELECT
                        SZ.Наименование AS Оборудование,
                        SZ.Срок_служб AS Срок_службы,
                        ISZ.Дата_окончания_использования AS Срок_действия_сертификата,
                        'Требуется замена оборудования' AS Действие
                    FROM
                        Средства_Защиты SZ
                    INNER JOIN
                        Использование_средств_защиты ISZ ON SZ.ID = ISZ.Средство_защиты_ID
                    WHERE
                        GETDATE() >= ISZ.Дата_окончания_использования";

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    DataGridView data1 = new DataGridView();
                    data1.DataSource = dataTable1;
                    data1.Size = new Size(540, 200);
                    data1.ReadOnly = true;
                    data1.AutoSize = true;
                    data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    data1.ScrollBars = ScrollBars.Horizontal;
                    data1.CellClick += new DataGridViewCellEventHandler(Data1_Click);
                    flowLayoutPanel1.Controls.Add(data1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message);
            }
        }

        private void Data_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Проверяем, что ячейка не является заголовочной ячейкой
            {
                DataGridView dataGridView = (DataGridView)sender;
                string name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (name != "")
                {
                    DialogResult result = MessageBox.Show("Вы хотите обновить сертификат?", "Предупреждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string name_szi = name;
                        Sql sl = new Sql();
                        using (SqlConnection connection = new SqlConnection(sl.Connect()))
                        {
                            connection.Open();

                            string query = @"
                            DECLARE @Наименование_оборудования NVARCHAR(100) = @Наименование;

                            UPDATE Сертификаты_Средств_Защиты
                            SET Действует_до = DATEADD(YEAR, 2, Действует_до)
                            WHERE Средство_защиты_ID = (
                                SELECT ID
                                FROM Средства_Защиты
                                WHERE Наименование = @Наименование_оборудования
                            )";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Наименование", name_szi);

                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Отлично,вы обновили сертификат для оборудования {name} на 2 года");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show($"{Name}, давай так не прикалывайся,у нас за такие приколы по голове не погладят", "Приколист?");
                    }
                }
                else 
                {
                    MessageBox.Show("Не,не пустую ячейку в нашем обществе не выбирают","Не прикалывайся:)");
                }
            }
            
        }
        private void Data1_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Проверяем, что ячейка не является заголовочной ячейкой
            {
                DataGridView dataGridView = (DataGridView)sender;
                string name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (name != "")
                {
                    DialogResult result = MessageBox.Show("Вы хотите оставить заявку?", "Предупреждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Sql sl = new Sql();
                        string equipmentName = name;
                        string employeeFirstName = Name;
                        string employeeLastName = Surname;

                        using (SqlConnection connection = new SqlConnection(sl.Connect()))
                        {
                            connection.Open();

                            string query = @"
                            DECLARE @EquipmentId INT;
                            DECLARE @EmployeeId INT;
                            DECLARE @DepartmentId INT;

                            SELECT @EquipmentId = ID FROM Средства_Защиты WHERE Наименование = @EquipmentName;
                            SELECT @EmployeeId = ID, @DepartmentId = ID_отдела FROM Сотрудники WHERE Имя = @FirstName AND Фамилия = @LastName;

                            BEGIN TRANSACTION;

                            INSERT INTO Заявки_на_закупку_оборудования (ID_оборудования, ID_Сотрудника, ID_Отдела, Дата_подачи_заявки, Стоймость_оборуд)
                            VALUES (@EquipmentId, @EmployeeId, @DepartmentId, GETDATE(), 0);

                            IF @@ROWCOUNT > 0
                            BEGIN
                                DELETE FROM Использование_средств_защиты WHERE Средство_защиты_ID = @EquipmentId;
                            END

                            COMMIT;
                        ";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@EquipmentName", equipmentName);
                                command.Parameters.AddWithValue("@FirstName", employeeFirstName);
                                command.Parameters.AddWithValue("@LastName", employeeLastName);
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Заявка созданна");
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show($"{Name}, давай так не прикалывайся,у нас за такие приколы по голове не погладят", "Приколист?");
                    }
                }
                else
                {
                    MessageBox.Show("Не,не пустую ячейку в нашем обществе не выбирают", "Не прикалывайся:)");
                }
            }
        }
        private void расходыПредприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sql sl = new Sql();
            label4.Text = "Рассходы предприятия на закупку и на закупленное оборудование";
            flowLayoutPanel1.Controls.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(sl.Connect()))
                {
                    connection.Open();

                    string query = @"
                SELECT
                    SUM(Заявки_на_закупку_оборудования.Стоймость_оборуд) AS Расходы_на_закупку,
                    SUM(Закупки_оборудования.Стоймость) AS Расходы_на_уже_закупленное
                FROM
                    Заявки_на_закупку_оборудования
                    LEFT JOIN Закупки_оборудования ON Заявки_на_закупку_оборудования.ID_оборудования = Закупки_оборудования.Средство_защиты_ID";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int zacup = reader.GetInt32(0);
                        int cup = reader.GetInt32(1);
                        Label lbl1 = new Label();
                        lbl1.Text = "Расходы на закупку: " + zacup.ToString() + " руб.";
                        lbl1.Font = new Font("Impact", 12, FontStyle.Regular);
                        lbl1.Margin = new Padding(5);
                        lbl1.Size = new Size(500, 50);
                        Label lbl2 = new Label();
                        lbl2.Text = "Расходы на закупленное оборудование: " + cup.ToString() + " руб.";
                        lbl2.Font = new Font("Impact", 12, FontStyle.Regular);
                        lbl2.Margin = new Padding(5);
                        lbl2.Size = new Size(500, 50);
                        Label lbl3 = new Label();
                        lbl3.Text = "Обшие рассходы: " + (cup + zacup).ToString() + " руб.";
                        lbl3.Font = new Font("Impact", 12, FontStyle.Regular);
                        lbl3.Margin = new Padding(5);
                        lbl3.Size = new Size(500, 50);
                        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel1.Controls.Add(lbl1);
                        flowLayoutPanel1.Controls.Add(lbl2);
                        flowLayoutPanel1.Controls.Add(lbl3);
                    }
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
