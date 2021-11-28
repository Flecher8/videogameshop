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
    public partial class CardForm : Form
    {
        CardFormRealizer realizer;
        public CardForm(User user, string gameName)
        {
            InitializeComponent();
            realizer = new CardFormRealizer(this, user, gameName);

        }

        private void CardForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //realizer.createWordFile();
            realizer.BuyGame(textBox1.Text, textBox2.Text);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Товарный чек", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(185, 10));
        }
    }
}
