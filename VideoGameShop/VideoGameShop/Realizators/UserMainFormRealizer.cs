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
        public void OpenBuyGameForm()
        {

        }
    }
}
