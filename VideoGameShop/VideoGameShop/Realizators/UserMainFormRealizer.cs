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
    class UserMainFormRealizer : VideoGamesFormRealizer
    {
        private User user;
        public UserMainFormRealizer(Form form, User user) : base(form)
        {
            this.form = form;
            this.user = user;
        }
        public void OpenBuyGameForm(string gameName)
        {
            BuyGameForm buyGameForm = new BuyGameForm(user, gameName);
            form.Hide();
            buyGameForm.ShowDialog();
            form.Show();
        }
        public void OpenStatisticForm(int number)
        {
            StatisticForm statisticForm = new StatisticForm(number);
            form.Hide();
            statisticForm.ShowDialog();
            form.Show();
        }
        public void OpenAboutForm()
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            form.Hide();
            aboutProgramForm.ShowDialog();
            form.Show();
        }
        public void OpenAutoForm()
        {
            AutoForm autoForm = new AutoForm();
            form.Hide();
            autoForm.ShowDialog();
            form.Show();
        }
    }
}
