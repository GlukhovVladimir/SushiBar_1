using SushiBarBusinessLogic.BindingModels;
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
    public partial class FormDish : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDishLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> dishSushis;

        public FormDish(IDishLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void LoadData()
        {
            try
            {
                if (dishSushis != null)
                {
                    dataGridViewDish.Rows.Clear();
                    foreach (var pc in dishSushis)
                    {
                        dataGridViewDish.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
                            pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormDish_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DishViewModel view = logic.Read(new DishBindingModel
                    {
                        Id =
                        id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.DishName;
                        textBoxPrice.Text = view.Price.ToString();
                        dishSushis = view.DishSushis;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                dishSushis = new Dictionary<int, (string, int)>();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishSushi>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (dishSushis.ContainsKey(form.Id))
                {
                    dishSushis[form.Id] = (form.SushiName, form.Count);
                }
                else
                {
                    dishSushis.Add(form.Id, (form.SushiName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDish.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDishSushi>();
                int id = Convert.ToInt32(dataGridViewDish.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = dishSushis[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dishSushis[form.Id] = (form.SushiName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDish.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        dishSushis.Remove(Convert.ToInt32(dataGridViewDish.SelectedRows[0].Cells[0].Value));
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

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (dishSushis == null || dishSushis.Count == 0)
            {
                MessageBox.Show("Заполните ингридиенты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DishBindingModel
                {
                    Id = id,
                    DishName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    DishSushis = dishSushis
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
