using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormStoreHouses : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly StoreHouseLogic logic;

        public FormStoreHouses(StoreHouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), storehousesDataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormStoreHouses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addStoreHouseButton_Click(object sender, EventArgs e)
        {
            FormStoreHouse form = Container.Resolve<FormStoreHouse>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void changeStoreHouseButton_Click(object sender, EventArgs e)
        {
            if (storehousesDataGridView.SelectedRows.Count == 1)
            {
                FormStoreHouse form = Container.Resolve<FormStoreHouse>();
                form.Id = Convert.ToInt32(storehousesDataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void deleteStoreHouseButton_Click(object sender, EventArgs e)
        {
            if (storehousesDataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(storehousesDataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new StoreHouseBindingModel
                        {
                            Id = id
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void updateStoreHouseButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
