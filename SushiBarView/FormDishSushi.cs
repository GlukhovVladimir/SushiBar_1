using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SushiBarView
{
    public partial class FormDishSushi : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSushi.SelectedValue); }
            set { comboBoxSushi.SelectedValue = value; }
        }
        public string SushiName { get { return comboBoxSushi.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormDishSushi(ISushiLogic logic)
        {
            InitializeComponent();

            List<SushiViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSushi.DisplayMember = "SushiName";
                comboBoxSushi.ValueMember = "Id";
                comboBoxSushi.DataSource = list;
                comboBoxSushi.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSushi.SelectedValue == null)
            {
                MessageBox.Show("Выберите ингридиент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
