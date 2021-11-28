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
    public partial class BuyGameForm : Form
    {
        BuyGameFormRealizer realizer;
        public BuyGameForm(User user, string gameName)
        {
            InitializeComponent();
            realizer = new BuyGameFormRealizer(this, user, gameName);
        }

        private void BuyGameForm_Load(object sender, EventArgs e)
        {
            realizer.getLabels(label16, label17, label18, label19, label20, label21, label22, label23,
                label24, label27, label25, label26);

            realizer.fillLabels();
            realizer.checkIfHideMark(label14, label15, textBox1, button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizer.makeMarkByUser(textBox1, label14, label15, textBox1, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.OpenCardForm();
        }
    }
}
