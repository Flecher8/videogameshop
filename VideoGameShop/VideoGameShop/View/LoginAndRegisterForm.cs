using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VideoGameShop
{
    public partial class LoginAndRegisterForm : Form
    {
        LoginAndRegisterFormRealizer realizer;
        public LoginAndRegisterForm()
        {
            InitializeComponent();
            realizer = new LoginAndRegisterFormRealizer(this);
        }

        private void LoginRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSwitchLogin_click(object sender, EventArgs e)
        {
            realizer.bringToFrontPanel(panelLogin);
        }

        private void buttonSwitchRegistration_Click(object sender, EventArgs e)
        {
            realizer.bringToFrontPanel(panelRegister);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            realizer.loginProsses(new User(textBoxLoginLogin.Text, textBoxLoginPassword.Text));
            /*DataBase DB = new DataBase();
            DataTable table = new DataTable();
            DB.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE [login] = @uL AND [password] = @uP", DB.Connection);
            command.Parameters.Add("@uL", SqlDbType.NVarChar).Value = textBoxLoginLogin.Text;
            command.Parameters.Add("@uP", SqlDbType.NVarChar).Value = textBoxLoginPassword.Text;
            MessageBox.Show("Helol");
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DB.closeConnection();
            if (table.Rows.Count > 0)
                MessageBox.Show("Helol");*/
            /*string ConnectionString = @"Data Source=Desktop;Initial Catalog=DBVideoGameShop;Integrated Security=True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE user_login = @uL AND password = @uP", connection);
                command.Parameters.Add("@uL", SqlDbType.NVarChar).Value = textBoxLoginLogin.Text;
                command.Parameters.Add("@uP", SqlDbType.NVarChar).Value = textBoxLoginPassword.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    MessageBox.Show("Helol");
                connection.Close();
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
            */
            
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
