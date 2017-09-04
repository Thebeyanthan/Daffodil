using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daffodil
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void montessoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.MdiParent = this;
            f4.Show();
        }

        private void eveningClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.MdiParent = this;
            f5.Show();
        }

        private void montessoriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void eveningClassesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.MdiParent = this;
            f6.Show();
        }

        private void eveningClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.MdiParent = this;
            f7.Show();
        }

        private void lKGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.MdiParent = this;
            f8.Show();
        }

        private void uKGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.MdiParent = this;
            f9.Show();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.MdiParent = this;
            f10.Show();
        }
    }
}
