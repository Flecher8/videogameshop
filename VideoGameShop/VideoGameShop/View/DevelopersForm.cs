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

        }
    }
}
