﻿using System;
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
        // Заполение таблицы данными из базы данных
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
        public void DeleteDeveloper(DataGridView table)
        {
            DialogResult result = MessageBox.Show("Удалить выбраных разработчиков?",
                    "Удаление",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < table.SelectedRows.Count; i++)
                {
                    DB.UpdateDataBase($"DELETE FROM Developers " +
                        $"WHERE developer_company='{table.SelectedRows[i].Cells[0].Value.ToString()}'");
                }
            }
        }
        public void CleanTextBoxes(params Control[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].Text = "";
            }
        }
        private string makeSearchLineForCompanyName(Control textBoxCompanyName)
        {
            if(textBoxCompanyName.Text != "")
            {
                return $"LOWER (developer_company) LIKE '%{textBoxCompanyName.Text}%'";
            }
            return "";
        }
        private string makeSearchLineForLocation(Control textBoxLocation)
        {
            if (textBoxLocation.Text != "")
            {
                return $"location='{textBoxLocation.Text}'";
            }
            return "";
        }
        private string makeCriteries(params string[] arr)
        {
            if(arr.Length == 1)
            {
                return arr[0];
            }
            string result = "";
            List<string> list = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "")
                    list.Add(arr[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
                if (i != list.Count - 1)
                    result += " AND ";
            }
            return result;
        }
        // Проверяет не пусты ли элементы и возвращает строку критериев
        private string checkEmptyAndFind(Control[] arr)
        {
            string companyName = makeSearchLineForCompanyName(arr[0]);
            string location = makeSearchLineForLocation(arr[1]);
            if (companyName == location && companyName == "")
            {
                return "";
            }

            return "WHERE " + makeCriteries(companyName, location);
        }
        public void FindDevelopers(DataGridView table, params Control[] arr)
        {
            table.DataSource = DB.GetDataBase("SELECT developer_company AS 'Название компании', " +
                "location AS 'Локация', official_page AS 'Сайт' FROM Developers " 
                + checkEmptyAndFind(arr));
        }
    }
}
