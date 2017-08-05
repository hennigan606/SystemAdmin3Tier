namespace SystemAdmin_UI
{
    partial class AssignAdminOperator
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
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.AssignOperatorbtn = new System.Windows.Forms.Button();
            this.AdminOperatorlabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.Location = new System.Drawing.Point(324, 58);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(95, 33);
            this.Cancelbtn.TabIndex = 7;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // AssignOperatorbtn
            // 
            this.AssignOperatorbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignOperatorbtn.Location = new System.Drawing.Point(181, 58);
            this.AssignOperatorbtn.Name = "AssignOperatorbtn";
            this.AssignOperatorbtn.Size = new System.Drawing.Size(136, 33);
            this.AssignOperatorbtn.TabIndex = 6;
            this.AssignOperatorbtn.Text = "Assign Operator";
            this.AssignOperatorbtn.UseVisualStyleBackColor = true;
            this.AssignOperatorbtn.Click += new System.EventHandler(this.AssignOperatorbtn_Click);
            // 
            // AdminOperatorlabel
            // 
            this.AdminOperatorlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminOperatorlabel.Location = new System.Drawing.Point(39, 32);
            this.AdminOperatorlabel.Name = "AdminOperatorlabel";
            this.AdminOperatorlabel.Size = new System.Drawing.Size(136, 24);
            this.AdminOperatorlabel.TabIndex = 5;
            this.AdminOperatorlabel.Text = "Admin Operator:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(181, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 24);
            this.textBox1.TabIndex = 4;
            // 
            // AssignAdminOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 118);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.AssignOperatorbtn);
            this.Controls.Add(this.AdminOperatorlabel);
            this.Controls.Add(this.textBox1);
            this.Name = "AssignAdminOperator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignAdminOperator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button AssignOperatorbtn;
        private System.Windows.Forms.Label AdminOperatorlabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}