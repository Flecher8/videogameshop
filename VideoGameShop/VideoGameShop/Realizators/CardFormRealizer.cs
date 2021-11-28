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
    class CardFormRealizer : BuyGameFormRealizer
    {
        protected DateTime now = DateTime.Now;
        public CardFormRealizer(Form form, User user, string gameName) : base(form, user, gameName)
        {

        }
        protected bool checkIfNumber(string s)
        {
            if(s == "0" || s == "1" || s == "2" || s == "3" 
                || s == "4" || s == "5" || s == "6" || s == "7" 
                || s =="8" || s =="9" )
            {
                return true;
            }
            return false;
        }
        public void BuyGame(string numberOfCard, string defNumber)
        {
            if(numberOfCard.Length != 10 || defNumber.Length != 4)
            {
                MessageBox.Show("Поля не совпадают длине карты или длене защитного кода.\n Номер карты должен состоять из 10 цифр.\n Номер защитного кода должен состоять из 4 цифр.");
                return;
            }
            // Проверка номера карты
            for(int i = 0; i < numberOfCard.Length; i++)
            {
                if(!checkIfNumber(numberOfCard[i].ToString()))
                {
                    MessageBox.Show("Поле 'Номер карты' не состоит только из цифр. Пожалуйста повторите попытку.");
                    return;
                }
            }
            // Проверка защитного кода
            for (int i = 0; i < defNumber.Length; i++)
            {
                if (!checkIfNumber(defNumber[i].ToString()))
                {
                    MessageBox.Show("Поле 'Номер карты' не состоит только из цифр. Пожалуйста повторите попытку.");
                    return;
                }
            }
            fullWord();

        }
        public void fullWord()
        {
            System.Data.DataTable t1 = DB.GetDataBase("SELECT * FROM Sales");
            System.Data.DataTable maxSaleNumber = DB.GetDataBase("SELECT MAX(sale_id) AS MAX_SALE_ID FROM Sales");
            string maxSale = "";
            if(t1.Rows.Count == 0)
            {
                maxSale = "1";
            }
            else
            {
                maxSale = (maxSaleNumber.Rows[0].Field<int>("MAX_SALE_ID") + 1).ToString();
            }
            System.Data.DataTable price = DB.GetDataBase($"SELECT price FROM Games WHERE game_name='{GameName}'");
            string prc = price.Rows[0]["price"].ToString();



            FileInfo fileInfo = new FileInfo("product_check.docx");
            var items = new Dictionary<string, string>
            {
                { "<CHECK_NUMBER>",  maxSale },
                { "<GAME_NAME>", GameName},
                { "<PRICE>", prc},
                { "<DATA>", now.ToString("dd.MM.yyyy")},
            };
            
            Microsoft.Office.Interop.Word.Application app = null;
            //Microsoft.Office.Interop.Word.Application WordApp = null;

            DialogResult result = MessageBox.Show("Сохранить товарный чек?",
                    "Скачать товарный чек",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
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

                    /*object miss = System.Reflection.Missing.Value;
                    WordApp = new Microsoft.Office.Interop.Word.Application();
                    Document aDocument = WordApp.Documents.Add(ref miss, ref miss, ref miss, ref miss);
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Word document|*.docx";
                    saveFileDialog1.Title = "Save the Word Document";
                    if (DialogResult.OK == saveFileDialog1.ShowDialog())
                    {
                        string docName = saveFileDialog1.FileName;
                        if (docName.Length > 0)
                        {
                            Object newFileName = Path.Combine(aDocument.Path, docName);
                            app.ActiveDocument.SaveAs2(newFileName);
                        }
                    }*/

                    Object newFileName = Path.Combine(fileInfo.DirectoryName, now.ToString("yyyy_MM_dd HH_mm_ss") + " " + "Товарный чек");
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
            }

            // Заносим данные в таблицу
            string day = now.ToString("dd");
            if(day[0].ToString() == "0")
            {
                day = day[1].ToString();
            }
            string month = now.ToString("MM");
            if (month[0].ToString() == "0")
            {
                month = month[1].ToString();
            }
            DB.UpdateDataBase($"INSERT INTO Sales (sale_id, user_login, game_name, sale_sum, day_sale, month_sale, year_sale) " +
                $"Values ('{maxSale}', '{user.Login}', '{GameName}', '{prc}', '{day}', '{month}', '{now.ToString("yyyy")}')");

            form.Close();
        }
        private void createWordFile()
        {
            object miss = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            Document aDocument = WordApp.Documents.Add(ref miss, ref miss, ref miss, ref miss);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word document|*.doc";
            saveFileDialog1.Title = "Save the Word Document";
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                string docName = saveFileDialog1.FileName;
                if (docName.Length > 0)
                {
                    object oDocName = (object)docName;
                    aDocument.SaveAs(ref oDocName, ref miss, ref miss, ref miss, ref miss, ref miss,
                                 ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                                 ref miss, ref miss, ref miss, ref miss);
                    WordApp.Visible = true;
                }
            }
            MessageBox.Show($"{aDocument.Path + aDocument.Name}");
        }
    }
}
