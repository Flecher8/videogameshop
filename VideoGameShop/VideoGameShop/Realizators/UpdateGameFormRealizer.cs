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
            if(DB.GetDataBase("SELECT STRING_AGG(genre_name, ';') AS 'Genres' FROM [Games-Genres]").Rows[0]["Genres"].ToString().Contains("Шутер"))
            {
                MessageBox.Show("1");
            }
        }
    }
}
