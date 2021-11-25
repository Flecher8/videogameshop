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
    public partial class UpdateDevForm : Form
    {
        UpdateDeveloperFormRealizer realizer;
        public UpdateDevForm()
        {
            InitializeComponent();
        }
        public UpdateDevForm(string developer_company)
        {
            InitializeComponent();
            realizer = new UpdateDeveloperFormRealizer(this, developer_company);
        }

        private void UpdateDevForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.fillTextBoxes(textBox1, textBox2, textBox3);
        }
    }
}
