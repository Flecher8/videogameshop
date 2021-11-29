using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace VideoGameShop
{
    class AdminMainFormRealizer
    {
        private DataBase DB = new DataBase();
        private Form form;
        protected DateTime now = DateTime.Now;
        public AdminMainFormRealizer(AdminMainForm form)
        {
            this.form = form;
        }
        public void OpenDevelopersForm()
        {
            DevelopersForm developersMainForm = new DevelopersForm();
            form.Hide();
            developersMainForm.ShowDialog();
            form.Show();
        }
        public void OpenPublishersForm()
        {
            PublishersForm publishersForm = new PublishersForm();
            form.Hide();
            publishersForm.ShowDialog();
            form.Show();
        }
        public void OpenVideoGamesForm()
        {
            VideoGamesForm videoGamesForm = new VideoGamesForm();
            form.Hide();
            videoGamesForm.ShowDialog();
            form.Show();
        }
        // Доделать
        
        public void fullWord()
        {
            System.Data.DataTable numOfGames = DB.GetDataBase("SELECT COUNT(game_name) AS NUMBER_OF_GAMES FROM Games");
            string numberOfGames = numOfGames.Rows[0].Field<int>("NUMBER_OF_GAMES").ToString();

            System.Data.DataTable numOfUsers = DB.GetDataBase("SELECT COUNT(user_login) AS NUMBER_OF_USERS FROM Users WHERE user_type='user'");
            string numberOfUsers = numOfUsers.Rows[0].Field<int>("NUMBER_OF_USERS").ToString();

            System.Data.DataTable numOfBoughtGames = DB.GetDataBase("SELECT COUNT(sale_id) AS NUMBER_OF_SALES FROM Sales");
            string numberOfBoughtGames = numOfBoughtGames.Rows[0].Field<int>("NUMBER_OF_SALES").ToString();

            System.Data.DataTable prof = DB.GetDataBase("SELECT SUM(sale_sum) AS PROFIT FROM Sales");
            string profit = prof.Rows[0].Field<int>("PROFIT").ToString();

            FileInfo fileInfo = new FileInfo("admin_sales_check.docx");
            var items = new Dictionary<string, string>
            {
                { "<NumberOfGames>",  numberOfGames },
                { "<NumberOfUsers>", numberOfUsers },
                { "<NumberOfBoughtGames>", numberOfBoughtGames },
                { "<DATA>", now.ToString("dd.MM.yyyy")},
            };

            Microsoft.Office.Interop.Word.Application app = null;

            // Скачиваем файл
            try
            {
                app = new Microsoft.Office.Interop.Word.Application();

                Object file = fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }

                Object newFileName = Path.Combine(fileInfo.DirectoryName, now.ToString("yyyy_MM_dd HH_mm_ss") + " " + "Отчёт администратора");
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }


            MessageBox.Show("Отчёт успешно сохранён.");
        }
        public void OpenStatisticForm(int number)
        {
            StatisticForm statisticForm = new StatisticForm(number);
            form.Hide();
            statisticForm.ShowDialog();
            form.Show();
        }
    }
}
