namespace WindowsFormsApp5
{
    partial class User_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оборудованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сертификатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заявкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.установленноеОборудованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формаНаСписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расходыПредприятияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1114, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(1114, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выйти из учетной записи";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оборудованиеToolStripMenuItem,
            this.сертификатыToolStripMenuItem,
            this.заявкиToolStripMenuItem,
            this.установленноеОборудованиеToolStripMenuItem,
            this.формаНаСписаниеToolStripMenuItem,
            this.расходыПредприятияToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(9, 97);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(430, 566);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оборудованиеToolStripMenuItem
            // 
            this.оборудованиеToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.оборудованиеToolStripMenuItem.Name = "оборудованиеToolStripMenuItem";
            this.оборудованиеToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.оборудованиеToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.оборудованиеToolStripMenuItem.Text = "Оборудование";
            this.оборудованиеToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.оборудованиеToolStripMenuItem.Click += new System.EventHandler(this.оборудованиеToolStripMenuItem_Click);
            // 
            // сертификатыToolStripMenuItem
            // 
            this.сертификатыToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.сертификатыToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.сертификатыToolStripMenuItem.Name = "сертификатыToolStripMenuItem";
            this.сертификатыToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.сертификатыToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.сертификатыToolStripMenuItem.Text = "Сертификаты ";
            this.сертификатыToolStripMenuItem.Click += new System.EventHandler(this.сертификатыToolStripMenuItem_Click);
            // 
            // заявкиToolStripMenuItem
            // 
            this.заявкиToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.заявкиToolStripMenuItem.Name = "заявкиToolStripMenuItem";
            this.заявкиToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.заявкиToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.заявкиToolStripMenuItem.Text = "Заявки ";
            this.заявкиToolStripMenuItem.Click += new System.EventHandler(this.заявкиToolStripMenuItem_Click);
            // 
            // установленноеОборудованиеToolStripMenuItem
            // 
            this.установленноеОборудованиеToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.установленноеОборудованиеToolStripMenuItem.Name = "установленноеОборудованиеToolStripMenuItem";
            this.установленноеОборудованиеToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.установленноеОборудованиеToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.установленноеОборудованиеToolStripMenuItem.Text = "Установленное оборудование";
            this.установленноеОборудованиеToolStripMenuItem.Click += new System.EventHandler(this.установленноеОборудованиеToolStripMenuItem_Click);
            // 
            // формаНаСписаниеToolStripMenuItem
            // 
            this.формаНаСписаниеToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.формаНаСписаниеToolStripMenuItem.Name = "формаНаСписаниеToolStripMenuItem";
            this.формаНаСписаниеToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.формаНаСписаниеToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.формаНаСписаниеToolStripMenuItem.Text = "Форма на списание";
            this.формаНаСписаниеToolStripMenuItem.Click += new System.EventHandler(this.формаНаСписаниеToolStripMenuItem_Click);
            // 
            // расходыПредприятияToolStripMenuItem
            // 
            this.расходыПредприятияToolStripMenuItem.BackColor = System.Drawing.Color.SandyBrown;
            this.расходыПредприятияToolStripMenuItem.Name = "расходыПредприятияToolStripMenuItem";
            this.расходыПредприятияToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.расходыПредприятияToolStripMenuItem.Size = new System.Drawing.Size(423, 45);
            this.расходыПредприятияToolStripMenuItem.Text = "Расходы предприятия ";
            this.расходыПредприятияToolStripMenuItem.Click += new System.EventHandler(this.расходыПредприятияToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(442, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(848, 501);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(111, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 59);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ivanus.INC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(438, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 6;
            // 
            // User_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(1336, 629);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User_form";
            this.ShowIcon = false;
            this.Text = "User_form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.User_form_FormClosing);
            this.Load += new System.EventHandler(this.User_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оборудованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сертификатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заявкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem установленноеОборудованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem формаНаСписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расходыПредприятияToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}