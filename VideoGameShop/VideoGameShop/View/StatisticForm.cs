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
    public partial class StatisticForm : Form
    {
        StatisticFormRealizer realizer;
        public StatisticForm(int number)
        {
            InitializeComponent();
            realizer = new StatisticFormRealizer(this, number);
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            realizer.LoadData(label1, dataGridView1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
