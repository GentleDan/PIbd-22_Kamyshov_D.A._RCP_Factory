using System;
using System.Windows.Forms;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormMail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;
        public FormMail(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormMail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridViewMail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
