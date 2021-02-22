﻿using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
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
        public FormMain(OrderLogic orderLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
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
                    dataOrderFactoryGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void submitExecutionButton_Click(object sender, EventArgs e)
        {
            if (dataOrderFactoryGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataOrderFactoryGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void orderReadyButton_Click(object sender, EventArgs e)
        {
            if (dataOrderFactoryGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataOrderFactoryGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel
                    {
                        OrderId = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
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
    }
}
