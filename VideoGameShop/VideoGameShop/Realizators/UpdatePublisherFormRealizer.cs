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
    class UpdatePublisherFormRealizer
    {
        DataBase DB = new DataBase();
        UpdatePublisherForm form;
        private string publisherCompany;
        private bool checkDeveloperUniqueness(string company_name)
        {
            // Такой разработчик есть, но название не изменилось у меняемого разработчика
            if (company_name == publisherCompany)
                return true;

            DataTable data = DB.GetDataBase($"SELECT * FROM Publishers WHERE publisher_company='{company_name}'");
            if (data.Rows.Count == 1)
                return false;
            return true;
        }
        private bool UserAgreeToUpdateDeveloper()
        {
            DialogResult result = MessageBox.Show("Изменить данные о публикаторах?",
                    "Изменение данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public UpdatePublisherFormRealizer(UpdatePublisherForm form, string publisher_company)
        {
            this.form = form;
            this.publisherCompany = publisher_company;
        }
        public DataTable getPublisher()
        {
            return DB.GetDataBase($"SELECT * FROM Publishers WHERE publisher_company='{publisherCompany}'");
        }
        public void fillTextBoxes(params Control[] arr)
        {
            DataTable table = getPublisher();
            arr[0].Text = table.Rows[0].Field<string>("publisher_company");
            arr[1].Text = table.Rows[0].Field<string>("location");
            arr[2].Text = table.Rows[0].Field<string>("official_page");
        }
        public void UpdatePublisher(params Control[] arr)
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
            if (UserAgreeToUpdateDeveloper())
            {
                DB.UpdateDataBase($"UPDATE Publishers SET publisher_company='{arr[0].Text}', " +
                $"location='{arr[1].Text}', official_page='{arr[2].Text}' WHERE publisher_company='{publisherCompany}'");
            }
            form.Close();
        }
    }
}
