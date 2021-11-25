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
    public partial class UpdatePublisherForm : Form
    {
        UpdatePublisherFormRealizer realizer;
        public UpdatePublisherForm()
        {
            InitializeComponent();
        }
        public UpdatePublisherForm(string publisher_company)
        {
            InitializeComponent();
            realizer = new UpdatePublisherFormRealizer(this, publisher_company);
        }

        private void UpdatePublisherForm_Load(object sender, EventArgs e)
        {
            realizer.fillTextBoxes(textBox1, textBox2, textBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.UpdatePublisher(textBox1, textBox2, textBox3);
        }
    }
}
