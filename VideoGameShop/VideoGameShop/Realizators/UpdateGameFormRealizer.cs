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
    class UpdateGameFormRealizer : AddGameFormRealizer
    {
        protected string GameName;
        protected override bool checkGameUniqueness(string gameName)
        {
            // Такая игра есть, но название не изменилось у меняемой игры
            if (GameName == gameName)
                return true;

            DataTable data = DB.GetDataBase($"SELECT * FROM Games WHERE game_name='{gameName}'");
            if (data.Rows.Count == 1)
                return false;
            return true;
        }
        public UpdateGameFormRealizer(Form form, string gameName) : base(form)
        {
            this.form = form;
            this.GameName = gameName;
        }
        public void fillFields()
        {
            // Добавить заполнение полей
            DataTable game = DB.GetDataBase($"SELECT * FROM Games WHERE game_name='{GameName}'");
            controls[0].Text = game.Rows[0].Field<string>("game_name");
            controls[1].Text = game.Rows[0].Field<int>("release_year").ToString();
            controls[2].Text = game.Rows[0].Field<string>("game_description");
            controls[3].Text = game.Rows[0].Field<int>("critics_score").ToString();
            controls[4].Text = game.Rows[0].Field<string>("cpu_name");
            controls[5].Text = game.Rows[0].Field<string>("videocard_name");
            controls[6].Text = game.Rows[0].Field<int>("ram_amount").ToString();
            controls[7].Text = game.Rows[0].Field<int>("price").ToString();
            controls[8].Text = game.Rows[0].Field<int>("age_limit").ToString();
            controls[9].Text = game.Rows[0].Field<string>("official_page");

            // Разработчик и публикатор
            developersComboBox.SelectedIndex = developersComboBox.Items.IndexOf($"{game.Rows[0].Field<string>("developer_company")}");
            publishersComboBox.SelectedIndex = publishersComboBox.Items.IndexOf($"{game.Rows[0].Field<string>("publisher_company")}");
            
            //Количество игр на складе
            DataTable amountOfGameOnStorage = DB.GetDataBase($"SELECT amount FROM Storage WHERE game_name='{GameName}'");
            controls[10].Text = amountOfGameOnStorage.Rows[0].Field<int>("amount").ToString();

            // Заполение жанров
            DataTable genres = DB.GetDataBase($"SELECT genre_name FROM [Games-Genres] WHERE game_name='{GameName}'");
            for(int i = 0; i < checkBoxes.Count; i++)
            {
                for(int j = 0; j < genres.Rows.Count; j++)
                {
                    if(checkBoxes[i].Text == genres.Rows[j]["genre_name"].ToString())
                    {
                        checkBoxes[i].CheckState = CheckState.Checked;
                    }
                }
            }
        }
        public void UpdateGame()
        {
            // Проверяеться чтобы все поля нужные были заполены
            if (!allNeededDataFull())
            {
                MessageBox.Show("Не все необходимые поля заполнены");
                return;
            }
            // Проверка правильности заполения данных

            string error = errorAllDataCorrect();
            if (error != "")
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


            // Обновить запись в таблице Games
            DB.UpdateDataBase($"UPDATE Games SET game_name='{controls[0].Text}', " +
                $"developer_company='{developersComboBox.SelectedItem.ToString()}', " +
                $"publisher_company='{publishersComboBox.SelectedItem.ToString()}', " +
                $"release_year='{controls[1].Text}', " +
                $"game_description='{controls[2].Text}', " +
                $"critics_score='{controls[3].Text}', " +
                $"cpu_name='{controls[4].Text}', " +
                $"videocard_name='{controls[5].Text}', " +
                $"ram_amount='{controls[6].Text}', " +
                $"price='{controls[7].Text}', " +
                $"age_limit='{controls[8].Text}', " +
                $"official_page='{controls[9].Text}'" +
                $"WHERE game_name='{GameName}'");

            // Обновить запись в таблицу Games-Genres
            DB.UpdateDataBase($"DELETE FROM [Games-Genres] WHERE game_name='{controls[0].Text}'");

            List<string> genres = new List<string>();
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    genres.Add(checkBoxes[i].Text);
                }
            }
            for (int i = 0; i < genres.Count; i++)
            {
                DB.UpdateDataBase($"INSERT INTO [Games-Genres] (game_name, genre_name) VALUES ('{controls[0].Text}','{genres[i]}')");
            }

            // Обновить запись в таблицу Products
            DB.UpdateDataBase($"UPDATE Storage SET amount='{controls[10].Text}' WHERE game_name='{controls[0].Text}'");


            MessageBox.Show("Данные были успешно изменены.");

            form.Close();
        }
    }
}
