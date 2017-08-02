namespace SystemAdmin_UI
{
    partial class UserManagement
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
            this.ReturnMainMenuButton = new System.Windows.Forms.Button();
            this.SetUserPermissionsButton = new System.Windows.Forms.Button();
            this.BanUserButton = new System.Windows.Forms.Button();
            this.DeleteUserButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(594, 391);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(216, 39);
            this.LogoutButton.TabIndex = 12;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // ReturnMainMenuButton
            // 
            this.ReturnMainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnMainMenuButton.Location = new System.Drawing.Point(594, 329);
            this.ReturnMainMenuButton.Name = "ReturnMainMenuButton";
            this.ReturnMainMenuButton.Size = new System.Drawing.Size(216, 39);
            this.ReturnMainMenuButton.TabIndex = 11;
            this.ReturnMainMenuButton.Text = "Return To Main Menu";
            this.ReturnMainMenuButton.UseVisualStyleBackColor = true;
            // 
            // SetUserPermissionsButton
            // 
            this.SetUserPermissionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUserPermissionsButton.Location = new System.Drawing.Point(594, 268);
            this.SetUserPermissionsButton.Name = "SetUserPermissionsButton";
            this.SetUserPermissionsButton.Size = new System.Drawing.Size(216, 39);
            this.SetUserPermissionsButton.TabIndex = 10;
            this.SetUserPermissionsButton.Text = "Set User Permissions";
            this.SetUserPermissionsButton.UseVisualStyleBackColor = true;
            // 
            // BanUserButton
            // 
            this.BanUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BanUserButton.Location = new System.Drawing.Point(594, 207);
            this.BanUserButton.Name = "BanUserButton";
            this.BanUserButton.Size = new System.Drawing.Size(216, 39);
            this.BanUserButton.TabIndex = 9;
            this.BanUserButton.Text = "Ban User / Lift Ban";
            this.BanUserButton.UseVisualStyleBackColor = true;
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteUserButton.Location = new System.Drawing.Point(594, 145);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(216, 39);
            this.DeleteUserButton.TabIndex = 8;
            this.DeleteUserButton.Text = "Delete User";
            this.DeleteUserButton.UseVisualStyleBackColor = true;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserButton.Location = new System.Drawing.Point(594, 85);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(216, 39);
            this.AddUserButton.TabIndex = 7;
            this.AddUserButton.Text = "Add New User";
            this.AddUserButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(537, 345);
            this.dataGridView1.TabIndex = 13;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 458);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ReturnMainMenuButton);
            this.Controls.Add(this.SetUserPermissionsButton);
            this.Controls.Add(this.BanUserButton);
            this.Controls.Add(this.DeleteUserButton);
            this.Controls.Add(this.AddUserButton);
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagement";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ReturnMainMenuButton;
        private System.Windows.Forms.Button SetUserPermissionsButton;
        private System.Windows.Forms.Button BanUserButton;
        private System.Windows.Forms.Button DeleteUserButton;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}