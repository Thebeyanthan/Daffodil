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
    public partial class Form5 : Form
    {
        string ID;
        public Form5()
        {
            InitializeComponent();

            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select top 1 ID from evengStudent order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "DAFEVC-1111111";
                        label2.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "DAFEVC-" + SID;
                        label2.Text = ID;
                    }


                    dr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            numericUpDown1.Value=0;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox8.Text == "" || textBox9.Text == "" ||  (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false))
                {
                    MessageBox.Show("Check all Important fields!");
                }
                else
                {
                    string tamil, sinhala, environment, maths, music, dance;
                    string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        conn.Open();
                        if (checkBox1.Checked == true)
                        {
                            tamil = "Yes";
                        }
                        else
                        {
                            tamil = "No";
                        }
                        if (checkBox2.Checked == true)
                        {
                            sinhala = "Yes";
                        }
                        else
                        {
                            sinhala = "No";
                        }
                        if (checkBox3.Checked == true)
                        {
                            environment = "Yes";
                        }
                        else
                        {
                            environment = "No";
                        }
                        if (checkBox4.Checked == true)
                        {
                            maths = "Yes";
                        }
                        else
                        {
                            maths = "No";
                        }
                        if (checkBox5.Checked == true)
                        {
                            dance = "Yes";
                        }
                        else
                        {
                            dance = "No";
                        }
                        if (checkBox6.Checked == true)
                        {
                            music = "Yes";
                        }
                        else
                        {
                            music = "No";
                        }
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("insert into evengstudent values (@id, @name, @dob, @age, @address, @telnum, @fname, @foccupation, @fmobnum, @mname, @moccupation, @mmobnum, @tamil, @sinhala, @environment, @maths, @music, @dance)", conn))
                            {
                                cmd.Parameters.AddWithValue("@id", label2.Text);
                                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                                cmd.Parameters.AddWithValue("@telnum", textBox8.Text);
                                cmd.Parameters.AddWithValue("@fname", textBox5.Text);
                                cmd.Parameters.AddWithValue("@foccupation", textBox6.Text);
                                cmd.Parameters.AddWithValue("@fmobnum", textBox7.Text);
                                cmd.Parameters.AddWithValue("@mname", textBox9.Text);
                                cmd.Parameters.AddWithValue("@moccupation", textBox10.Text);
                                cmd.Parameters.AddWithValue("@mmobnum", textBox11.Text);
                                cmd.Parameters.AddWithValue("@tamil", tamil);
                                cmd.Parameters.AddWithValue("@sinhala", sinhala);
                                cmd.Parameters.AddWithValue("@environment", environment);
                                cmd.Parameters.AddWithValue("@maths", maths);
                                cmd.Parameters.AddWithValue("@music", music);
                                cmd.Parameters.AddWithValue("@dance", dance);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Data inserted Successfully!");

                                textBox1.Text = "";
                                numericUpDown1.Value=0;
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";
                                textBox7.Text = "";
                                textBox8.Text = "";
                                textBox9.Text = "";
                                textBox10.Text = "";
                                textBox11.Text = "";
                                dateTimePicker1.Value = DateTime.Today;
                                checkBox1.Checked = false;
                                checkBox2.Checked = false;
                                checkBox3.Checked = false;
                                checkBox4.Checked = false;
                                checkBox5.Checked = false;
                                checkBox6.Checked = false;
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid Age!");
                        }
                        using (SqlCommand cmd = new SqlCommand("select top 1 ID from evengStudent order by ID desc", conn))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())

                                ID = dr.GetString(0);

                            if (ID == null)
                            {
                                ID = "DAFEVC-1111111";
                                label2.Text = ID;
                            }

                            else
                            {
                                string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                                ID = "DAFEVC-" + SID;
                                label2.Text = ID;
                            }

                            dr.Close();
                        }
                    }
                }
            
                
            }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'daffodilDataSet5.evengStudent' table. You can move, or remove it, as needed.
            this.evengStudentTableAdapter1.Fill(this.daffodilDataSet5.evengStudent);
            
        }
        }
 }


