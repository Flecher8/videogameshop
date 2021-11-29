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
    class VideoGamesFormRealizer
    {
        protected DataBase DB = new DataBase();
        protected Form form;
        protected List<CheckBox> checkBoxes = new List<CheckBox>();
        protected List<Control> controls = new List<Control>();

        public VideoGamesFormRealizer(Form form)
        {
            this.form = form;
        }
        public void getControls(params Control[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                controls.Add(arr[i]);
            }
        }
        public void getCheckBoxes(params CheckBox[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                checkBoxes.Add(arr[i]);
            }
        }
        public void UpdateDataGridView(DataGridView table)
        {
            table.DataSource = DB.GetDataBase("SELECT game_name AS 'Название', " +
                "developer_company AS 'Разработчик', " +
                "publisher_company AS 'Публикатор', " +
                "ARRAY_OF_GENRES AS 'Жанры', " +
                "release_year AS 'Год выхода', " +
                "critics_score AS 'Оценка критиков', " +
                "cpu_name AS 'Мин. Процессор', " +
                "videocard_name AS 'Мин. Видеокарта', " +
                "ram_amount AS 'Мин. ОП.', " +
                "price AS 'Цена', " +
                "age_limit AS 'Возрастное ограничение', " +
                "official_page AS 'Сайт' " +
                "FROM Games, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                "WHERE  Games.game_name = T1.GName");
        }
        public void OpenAddGameForm()
        {
            AddGameForm addGameForm = new AddGameForm();
            form.Hide();
            addGameForm.ShowDialog();
            form.Show();
        }
        public void OpenUpdateGameForm(DataGridView table)
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
            UpdateGameForm updateGameForm = new UpdateGameForm(table.SelectedRows[0].Cells[0].Value.ToString());
            form.Hide();
            updateGameForm.ShowDialog();
            form.Show();
        }
        public void DeleteGame(DataGridView table)
        {
            DialogResult result = MessageBox.Show("Удалить выбраные компьютерные игры?",
                    "Удаление",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < table.SelectedRows.Count; i++)
                {
                    DB.UpdateDataBase($"DELETE FROM Games " +
                        $"WHERE game_name='{table.SelectedRows[i].Cells[0].Value.ToString()}'");
                }
            }
        }
        public void clearAllTextBoxes(params Control[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].Text = "";
            }
        }
        public void clearAllCheckBoxes(params CheckBox[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].CheckState = CheckState.Unchecked;
            }
        }
        public void findGames(DataGridView table)
        {
            List<string> fillters = new List<string>();
            //AND ARRAY_OF_GENRES LIKE '%Шутеры%'
            // Смотрим поисковые запросы
            if (controls[0].Text != "")
                fillters.Add(takeGameNameString(controls[0].Text));
            if (controls[1].Text != "")
                fillters.Add(takeDeveloperString(controls[1].Text));
            if (controls[2].Text != "")
                fillters.Add(takePublisherString(controls[2].Text));

            if(controls[3].Text == controls[4].Text && controls[3].Text == "")
            {

            }
            else
            {
                if (takePriceString(controls[3].Text, controls[4].Text) == "ERROR")
                    return;
                fillters.Add(takePriceString(controls[3].Text, controls[4].Text));
            }

            // Смотрим запросы жанров
            List<string> genres = takeGenres();

            for(int i = 0; i < genres.Count; i++)
            {
                fillters.Add(genres[i]);
            }
            string resultCommand = "SELECT game_name AS 'Название', " +
                "developer_company AS 'Разработчик', " +
                "publisher_company AS 'Публикатор', " +
                "ARRAY_OF_GENRES AS 'Жанры', " +
                "release_year AS 'Год выхода', " +
                "critics_score AS 'Оценка критиков', " +
                "cpu_name AS 'Мин. Процессор', " +
                "videocard_name AS 'Мин. Видеокарта', " +
                "ram_amount AS 'Мин. Оп.', " +
                "price AS 'Цена', " +
                "age_limit AS 'Возрастное ограничение', " +
                "official_page AS 'Сайт' " +
                "FROM Games, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                "WHERE Games.game_name = T1.GName ";

            if(fillters.Count > 0)
            {
                resultCommand += "AND ";
            }
            for (int i = 0; i < fillters.Count; i++)
            {
                resultCommand += fillters[i];
                if (i != fillters.Count - 1)
                    resultCommand += " AND ";
            }
            // Order By
            if(sortString() != "")
            {
                resultCommand += " ORDER BY " + sortString();
            }

            table.DataSource = DB.GetDataBase(resultCommand);
        }
        protected string takeGameNameString(string gameName)
        {
            if (gameName == "")
                return "";
            return $"LOWER(game_name) LIKE '%{gameName}%'";
        }
        protected string takeDeveloperString(string developer)
        {
            if (developer == "")
                return "";
            return $"LOWER(developer_company) LIKE '%{developer}%'";
        }
        protected string takePublisherString(string publisher)
        {
            if (publisher == "")
                return "";
            return $"LOWER(publisher_company) LIKE '%{publisher}%'";
        }
        protected string takePriceString(string leftPrice, string rightPrice)
        {
            if(leftPrice != "" && rightPrice != "")
            {
                string left = isCorrectNumber(1, 1000000, leftPrice);
                string right = isCorrectNumber(1, 1000000, rightPrice);
                if (left == right && left == "")
                {
                    int? l = tryParseInt32(leftPrice);
                    int? r = tryParseInt32(rightPrice);
                    if (l > r)
                    {
                        MessageBox.Show($"Поле 'цена от' и поле 'цена до' заполнены не правильно.");
                        return "ERROR";
                    }
                }
                else
                {
                    MessageBox.Show($"Поле для 'цена от' содержит ошибку: '{left}'\n Поле для 'цена до' содержит ошибку: '{right}'");
                    return "ERROR";
                }
                return $"price >= {leftPrice} AND price <= {rightPrice}";
            }
            if(leftPrice == "")
            {
                string right = isCorrectNumber(1, 1000000, rightPrice);
                if (right != "")
                {
                    MessageBox.Show($"Поле для 'цена до' содержит ошибку: '{right}' ");
                    return "ERROR";
                }
                return $"price >= 1 AND price <= {rightPrice}";
            }
            if(rightPrice == "")
            {
                string left = isCorrectNumber(1, 1000000, leftPrice);
                if(left != "")
                {
                    MessageBox.Show($"Поле для 'цена от' содержит ошибку: '{left}' ");
                    return "ERROR";
                }
                return $"price >= {leftPrice} AND price <= 1000000";
            }
            return $"price >= {leftPrice} AND price <= {rightPrice}";
        }
        protected string sortString()
        {
            // 16 17
            List<string> e = new List<string>();
            if(checkBoxes[16].Checked)
            {
                e.Add("release_year");
            }
            if(checkBoxes[17].Checked)
            {
                e.Add("price");
            }
            if (e.Count == 0)
                return "";
            if(e.Count == 1)
            {
                return e[0];
            }
            return "release_year, price";
        }
        protected List<string> takeGenres()
        {
            List<string> genreCommands = new List<string>();

            // Количество жанров 16 !!!!!!!!!!!!
            for(int i = 0; i < 16; i++)
            {
                if(checkBoxes[i].Checked)
                {
                    genreCommands.Add($"ARRAY_OF_GENRES LIKE '%{checkBoxes[i].Text}%'");
                }
            }

            return genreCommands;
        }
        protected string isCorrectNumber(int leftLimit, int rightLimit, string control)
        {
            int? number = tryParseInt32(control);
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
    }
}
