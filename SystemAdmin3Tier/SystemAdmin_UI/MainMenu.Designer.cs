namespace SystemAdmin_UI
{
    partial class MainMenu
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
            this.LogoutButton = new System.Windows.Forms.Button();
            this.UserLogsButton = new System.Windows.Forms.Button();
            this.ServiceRequestsButton = new System.Windows.Forms.Button();
            this.UserMgmtButton = new System.Windows.Forms.Button();
            this.btnLogonStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(102, 291);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(218, 41);
            this.LogoutButton.TabIndex = 9;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // UserLogsButton
            // 
            this.UserLogsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLogsButton.Location = new System.Drawing.Point(102, 227);
            this.UserLogsButton.Name = "UserLogsButton";
            this.UserLogsButton.Size = new System.Drawing.Size(218, 41);
            this.UserLogsButton.TabIndex = 8;
            this.UserLogsButton.Text = "View User Logs";
            this.UserLogsButton.UseVisualStyleBackColor = true;
            // 
            // ServiceRequestsButton
            // 
            this.ServiceRequestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceRequestsButton.Location = new System.Drawing.Point(102, 91);
            this.ServiceRequestsButton.Name = "ServiceRequestsButton";
            this.ServiceRequestsButton.Size = new System.Drawing.Size(218, 41);
            this.ServiceRequestsButton.TabIndex = 7;
            this.ServiceRequestsButton.Text = "User Service Requests";
            this.ServiceRequestsButton.UseVisualStyleBackColor = true;
            // 
            // UserMgmtButton
            // 
            this.UserMgmtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserMgmtButton.Location = new System.Drawing.Point(102, 25);
            this.UserMgmtButton.Name = "UserMgmtButton";
            this.UserMgmtButton.Size = new System.Drawing.Size(218, 41);
            this.UserMgmtButton.TabIndex = 6;
            this.UserMgmtButton.Text = "User Management";
            this.UserMgmtButton.UseVisualStyleBackColor = true;
            // 
            // btnLogonStats
            // 
            this.btnLogonStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogonStats.Location = new System.Drawing.Point(102, 159);
            this.btnLogonStats.Name = "btnLogonStats";
            this.btnLogonStats.Size = new System.Drawing.Size(218, 41);
            this.btnLogonStats.TabIndex = 10;
            this.btnLogonStats.Text = "Logon Statistics";
            this.btnLogonStats.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 355);
            this.Controls.Add(this.btnLogonStats);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.UserLogsButton);
            this.Controls.Add(this.ServiceRequestsButton);
            this.Controls.Add(this.UserMgmtButton);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button UserLogsButton;
        private System.Windows.Forms.Button ServiceRequestsButton;
        private System.Windows.Forms.Button UserMgmtButton;
        private System.Windows.Forms.Button btnLogonStats;
    }
}