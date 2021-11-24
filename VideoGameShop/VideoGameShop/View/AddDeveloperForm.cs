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
    public partial class AddDeveloperForm : Form
    {
        AddDeveloperFormRealizer realizer;
        public AddDeveloperForm()
        {
            InitializeComponent();
            realizer = new AddDeveloperFormRealizer(this);
        }

        private void AddDeveloperForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.AddDeveloper(textBox1, textBox2, textBox3);
        }
    }
}
