using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Plugins.PersonCard
{
    public partial class GroupSearch : FT.Windows.Forms.DataSearchControl
    {
        public GroupSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Group);
            this.DetailFormType=typeof(GroupBrowser);
        }

        #region 子类必须实现的
        protected override string GetExportTitle()
        {
            return "名片分组数据";
        }
        protected override string GetExportField()
        {
            return "id as 编号,c_name as 分组名称,c_description as 分组描述";
        }

        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Group);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("编号", 80);
            this.CreateColumn("分组名称", 80);
            this.CreateColumn("分组描述");
        }
        #endregion

        protected override string GetPrintField()
        {
            return "c_name as 分组名称,c_description as 分组描述";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 120};
            //return base.GetPrintWidths();
        }
    }
}

