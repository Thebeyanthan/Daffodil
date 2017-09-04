using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Daffodil
{
    public partial class Form4 : Form
    {
        string ID;
        public Form4()
        {
            InitializeComponent();

            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select top 1 ID from employee order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "DAFEMP-1111111";
                        label7.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "DAFEMP-" + SID;
                        label7.Text = ID;
                    }


                    dr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Check all Values!");
            }
            else
            {
                 string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                 using (SqlConnection conn = new SqlConnection(connectionstring))
                 {
                     conn.Open();
                     using (SqlCommand cmd = new SqlCommand("insert into employee values(@id, @name, @designation, @address, @mobnum, @dob)", conn))
                     {
                         cmd.Parameters.AddWithValue("@id",label7.Text);
                         cmd.Parameters.AddWithValue("@name", textBox1.Text);
                         cmd.Parameters.AddWithValue("@designation", textBox2.Text);
                         cmd.Parameters.AddWithValue("@address", textBox3.Text);
                         cmd.Parameters.AddWithValue("@mobnum", textBox4.Text);
                         cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Data inserted Successfully!");

                         textBox1.Text = "";
                         textBox2.Text = "";
                         textBox3.Text = "";
                         textBox4.Text = "";
                         dateTimePicker1.Value = DateTime.Today;
                     }
                     using (SqlCommand cmd = new SqlCommand("select top 1 ID from employee order by ID desc", conn))
                     {
                         SqlDataReader dr = cmd.ExecuteReader();

                         while (dr.Read())

                             ID = dr.GetString(0);

                         if (ID == null)
                         {
                             ID = "DAFEMP-111111";
                             label7.Text = ID;
                         }

                         else
                         {
                             string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                             ID = "DAFEMP-"+SID;
                             label7.Text = ID;
                         }


                         dr.Close();
                     }
                 }

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'daffodilDataSet4.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter1.Fill(this.daffodilDataSet4.employee);
            

        }
    }
}
