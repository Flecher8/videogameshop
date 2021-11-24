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
        // Проверка есть пользователь с таким login
        private bool findUser(User user)
        {

            DataTable data =  DB.GetDataBase($"SELECT * FROM Users WHERE user_login='{user.Login}'");
            if (data.Rows.Count == 1)
                return true;
            return false;
        }
        // Проверка совпадает ли пароль с паролем в базе данных для данного login
        private bool checkUserPassword(User user)
        {
            DataTable data = DB.GetDataBase($"SELECT * FROM Users WHERE user_login='{user.Login}' AND password='{user.Password}'");
            if (data.Rows.Count == 1)
                return true;
            return false;
        }
        // Функция проверяющаа не пустые ли поля.
        private bool checkEmptyControls(params Control[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Text == "")
                {
                    return false;
                }
            }
            return true;
        }
        // Находит тип пользователя
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
        private void openUserMainForm(User user)
        {
            UserMainForm userMainForm = new UserMainForm(user);
            form.Hide();
            userMainForm.ShowDialog();
            form.Show();
        }
        private void openAdminMainForm()
        {
            AdminMainForm adminMainForm = new AdminMainForm();
            form.Hide();
            adminMainForm.ShowDialog();
            form.Show();
        }
        public LoginAndRegisterFormRealizer (LoginAndRegisterForm form)
        {
            this.form = form;
        }
        // Выводит оперделённую панель на передний план
        public void bringToFrontPanel(Panel panel)
        {
            panel.BringToFront();
        }
        public void loginProsses(params Control[] arr)
        {
            // CheckFE
            // If not добавить ошибку о том что такого пользователя не существует!!!!!!!!!
            if (!checkEmptyControls(arr))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            User user = new User(arr[0].Text, arr[1].Text);

            // CheckFE
            if (!findUser(user))
            {
                MessageBox.Show("Такого пользователя нету в нашей базе данных. Пожалуйста повторите попытку.");
                return;
            }
            if(!checkUserPassword(user))
            {
                MessageBox.Show("Не правильный пароль. Пожалуйста повторите попытку.");
                return;
            }

            string userType = this.findUserType(user);

            // Для пользователей типо админ открывается админская форма, для всех остальных пользователей
            // открывается пользовательская форма
            if(userType == "admin")
            {
                openAdminMainForm();
            }
            else
            {
                openUserMainForm(user);
            }
        }

        public void registerProsses(params Control[] arr)
        {
            // CheckFE
            if (!checkEmptyControls(arr))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            User user = new User(arr[0].Text, arr[1].Text);
            // CheckFE
            if (findUser(user))
            {
                MessageBox.Show("Пользователь с таким именем уже есть в базе данных. Пожалуйста выбирите другой логин.");
                return;
            }
            // CheckFE
            if (arr[1].Text != arr[2].Text)
            {
                // Выбить ошибку о том что пароль не совпадает с confirm паролем
                MessageBox.Show("Поле 'пароль' и поле 'повторите пароль' не совпадают. Пожалуйста повторите попытку.");
                return;
            }

            // Регистрируеться новый пользователь
            DB.UpdateDataBase($"INSERT INTO Users (user_login, password, user_type) VALUES ('{user.Login}', '{user.Password}', 'user')");
            
            // Сообщение об успешной регистрации
            MessageBox.Show("Регистрация прошла успешно.");

            // Переход к главной форме для пользователей
            openUserMainForm(user);
        }
    }
}
