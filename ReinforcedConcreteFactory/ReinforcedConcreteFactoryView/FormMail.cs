using System;
using System.Windows.Forms;
using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.BusinessLogics;
using Unity;

namespace ReinforcedConcreteFactoryView
{
    public partial class FormMail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;
        private bool hasNext = false;
        private readonly int mailsOnPage = 2;
        private int currentPage = 0;
        public FormMail(MailLogic logic)
        {
            if (mailsOnPage < 1) { mailsOnPage = 5; }
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
                var list = logic.Read(new MessageInfoBindingModel { ToSkip = currentPage * mailsOnPage, ToTake = mailsOnPage + 1 });

                hasNext = !(list.Count <= mailsOnPage);

                if (hasNext)
                {
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = false;
                }

                if (list != null)
                {
                    dataGridViewMail.DataSource = list;
                    dataGridViewMail.Columns[0].Visible = false;
                    dataGridViewMail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (currentPage != 0)
                {
                    buttonPrev.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrev.Enabled = true;
                LoadData();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                if (currentPage == 0)
                {
                    buttonPrev.Enabled = false;
                }
                LoadData();
            }
        }

        private void buttonCurrentPage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCurrentPage.Text))
            {
                MessageBox.Show("Введите номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var list = logic.Read(null);

            if (Convert.ToInt32(textBoxCurrentPage.Text) < 0 || Convert.ToInt32(textBoxCurrentPage.Text) > list.Count)
            {
                MessageBox.Show("Недопустимый номер страницы номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentPage = Convert.ToInt32(textBoxCurrentPage.Text) - 1;
            textBoxPage.Text = (currentPage + 1).ToString();
            LoadData();
        }
    }
}
