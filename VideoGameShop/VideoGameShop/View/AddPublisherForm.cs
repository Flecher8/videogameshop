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
    public partial class AddPublisherForm : Form
    {
        AddPublisherFormRealizer realizer;
        public AddPublisherForm()
        {
            InitializeComponent();
            realizer = new AddPublisherFormRealizer(this);
        }

        private void AddPublisherForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.AddPublisher(textBox1, textBox2, textBox3);
        }
    }
}
