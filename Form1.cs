/*
ver: 0.1a  date: 2021.05.24
autor: Mikhail625@protonmail.com
*/


/*
 * Tip: for formatting Ctrl + K, а затем Ctrl + D
 * */



using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace DBMan
{
    public partial class frmConn1 : Form
    {
        public frmConn1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textbox_label();
            // ConnMSSQLExpess();
            
            ConnTest1();
        }

        private void textbox_label()
        {
            StringBuilder sb = new StringBuilder();
            string[] arrTextBox = new string[33];
            bool flag1 = true;
            int countArr1 = 0;

            int posX0 = 0;
            int offsetX1 = 0;
            int offsetX2 = 0;
            int offsetX3 = 0;
            int offsetX4 = 0;

            int posY0 = 0;
            int offsetY1 = 24;
            int offsetY2 = 0;
            int offsetY3 = 0;
            int offsetY4 = 0;


            listBox1.Sorted = false;

            foreach (Control t in this.Controls)
            {
                if (t is TextBox)
                {
                    if (flag1 == true)
                    {
                        posY0 = t.Location.Y;
                        posX0 = t.Location.X;

                        flag1 = false;
                    }
                    else
                    {
                        t.Location = new Point(posX0, posY0 + offsetY1);
                        posY0 += offsetY1;
                    }

                }
            }

            foreach (Control t in this.Controls)
            {
                if (t is TextBox)
                {
                    Console.WriteLine("Name: {0}   Loct: {1}    Size : {2}", t.Name, t.Location, t.Size);
                    sb.Append("Name:" + t.Name + " Loct:" + t.Location + "Size :" + t.Size);

                    arrTextBox[countArr1] = sb.ToString();
                    listBox1.Items.Add(sb.ToString());
                    sb.Clear(); countArr1++;
                }
            }



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox6.Text);




        }


        private void ConnMySQL()
        {
            var host = "HostName";
            var port = 3306;
            var dataBase = "DatabaseName";
            var userName = "UserName";
            var password = "Password";
            var connString =
                $"Server={host};Database={dataBase};port={port}" +
                $";User Id={userName};pasword={password}";
            var conn = new MySqlConnection(connString);

        }

        private void ConnMSSQLExpess()
        {

            var server = "Data Source=ServerName";
            var port = 1433;
            var dataBase = "Initial Catalog=DataBaseName";


            var userName = "User id=UserName";
            var password = "Password=UserPassword";
            var connString =
            string.Join(";", new[] { server, dataBase, userName, password });

            using (var conn = new SqlConnection(connString)) { conn.Open(); }
        }


        private void SetDefMySQL()
        {
            textBox11.Text = "local";
            comboBox1.Text = "MySQL";
            textBox10.Text = "127.0.0.1";
            textBox9.Text = Convert.ToString(3306);
            textBox8.Text = "persons";
            textBox7.Text = "root";
            textBox6.Text = "ac9b8f664f";


        }

        private void ConnMSSQLAutSQL()
        {


            // If you use SQL authentication, use this:
            // using System.Data.SqlClient;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                 @"Data Source=.\SQLExpress;" +
                 "User Instance=true;" +
                 "User Id=UserName;" +
                 "Password=Secret;" +
                 "AttachDbFilename=|DataDirectory|Database1.mdf;";
            conn.Open();





        }

        private void ConnTest1()
        {
            /*
            textBox11.Text = "local";
            comboBox1.Text = "MySQL";
            textBox10.Text = "127.0.0.1";
            textBox9.Text = Convert.ToString(3306); // port
            textBox8.Text = "persons";  // database name
            textBox7.Text = "root"; // user name
            textBox6.Text = "ac9b8f664f";  //pass
            */
            //

            var host = textBox10.Text;
            var port = textBox9.Text;
            var dataBase = textBox8.Text;
            var userName = textBox7.Text;
            var password = textBox6.Text;
            var connString = $"Server={host};Database={dataBase};port={port}" +
                $";User Id={userName};password={password}";

            listBox1.Items.Add(" " + host);
            listBox1.Items.Add(" " + dataBase);
            listBox1.Items.Add(":" + port);
          //  listBox1.Items.Add(" " + dataBase);
          //  listBox1.Items.Add(" " + dataBase);
          //  listBox1.Items.Add(" " + dataBase);
              
            var conn = new MySqlConnection(connString);
            conn.Open();
            var command = conn.CreateCommand();
            //  command.CommandText = @"SELECT Language, Percentage FROM countrylanguage WHERE " +
            //                          @"CountryCode = 'RUS' ORDER BY Percentage DESC";
            command.CommandText = @"SELECT * FROM tbl_name1";


            var reader = command.ExecuteReader(); // Get the data
            if (!reader.Read()) return;


            Console.WriteLine(reader.GetString(0) + ": " + reader.GetFloat("Percentage"));
            listBox1.Items.Add(reader.GetString(0) + ": " + reader.GetFloat("Percentage"));
            listBox1.Update();

        }


        private void ConnAutWin()
        {
            //If you use Windows authentication, use this:
            //  using System.Data.SqlClient;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                 @"Data Source=.\SQLExpress;" +
                 "User Instance=true;" +
                 "Integrated Security=true;" +
                 "AttachDbFilename=|DataDirectory|Database1.mdf;";
            conn.Open();

        }
        private void ConnTest()
        {
            new SqlConnection("Server=(local);Integrated Security=true");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
            MS SQL 
            Access
            MySQL
            MariaDB
            Oracle
            PostgreSQL
            MongoDB
            FireBird
            */
            string choiceDB;
            choiceDB = comboBox1.Text;



            switch (choiceDB)
            {
                case "MS SQL":

                    break;
                case "MySQL":
                    SetDefMySQL();


                    break;
                case "Access":

                    break;
                case "":

                    break;
            }




        }
    } /// end of frmConn
}
