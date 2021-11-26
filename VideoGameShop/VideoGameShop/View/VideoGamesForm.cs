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

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
