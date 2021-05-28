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
        public FormMain(OrderLogic orderLogic, ReportLogic reportLogic, WorkModeling workModeling)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _report = reportLogic;
            _workModeling = workModeling;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<ReinforcedConcreteFactoryBusinessLogic.ViewModels.OrderViewModel> list = _orderLogic.Read(null);
                if (list != null)
                {
                    dataOrderFactoryGridView.DataSource = list;
                    dataOrderFactoryGridView.Columns[0].Visible = false;
                    dataOrderFactoryGridView.Columns[1].Visible = false;
                    dataOrderFactoryGridView.Columns[2].Visible = false;
                    dataOrderFactoryGridView.Columns[3].Visible = false;
                    dataOrderFactoryGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
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
            using (SaveFileDialog dialog = new SaveFileDialog { Filter = "docx|*.docx" })
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
            FormReportReinforcedMaterials form = Container.Resolve<FormReportReinforcedMaterials>();
            form.ShowDialog();
        }

        private void ordersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportOrders form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void storehousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStoreHouses form = Container.Resolve<FormStoreHouses>();
            form.ShowDialog();
        }

        private void storehouseRefillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStoreHouseRefill form = Container.Resolve<FormStoreHouseRefill>();
            form.ShowDialog();
        }

        private void storeHousesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _report.SaveStoreHousesToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void storeHouseMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportStoreHouseMaterials form = Container.Resolve<FormReportStoreHouseMaterials>();
            form.ShowDialog();
        }

        private void ordersForAllDatesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportOrdersForAllDates form = Container.Resolve<FormReportOrdersForAllDates>();
            form.ShowDialog();
        }
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClients form = Container.Resolve<FormClients>();
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
    }
}
