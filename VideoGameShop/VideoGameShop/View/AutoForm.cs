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
    public partial class AutoForm : Form
    {
        AutoFormRealizer realizer;
        public AutoForm()
        {
            InitializeComponent();
            realizer = new AutoFormRealizer(this);
        }

        private void AutoForm_Load(object sender, EventArgs e)
        {
            realizer.getControls(textBox1, textBox2, textBox3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            realizer.clearAllTextBoxes(textBox1, textBox2, textBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizer.TakeNeededGames(dataGridView1);
        }
    }
}
