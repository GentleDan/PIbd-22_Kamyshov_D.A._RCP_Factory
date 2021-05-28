using Microsoft.Reporting.WinForms;
using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using ReinforcedConcreteFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormReportOrdersForAllDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportOrdersForAllDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void createOrdersListButton_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetOrdersForAllDates");
                List<ReportOrdersForAllDatesViewModel> dataSource = (List<ReportOrdersForAllDatesViewModel>)method.Invoke(logic, null);

                ReportDataSource source = new ReportDataSource("DataSetOrderDate", dataSource);
                OrdersReportViewer.LocalReport.DataSources.Add(source);
                OrdersReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void saveToPdfButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveOrdersForAllDatesToPdfFile");
                        method.Invoke(logic, new object[]
                        {
                            new ReportBindingModel
                            {
                                FileName = dialog.FileName,
                            }
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
        }
    }
}
