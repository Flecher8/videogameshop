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
    class AddGameFormRealizer
    {
        protected DataBase DB = new DataBase();
        protected Form form;

        protected List<CheckBox> checkBoxes = new List<CheckBox>();
        protected List<Control> controls = new List<Control>();
        protected ComboBox developersComboBox;
        protected ComboBox publishersComboBox;

        protected virtual bool checkGameUniqueness(string gameName)
        {
            DataTable data = DB.GetDataBase($"SELECT * FROM Games WHERE game_name='{gameName}'");
            if (data.Rows.Count == 1)
                return false;
            return true;
        }
        public AddGameFormRealizer(Form form)
        {
            this.form = form;
        }

        public void getControls(params Control[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                controls.Add(arr[i]);
            }
        }
        public void getCheckBoxes(params CheckBox[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                checkBoxes.Add(arr[i]);
            }
        }
        public void getComboBoxes(params ComboBox[] arr)
        {
            developersComboBox = arr[0];
            publishersComboBox = arr[1];
        }
        public void fillComboBoxes()
        {
            fillComboBoxDevelopers();
            fillComboBoxesPublishers();
        }
        // Выводиться ошибка о том, что в базе данных нету либо разработчиков либо публикаторов и закрывается форма
        protected void errorNoDeveloperORPublisher()
        {
            MessageBox.Show("Извините, но данная форма будет закрыта т.к. " +
                    "невозможно создать разботчиков если у вас в базе даных нету разработчиков/публикаторов, " +
                    "пожалуйста проверьте, чтобы хотя бы один разработчик и публикатор был в базе данных!");
            form.Close();
        }
        protected void fillComboBoxesPublishers()
        {
            DataTable table = DB.GetDataBase("SELECT publisher_company FROM Publishers");
            if (table.Rows.Count == 0)
            {
                errorNoDeveloperORPublisher();
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                publishersComboBox.Items.Add(table.Rows[i].Field<string>("publisher_company"));
            }
        }
        protected void fillComboBoxDevelopers()
        {
            DataTable table = DB.GetDataBase("SELECT developer_company FROM Developers");
            if(table.Rows.Count == 0)
            {
                errorNoDeveloperORPublisher();
            }
            for(int i = 0; i < table.Rows.Count; i++)
            {
                developersComboBox.Items.Add(table.Rows[i].Field<string>("developer_company"));
            }
        }
        // Проверка все ли нужные поля заполнены чем-то
        protected bool allNeededDataFull()
        {
            if(controls[0].Text != "" && 
                developersComboBox.Text != "" &&
                publishersComboBox.Text != "" &&
                controls[3].Text != "" &&
                controls[4].Text != "" &&
                controls[5].Text != "" &&
                controls[6].Text != "" &&
                controls[7].Text != "" &&
                controls[4].Text != "" &&
                controls[10].Text != "")
            {
                return true;
            }
            return false;
        }
        protected string errorAllDataCorrect()
        {
            string error = "";
            // Проверка правильно ли заполнено поле год выхода
            if (controls[1].Text != "")
            {
                string e = "";
                e = isCorrectNumber(1950, 2021, controls[1]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Год выхода' " + e + "\n";
                }
            }
            // Проверка выбран ли хотя бы один жанр
            if(!oneGenreSelected())
            {
                error += "\n Не выбран ни один из жанров \n";
            }
            if(!minCPURight())
            {
                error += "\n Процессора с таким название нету в базе данных.\n";
            }
            if(!minVideocardRight())
            {
                error += "\n Видеокарты с таким название нету в базе данных.\n";
            }
            // Проверка правильно ли заполнено поле оценка критиков
            if (controls[3].Text != "")
            {
                string e = "";
                e = isCorrectNumber(0, 10, controls[3]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Оценка критиков' " + e + "\n";
                }
            }

            // Проверка правильно ли заполнено поле Количество ОП
            if (controls[6].Text != "")
            {
                string e = "";
                e = isCorrectNumber(1, 10000000, controls[6]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Количество ОП' " + e + "\n";
                }
            }
            // Проверка правильно ли заполнено поле Цена
            if (controls[7].Text != "")
            {
                string e = "";
                e = isCorrectNumber(1, 10000000, controls[7]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Цена' " + e + "\n";
                }
            }
            // Проверка правильно ли заполнено поле Возрастное ограничение
            if (controls[8].Text != "")
            {
                string e = "";
                e = isCorrectNumber(0, 100, controls[8]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Возрастное ограничение' " + e + "\n";
                }
            }
            // Проверка правильно ли заполнено поле Количество игр на складе
            if (controls[10].Text != "")
            {
                string e = "";
                e = isCorrectNumber(1, 10000000, controls[10]);
                if (e != "")
                {
                    error += "\n Данные в поле 'Количество игр на складе' " + e + "\n";
                }
            }
            return error;
        }
        protected bool oneGenreSelected()
        {
            for(int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                    return true;
            }
            return false;
        }
        protected bool minCPURight()
        {
            string cpuName = controls[4].Text;
            DataTable table = DB.GetDataBase($"SELECT cpu_name FROM CPUs WHERE cpu_name='{cpuName}'");
            if (table.Rows.Count > 0)
                return true;
            return false;
        }
        protected bool minVideocardRight()
        {
            string videocardName = controls[5].Text;
            DataTable table = DB.GetDataBase($"SELECT videocard_name FROM Videocards WHERE videocard_name='{videocardName}'");
            if (table.Rows.Count > 0)
                return true;
            return false;
        }
        protected string isCorrectNumber(int leftLimit, int rightLimit, Control control)
        {
            int? number = tryParseInt32(control.Text);
            if (number == null)
            {
                return "не являються целым числом";
            }
            if (number < leftLimit || number > rightLimit)
            {
                return $"меньше {leftLimit} или больше {rightLimit}";
            }
            return "";
        }

        protected int? tryParseInt32(string text)
        {
            if (Int32.TryParse(text, out int n))
            {
                return n;
            }
            else
            {
                return null;
            }
        }

        public void AddGame()
        {
            // Проверяеться чтобы все поля нужные были заполены
            if(!allNeededDataFull())
            {
                MessageBox.Show("Не все необходимые поля заполнены");
                return;
            }
            // Проверка правильности заполения данных

            string error = errorAllDataCorrect();
            if(error != "")
            {
                MessageBox.Show(error);
                return;
            }
            // Проверяеться уникальность имени
            if (!checkGameUniqueness(controls[0].Text))
            {
                MessageBox.Show("Игра с таким названием уже есть в базе данных.");
                return;
            }


            // Добавлена запись в таблицу Games
            DB.UpdateDataBase($"INSERT INTO Games " +
                $"(game_name, developer_company, publisher_company, release_year, " +
                $"game_description, critics_score, cpu_name, videocard_name, ram_amount, " +
                $"price, age_limit, official_page) " +
                $"VALUES ('{controls[0].Text}','{developersComboBox.SelectedItem.ToString()}'," +
                $"'{publishersComboBox.SelectedItem.ToString()}','{controls[1].Text}','{controls[2].Text}'," +
                $"'{controls[3].Text}','{controls[4].Text}','{controls[5].Text}','{controls[6].Text}'," +
                $"'{controls[7].Text}','{controls[8].Text}','{controls[9].Text}')");

            // Добавлена запись в таблицу Games-Genres
            List<string> genres = new List<string>();
            for(int i = 0; i < checkBoxes.Count; i++)
            {
                if(checkBoxes[i].Checked)
                {
                    genres.Add(checkBoxes[i].Text);
                }
            }
            for(int i = 0; i < genres.Count; i++)
            {
                DB.UpdateDataBase($"INSERT INTO [Games-Genres] (game_name, genre_name) VALUES ('{controls[0].Text}','{genres[i]}')");
            }

            // Добавлена запись в таблицу Products
            DataTable table = DB.GetDataBase("SELECT * FROM Storage");
            if(table.Rows.Count == 0)
            {
                DB.UpdateDataBase($"INSERT INTO Storage (product_id, game_name, amount) " +
                    $"VALUES ('1', '{controls[0].Text}', '{controls[10].Text}')");
            }
            else
            {
                DataTable table1 = DB.GetDataBase("SELECT MAX(product_id) AS MAX_PRODUCT_ID FROM Storage");
                DB.UpdateDataBase($"INSERT INTO Storage (product_id, game_name, amount) " +
                    $"VALUES ('{table1.Rows[0].Field<int>("MAX_PRODUCT_ID") + 1}', '{controls[0].Text}', '{controls[10].Text}')");
            }
            


            MessageBox.Show("Данные были успешно добавлены.");

            form.Close();
        }
    }
}
