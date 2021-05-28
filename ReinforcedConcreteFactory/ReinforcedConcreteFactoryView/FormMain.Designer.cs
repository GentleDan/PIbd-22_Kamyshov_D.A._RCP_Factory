namespace ReinforcedConcreteFactoryView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinforcedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.implementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinforcedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinforcedMaterialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataOrderFactoryGridView = new System.Windows.Forms.DataGridView();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.orderPaidButton = new System.Windows.Forms.Button();
            this.refreshListButton = new System.Windows.Forms.Button();
            this.createBackUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderFactoryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referencesToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.startWorkToolStripMenuItem,
            this.mailToolStripMenuItem,
            this.createBackUpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1050, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // referencesToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialsToolStripMenuItem,
            this.reinforcedToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.implementersToolStripMenuItem});
            this.referencesToolStripMenuItem.Name = "referencesToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.referencesToolStripMenuItem.Text = "Справочники";
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.materialsToolStripMenuItem.Text = "Материалы";
            this.materialsToolStripMenuItem.Click += new System.EventHandler(this.materialsToolStripMenuItem_Click);
            // 
            // reinforcedToolStripMenuItem
            // 
            this.reinforcedToolStripMenuItem.Name = "reinforcedToolStripMenuItem";
            this.reinforcedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.reinforcedToolStripMenuItem.Text = "Изделия";
            this.reinforcedToolStripMenuItem.Click += new System.EventHandler(this.reinforcedToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clientsToolStripMenuItem.Text = "Клиенты";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // implementersToolStripMenuItem
            // 
            this.implementersToolStripMenuItem.Name = "implementersToolStripMenuItem";
            this.implementersToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.implementersToolStripMenuItem.Text = "Исполнители";
            this.implementersToolStripMenuItem.Click += new System.EventHandler(this.implementersToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reinforcedListToolStripMenuItem,
            this.reinforcedMaterialsToolStripMenuItem,
            this.ordersListToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // reinforcedListToolStripMenuItem
            // 
            this.reinforcedListToolStripMenuItem.Name = "reinforcedListToolStripMenuItem";
            this.reinforcedListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.reinforcedListToolStripMenuItem.Text = "Список изделий";
            this.reinforcedListToolStripMenuItem.Click += new System.EventHandler(this.reinforcedListToolStripMenuItem_Click);
            // 
            // reinforcedMaterialsToolStripMenuItem
            // 
            this.reinforcedMaterialsToolStripMenuItem.Name = "reinforcedMaterialsToolStripMenuItem";
            this.reinforcedMaterialsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.reinforcedMaterialsToolStripMenuItem.Text = "Материалы по изделям";
            this.reinforcedMaterialsToolStripMenuItem.Click += new System.EventHandler(this.reinforcedMaterialsToolStripMenuItem_Click);
            // 
            // ordersListToolStripMenuItem
            // 
            this.ordersListToolStripMenuItem.Name = "ordersListToolStripMenuItem";
            this.ordersListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.ordersListToolStripMenuItem.Text = "Список заказов";
            this.ordersListToolStripMenuItem.Click += new System.EventHandler(this.ordersListToolStripMenuItem_Click);
            // 
            // startWorkToolStripMenuItem
            // 
            this.startWorkToolStripMenuItem.Name = "startWorkToolStripMenuItem";
            this.startWorkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.startWorkToolStripMenuItem.Text = "Запуск работ";
            this.startWorkToolStripMenuItem.Click += new System.EventHandler(this.startWorkToolStripMenuItem_Click);
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.mailToolStripMenuItem.Text = "Письма";
            this.mailToolStripMenuItem.Click += new System.EventHandler(this.mailToolStripMenuItem_Click);
            // 
            // dataOrderFactoryGridView
            // 
            this.dataOrderFactoryGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataOrderFactoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrderFactoryGridView.Location = new System.Drawing.Point(0, 27);
            this.dataOrderFactoryGridView.Name = "dataOrderFactoryGridView";
            this.dataOrderFactoryGridView.RowHeadersVisible = false;
            this.dataOrderFactoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataOrderFactoryGridView.Size = new System.Drawing.Size(834, 424);
            this.dataOrderFactoryGridView.TabIndex = 1;
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(873, 43);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(107, 44);
            this.createOrderButton.TabIndex = 2;
            this.createOrderButton.Text = "Создать заказ";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // orderPaidButton
            // 
            this.orderPaidButton.Location = new System.Drawing.Point(873, 273);
            this.orderPaidButton.Name = "orderPaidButton";
            this.orderPaidButton.Size = new System.Drawing.Size(107, 47);
            this.orderPaidButton.TabIndex = 5;
            this.orderPaidButton.Text = "Заказ оплачен";
            this.orderPaidButton.UseVisualStyleBackColor = true;
            this.orderPaidButton.Click += new System.EventHandler(this.orderPaidButton_Click);
            // 
            // refreshListButton
            // 
            this.refreshListButton.Location = new System.Drawing.Point(873, 358);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(107, 47);
            this.refreshListButton.TabIndex = 6;
            this.refreshListButton.Text = "Обновить список";
            this.refreshListButton.UseVisualStyleBackColor = true;
            this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
            // 
            // createBackUpToolStripMenuItem
            // 
            this.createBackUpToolStripMenuItem.Name = "createBackUpToolStripMenuItem";
            this.createBackUpToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.createBackUpToolStripMenuItem.Text = "Создать бекап";
            this.createBackUpToolStripMenuItem.Click += new System.EventHandler(this.createBackUpToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 468);
            this.Controls.Add(this.refreshListButton);
            this.Controls.Add(this.orderPaidButton);
            this.Controls.Add(this.createOrderButton);
            this.Controls.Add(this.dataOrderFactoryGridView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "Завод ЖБИ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderFactoryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinforcedToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataOrderFactoryGridView;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button orderPaidButton;
        private System.Windows.Forms.Button refreshListButton;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinforcedListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinforcedMaterialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem implementersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBackUpToolStripMenuItem;
    }
}