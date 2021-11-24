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
    class LoginAndRegisterFormRealizer
    {
        private DataBase DB = new DataBase();
        private Form form;
        private bool checkUser(User user)
        {

            DataTable data =  DB.GetDataBase($"SELECT * FROM Users WHERE user_login='{user.Login}' AND password='{user.Password}'");
            if (data.Rows.Count == 1)
                return true;
            MessageBox.Show("Такого пользователя нету. Пожалуйста повторите попытку.");
            return false;
        }
        // Функция проверяющаа не пустые ли формы.
        private bool checkEmptyControls(params Control[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Text == "")
                {
                    MessageBox.Show("Не все поля заполнены");
                    return false;
                }
            }
            return true;
        }
        private string findUserType(User user)
        {
            DataTable data = DB.GetDataBase($"SELECT user_type FROM Users WHERE user_login='{user.Login}'");
            string userType = "";
            foreach(DataRow row in data.Rows)
            {
                userType = row["user_type"].ToString();
            }
            return userType;
        }
        public LoginAndRegisterFormRealizer (LoginAndRegisterForm form)
        {
            this.form = form;
        }
        public void bringToFrontPanel(Panel panel)
        {
            panel.BringToFront();
        }
        public void loginProsses(params Control[] arr)
        {
            User user = new User(arr[0].Text, arr[1].Text);
            // CheckFE
            // If not добавить ошибку о том что такого пользователя не существует!!!!!!!!!
            if (!checkEmptyControls(arr) || !checkUser(user))
            {
                return;
            }

            string userType = this.findUserType(user);
            // Для пользователей типо админ открывается админская форма, для всех остальных пользователей
            // открывается пользовательская форма
            if(userType == "admin")
            {
                AdminMainForm adminMainForm= new AdminMainForm();
                form.Hide();
                adminMainForm.ShowDialog();
                form.Show();
            }
            else
            {
                UserMainForm userMainForm = new UserMainForm();
                form.Hide();
                userMainForm.ShowDialog();
                form.Show();
            }
        }

        public void registerProsses(string login, string password, string confirmPassword)
        {
            if(password == confirmPassword && password == "")
            {
                // Выбить ошибку о том что пароль не может быть пустым
            }
            if(password != confirmPassword)
            {
                // Выбить ошибку о том что пароль не совпадает с confirm паролем
            }

        }
    }
}
