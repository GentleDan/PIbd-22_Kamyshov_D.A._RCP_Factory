using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;
using System.Reflection;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormReportOrders : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;

        public FormReportOrders(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void createReportButton_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                "c " +
               dateTimePickerFrom.Value.ToShortDateString() +
                " по " +
               dateTimePickerTo.Value.ToShortDateString());
                reportViewerOrders.LocalReport.SetParameters(parameter);
                MethodInfo method = logic.GetType().GetMethod("GetOrders");
                var dataSource = method.Invoke(logic, new object[]
                {
                    new ReportBindingModel
                    {
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    }
                });
                ReportDataSource source = new ReportDataSource("DataSetOrders",
               dataSource);
                reportViewerOrders.LocalReport.DataSources.Add(source);
                reportViewerOrders.RefreshReport();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void createReportPDFButton_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveOrdersToPdfFile");
                        method.Invoke(logic, new object[]
                        {
                            new ReportBindingModel
                            {
                                FileName = dialog.FileName,
                                DateFrom = dateTimePickerFrom.Value,
                                DateTo = dateTimePickerTo.Value
                            }
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
