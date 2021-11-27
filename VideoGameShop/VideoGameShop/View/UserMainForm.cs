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
    public partial class UserMainForm : Form
    {
        UserMainFormRealizer realizer;
        public UserMainForm(User user)
        {
            InitializeComponent();
            realizer = new UserMainFormRealizer(this, user);
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            realizer.getControls(textBox1, textBox2, textBox3, textBox6, textBox7);
            realizer.getCheckBoxes(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5,
                checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12,
                checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            realizer.clearAllTextBoxes(textBox1, textBox2, textBox3, textBox6, textBox7);
            realizer.clearAllCheckBoxes(checkBox1, checkBox10, checkBox11, checkBox12,
                checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18,
                checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9);

            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizer.findGames(dataGridView1);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            realizer.OpenBuyGameForm(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
