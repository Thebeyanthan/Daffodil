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
    public partial class Form8 : Form
    {
        int termcount = 0;
        int feecount = 0;
        string ID;
        string term1, term2, term3, regFee, bookFee, other;
        string term1Fee = "Not Paid";
        string term2Fee = "Not Paid";
        string term3Fee = "Not Paid";
        
        public Form8()
        {
            InitializeComponent();
            comboBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            checkBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            checkBox7.Enabled = true;

            term1 = "No";
            term2 = "No";
            term3 = "No";

            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select top 1 ID from LKGpayment order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {
                        ID = "PAYLKG-1111111";
                        label6.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7,7)) + 1).ToString();
                        ID = "PAYLKG-" + SID;
                        label6.Text = ID;
                    }


                    dr.Close();


                    cmd.CommandText = "Select ID from student";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.Enabled = true;
                feecount++;
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "";
                feecount--;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox4.Enabled = true;
                feecount++;
            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "";
                feecount--;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox5.Enabled = true;
                feecount++;
            }
            else
            {
                textBox5.Enabled = false;
                textBox5.Text = "";
                feecount--;
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'daffodilDataSet7.LKGpayment' table. You can move, or remove it, as needed.
            this.lKGpaymentTableAdapter.Fill(this.daffodilDataSet7.LKGpayment);
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked || checkBox6.Checked || checkBox7.Checked)
            {
                checkBox1.Enabled = true;
                termcount++;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                textBox2.Enabled = false;
                textBox2.Text = "";
                termcount--;

                string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {

                                if (dr1.GetString(4) == "Yes")
                                {
                                    checkBox5.Enabled = false;
                                    term1 = "Yes";
                                }
                                else
                                {
                                    checkBox5.Enabled = true;
                                }
                                if (dr1.GetString(5) == "Yes")
                                {
                                    checkBox6.Enabled = false;
                                    term2 = "Yes";
                                }
                                else
                                {
                                    checkBox6.Enabled = true;
                                }
                                if (dr1.GetString(6) == "Yes")
                                {
                                    checkBox7.Enabled = false;
                                    term3 = "Yes";
                                }
                                else
                                {
                                    checkBox7.Enabled = true;
                                }


                            }
                        }
                        else
                        {
                            checkBox5.Enabled = true;
                            checkBox6.Enabled = true;
                            checkBox7.Enabled = true;
                        }
                        dr1.Close();

                    }
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked || checkBox6.Checked || checkBox7.Checked)
            {
                checkBox1.Enabled = true;
                termcount++;
                checkBox5.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                textBox2.Enabled = false;
                textBox2.Text = "";
                termcount--;

                string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {

                                if (dr1.GetString(4) == "Yes")
                                {
                                    checkBox5.Enabled = false;
                                    term1 = "Yes";
                                }
                                else
                                {
                                    checkBox5.Enabled = true;
                                }
                                if (dr1.GetString(5) == "Yes")
                                {
                                    checkBox6.Enabled = false;
                                    term2 = "Yes";
                                }
                                else
                                {
                                    checkBox6.Enabled = true;
                                }
                                if (dr1.GetString(6) == "Yes")
                                {
                                    checkBox7.Enabled = false;
                                    term3 = "Yes";
                                }
                                else
                                {
                                    checkBox7.Enabled = true;
                                }


                            }
                        }
                        else
                        {
                            checkBox5.Enabled = true;
                            checkBox6.Enabled = true;
                            checkBox7.Enabled = true;
                        }
                        dr1.Close();

                    }
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked || checkBox6.Checked || checkBox7.Checked)
            {
                checkBox1.Enabled = true;
                termcount++;
                checkBox6.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                textBox2.Enabled = false;
                textBox2.Text = "";
                termcount--;

                string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {

                                if (dr1.GetString(4) == "Yes")
                                {
                                    checkBox5.Enabled = false;
                                    term1 = "Yes";
                                }
                                else
                                {
                                    checkBox5.Enabled = true;
                                }
                                if (dr1.GetString(5) == "Yes")
                                {
                                    checkBox6.Enabled = false;
                                    term2 = "Yes";
                                }
                                else
                                {
                                    checkBox6.Enabled = true;
                                }
                                if (dr1.GetString(6) == "Yes")
                                {
                                    checkBox7.Enabled = false;
                                    term3 = "Yes";
                                }
                                else
                                {
                                    checkBox7.Enabled = true;
                                }


                            }
                        }
                        else
                        {
                            checkBox5.Enabled = true;
                            checkBox6.Enabled = true;
                            checkBox7.Enabled = true;
                        }
                        dr1.Close();

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            label3.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Check Student ID!");
            }
            else if (termcount > 0)
            {
                if ((checkBox1.Checked && textBox2.Text != "") && feecount == 0)
                {                    
                    insertData();
                }
                else if ((checkBox1.Checked && textBox2.Text != "") && feecount > 0)
                {
                    checkFeecount();
                }
                else
                {
                    MessageBox.Show("Check All Values!");
                }
            }
            else
            {
                checkFeecount();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from student where ID = '" + comboBox1.Text + "'", conn))
                {
                    cmd.Connection = conn;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        label3.Text = dr.GetString(1);

                    }
                    dr.Close();


                }
                using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {

                            if (dr1.GetString(4) == "Yes")
                            {
                                checkBox5.Enabled = false;
                                term1 = "Yes";
                            }
                            else
                            {
                                checkBox5.Enabled = true;
                            }
                            if (dr1.GetString(5) == "Yes")
                            {
                                checkBox6.Enabled = false;
                                term2 = "Yes";
                            }
                            else
                            {
                                checkBox6.Enabled = true;
                            }
                            if (dr1.GetString(6) == "Yes")
                            {
                                checkBox7.Enabled = false;
                                term3 = "Yes";
                            }
                            else
                            {
                                checkBox7.Enabled = true;
                            }


                        }
                    }
                    else
                    {
                        checkBox5.Enabled = true;
                        checkBox6.Enabled = true;
                        checkBox7.Enabled = true;
                    }
                    dr1.Close();

                }
                using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {

                        while (dr1.Read())
                        {
                            if (dr1.GetString(10) == "Not Paid")
                            {
                                checkBox3.Enabled = true;
                                regFee = "Not Paid";
                            }
                            else
                            {
                                checkBox3.Enabled = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        checkBox3.Enabled = true;
                    }
                    dr1.Close();
                }

            }
        }
        public void checkFeecount()
        {
            if (feecount == 1)
            {
                if (checkBox2.Checked && textBox3.Text != "")
                {                    
                    insertData();
                }
                else if (checkBox3.Checked && textBox4.Text != "")
                {                    
                   insertData();
                }
                else if (checkBox4.Checked && textBox5.Text != "")
                {                   
                    insertData();
                }
                else
                {
                    MessageBox.Show("Check All Values!");
                }
            }
            else if (feecount == 2)
            {
                if ((checkBox2.Checked && textBox3.Text != "") && (checkBox3.Checked && textBox4.Text != ""))
                {                    
                    insertData();
                }
                else if ((checkBox2.Checked && textBox3.Text != "") && (checkBox4.Checked && textBox5.Text != ""))
                {                    
                    insertData();
                }
                else if ((checkBox3.Checked && textBox4.Text != "") && (checkBox4.Checked && textBox5.Text != ""))
                {                    
                    insertData();
                }
                else
                {
                    MessageBox.Show("Check All the Values!");
                }
            }
            else if (feecount == 3)
            {
                if ((checkBox2.Checked && textBox3.Text != "") && (checkBox3.Checked && textBox4.Text != "") && (checkBox4.Checked && textBox5.Text != ""))
                {                    
                    insertData();
                }
                else
                {
                    MessageBox.Show("Check All the Values!");
                }
            }
            else
            {
                MessageBox.Show("Check All Values!");
            }
        }
        public void insertData()
        {
            string connectionstring = "server=DESKTOP-GHBVM6U; Database=Daffodil; Integrated security=true";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                if (checkBox5.Checked)
                {
                    term1 = "Yes";                   
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(7) == "Yes")
                                {
                                    checkBox3.Enabled = false;
                                    term1Fee = dr1.GetString(7);

                                    break;
                                }
                            }
                        }
                        else
                        {
                            term1Fee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox6.Checked)
                {
                    term2 = "Yes";
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(8) == "Yes")
                                {
                                    checkBox3.Enabled = false;
                                    term2Fee = dr1.GetString(8);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            term2Fee = "Not Paid";
                        }
                        dr1.Close();
                    }
                }
                if (checkBox7.Checked)
                {
                    term3 = "Yes";
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(9) == "Yes")
                                {
                                    checkBox3.Enabled = false;
                                    term3Fee = dr1.GetString(9);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            term3Fee = "Not Paid";
                        }
                        dr1.Close();
                    } 
                }
                if (checkBox1.Checked && checkBox5.Checked)
                {
                    term1Fee = textBox2.Text;

                }
                else if (checkBox1.Checked && checkBox6.Checked)
                {
                    term2Fee = textBox2.Text;

                }
                else if (checkBox1.Checked && checkBox7.Checked)
                {
                    term3Fee = textBox2.Text;
                }
                if (checkBox2.Checked)
                {
                    bookFee = textBox3.Text;
                }
                else
                {
                    bookFee = "";
                }
                if (checkBox3.Checked)
                {
                    regFee = textBox4.Text;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from LKGpayment where StudentID = '" + comboBox1.Text + "'", conn))
                    {
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                if (dr1.GetString(10) != "Not Paid")
                                {
                                    checkBox3.Enabled = false;
                                    regFee = dr1.GetString(10);
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
                if (checkBox4.Checked)
                {
                    other = textBox5.Text;
                }
                else
                {
                    other = "";
                }
                using (SqlCommand cmd = new SqlCommand("insert into LKGpayment values (@id, @stuid, @name, @paydate, @term1, @term2, @term3, @term1Fee, @term2Fee, @term3Fee, @regfee, @bookfee, @other)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", label6.Text);
                    cmd.Parameters.AddWithValue("@stuid", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@name", label3.Text);
                    cmd.Parameters.AddWithValue("@paydate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@term1", term1);
                    cmd.Parameters.AddWithValue("@term2", term2);
                    cmd.Parameters.AddWithValue("@term3", term3);
                    cmd.Parameters.AddWithValue("@term1Fee", term1Fee);
                    cmd.Parameters.AddWithValue("@term2Fee", term2Fee);
                    cmd.Parameters.AddWithValue("@term3Fee", term3Fee);
                    cmd.Parameters.AddWithValue("@regfee", regFee);
                    cmd.Parameters.AddWithValue("@bookfee", bookFee);
                    cmd.Parameters.AddWithValue("@other", other);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted Successfully!");

                    comboBox1.SelectedIndex = -1;
                    label3.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    dateTimePicker1.Value = DateTime.Today;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                using (SqlCommand cmd = new SqlCommand("select top 1 ID from LKGpayment order by ID desc", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                        ID = dr.GetString(0);

                    if (ID == null)
                    {  
                        ID = "PAYLKG-1111111";
                        label6.Text = ID;
                    }

                    else
                    {
                        string SID = (int.Parse(ID.Substring(7,7)) + 1).ToString();
                        ID = "PAYLKG-"+SID;
                        label6.Text = ID;
                    }
                    dr.Close();


                    cmd.CommandText = "Select ID from student";
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
    }
}
