namespace ReinforcedConcreteFactoryView
{
    partial class FormReportReinforcedMaterials
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
            this.saveToExcelButton = new System.Windows.Forms.Button();
            this.reportReinforcedMaterialsDataGridView = new System.Windows.Forms.DataGridView();
            this.Reinforced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reportReinforcedMaterialsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveToExcelButton
            // 
            this.saveToExcelButton.Location = new System.Drawing.Point(12, 12);
            this.saveToExcelButton.Name = "saveToExcelButton";
            this.saveToExcelButton.Size = new System.Drawing.Size(119, 23);
            this.saveToExcelButton.TabIndex = 0;
            this.saveToExcelButton.Text = "Сохранить в Excel";
            this.saveToExcelButton.UseVisualStyleBackColor = true;
            this.saveToExcelButton.Click += new System.EventHandler(this.saveToExcelButton_Click);
            // 
            // reportReinforcedMaterialsDataGridView
            // 
            this.reportReinforcedMaterialsDataGridView.AllowUserToAddRows = false;
            this.reportReinforcedMaterialsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.reportReinforcedMaterialsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportReinforcedMaterialsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reinforced,
            this.Material,
            this.Count});
            this.reportReinforcedMaterialsDataGridView.Location = new System.Drawing.Point(12, 52);
            this.reportReinforcedMaterialsDataGridView.Name = "reportReinforcedMaterialsDataGridView";
            this.reportReinforcedMaterialsDataGridView.RowHeadersVisible = false;
            this.reportReinforcedMaterialsDataGridView.Size = new System.Drawing.Size(535, 415);
            this.reportReinforcedMaterialsDataGridView.TabIndex = 1;
            // 
            // Reinforced
            // 
            this.Reinforced.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reinforced.HeaderText = "Изделие";
            this.Reinforced.Name = "Reinforced";
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material.HeaderText = "Материал";
            this.Material.Name = "Material";
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // FormReportReinforcedMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 479);
            this.Controls.Add(this.reportReinforcedMaterialsDataGridView);
            this.Controls.Add(this.saveToExcelButton);
            this.Name = "FormReportReinforcedMaterials";
            this.Text = "Материалы по изделиям";
            this.Load += new System.EventHandler(this.FormReportReinforcedMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportReinforcedMaterialsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveToExcelButton;
        private System.Windows.Forms.DataGridView reportReinforcedMaterialsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reinforced;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}