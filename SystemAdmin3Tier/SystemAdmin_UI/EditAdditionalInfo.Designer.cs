namespace SystemAdmin_UI
{
    partial class EditAdditionalInfo
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
            this.EditInfolabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditInfolabel
            // 
            this.EditInfolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditInfolabel.Location = new System.Drawing.Point(44, 29);
            this.EditInfolabel.Name = "EditInfolabel";
            this.EditInfolabel.Size = new System.Drawing.Size(86, 39);
            this.EditInfolabel.TabIndex = 7;
            this.EditInfolabel.Text = "Additional Info:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(136, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 24);
            this.textBox1.TabIndex = 6;
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.Location = new System.Drawing.Point(256, 77);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(111, 30);
            this.Cancelbtn.TabIndex = 5;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Location = new System.Drawing.Point(136, 77);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(104, 30);
            this.Savebtn.TabIndex = 4;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // EditAdditionalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 140);
            this.Controls.Add(this.EditInfolabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Savebtn);
            this.Name = "EditAdditionalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditAdditionalInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EditInfolabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button Savebtn;
    }
}