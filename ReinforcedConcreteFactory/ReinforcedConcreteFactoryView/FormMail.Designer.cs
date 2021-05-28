namespace ReinforcedConcreteFactoryView
{
    partial class FormMail
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
            this.dataGridViewMail = new System.Windows.Forms.DataGridView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.textBoxCurrentPage = new System.Windows.Forms.TextBox();
            this.buttonCurrentPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMail
            // 
            this.dataGridViewMail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMail.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewMail.Name = "dataGridViewMail";
            this.dataGridViewMail.RowHeadersVisible = false;
            this.dataGridViewMail.Size = new System.Drawing.Size(472, 447);
            this.dataGridViewMail.TabIndex = 0;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(273, 480);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "Назад";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(377, 480);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Вперед";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(354, 480);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(17, 20);
            this.textBoxPage.TabIndex = 3;
            // 
            // textBoxCurrentPage
            // 
            this.textBoxCurrentPage.Location = new System.Drawing.Point(95, 482);
            this.textBoxCurrentPage.Name = "textBoxCurrentPage";
            this.textBoxCurrentPage.Size = new System.Drawing.Size(23, 20);
            this.textBoxCurrentPage.TabIndex = 4;
            // 
            // buttonCurrentPage
            // 
            this.buttonCurrentPage.Location = new System.Drawing.Point(12, 480);
            this.buttonCurrentPage.Name = "buttonCurrentPage";
            this.buttonCurrentPage.Size = new System.Drawing.Size(75, 23);
            this.buttonCurrentPage.TabIndex = 5;
            this.buttonCurrentPage.Text = "Перейти";
            this.buttonCurrentPage.UseVisualStyleBackColor = true;
            this.buttonCurrentPage.Click += new System.EventHandler(this.buttonCurrentPage_Click);
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 517);
            this.Controls.Add(this.buttonCurrentPage);
            this.Controls.Add(this.textBoxCurrentPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.dataGridViewMail);
            this.Name = "FormMail";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMail;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.TextBox textBoxCurrentPage;
        private System.Windows.Forms.Button buttonCurrentPage;
    }
}