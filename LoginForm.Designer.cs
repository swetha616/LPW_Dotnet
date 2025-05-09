namespace ADBApp1
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label Uname;
        private Label Pwd;
        private TextBox unametxt;
        private TextBox pwdtxt;
        private Button Loginbtn;
        private Button Cnclbtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Uname = new Label();
            this.Pwd = new Label();
            this.unametxt = new TextBox();
            this.pwdtxt = new TextBox();
            this.Loginbtn = new Button();
            this.Cnclbtn = new Button();
            this.SuspendLayout();
            // 
            // Uname
            // 
            this.Uname.AutoSize = true;
            this.Uname.Location = new System.Drawing.Point(158, 89);
            this.Uname.Name = "Uname";
            this.Uname.Size = new System.Drawing.Size(78, 20);
            this.Uname.TabIndex = 0;
            this.Uname.Text = "Username:";
            // 
            // Pwd
            // 
            this.Pwd.AutoSize = true;
            this.Pwd.Location = new System.Drawing.Point(158, 179);
            this.Pwd.Name = "Pwd";
            this.Pwd.Size = new System.Drawing.Size(73, 20);
            this.Pwd.TabIndex = 1;
            this.Pwd.Text = "Password:";
            // 
            // unametxt
            // 
            this.unametxt.Location = new System.Drawing.Point(338, 82);
            this.unametxt.Name = "unametxt";
            this.unametxt.Size = new System.Drawing.Size(192, 27);
            this.unametxt.TabIndex = 2;
            // 
            // pwdtxt
            // 
            this.pwdtxt.Location = new System.Drawing.Point(338, 172);
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.PasswordChar = '*';
            this.pwdtxt.Size = new System.Drawing.Size(192, 27);
            this.pwdtxt.TabIndex = 3;
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(436, 272);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(94, 29);
            this.Loginbtn.TabIndex = 4;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // Cnclbtn
            // 
            this.Cnclbtn.Location = new System.Drawing.Point(309, 272);
            this.Cnclbtn.Name = "Cnclbtn";
            this.Cnclbtn.Size = new System.Drawing.Size(94, 29);
            this.Cnclbtn.TabIndex = 5;
            this.Cnclbtn.Text = "Cancel";
            this.Cnclbtn.UseVisualStyleBackColor = true;
            this.Cnclbtn.Click += new System.EventHandler(this.Cnclbtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.Cnclbtn);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.pwdtxt);
            this.Controls.Add(this.unametxt);
            this.Controls.Add(this.Pwd);
            this.Controls.Add(this.Uname);
            this.Name = "LoginForm";
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
