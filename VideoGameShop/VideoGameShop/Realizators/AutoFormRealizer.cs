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
    class AutoFormRealizer : VideoGamesFormRealizer
    {
        public AutoFormRealizer(Form form) : base(form)
        {
            this.form = form;
        }
        public bool checkEmpty()
        {
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].Text == "")
                {
                    return false;
                }
            }
            return true;
        }
        public string checkError()
        {
            string error = "";
            if(controls[0].Text.Length < 5)
            {
                error += "\nДлинна поля 'Название процессора' для более точно понимание, какой процессор необходим пользователю, должно быть длинее 4 символов.\n";
            }
            if(controls[1].Text.Length < 5)
            {
                error += "\nДлинна поля 'Название видеокарты' для более точно понимание, какой процессор необходим пользователю, должно быть длинее 4 символов.\n";
            }
            int? ram = tryParseInt32(controls[2].Text);
            if(ram == null)
            {
                error += "\n Поле 'Количество ОП.' должно содержать только целые числовые значения.\n";
            }
            if(ram != null && (ram < 1 || ram > 10000))
            {
                error += "\n Поле 'Количество ОП.' не может быть меньше 1 или больше 10000.\n";
            }

            return error;
        }
        public string checkCorrectCpuAndVideoGame()
        {
            string error = "";
            DataTable cpu = DB.GetDataBase($"SELECT power FROM CPUs WHERE LOWER(cpu_name) LIKE '%{controls[0].Text}%'");
            if(cpu.Rows.Count == 0)
            {
                error += "\nТакого процессора нету в базе данных. Пожалуйста введите либо более точное название процессора, либо другое название.";
            }
            DataTable videocard = DB.GetDataBase($"SELECT power FROM Videocards WHERE LOWER(videocard_name) LIKE '%{controls[1].Text}%'");
            if (videocard.Rows.Count == 0)
            {
                error += "\nТакой видеокарты нету в базе данных. Пожалуйста введите либо более точное название видеокарты, либо другое название.";
            }

            return error;
        }
        public void TakeNeededGames(DataGridView table)
        {
            // Проверка пусты ли textboxes
            if(!checkEmpty())
            {
                MessageBox.Show("Не все поля заполнены. Пожалуйста заполните все поля.");
                return;
            }
            
            // Проверка не ошибочны ли данные в textboxes
            if(checkError() != "")
            {
                MessageBox.Show(checkError());
                return;
            }

            // Проверка не ошибочны ли названия в textboxes
            if (checkCorrectCpuAndVideoGame() != "")
            {
                MessageBox.Show(checkCorrectCpuAndVideoGame());
                return;
            }

            DataTable cpuP = DB.GetDataBase($"SELECT power FROM CPUs WHERE LOWER(cpu_name) LIKE '%{controls[0].Text}%'");
            int cpuPower = cpuP.Rows[0].Field<int>("power");

            DataTable videocardP = DB.GetDataBase($"SELECT power FROM Videocards WHERE LOWER(videocard_name) LIKE '%{controls[1].Text}%'");
            int videocardPower = videocardP.Rows[0].Field<int>("power");
            

            int? ramAmount = tryParseInt32(controls[2].Text);

            table.DataSource = DB.GetDataBase($"SELECT game_name AS 'Название', " +
                $"developer_company AS 'Разработчик', " +
                $"publisher_company AS 'Публикатор', " +
                $"ARRAY_OF_GENRES AS 'Жанры', " +
                $"release_year AS 'Год выхода', " +
                $"critics_score AS 'Оценка критиков', " +
                $"cpu_name AS 'Мин. Процессор', " +
                $"videocard_name AS 'Мин. Видеокарта', " +
                $"ram_amount AS 'Мин. Оп.', " +
                $"price AS 'Цена', " +
                $"age_limit AS 'Возрастное ограничение', " +
                $"official_page AS 'Сайт' " +
                $"FROM Games, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                $"WHERE Games.game_name = T1.GName AND ram_amount <= '{ramAmount}' AND game_name IN(" +
                $"SELECT game_name FROM Games JOIN CPUs ON Games.cpu_name = CPUs.cpu_name " +
                $"WHERE power <= '{cpuPower}' AND game_name IN (" +
                $"SELECT game_name FROM Games JOIN Videocards ON Games.videocard_name = Videocards.videocard_name " +
                $"WHERE power <= {videocardPower}))");

            // SELECT game_name FROM Games JOIN CPUs ON Games.cpu_name = CPUs.cpu_name WHERE power <= 2000
            // SELECT * FROM Games JOIN Videocards ON Games.videocard_name = Videocards.videocard_name WHERE power <= 2000
        }
    }
}
