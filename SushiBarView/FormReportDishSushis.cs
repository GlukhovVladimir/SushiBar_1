using Microsoft.Reporting.WinForms;
using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.BusinessLogic;
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
    public partial class FormReportDishSushis : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReportDishSushis(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonMakeOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetDishSushi();
                ReportDataSource source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void buttonPDFOrder_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveDishSushisToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
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

        private void FormReportDishSushis_Load(object sender, EventArgs e)
        {

        }
    }
}
