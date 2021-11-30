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
    public partial class AdminMainForm : Form
    {
        AdminMainFormRealizer realizer;
        public AdminMainForm()
        {
            InitializeComponent();
            realizer = new AdminMainFormRealizer(this);
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonDevelopers_Click(object sender, EventArgs e)
        {
            realizer.OpenDevelopersForm();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenAboutForm();
        }

        private void sQLЗапросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenSQLEditorForm();
        }

        private void buttonPublishers_Click(object sender, EventArgs e)
        {
            realizer.OpenPublishersForm();
        }

        private void buttonVideoGames_Click(object sender, EventArgs e)
        {
            realizer.OpenVideoGamesForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            realizer.fullWord();
        }

        private void tOP10ЛучшихToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tOP10НаболееПродаваемыеКомпьютерныеИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenStatisticForm(1);
        }

        private void tOP10ЛучшихКомпьютерныхИгрПоМнениюКритиковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenStatisticForm(2);
        }

        private void tOP10ЛучшихКомпьютерныхИгрПоМнениюПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenStatisticForm(3);
        }

        private void tOP10СамыхДорогихКомпьютерныхИгрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realizer.OpenStatisticForm(4);
        }
    }
}
