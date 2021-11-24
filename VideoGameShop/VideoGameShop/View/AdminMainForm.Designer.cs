
namespace VideoGameShop
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonVideoGames = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDevelopers = new System.Windows.Forms.Button();
            this.buttonPublishers = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.статистикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLЗапросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVideoGames
            // 
            this.buttonVideoGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVideoGames.Location = new System.Drawing.Point(12, 162);
            this.buttonVideoGames.Name = "buttonVideoGames";
            this.buttonVideoGames.Size = new System.Drawing.Size(236, 75);
            this.buttonVideoGames.TabIndex = 0;
            this.buttonVideoGames.Text = "Компьютерные игры";
            this.buttonVideoGames.UseVisualStyleBackColor = true;
            this.buttonVideoGames.Click += new System.EventHandler(this.buttonVideoGames_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(305, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Данные";
            // 
            // buttonDevelopers
            // 
            this.buttonDevelopers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDevelopers.Location = new System.Drawing.Point(254, 162);
            this.buttonDevelopers.Name = "buttonDevelopers";
            this.buttonDevelopers.Size = new System.Drawing.Size(236, 75);
            this.buttonDevelopers.TabIndex = 2;
            this.buttonDevelopers.Text = "Разработчики";
            this.buttonDevelopers.UseVisualStyleBackColor = true;
            this.buttonDevelopers.Click += new System.EventHandler(this.buttonDevelopers_Click);
            // 
            // buttonPublishers
            // 
            this.buttonPublishers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPublishers.Location = new System.Drawing.Point(496, 162);
            this.buttonPublishers.Name = "buttonPublishers";
            this.buttonPublishers.Size = new System.Drawing.Size(236, 75);
            this.buttonPublishers.TabIndex = 3;
            this.buttonPublishers.Text = "Публикаторы";
            this.buttonPublishers.UseVisualStyleBackColor = true;
            this.buttonPublishers.Click += new System.EventHandler(this.buttonPublishers_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистикиToolStripMenuItem,
            this.sQLЗапросыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // статистикиToolStripMenuItem
            // 
            this.статистикиToolStripMenuItem.Name = "статистикиToolStripMenuItem";
            this.статистикиToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.статистикиToolStripMenuItem.Text = "Статистики";
            // 
            // sQLЗапросыToolStripMenuItem
            // 
            this.sQLЗапросыToolStripMenuItem.Name = "sQLЗапросыToolStripMenuItem";
            this.sQLЗапросыToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.sQLЗапросыToolStripMenuItem.Text = "SQL Запросы";
            this.sQLЗапросыToolStripMenuItem.Click += new System.EventHandler(this.sQLЗапросыToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(496, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(236, 75);
            this.button4.TabIndex = 5;
            this.button4.Text = "Отчёт";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonPublishers);
            this.Controls.Add(this.buttonDevelopers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVideoGames);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMainForm";
            this.Text = "AdminMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVideoGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDevelopers;
        private System.Windows.Forms.Button buttonPublishers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem статистикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLЗапросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button button4;
    }
}