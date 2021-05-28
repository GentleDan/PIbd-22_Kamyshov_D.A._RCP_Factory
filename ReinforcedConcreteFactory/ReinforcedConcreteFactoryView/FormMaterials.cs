using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormMaterials : System.Windows.Forms.Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MaterialLogic logic;

        public FormMaterials(MaterialLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormMaterials_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataMaterialsGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void addMaterialsButton_Click(object sender, EventArgs e)
        {
            FormMaterial form = Container.Resolve<FormMaterial>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateMaterialsButton_Click(object sender, EventArgs e)
        {
            if (dataMaterialsGridView.SelectedRows.Count == 1)
            {
                FormMaterial form = Container.Resolve<FormMaterial>();
                form.Id = Convert.ToInt32(dataMaterialsGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void deleteMaterialsButton_Click(object sender, EventArgs e)
        {
            if (dataMaterialsGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataMaterialsGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new MaterialBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void refreshMaterialsButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
