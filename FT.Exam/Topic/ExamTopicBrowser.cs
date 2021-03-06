using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;

namespace FT.Exam
{
    public partial class ExamTopicBrowser : FT.Windows.Forms.DataBrowseForm
    {
       public ExamTopicBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public ExamTopicBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public ExamTopicBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("value");
                dt.Rows.Add(new string[] { "1", "1:判断题" });
                dt.Rows.Add(new string[] { "2", "2:选择题" });
                this.cbTopicTypeValue.DataSource = dt;
                this.cbTopicTypeValue.DropDownStyle = ComboBoxStyle.DropDown;
                this.cbTopicTypeValue.ValueMember = "key";
                this.cbTopicTypeValue.DisplayMember = "value";
            }
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new ExamTopic();
            
        }
        #endregion
    }
}

