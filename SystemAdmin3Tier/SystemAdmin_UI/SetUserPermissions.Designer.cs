namespace SystemAdmin_UI
{
    partial class SetUserPermissions
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.RemoveUserFromGroupbutton = new System.Windows.Forms.Button();
            this.AddUserToGroupbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(261, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbutton.Location = new System.Drawing.Point(322, 156);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(190, 39);
            this.Cancelbutton.TabIndex = 16;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // RemoveUserFromGroupbutton
            // 
            this.RemoveUserFromGroupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveUserFromGroupbutton.Location = new System.Drawing.Point(322, 94);
            this.RemoveUserFromGroupbutton.Name = "RemoveUserFromGroupbutton";
            this.RemoveUserFromGroupbutton.Size = new System.Drawing.Size(190, 39);
            this.RemoveUserFromGroupbutton.TabIndex = 15;
            this.RemoveUserFromGroupbutton.Text = "Remove User";
            this.RemoveUserFromGroupbutton.UseVisualStyleBackColor = true;
            this.RemoveUserFromGroupbutton.Click += new System.EventHandler(this.RemoveUserFromGroupbutton_Click);
            // 
            // AddUserToGroupbutton
            // 
            this.AddUserToGroupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserToGroupbutton.Location = new System.Drawing.Point(322, 34);
            this.AddUserToGroupbutton.Name = "AddUserToGroupbutton";
            this.AddUserToGroupbutton.Size = new System.Drawing.Size(190, 39);
            this.AddUserToGroupbutton.TabIndex = 14;
            this.AddUserToGroupbutton.Text = "Add User";
            this.AddUserToGroupbutton.UseVisualStyleBackColor = true;
            this.AddUserToGroupbutton.Click += new System.EventHandler(this.AddUserToGroupbutton_Click);
            // 
            // SetUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 359);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.RemoveUserFromGroupbutton);
            this.Controls.Add(this.AddUserToGroupbutton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SetUserPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetUserPermissions";
            this.Load += new System.EventHandler(this.SetUserPermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button RemoveUserFromGroupbutton;
        private System.Windows.Forms.Button AddUserToGroupbutton;
    }
}