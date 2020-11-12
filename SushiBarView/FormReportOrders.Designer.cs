namespace SushiBarView
{
    partial class FormReportOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonMakeOrder = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.reportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formReportDishSushisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formReportOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrdersViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportDishSushisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportOrdersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewReport.Location = new System.Drawing.Point(13, 89);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.Size = new System.Drawing.Size(582, 384);
            this.dataGridViewReport.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Дата";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Суши";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Цена";
            this.Column3.Name = "Column3";
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(451, 12);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(143, 37);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "Сохранить в Excel ";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // buttonMakeOrder
            // 
            this.buttonMakeOrder.Location = new System.Drawing.Point(297, 12);
            this.buttonMakeOrder.Name = "buttonMakeOrder";
            this.buttonMakeOrder.Size = new System.Drawing.Size(131, 36);
            this.buttonMakeOrder.TabIndex = 2;
            this.buttonMakeOrder.Text = "Сформировать";
            this.buttonMakeOrder.UseVisualStyleBackColor = true;
            this.buttonMakeOrder.Click += new System.EventHandler(this.buttonMakeOrder_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(13, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFrom.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(13, 39);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTo.TabIndex = 0;
            // 
            // reportOrdersViewModelBindingSource
            // 
            this.reportOrdersViewModelBindingSource.DataSource = typeof(SushiBarBusinessLogic.ViewModels.ReportOrdersViewModel);
            // 
            // formReportDishSushisBindingSource
            // 
            this.formReportDishSushisBindingSource.DataSource = typeof(SushiBarView.FormReportDishSushis);
            // 
            // formReportOrdersBindingSource
            // 
            this.formReportOrdersBindingSource.DataSource = typeof(SushiBarView.FormReportOrders);
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 537);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.buttonMakeOrder);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridViewReport);
            this.Name = "FormReportOrders";
            this.Text = "Отчёт по заказам";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrdersViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportDishSushisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportOrdersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonMakeOrder;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.BindingSource formReportOrdersBindingSource;
        private System.Windows.Forms.BindingSource formReportDishSushisBindingSource;
        private System.Windows.Forms.BindingSource reportOrdersViewModelBindingSource;
    }
}