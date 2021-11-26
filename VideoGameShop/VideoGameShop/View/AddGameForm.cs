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
    public partial class AddGameForm : Form
    {
        AddGameFormRealizer realizer;
        public AddGameForm()
        {
            InitializeComponent();
            realizer = new AddGameFormRealizer(this);
        }

        private void AddGameForm_Load(object sender, EventArgs e)
        {
            realizer.getControls(textBox1, textBox2, richTextBox1, textBox3,
                textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10);

            realizer.getCheckBoxes(checkBox1, checkBox2, checkBox3, checkBox4,
                checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16);

            realizer.getComboBoxes(comboBox1, comboBox2);


            realizer.fillComboBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.AddGame();
        }
    }
}
