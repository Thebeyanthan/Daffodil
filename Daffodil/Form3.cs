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
    public partial class Form3 : Form
    {
        string ID;
        public Form3()
        {
            InitializeComponent();
            
             string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
             using (SqlConnection conn = new SqlConnection(connectionstring))
             {
                  conn.Open();
                  using (SqlCommand cmd = new SqlCommand("select top 1 ID from student order by ID desc", conn))
                  {
                      SqlDataReader dr = cmd.ExecuteReader();
                      
                          while (dr.Read())

                              ID = dr.GetString(0);
                          
                          if (ID == null)
                          {
                              ID = "DAFMON-1111111";
                              label9.Text = ID;
                          }

                          else
                          {                              
                              string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                              ID = "DAFMON-"+SID;
                              label9.Text = ID;
                          }
                      

                      dr.Close();
                  }
             }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Today;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || (checkBox1.Checked == false && checkBox2.Checked == false) || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Important fiels are not Filled!");
            }
            else
            {
                string polio;
                string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    
                    if (checkBox1.Checked == true)
                    {
                        polio = "Immunized";
                    }
                    else 
                    {
                        polio = "Not Immunized";
                    }
                    using (SqlCommand cmd = new SqlCommand("insert into student values(@id, @name, @dob, @age, @religion, @mothertongue, @medofinstruction, @polio, @fname, @foccupation, @fnationality, @freligion, @fhomeadd, @fofficeadd, @fmobilenum, @fhomenum, @fofficenum, @femail, @mname, @moccupation, @mnationality, @mreligion, @mhomeadd, @mofficeadd, @mmobilenum, @mhomenum, @mofficenum, @memail)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", label9.Text);
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@religion", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@mothertongue", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@medofinstruction", comboBox3.Text);
                        cmd.Parameters.AddWithValue("@polio", polio);
                        cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@foccupation", textBox3.Text);
                        cmd.Parameters.AddWithValue("@fnationality", textBox4.Text);
                        cmd.Parameters.AddWithValue("@freligion", comboBox4.Text);
                        cmd.Parameters.AddWithValue("@fhomeadd", textBox5.Text);
                        cmd.Parameters.AddWithValue("@fofficeadd", textBox6.Text);
                        cmd.Parameters.AddWithValue("@fmobilenum", textBox7.Text);
                        cmd.Parameters.AddWithValue("@fhomenum", textBox8.Text);
                        cmd.Parameters.AddWithValue("@fofficenum", textBox9.Text);
                        cmd.Parameters.AddWithValue("@femail", textBox10.Text);
                        cmd.Parameters.AddWithValue("@mname", textBox11.Text);
                        cmd.Parameters.AddWithValue("@moccupation", textBox12.Text);
                        cmd.Parameters.AddWithValue("@mnationality", textBox13.Text);
                        cmd.Parameters.AddWithValue("@mreligion", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@mhomeadd", textBox14.Text);
                        cmd.Parameters.AddWithValue("@mofficeadd", textBox15.Text);
                        cmd.Parameters.AddWithValue("@mmobilenum", textBox16.Text);
                        cmd.Parameters.AddWithValue("@mhomenum", textBox17.Text);
                        cmd.Parameters.AddWithValue("@mofficenum", textBox18.Text);
                        cmd.Parameters.AddWithValue("@memail", textBox19.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted Successfully!");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        textBox16.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                        comboBox5.Text = "";
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        numericUpDown1.Value = 0;
                        dateTimePicker1.Value = DateTime.Today;
                    }
                    using (SqlCommand cmd = new SqlCommand("select top 1 ID from student order by ID desc", conn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())

                            ID = dr.GetString(0);
                        if (ID == null)
                        {
                            ID = "DAFMON-1111111";
                            label9.Text = ID;
                        }

                        else
                        {
                            string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                            ID = "DAFMON-"+SID;
                            label9.Text = ID;
                        }

                        dr.Close();
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'daffodilDataSet3.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.daffodilDataSet3.student);
           

        }
    }
}
