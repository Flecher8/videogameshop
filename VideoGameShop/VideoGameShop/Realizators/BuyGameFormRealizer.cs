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
    class BuyGameFormRealizer
    {
        protected DataBase DB = new DataBase();
        protected Form form;
        protected User user;
        protected List<Label> labels = new List<Label>();
        protected string GameName;
        public BuyGameFormRealizer(Form form, User user, string gameName)
        {
            this.form = form;
            this.user = user;
            this.GameName = gameName;
        }
        public void getLabels(params Label[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                labels.Add(arr[i]);
            }
        }
        public void fillLabels()
        {
            DataTable table = DB.GetDataBase($"SELECT game_name AS 'Название', " +
                $"developer_company AS 'Разработчик', " +
                $"publisher_company AS 'Публикатор', " +
                $"ARRAY_OF_GENRES AS 'Жанры', " +
                $"release_year AS 'Год выхода', " +
                $"critics_score AS 'Оценка критиков', " +
                $"cpu_name AS 'Мин. Процессор', " +
                $"videocard_name AS 'Мин. Видеокарта', " +
                $"ram_amount AS 'Мин. ОП.', " +
                $"price AS 'Цена', " +
                $"age_limit AS 'Возрастное ограничение', " +
                $"official_page AS 'Сайт' " +
                $"FROM Games, (SELECT Games.game_name AS GName, STRING_AGG(genre_name, ';') AS ARRAY_OF_GENRES FROM Games JOIN [Games-Genres] ON Games.game_name = [Games-Genres].game_name GROUP BY Games.game_name) T1 " +
                $"WHERE  Games.game_name = T1.GName AND game_name='{GameName}'");

            labels[0].Text = table.Rows[0]["Название"].ToString();
            labels[1].Text = table.Rows[0]["Разработчик"].ToString();
            labels[2].Text = table.Rows[0]["Публикатор"].ToString();
            labels[3].Text = table.Rows[0]["Жанры"].ToString();
            labels[4].Text = table.Rows[0]["Год выхода"].ToString();
            labels[5].Text = table.Rows[0]["Оценка критиков"].ToString();
            labels[6].Text = table.Rows[0]["Мин. Процессор"].ToString();
            labels[7].Text = table.Rows[0]["Мин. Видеокарта"].ToString();
            labels[8].Text = table.Rows[0]["Мин. ОП."].ToString();
            labels[9].Text = table.Rows[0]["Цена"].ToString();
            labels[10].Text = table.Rows[0]["Возрастное ограничение"].ToString();
            labels[11].Text = table.Rows[0]["Сайт"].ToString();
        }
        public void checkIfHideMark(params Control[] arr)
        {
            DataTable table = DB.GetDataBase($"SELECT * FROM Marks WHERE user_login='{user.Login}' AND game_name='{GameName}'");

            if(table.Rows.Count > 0)
            {
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i].Hide();
                }
            }
        }
        public void makeMarkByUser(TextBox textbox, params Control[] arr)
        {
            int? mark = tryParseInt32(textbox.Text);
            if(mark == null)
            {
                MessageBox.Show("Вы ввели не предусмотренное значение. Пожалуйста введите число от 1 до 10.");
                return;
            }
            if(mark < 1 || mark > 10)
            {
                MessageBox.Show("Ваша оценка должна быть от 1 до 10. Пожалуйста повторите попытку.");
                return;
            }

            DB.UpdateDataBase($"INSERT INTO Marks (user_login, game_name, mark) " +
                $"VALUES ('{user.Login}','{GameName}','{mark}')");

            MessageBox.Show("Спасибо за оценивание данной компьютерное игры.");
            checkIfHideMark(arr);
        }
        public void OpenCardForm()
        {
            DataTable table = DB.GetDataBase($"SELECT amount FROM Storage WHERE game_name='{GameName}'");
            if(table.Rows[0].Field<int>("amount") > 0)
            {
                CardForm cardForm = new CardForm(user, labels[0].Text);
                form.Hide();
                cardForm.ShowDialog();
                form.Show();
            }
            else
            {
                MessageBox.Show("Данной игры нету на складе. Пожалуйста повторите попытку позже.");
                return;
            }
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
