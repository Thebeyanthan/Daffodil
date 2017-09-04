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
    public partial class Form7 : Form
    {
        int count = 0, count2 = 0;
        string ID;
        string regFee, tamilFee, sinhalaFee, environmentFee, mathsFee, musicFee, danceFee;
        string tamil, sinhala, environment, maths, music, dance;
        public Form7()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            comboBox3.Items.Add(System.DateTime.Today.ToString("yyyy"));
            comboBox3.Items.Add((int.Parse((System.DateTime.Today.ToString("yyyy"))) + 1).ToString());

            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select top 1 ID from EvengPayament order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "PAYEVC-1111111";
                        label5.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "PAYEVC-" + SID;
                        label5.Text = ID;
                    }


                    dr.Close();


                    cmd.CommandText = "Select ID from evengStudent";
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

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'daffodilDataSet9.EvengPayament' table. You can move, or remove it, as needed.
            this.evengPayamentTableAdapter.Fill(this.daffodilDataSet9.EvengPayament);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                count2++;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
                count2--;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                count2++;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
                count2--;
            }
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
                count2++;
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "";
                count2--;
            }
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Enabled = true;
                count2++;
            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "";
                count2--;
            }
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox5.Enabled = true;
                count2++;
            }
            else
            {
                textBox5.Enabled = false;
                textBox5.Text = "";
                count2--;
            }
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                textBox6.Enabled = true;
                count2++;
            }
            else
            {
                textBox6.Enabled = false;
                textBox6.Text = "";
                count2--;
            }
            
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                textBox8.Enabled = true;                
                count++;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            else
            {
                textBox8.Enabled = false;
                textBox8.Text = "";                
                count--;
                CheckSubject();
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
             using (SqlConnection conn = new SqlConnection(connectionstring))
             {
                 conn.Open();
                 using (SqlCommand cmd = new SqlCommand("Select * from evengStudent where ID = '" + comboBox1.Text + "'", conn))
                 {
                     cmd.Connection = conn;

                     SqlDataReader dr = cmd.ExecuteReader();

                     while (dr.Read())
                     {
                         label3.Text = dr.GetString(1);

                     }
                     dr.Close();
                 }                
                 CheckSubject();
                
                 using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "'", conn))
                 {
                     SqlDataReader dr1 = cmd.ExecuteReader();
                     if (dr1.HasRows)
                     {

                         while (dr1.Read())
                         {
                             if (dr1.GetString(12) == "Not Paid")
                             {
                                 checkBox7.Enabled = true;
                                 regFee = "Not Paid";
                             }
                             else
                             {
                                 checkBox7.Enabled = false;
                                 break;
                             }
                         }
                     }
                     else
                     {
                         checkBox7.Enabled = true;
                     }
                     dr1.Close();
                 }
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((count == 1 && count2 == 0) && comboBox1.Text != "" && textBox8.Text != "")
            {
                insertValue();
            }
            else if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || ((checkBox1.Checked == false || textBox1.Text == "") && (checkBox2.Checked == false || textBox2.Text == "") && (checkBox3.Checked == false || textBox3.Text == "") && (checkBox4.Checked == false || textBox4.Text == "") && (checkBox5.Checked == false  || textBox5.Text == "") &&  (checkBox6.Checked == false || textBox6.Text == ""))) 
            {
                MessageBox.Show("Check All Inputs!");
            }
            
            else
            {
                insertValue(); 
            }
        }
        public void insertValue()
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from evengStudent where ID = '" + comboBox1.Text + "'", conn))
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {

                            if (dr1.GetString(12) == "Yes")
                            {
                                tamil = "Yes";
                                checkBox1.Enabled = true;                                
                            }
                            else
                            {
                                tamil = "No";                                
                            }
                            if (dr1.GetString(13) == "Yes")
                            {
                                sinhala = "Yes";
                                checkBox2.Enabled = true;                                
                            }
                            else
                            {
                                sinhala = "No";                               
                            }
                            if (dr1.GetString(14) == "Yes")
                            {
                                environment = "Yes";
                                checkBox3.Enabled = true;                                
                            }
                            else
                            {
                                environment = "No";                                
                            }
                            if (dr1.GetString(15) == "Yes")
                            {
                                maths = "Yes";
                                checkBox4.Enabled = true;                               
                            }
                            else
                            {
                                maths = "No";                                
                            }
                            if (dr1.GetString(16) == "Yes")
                            {
                                music = "Yes";
                                checkBox5.Enabled = true;                               
                            }
                            else
                            {
                                music = "No";                                
                            }
                            if (dr1.GetString(17) == "Yes")
                            {
                                dance = "Yes";
                                checkBox6.Enabled = true;                                
                            }
                            else
                            {
                                dance = "No";                                
                            }
                        }
                    }

                    dr1.Close();
                }
                if (checkBox1.Checked)
                {
                    tamilFee = textBox1.Text;
                }
                else
                {                    
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='"+comboBox3.Text+"'and Month='"+comboBox2.Text+"'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(13) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {                                    
                                    tamilFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            tamilFee = "Not Paid";
                        }
                        dr1.Close();
                    } 
                }
                if (checkBox2.Checked)
                {
                    sinhalaFee = textBox2.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='" + comboBox3.Text + "'and Month='" + comboBox2.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(14) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {
                                    sinhalaFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            sinhalaFee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox3.Checked)
                {
                    environmentFee = textBox3.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='" + comboBox3.Text + "'and Month='" + comboBox2.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(15) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {
                                    environmentFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            environmentFee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox4.Checked)
                {
                    mathsFee = textBox4.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='" + comboBox3.Text + "'and Month='" + comboBox2.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(16) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {
                                    mathsFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            mathsFee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox5.Checked)
                {
                    musicFee = textBox5.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='" + comboBox3.Text + "'and Month='" + comboBox2.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(17) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {
                                    musicFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            musicFee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox6.Checked)
                {
                    danceFee = textBox6.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='" + comboBox3.Text + "'and Month='" + comboBox2.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(18) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                                {
                                    danceFee = "Paid";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            danceFee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox7.Checked)
                {
                    regFee = textBox8.Text;
                   
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(12) != "Not Paid")
                                {
                                    checkBox7.Enabled = false;
                                    regFee = "Paid";                                    
                                    break;
                                }
                            }
                        }
                        else
                        {
                            regFee = "Not Paid";                           
                        }
                        dr1.Close();
                    }       
                                       
                }
                using (SqlCommand cmd = new SqlCommand("Select * from evengStudent where ID = '" + comboBox1.Text + "'", conn))
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {

                            if (dr1.GetString(12) == "Yes")
                            {
                                checkBox1.Enabled = true;
                            }
                            else
                            {
                                checkBox1.Enabled = false;
                                tamilFee = "Not Registered";
                            }
                            if (dr1.GetString(13) == "Yes")
                            {
                                checkBox2.Enabled = true;
                            }
                            else
                            {
                                checkBox2.Enabled = false;
                                sinhalaFee = "Not Registered";
                            }
                            if (dr1.GetString(14) == "Yes")
                            {
                                checkBox3.Enabled = true;
                            }
                            else
                            {
                                checkBox3.Enabled = false;
                                environmentFee = "Not Registered";
                            }
                            if (dr1.GetString(15) == "Yes")
                            {
                                checkBox4.Enabled = true;
                            }
                            else
                            {
                                checkBox4.Enabled = false;
                                mathsFee = "Not Registered";
                            }
                            if (dr1.GetString(16) == "Yes")
                            {
                                checkBox5.Enabled = true;
                            }
                            else
                            {
                                checkBox5.Enabled = false;
                                musicFee = "Not Registered";
                            }
                            if (dr1.GetString(17) == "Yes")
                            {
                                checkBox6.Enabled = true;
                            }
                            else
                            {
                                checkBox6.Enabled = false;
                                danceFee = "Not Registered";
                            }
                        }
                    }
                    else
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox4.Enabled = true;
                        checkBox5.Enabled = true;
                        checkBox6.Enabled = true;
                    }
                    dr1.Close();
                }
                using (SqlCommand cmd = new SqlCommand("insert into EvengPayament values (@id, @stuid, @name, @paydate, @month, @year, @tamil, @sinhala, @environment, @maths, @music, @dance, @regfee, @tamilFee, @sinhalaFee, @environmentFee, @mathsfee, @musicfee, @dancefee)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", label5.Text);
                    cmd.Parameters.AddWithValue("@stuid", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@name", label3.Text);
                    cmd.Parameters.AddWithValue("@paydate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@month", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@year", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@tamil", tamil);
                    cmd.Parameters.AddWithValue("@sinhala", sinhala);
                    cmd.Parameters.AddWithValue("@environment", environment);
                    cmd.Parameters.AddWithValue("@maths", maths);
                    cmd.Parameters.AddWithValue("@music", music);
                    cmd.Parameters.AddWithValue("@dance", dance);
                    cmd.Parameters.AddWithValue("@regfee", regFee);
                    cmd.Parameters.AddWithValue("@tamilFee", tamilFee);
                    cmd.Parameters.AddWithValue("@sinhalaFee", sinhalaFee);
                    cmd.Parameters.AddWithValue("@environmentFee", environmentFee);
                    cmd.Parameters.AddWithValue("@mathsfee", mathsFee);
                    cmd.Parameters.AddWithValue("@musicfee", musicFee);
                    cmd.Parameters.AddWithValue("@dancefee", danceFee);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted Successfully!");

                    label3.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Today;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    comboBox3.SelectedIndex = -1;
                }

                using (SqlCommand cmd = new SqlCommand("select top 1 ID from EvengPayament order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "PAYEVC-1111111";
                        label5.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7, 7)) + 1).ToString();
                        ID = "PAYEVC-" + SID;
                        label5.Text = ID;
                    }


                    dr.Close();


                    cmd.CommandText = "Select ID from evengStudent";
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Month='"+comboBox2.Text+"' and Year='"+comboBox3.Text+"'" , conn))
                {
                    CheckSubject();
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            if (dr1.GetString(6) == "Yes" && dr1.GetString(13) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox1.Enabled = false;
                            }
                            if (dr1.GetString(7) == "Yes" && dr1.GetString(14) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox2.Enabled = false;
                            }
                            if (dr1.GetString(8) == "Yes" && dr1.GetString(15) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox3.Enabled = false;
                            }
                            if (dr1.GetString(9) == "Yes" && dr1.GetString(16) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox4.Enabled = false;
                            }
                            if (dr1.GetString(10) == "Yes" && dr1.GetString(17) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox5.Enabled = false;
                            }
                            if (dr1.GetString(11) == "Yes" && dr1.GetString(18) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox6.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        dr1.Close();
                        CheckSubject();
                    }
                    
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from EvengPayament where StudentID = '" + comboBox1.Text + "' and Year='"+comboBox3.Text+"' and Month='"+comboBox2.Text+"'", conn))
                {
                    CheckSubject();
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            if (dr1.GetString(6) == "Yes" && dr1.GetString(13) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox1.Enabled = false;
                            }
                           
                            if (dr1.GetString(7) == "Yes" && dr1.GetString(14) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox2.Enabled = false;
                            }

                            if (dr1.GetString(8) == "Yes" && dr1.GetString(15) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox3.Enabled = false;
                            }
                           
                            if (dr1.GetString(9) == "Yes" && dr1.GetString(16) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox4.Enabled = false;
                            }

                            if (dr1.GetString(10) == "Yes" && dr1.GetString(17) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox5.Enabled = false;
                            }

                            if (dr1.GetString(11) == "Yes" && dr1.GetString(18) != "Not Paid" && dr1.GetString(4) == comboBox2.Text && dr1.GetString(5) == comboBox3.Text)
                            {
                                checkBox6.Enabled = false;
                            }
                           
                        }
                    }
                    else
                    {
                        dr1.Close();
                        CheckSubject();                        
                    }
                }
            }
        }
        public void CheckSubject()
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd2 = new SqlCommand("Select * from evengStudent where ID = '" + comboBox1.Text + "'", conn))
                {
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {

                            if (dr2.GetString(12) == "Yes")
                            {
                                checkBox1.Enabled = true;
                                label15.Text = "Registered";
                                label15.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox1.Enabled = false;
                                label15.Text = "Not Registered";
                                label15.ForeColor = System.Drawing.Color.Blue;
                            }
                            if (dr2.GetString(13) == "Yes")
                            {
                                checkBox2.Enabled = true;
                                label16.Text = "Registered";
                                label16.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox2.Enabled = false;
                                label16.Text = "Not Registered";
                                label16.ForeColor = System.Drawing.Color.Blue;
                            }
                            if (dr2.GetString(14) == "Yes")
                            {
                                checkBox3.Enabled = true;
                                label17.Text = "Registered";
                                label17.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox3.Enabled = false;
                                label17.Text = "Not Registered";
                                label17.ForeColor = System.Drawing.Color.Blue;
                            }
                            if (dr2.GetString(15) == "Yes")
                            {
                                checkBox4.Enabled = true;
                                label18.Text = "Registered";
                                label18.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox4.Enabled = false;
                                label18.Text = "Not Registered";
                                label18.ForeColor = System.Drawing.Color.Blue;
                            }
                            if (dr2.GetString(16) == "Yes")
                            {
                                checkBox5.Enabled = true;
                                label19.Text = "Registered";
                                label19.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox5.Enabled = false;
                                label19.Text = "Not Registered";
                                label19.ForeColor = System.Drawing.Color.Blue;
                            }
                            if (dr2.GetString(17) == "Yes")
                            {
                                checkBox6.Enabled = true;
                                label20.Text = "Registered";
                                label20.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                checkBox6.Enabled = false;
                                label20.Text = "Not Registered";
                                label20.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                    }
                    else
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox4.Enabled = true;
                        checkBox5.Enabled = true;
                        checkBox6.Enabled = true;
                        comboBox2.Enabled = true;
                        comboBox3.Enabled = true;
                        label15.Text = "";
                        label16.Text = "";
                        label17.Text = "";
                        label18.Text = "";
                        label19.Text = "";
                        label20.Text = "";
                    }
                    dr2.Close();
                }
            }
        }
    }
}
