
namespace VideoGameShop
{
    partial class LoginAndRegisterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSwitchLogin = new System.Windows.Forms.Button();
            this.buttonSwitchRegistration = new System.Windows.Forms.Button();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.textBoxRegisterRepPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxRegisterPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRegisterLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxLoginPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLoginLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRegister.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSwitchLogin
            // 
            this.buttonSwitchLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSwitchLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSwitchLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSwitchLogin.Location = new System.Drawing.Point(-6, 42);
            this.buttonSwitchLogin.Name = "buttonSwitchLogin";
            this.buttonSwitchLogin.Size = new System.Drawing.Size(261, 121);
            this.buttonSwitchLogin.TabIndex = 0;
            this.buttonSwitchLogin.Text = "Вход";
            this.buttonSwitchLogin.UseVisualStyleBackColor = true;
            this.buttonSwitchLogin.Click += new System.EventHandler(this.buttonSwitchLogin_click);
            // 
            // buttonSwitchRegistration
            // 
            this.buttonSwitchRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSwitchRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSwitchRegistration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSwitchRegistration.Location = new System.Drawing.Point(249, 42);
            this.buttonSwitchRegistration.Name = "buttonSwitchRegistration";
            this.buttonSwitchRegistration.Size = new System.Drawing.Size(256, 121);
            this.buttonSwitchRegistration.TabIndex = 1;
            this.buttonSwitchRegistration.Text = "Регистрация";
            this.buttonSwitchRegistration.UseVisualStyleBackColor = true;
            this.buttonSwitchRegistration.Click += new System.EventHandler(this.buttonSwitchRegistration_Click);
            // 
            // panelRegister
            // 
            this.panelRegister.Controls.Add(this.textBoxRegisterRepPassword);
            this.panelRegister.Controls.Add(this.label5);
            this.panelRegister.Controls.Add(this.buttonRegister);
            this.panelRegister.Controls.Add(this.textBoxRegisterPassword);
            this.panelRegister.Controls.Add(this.label3);
            this.panelRegister.Controls.Add(this.textBoxRegisterLogin);
            this.panelRegister.Controls.Add(this.label4);
            this.panelRegister.Location = new System.Drawing.Point(2, 169);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(503, 391);
            this.panelRegister.TabIndex = 5;
            // 
            // textBoxRegisterRepPassword
            // 
            this.textBoxRegisterRepPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRegisterRepPassword.Location = new System.Drawing.Point(193, 128);
            this.textBoxRegisterRepPassword.Name = "textBoxRegisterRepPassword";
            this.textBoxRegisterRepPassword.PasswordChar = '*';
            this.textBoxRegisterRepPassword.Size = new System.Drawing.Size(277, 26);
            this.textBoxRegisterRepPassword.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(36, 131);
            this.label5.MaximumSize = new System.Drawing.Size(0, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Повторите пароль:";
            // 
            // buttonRegister
            // 
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegister.Location = new System.Drawing.Point(39, 231);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(431, 51);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "Регистрация";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxRegisterPassword
            // 
            this.textBoxRegisterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRegisterPassword.Location = new System.Drawing.Point(193, 78);
            this.textBoxRegisterPassword.Name = "textBoxRegisterPassword";
            this.textBoxRegisterPassword.PasswordChar = '*';
            this.textBoxRegisterPassword.Size = new System.Drawing.Size(277, 26);
            this.textBoxRegisterPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль:";
            // 
            // textBoxRegisterLogin
            // 
            this.textBoxRegisterLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRegisterLogin.Location = new System.Drawing.Point(193, 36);
            this.textBoxRegisterLogin.Name = "textBoxRegisterLogin";
            this.textBoxRegisterLogin.Size = new System.Drawing.Size(277, 26);
            this.textBoxRegisterLogin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(35, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Логин:";
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.textBoxLoginPassword);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textBoxLoginLogin);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Location = new System.Drawing.Point(2, 169);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(503, 391);
            this.panelLogin.TabIndex = 7;
            // 
            // buttonLogin
            // 
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.Location = new System.Drawing.Point(38, 232);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(431, 51);
            this.buttonLogin.TabIndex = 14;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxLoginPassword
            // 
            this.textBoxLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLoginPassword.Location = new System.Drawing.Point(111, 155);
            this.textBoxLoginPassword.Name = "textBoxLoginPassword";
            this.textBoxLoginPassword.PasswordChar = '*';
            this.textBoxLoginPassword.Size = new System.Drawing.Size(358, 26);
            this.textBoxLoginPassword.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(34, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Пароль:";
            // 
            // textBoxLoginLogin
            // 
            this.textBoxLoginLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLoginLogin.Location = new System.Drawing.Point(111, 108);
            this.textBoxLoginLogin.Name = "textBoxLoginLogin";
            this.textBoxLoginLogin.Size = new System.Drawing.Size(358, 26);
            this.textBoxLoginLogin.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Логин:";
            // 
            // LoginAndRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 561);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelRegister);
            this.Controls.Add(this.buttonSwitchRegistration);
            this.Controls.Add(this.buttonSwitchLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(520, 600);
            this.Name = "LoginAndRegisterForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginRegisterForm_Load);
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSwitchLogin;
        private System.Windows.Forms.Button buttonSwitchRegistration;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxRegisterPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRegisterLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRegisterRepPassword;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxLoginPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoginLogin;
        private System.Windows.Forms.Label label1;
    }
}

