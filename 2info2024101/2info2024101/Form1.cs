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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
 
 
namespace _2info2024101
{
    public partial class Form1 : Form
    {
        private string HostName = "localhost";
        private string PortName = "3307";
        private string UserName = "root";
        private string Password = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            textHostName.Text = $"Gép név:";
            label2.Text = $"Port:";
            textUserName.Text = $"Felhasználó:";
            textPassword.Text = $"Jelszó:";
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayData();
            string Cn = string.Empty;
        }
 
        private void DisplayData()
        {
            MySqlConnectionStringBuilder mysqlConnectionStringBuilder = new MySqlConnectionStringBuilder()
            {
                Server = HostName,
                Port = (uint)System.Convert.ToInt32(PortName),
                UserID = UserName,
                Password = "",
                Database = "vasarlas",
                SslMode = MySqlSslMode.Preferred,
            };
 
 
            string ConnectionString = mysqlConnectionStringBuilder.ConnectionString; //$"datasource={HostName};port={PortName};username={UserName};password={Password}";
            MySqlConnection MyConn2 = new MySqlConnection(ConnectionString);
            string sqlQuery = "select * from vasarlas_lista;";
            try
            {
                MySqlCommand MyCommand2 = new MySqlCommand(sqlQuery, MyConn2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba az adatbázis kapcsolodáskor: {ex.Message}");
            }
 
        }
        private void textHostName_TextChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ConnectionString = $"datasource={HostName};port={PortName};username={UserName};password={Password}"; ;
            MySqlConnection MyConn2 = new MySqlConnection(ConnectionString);
            string sqlQuery = "select * from Parks_and_Recreation.employee_demographics;";
            MySqlCommand MyCommand2 = new MySqlCommand(sqlQuery, MyConn2);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
 
 
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HostName = txbName.Text;
            PortName = txbPort.Text;
            UserName = txbFelhNev.Text;
            Password = txbJelszo.Text;
            DisplayData();
        }
 
        private void UpdateButton()
        {
            string Cn = string.Empty;
            if (!string.IsNullOrWhiteSpace(textHostName.Text) &&
                //!string.IsNullOrWhiteSpace(textPassword.Text) &&
                !string.IsNullOrWhiteSpace(textUserName.Text) &&
                !string.IsNullOrWhiteSpace(txbPort.Text)
                )
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                { btnUpdate.Enabled = false; }
            }
        }
 
        private void txbName_TextChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }
        private void txbPort_TextChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }
        private void txbFelhNev_TextChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }
 
        private void txbJelszo_TextChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }
 
        private void textPortName_Click(object sender, EventArgs e)
        {
            UpdateButton();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HostName = textHostName.Text;
            PortName = label2.Text;
            UserName = textUserName.Text;
            Password = textPassword.Text;
            string ConnectionString = $"datasource={HostName};port={PortName};username={UserName};password={Password}";
            MySqlConnection MyConn2 = new MySqlConnection(ConnectionString);
            string Query = $"insert into {textBox6.Text}.employee_demographics(fist_name,last_name,age,gender," + $"birth_date)" +
                $"values('" + this.textLast_name.Text + "','" + this.textLastname.Text + "','" + this.textAge.Text + "','" + this.textGender.Text +
                "','" + this.textBirth_month.Text + "');";
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Save Data");
            while (MyReader2.Read())
            {
 
            }
            MyConn2.Close();
 
        }
 
        private void Adatbazis_Click(object sender, EventArgs e)
        {
 
        }
        private void trigger_Click(object sender, EventArgs e)
        {
            
            string ConnectionString = $"datasource={txbName.Text}; port={txbPort.Text};username={txbFelhNev.Text};password={txbJelszo.Text}";
            MySqlConnection MyConn2 = new MySqlConnection(ConnectionString);
            string Quary = $"insert into {textBox6.Text}.vasarlas_lista(id, name, price)" +
                $"values ('" + this.idtext.Text + "' , '" + this.nametext.Text + "' , '" + this.pricetext.Text + "') ;";
            MySqlCommand MyCommad2 = new MySqlCommand(Quary, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommad2.ExecuteReader();
            MessageBox.Show("Save data");
            MyConn2.Close();
        }
    }
}