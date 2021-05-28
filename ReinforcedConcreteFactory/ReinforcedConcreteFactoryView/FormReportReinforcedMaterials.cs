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
    public partial class FormReportReinforcedMaterials : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportReinforcedMaterials(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormReportReinforcedMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetReinforcedMaterials");

                List<ReportReinforcedMaterialViewModel> dict = (List<ReportReinforcedMaterialViewModel>)method.Invoke(logic, null);
                if (dict != null)
                {
                    reportReinforcedMaterialsDataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        reportReinforcedMaterialsDataGridView.Rows.Add(new object[] { elem.ReinforcedName, "", ""});
                        foreach (var listElem in elem.ReinforcedMaterials)
                        {
                            reportReinforcedMaterialsDataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        reportReinforcedMaterialsDataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount});
                        reportReinforcedMaterialsDataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void saveToExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveReinforcedMaterialToExcelFile");
                        method.Invoke(logic, new object[]
                        {
                            new ReportBindingModel
                            {
                                FileName = dialog.FileName,
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
