namespace SystemAdmin_UI
{
    partial class UserLog
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
            this.UserLogBox = new System.Windows.Forms.RichTextBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ReturnMainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserLogBox
            // 
            this.UserLogBox.Location = new System.Drawing.Point(1, -1);
            this.UserLogBox.Name = "UserLogBox";
            this.UserLogBox.Size = new System.Drawing.Size(661, 469);
            this.UserLogBox.TabIndex = 0;
            this.UserLogBox.Text = "";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(683, 83);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(172, 39);
            this.LogoutButton.TabIndex = 10;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // ReturnMainMenuButton
            // 
            this.ReturnMainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnMainMenuButton.Location = new System.Drawing.Point(683, 12);
            this.ReturnMainMenuButton.Name = "ReturnMainMenuButton";
            this.ReturnMainMenuButton.Size = new System.Drawing.Size(172, 56);
            this.ReturnMainMenuButton.TabIndex = 9;
            this.ReturnMainMenuButton.Text = "Return To Main Menu";
            this.ReturnMainMenuButton.UseVisualStyleBackColor = true;
            // 
            // UserLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 469);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ReturnMainMenuButton);
            this.Controls.Add(this.UserLogBox);
            this.Name = "UserLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserLog";
            this.Load += new System.EventHandler(this.UserLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox UserLogBox;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ReturnMainMenuButton;
    }
}