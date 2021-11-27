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
        DataBase DB = new DataBase();
        private VideoGamesForm form;
        public VideoGamesFormRealizer(VideoGamesForm form)
        {
            this.form = form;
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
                "ram_amount AS 'Мин. Оп. Пам.', " +
                "price AS 'Цена', " +
                "age_limit AS 'Возрастное ограничение', " +
                "official_page AS 'Сайт' " +
                "FROM Games, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                "WHERE  Games.game_name = T1.GName");
            // JOIN 
            /*
             * SELECT game_name AS 'Название', developer_company AS 'Разработчик', " +
                "publisher_company AS 'Публикатор', STRING_AGG(genre_name, ';') AS 'Жанры', release_year AS 'Год выхода', game_description AS 'Описание', " +
                "critics_score AS 'Оценка критиков', cpu_name AS 'Мин. Процессор', videocard_name AS 'Мин. Видеокарта', " +
                "ram_amount AS 'Мин. Оп. Пам.', price AS 'Цена', age_limit AS 'Возрастное ограничение', official_page AS 'Сайт' FROM Games NATURAL JOIN [Games-Genres]
             */

            /*
             * 
                SELECT game_name AS 'Название', developer_company AS 'Разработчик', " +
                "publisher_company AS 'Публикатор', (SELECT STRING_AGG(genre_name, ';') AS 'Genres' FROM [Games-Genres]) AS 'Жанры', release_year AS 'Год выхода', game_description AS 'Описание', " +
                "critics_score AS 'Оценка критиков', cpu_name AS 'Мин. Процессор', videocard_name AS 'Мин. Видеокарта', " +
                "ram_amount AS 'Мин. Оп. Пам.', price AS 'Цена', age_limit AS 'Возрастное ограничение', official_page AS 'Сайт' FROM Games
             */
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
    }
}
