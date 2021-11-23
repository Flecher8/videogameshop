using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGameShop
{
    public partial class LoginAndRegisterForm : Form
    {
        public LoginAndRegisterForm()
        {
            InitializeComponent();
        }

        private void LoginRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSwitchLogin_click(object sender, EventArgs e)
        {
            panelLogin.BringToFront();
        }

        private void buttonSwitchRegistration_Click(object sender, EventArgs e)
        {
            panelRegister.BringToFront();
        }
    }
}
