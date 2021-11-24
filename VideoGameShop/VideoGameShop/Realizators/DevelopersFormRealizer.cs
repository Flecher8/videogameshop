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
    }
}
