using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace VideoGameShop
{
    class SQLEditorFormRealizer
    {
        protected DataBase DB = new DataBase();
        protected Form form;

        public SQLEditorFormRealizer(Form form)
        {
            this.form = form;
        }
        public void clearTextbox(Control textBox)
        {
            textBox.Text = "SELECT";
        }
        protected bool checkSELECTFirst(string text)
        {
            string first6Char = Convert.ToString(text[0].ToString() + text[1].ToString() + text[2].ToString() + text[3].ToString() + text[4].ToString() + text[5].ToString());

            if (first6Char != "SELECT")
            {
                return false;
            }
            return true;
        }
        public void makeSQLCommand(Control textBox, DataGridView table)
        {
            if(!checkSELECTFirst(textBox.Text))
            {
                MessageBox.Show("Первые 6 символом должны быть 'SELECT'. Пожалуйста повторите попытку.");
                return;
            }
            table.DataSource = DB.GetDataBase(textBox.Text);
        }
    }
}
