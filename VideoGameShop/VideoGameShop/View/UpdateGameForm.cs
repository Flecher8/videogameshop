﻿using System;
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
    public partial class UpdateGameForm : Form
    {
        UpdateGameFormRealizer realizer;
        public UpdateGameForm()
        {
            InitializeComponent();
        }
        public UpdateGameForm(string gameName)
        {
            InitializeComponent();
            realizer = new UpdateGameFormRealizer(this, gameName);
        }

        private void UpdateGameForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            realizer.fillFields();
        }
    }
}
