using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using FT.Commons.Tools;
using FT.Commons.Com.Excels;
using System.IO;

namespace FT.Windows.Forms
{
    public partial class DataCounterControl : UserControl
    {
        public DataCounterControl()
        {
            InitializeComponent();
        }

        private void DataCounterControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                foreach (System.Windows.Forms.Control ctr in this.splitContainer2.Panel1.Controls)
                {
                    if (ctr is TextBox)
                    {
                        ctr.KeyDown += new KeyEventHandler(ctr_KeyDown);
                    }
                }
            }
        }

        protected virtual void Search()
        {
            throw new Exception("子类必须实现查询语句！");
        }

        protected virtual string GetTitle()
        {
            throw new Exception("子类必须实现设置Title！");
        }
        void ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                this.Export();
            }
            else
            {
                MessageBoxHelper.Show("没有可导出的数据！");
            }
        }

        private void Export()
        {

            DataTable dt = this.GetTableFromGrid();
            string path = FileDialogHelper.SaveExcel(this.GetTitle()+".xls");
                if (path != null && path != string.Empty)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    ListExcel ls = new ListExcel(path, dt);
                    ls.Title = this.GetTitle();
                    ls.GetExcelReport();
                    this.Cursor = Cursors.WaitCursor;
                    MessageBoxHelper.Show("导出成功！");
                    this.Cursor = Cursors.Default;
                }
            
        }

        private DataTable GetTableFromGrid()
        {
            int rows = this.dataGridView1.Rows.Count;
            int cols = this.dataGridView1.Columns.Count;
            if (rows == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();

            for (int i = 0; i < cols; i++)
            {
                dt.Columns.Add(this.dataGridView1.Columns[i].HeaderText);
            }
            DataRow dr = null;
            object tmp = null;
            for (int i = 0; i < rows; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    tmp = dataGridView1.Rows[i].Cells[j].FormattedValue;
                    dr[j] = tmp == null ? "" : tmp.ToString();

                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private int[] GetDataGridViewWidth()
        {
            int[] tmp = new int[this.dataGridView1.Columns.Count - 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = this.dataGridView1.Columns[i].Width;
            }
            return tmp;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataTable dt = this.GetTableFromGrid();
                try
                {

                    DataTablePrinterContent.Print(dt, this.GetDataGridViewWidth(), this.GetTitle());
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show(ex.Message);
                }
            }
            else
            {
                MessageBoxHelper.Show("没有可打印的数据！");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        #region 子类创建列
        public void ClearColumns()
        {
            this.dataGridView1.Columns.Clear();
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop)
        {
            return CreateColumn(prop, prop);
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, string header)
        {
            DataGridViewTextBoxColumn tmp = new DataGridViewTextBoxColumn();
            tmp.DataPropertyName = prop;
            tmp.HeaderText = header;
            tmp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(tmp);
            return tmp;
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, int width)
        {
            return this.CreateColumn(prop, prop, width);
        }

        public DataGridViewTextBoxColumn CreateColumn(string prop, string header, int width)
        {
            DataGridViewTextBoxColumn tmp = new DataGridViewTextBoxColumn();
            tmp.DataPropertyName = prop;
            tmp.HeaderText = header;
            tmp.Width = width;
            this.dataGridView1.Columns.Add(tmp);
            return tmp;
        }
        #endregion

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
       e.RowBounds.Location.Y,
        dataGridView1.RowHeadersWidth - 4,
        e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
