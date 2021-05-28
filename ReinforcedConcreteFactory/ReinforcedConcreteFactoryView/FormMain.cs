using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;
        private readonly ReportLogic _report;
        private readonly WorkModeling _workModeling;
        private readonly BackUpAbstractLogic _backUpAbstractLogic;
        public FormMain(OrderLogic orderLogic, ReportLogic reportLogic, WorkModeling workModeling, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _report = reportLogic;
            _workModeling = workModeling;
            _backUpAbstractLogic = backUpAbstractLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_orderLogic.Read(null), dataOrderFactoryGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaterials form = Container.Resolve<FormMaterials>();
            form.ShowDialog();
        }

        private void reinforcedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReinforceds form = Container.Resolve<FormReinforceds>();
            form.ShowDialog();

        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            FormCreateOrder form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void orderPaidButton_Click(object sender, EventArgs e)
        {
            if (dataOrderFactoryGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataOrderFactoryGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void reinforcedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _report.SaveReinforcedToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void reinforcedMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportReinforcedMaterials>();
            form.ShowDialog();
        }

        private void ordersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void startWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workModeling.DoWork();
            LoadData();
        }

        private void implementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMail>();
            form.ShowDialog();
        }

        private void createBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }
    }
}
