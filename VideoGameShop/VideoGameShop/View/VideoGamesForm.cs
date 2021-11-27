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
    public partial class VideoGamesForm : Form
    {
        VideoGamesFormRealizer realizer;
        public VideoGamesForm()
        {
            InitializeComponent();
            realizer = new VideoGamesFormRealizer(this);
        }

        private void VideoGamesForm_Load(object sender, EventArgs e)
        {
            realizer.getControls(textBox1, textBox2, textBox3, textBox6, textBox7);
            realizer.getCheckBoxes(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, 
                checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12,
                checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.OpenAddGameForm();
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            realizer.OpenUpdateGameForm(dataGridView1);
            realizer.UpdateDataGridView(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            realizer.DeleteGame(dataGridView1);
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
    }
}
