using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGameShop
{
    public partial class DevelopersForm : Form
    {
        DevelopersFormRealizer realizer;
        public DevelopersForm()
        {
            InitializeComponent();
            realizer = new DevelopersFormRealizer(this);
        }

        private void DevelopersForm_Load(object sender, EventArgs e)
        {
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.OpenAddDeveloperForm();
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            realizer.OpenUpdateDeveloperForm(dataGridView1);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            realizer.DeleteDeveloper(dataGridView1);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            realizer.CleanTextBoxes(textBox1, textBox2);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizer.FindDevelopers(dataGridView1, textBox1, textBox2);
        }
    }
}
