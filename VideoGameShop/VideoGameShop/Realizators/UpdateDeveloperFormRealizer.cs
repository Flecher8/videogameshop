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
    class UpdateDeveloperFormRealizer
    {
        DataBase DB = new DataBase();
        UpdateDevForm form;
        private string developer_company;

        private bool checkDeveloperUniqueness(string company_name)
        {
            // Такой разработчик есть, но название не изменилось у меняемого разработчика
            if (company_name == developer_company)
                return true;
            
            DataTable data = DB.GetDataBase($"SELECT * FROM Developers WHERE developer_company='{company_name}'");
            if (data.Rows.Count == 1)
                return false;
            return true;
        }
        private bool UserAgreeToUpdateDeveloper()
        {
            DialogResult result = MessageBox.Show("Изменить данные о разработчике?",
                    "Изменение данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public UpdateDeveloperFormRealizer(UpdateDevForm form, string developer_company)
        {
            this.form = form;
            this.developer_company = developer_company;
        }
        public DataTable getDeveloper()
        {
            return DB.GetDataBase($"SELECT * FROM Developers WHERE developer_company='{developer_company}'");
        }
        public void fillTextBoxes(params Control[] arr)
        {
            DataTable table = getDeveloper();
            arr[0].Text = table.Rows[0].Field<string>("developer_company");
            arr[1].Text = table.Rows[0].Field<string>("location");
            arr[2].Text = table.Rows[0].Field<string>("official_page");
        }
        public void UpdateDeveloper(params Control[] arr)
        {
            if (arr[0].Text == "")
            {
                MessageBox.Show("Обязательное поле 'Название компании' не заполнено.");
                return;
            }
            if (!checkDeveloperUniqueness(arr[0].Text))
            {
                MessageBox.Show("Компания с таким названием уже есть в базе данных.");
                return;
            }
            if(UserAgreeToUpdateDeveloper())
            {
                DB.UpdateDataBase($"UPDATE Developers SET developer_company='{arr[0].Text}', " +
                $"location='{arr[1].Text}', official_page='{arr[2].Text}' WHERE developer_company='{developer_company}'");
            }
            form.Close();
        }
    }
}
