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
            realizer.loginProsses(textBoxLoginLogin, textBoxLoginPassword);
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            realizer.registerProsses(textBoxRegisterLogin, textBoxRegisterPassword, textBoxRegisterRepPassword);
        }
    }
}
