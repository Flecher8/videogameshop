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
    public partial class SQLEditorForm : Form
    {
        SQLEditorFormRealizer realizer;
        public SQLEditorForm()
        {
            InitializeComponent();
            realizer = new SQLEditorFormRealizer(this);
        }

        private void SQLEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizer.makeSQLCommand(richTextBox1, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.clearTextbox(richTextBox1);
        }
    }
}
