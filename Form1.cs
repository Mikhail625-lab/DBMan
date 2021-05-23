using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            textBox11.Text = "local";
            comboBox1.Text = "MS SQL";
        }

        private void ConnAutSQL()
        {


           // If you use SQL authentication, use this:
           // using System.Data.SqlClient;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                 @"Data Source=.\SQLExpress;" +
                 "User Instance=true;" +
                 "User Id=UserName;" +
                 "Password=Secret;" +
                 "AttachDbFilename=|DataDirectory|Database1.mdf;"
            conn.Open();





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
                 "AttachDbFilename=|DataDirectory|Database1.mdf;"
conn.Open();

        }

    } /// end of frmConn
}
