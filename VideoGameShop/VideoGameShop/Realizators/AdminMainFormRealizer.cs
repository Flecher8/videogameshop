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
    class AdminMainFormRealizer
    {
        private DataBase DB = new DataBase();
        private Form form;
        public AdminMainFormRealizer(AdminMainForm form)
        {
            this.form = form;
        }
        public void OpenDevelopersForm()
        {
            DevelopersForm developersMainForm = new DevelopersForm();
            form.Hide();
            developersMainForm.ShowDialog();
            form.Show();
        }
    }
}
