namespace JapaneseFerry
{
    partial class GameForm
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
            this.RulesBtn = new System.Windows.Forms.Button();
            this.TimerLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Timer = new System.Timers.Timer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SwimAcrossBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.Timer)).BeginInit();
            this.SuspendLayout();
            // 
            // RulesBtn
            // 
            this.RulesBtn.Location = new System.Drawing.Point(734, 12);
            this.RulesBtn.Name = "RulesBtn";
            this.RulesBtn.Size = new System.Drawing.Size(82, 32);
            this.RulesBtn.TabIndex = 0;
            this.RulesBtn.Text = "Правила";
            this.RulesBtn.UseVisualStyleBackColor = true;
            this.RulesBtn.Click += new System.EventHandler(this.RulesBtn_Click);
            // 
            // TimerLbl
            // 
            this.TimerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.TimerLbl.Location = new System.Drawing.Point(95, 8);
            this.TimerLbl.Name = "TimerLbl";
            this.TimerLbl.Size = new System.Drawing.Size(41, 16);
            this.TimerLbl.TabIndex = 1;
            this.TimerLbl.Text = "15:00";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "У вас осталось";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(137, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "минут";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000D;
            this.Timer.SynchronizingObject = this;
            this.Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_Elapsed);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(250, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 595);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(559, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 595);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(-1, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(865, 2);
            this.panel3.TabIndex = 4;
            // 
            // SwimAcrossBtn
            // 
            this.SwimAcrossBtn.Location = new System.Drawing.Point(258, 598);
            this.SwimAcrossBtn.Name = "SwimAcrossBtn";
            this.SwimAcrossBtn.Size = new System.Drawing.Size(295, 39);
            this.SwimAcrossBtn.TabIndex = 6;
            this.SwimAcrossBtn.Text = "Переплыть";
            this.SwimAcrossBtn.UseVisualStyleBackColor = true;
            this.SwimAcrossBtn.Click += new System.EventHandler(this.SwimAcrossBtn_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 649);
            this.Controls.Add(this.SwimAcrossBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimerLbl);
            this.Controls.Add(this.RulesBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Японская переправа";
            ((System.ComponentModel.ISupportInitialize) (this.Timer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button SwimAcrossBtn;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

        private System.Windows.Forms.Panel panel1;

        private System.Timers.Timer Timer;

        private System.Windows.Forms.Label TimerLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button RulesBtn;

        #endregion
    }
}