using UltimateCalendar.Models;

namespace UltimateCalendar.UI
{
    partial class LogInForm
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
            this.emailTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(142, 195);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(100, 20);
            this.emailTB.TabIndex = 0;
            this.emailTB.TextChanged += new System.EventHandler(this.emailTB_TextChanged);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(282, 195);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 406);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.emailTB);
            this.Name = "LogInForm";
            this.Text = "LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button button1;
    }
}