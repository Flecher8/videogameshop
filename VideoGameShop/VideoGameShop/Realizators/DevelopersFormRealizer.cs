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
    class DevelopersFormRealizer
    {
        DataBase DB = new DataBase();
        private DevelopersForm form;
        public DevelopersFormRealizer(DevelopersForm form)
        {
            this.form = form;
        }
        public void UpdateDataGridView(DataGridView table)
        {
            table.DataSource = DB.GetDataBase("SELECT developer_company AS 'Название компании', location AS 'Локация', official_page AS 'Сайт' FROM Developers");
        }
        public void OpenAddDeveloperForm()
        {
            AddDeveloperForm addDeveloperForm = new AddDeveloperForm();
            form.Hide();
            addDeveloperForm.ShowDialog();
            form.Show();
        }
        public void OpenUpdateDeveloperForm(DataGridView table)
        {
            int numberOfSelectedRows = table.SelectedRows.Count;
            if (numberOfSelectedRows > 1)
            {
                DialogResult result = MessageBox.Show("Выберите только одну строку из таблицы.",
                    "Выбор строк",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            UpdateDevForm updateDeveloperForm = 
                new UpdateDevForm(table.SelectedRows[0].Cells[0].Value.ToString());
            form.Hide();
            updateDeveloperForm.ShowDialog();
            form.Show();
        }
    }
}
