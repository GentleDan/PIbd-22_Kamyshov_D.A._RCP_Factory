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
    public partial class FormReportStoreHouseMaterials : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReportStoreHouseMaterials(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveStoreHouseMaterialsToExcelFile");
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
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportStoreHouseMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetStoreHouseMaterials");
                List<ReportStoreHouseMaterialViewModel> storeHouseMaterials = (List<ReportStoreHouseMaterialViewModel>)method.Invoke(logic, null);
                if (storeHouseMaterials != null)
                {
                    storeHouseMaterialsDataGridView.Rows.Clear();

                    foreach (var storeHouse in storeHouseMaterials)
                    {
                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { storeHouse.StoreHouseName, "", "" });

                        foreach (var material in storeHouse.Materials)
                        {
                            storeHouseMaterialsDataGridView.Rows.Add(new object[] { "", material.Item1, material.Item2 });
                        }

                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { "Итого", "", storeHouse.TotalCount });
                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
