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
    class AddDeveloperFormRealizer
    {
        protected DataBase DB = new DataBase();
        private AddDeveloperForm form;
        private bool checkDeveloperUniqueness(string company_name)
        {
            DataTable data = DB.GetDataBase($"SELECT * FROM Developers WHERE developer_company='{company_name}'");
            if (data.Rows.Count == 1)
                return false;
            return true;
        }
        public AddDeveloperFormRealizer(AddDeveloperForm form)
        {
            this.form = form;
        }
        public void AddDeveloper(params Control[] arr)
        {
            if(arr[0].Text == "")
            {
                MessageBox.Show("Обязательное поле 'Название компании' не заполнено.");
                return;
            }
            if(!checkDeveloperUniqueness(arr[0].Text))
            {
                MessageBox.Show("Компания с таким названием уже есть в базе данных.");
                return;
            }

            DB.UpdateDataBase($"INSERT INTO Developers (developer_company, location, official_page) " +
                $"VALUES ('{arr[0].Text}','{arr[1].Text}','{arr[2].Text}')");

            MessageBox.Show("Данные были успешно добавлены.");

            form.Close();
        }
    }
}
