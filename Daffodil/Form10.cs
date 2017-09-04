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
    public partial class Form10 : Form
    {
        string ID;
        public Form10()
        {            
            InitializeComponent();

            comboBox3.Items.Add(System.DateTime.Today.ToString("yyyy"));
            comboBox3.Items.Add((int.Parse(System.DateTime.Today.ToString("yyyy"))+1)).ToString();

            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select top 1 SalaryID from salary order by SalaryID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "SALEMP-1111111";
                        label5.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "SALEMP-" + SID;
                        label5.Text = ID;
                    }


                    dr.Close();


                    cmd.CommandText = "Select ID from employee";
                    cmd.Connection = conn;

                    comboBox1.Items.Clear();
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        comboBox1.Items.Add(dr2[0]);
                    }

                    dr2.Close();
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            label4.Text = "";
            textBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
             using (SqlConnection conn = new SqlConnection(connectionstring))
             {
                 conn.Open();
                 using (SqlCommand cmd = new SqlCommand("Select * from employee where ID = '" + comboBox1.Text + "'", conn))
                 {
                     cmd.Connection = conn;

                     SqlDataReader dr = cmd.ExecuteReader();

                     while (dr.Read())
                     {
                         label4.Text = dr.GetString(1);

                     }
                     dr.Close();
                 }
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Check all the values!");
            }
            else
            {
                InputSalary();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from salary where EmployeeID = '" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and Year='" + comboBox3.Text + "'", conn))
                {                    
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            if (dr1.GetString(1) == comboBox1.Text && dr1.GetString(5) == comboBox2.Text && dr1.GetString(6) == comboBox3.Text)
                            {
                                MessageBox.Show("Already Paid!");
                            }                            
                        }
                    }                    
                    dr1.Close();  

                }
            }
        }

        public void InputSalary()
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into salary values (@id, @empid, @empname, @saldate, @amount, @month, @year)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", label5.Text);
                    cmd.Parameters.AddWithValue("@empid", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@empname", label4.Text);
                    cmd.Parameters.AddWithValue("@saldate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@amount", textBox1.Text);
                    cmd.Parameters.AddWithValue("@month", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@year", comboBox3.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted Successfully!");

                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Today;
                    label4.Text = "";
                    textBox1.Text = "";
                }
                using (SqlCommand cmd = new SqlCommand("select top 1 SalaryID from salary order by SalaryID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "SALEMP-1111111";
                        label5.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "SALEMP-" + SID;
                        label5.Text = ID;
                    }


                    dr.Close();


                    cmd.CommandText = "Select ID from employee";
                    cmd.Connection = conn;

                    comboBox1.Items.Clear();
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        comboBox1.Items.Add(dr2[0]);
                    }

                    dr2.Close();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from salary where EmployeeID = '" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and Year='" + comboBox3.Text + "'", conn))
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            if (dr1.GetString(1) == comboBox1.Text && dr1.GetString(5) == comboBox2.Text && dr1.GetString(6) == comboBox3.Text)
                            {
                                MessageBox.Show("Already Paid!");
                            }
                        }
                    }
                    dr1.Close();

                }
            }
        }

    }
}
