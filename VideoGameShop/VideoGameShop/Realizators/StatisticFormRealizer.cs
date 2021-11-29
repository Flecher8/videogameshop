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
    class StatisticFormRealizer
    {
        protected DataBase DB = new DataBase();
        protected Form form;
        protected int numberOfQuery;
        public StatisticFormRealizer(Form form, int numberOfQuery)
        {
            this.form = form;
            this.numberOfQuery = numberOfQuery;
        }
        public void LoadData(Label nameOfForm, DataGridView table)
        {
            switch(numberOfQuery)
            {
                case 1:
                    nameOfForm.Text = "TOP-10 наболее продаваемые компьютерные игры";
                    table.DataSource = DB.GetDataBase("SELECT T1.game_name AS 'Название', COUNT_GAMES AS 'Количество покупок' " +
                        "FROM (SELECT TOP(10) game_name, COUNT(game_name) AS COUNT_GAMES FROM Sales GROUP BY game_name) T1 " +
                        "ORDER BY COUNT_GAMES DESC");
                    break;
                case 2:
                    nameOfForm.Text = "TOP-10 лучших компьютерных игр по мнению критиков";
                    table.DataSource = DB.GetDataBase("SELECT TOP(10) game_name AS 'Название', " +
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
                        " FROM GAMES, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                        "WHERE  Games.game_name = T1.GName " +
                        "ORDER BY critics_score DESC");
                    break;
                case 3:
                    nameOfForm.Text = "TOP-10 лучших компьютерных игр по мнению пользователей";
                    table.DataSource = DB.GetDataBase("SELECT T1.game_name AS 'Название', T1.AVG_MARK AS 'Средняя оценка пользователей' " +
                        "FROM (SELECT TOP(10) game_name, AVG(mark) AS AVG_MARK FROM Marks GROUP BY game_name) T1 " +
                        "ORDER BY AVG_MARK DESC");
                    break;
                case 4:
                    nameOfForm.Text = "TOP-10 самых дорогих компьютерных игр";
                    table.DataSource = DB.GetDataBase("SELECT TOP(10) game_name AS 'Название', " +
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
                        " FROM GAMES, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                        "WHERE  Games.game_name = T1.GName " +
                        "ORDER BY Games.price DESC");
                    break;
            }
        }
    }
}
