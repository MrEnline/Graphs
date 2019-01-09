namespace Finder
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.SearchInBreadth = new System.Windows.Forms.Button();
            this.SearchInDeapth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Chess";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel.Location = new System.Drawing.Point(94, 13);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1065, 650);
            this.panel.TabIndex = 2;
            // 
            // SearchInBreadth
            // 
            this.SearchInBreadth.Location = new System.Drawing.Point(12, 80);
            this.SearchInBreadth.Name = "SearchInBreadth";
            this.SearchInBreadth.Size = new System.Drawing.Size(75, 38);
            this.SearchInBreadth.TabIndex = 3;
            this.SearchInBreadth.Text = "Поиск вширь";
            this.SearchInBreadth.UseVisualStyleBackColor = true;
            this.SearchInBreadth.Click += new System.EventHandler(this.SearchInBreadth_Click);
            // 
            // SearchInDeapth
            // 
            this.SearchInDeapth.Location = new System.Drawing.Point(13, 133);
            this.SearchInDeapth.Name = "SearchInDeapth";
            this.SearchInDeapth.Size = new System.Drawing.Size(75, 38);
            this.SearchInDeapth.TabIndex = 4;
            this.SearchInDeapth.Text = "Поиск в глубь";
            this.SearchInDeapth.UseVisualStyleBackColor = true;
            this.SearchInDeapth.Click += new System.EventHandler(this.SearchInDeapth_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 675);
            this.Controls.Add(this.SearchInDeapth);
            this.Controls.Add(this.SearchInBreadth);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button SearchInBreadth;
        private System.Windows.Forms.Button SearchInDeapth;
    }
}

