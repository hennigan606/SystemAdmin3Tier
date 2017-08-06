namespace SystemAdmin_UI
{
    partial class LogonStats
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logonAttemptsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._SystemAdminDataModel_SystemAdminContextDataSet = new SystemAdmin_UI._SystemAdminDataModel_SystemAdminContextDataSet();
            this.logonAttemptsTableAdapter = new SystemAdmin_UI._SystemAdminDataModel_SystemAdminContextDataSetTableAdapters.LogonAttemptsTableAdapter();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ReturnMainMenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logonAttemptsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SystemAdminDataModel_SystemAdminContextDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.logonAttemptsBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Logon Attempts";
            series1.XValueMember = "LogonDateTime";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "LogonSuccessful";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(654, 438);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // logonAttemptsBindingSource
            // 
            this.logonAttemptsBindingSource.DataMember = "LogonAttempts";
            this.logonAttemptsBindingSource.DataSource = this._SystemAdminDataModel_SystemAdminContextDataSet;
            // 
            // _SystemAdminDataModel_SystemAdminContextDataSet
            // 
            this._SystemAdminDataModel_SystemAdminContextDataSet.DataSetName = "_SystemAdminDataModel_SystemAdminContextDataSet";
            this._SystemAdminDataModel_SystemAdminContextDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logonAttemptsTableAdapter
            // 
            this.logonAttemptsTableAdapter.ClearBeforeFill = true;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(697, 63);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(178, 32);
            this.LogoutButton.TabIndex = 20;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ReturnMainMenuButton
            // 
            this.ReturnMainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnMainMenuButton.Location = new System.Drawing.Point(697, 12);
            this.ReturnMainMenuButton.Name = "ReturnMainMenuButton";
            this.ReturnMainMenuButton.Size = new System.Drawing.Size(178, 32);
            this.ReturnMainMenuButton.TabIndex = 19;
            this.ReturnMainMenuButton.Text = "Return To Main Menu";
            this.ReturnMainMenuButton.UseVisualStyleBackColor = true;
            this.ReturnMainMenuButton.Click += new System.EventHandler(this.ReturnMainMenuButton_Click);
            // 
            // LogonStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 462);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ReturnMainMenuButton);
            this.Controls.Add(this.chart1);
            this.Name = "LogonStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuccessfulLogons";
            this.Load += new System.EventHandler(this.SuccessfulLogons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logonAttemptsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SystemAdminDataModel_SystemAdminContextDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private _SystemAdminDataModel_SystemAdminContextDataSet _SystemAdminDataModel_SystemAdminContextDataSet;
        private System.Windows.Forms.BindingSource logonAttemptsBindingSource;
        private _SystemAdminDataModel_SystemAdminContextDataSetTableAdapters.LogonAttemptsTableAdapter logonAttemptsTableAdapter;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ReturnMainMenuButton;
    }
}