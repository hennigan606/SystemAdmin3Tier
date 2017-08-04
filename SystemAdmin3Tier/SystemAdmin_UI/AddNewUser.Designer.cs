namespace SystemAdmin_UI
{
    partial class AddNewUser
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
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.AddUserbutton = new System.Windows.Forms.Button();
            this.LastName = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.lNametextBox = new System.Windows.Forms.TextBox();
            this.fNametextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbutton.Location = new System.Drawing.Point(367, 252);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(148, 39);
            this.Cancelbutton.TabIndex = 19;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // AddUserbutton
            // 
            this.AddUserbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserbutton.Location = new System.Drawing.Point(189, 252);
            this.AddUserbutton.Name = "AddUserbutton";
            this.AddUserbutton.Size = new System.Drawing.Size(148, 39);
            this.AddUserbutton.TabIndex = 18;
            this.AddUserbutton.Text = "Add User";
            this.AddUserbutton.UseVisualStyleBackColor = true;
            this.AddUserbutton.Click += new System.EventHandler(this.AddUserbutton_Click);
            // 
            // LastName
            // 
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.Location = new System.Drawing.Point(64, 108);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(100, 23);
            this.LastName.TabIndex = 17;
            this.LastName.Text = "Last Name:";
            // 
            // Email
            // 
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(64, 156);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(100, 23);
            this.Email.TabIndex = 16;
            this.Email.Text = "Email:";
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(64, 202);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 23);
            this.Password.TabIndex = 15;
            this.Password.Text = "Password:";
            // 
            // firstName
            // 
            this.firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName.Location = new System.Drawing.Point(64, 61);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(119, 23);
            this.firstName.TabIndex = 14;
            this.firstName.Text = "First Name:";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textBox.Location = new System.Drawing.Point(189, 202);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(340, 24);
            this.Password_textBox.TabIndex = 13;
            // 
            // Email_textBox
            // 
            this.Email_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_textBox.Location = new System.Drawing.Point(189, 156);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(340, 24);
            this.Email_textBox.TabIndex = 12;
            // 
            // lNametextBox
            // 
            this.lNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNametextBox.Location = new System.Drawing.Point(189, 108);
            this.lNametextBox.Name = "lNametextBox";
            this.lNametextBox.Size = new System.Drawing.Size(340, 24);
            this.lNametextBox.TabIndex = 11;
            // 
            // fNametextBox
            // 
            this.fNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fNametextBox.Location = new System.Drawing.Point(189, 59);
            this.fNametextBox.Name = "fNametextBox";
            this.fNametextBox.Size = new System.Drawing.Size(340, 24);
            this.fNametextBox.TabIndex = 10;
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 350);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.AddUserbutton);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.lNametextBox);
            this.Controls.Add(this.fNametextBox);
            this.Name = "AddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button AddUserbutton;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.TextBox Email_textBox;
        private System.Windows.Forms.TextBox lNametextBox;
        private System.Windows.Forms.TextBox fNametextBox;
    }
}