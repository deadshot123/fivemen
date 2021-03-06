﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Web.Tools;
using FT.DAL.Orm;

public partial class DriverPerson_Preasign_SchoolCarInfoList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "table_school_car_info";
            this.ProcedurePager1.FieldString = @"id ,
	clpp ,
	hmhp ,
	name,
    idcard ,
	coachno ,
    mobile ,
    depname 
	".Replace("\r\n", "").Replace("\t", "");

            if (!string.IsNullOrEmpty(Request.Params["school"]))
            {
                int depId = this.Operator.DeptId;
                DepartMent dep = SimpleOrmOperator.Query<DepartMent>(depId);
                ViewState["dep"] = dep;
                this.ProcedurePager1.RowFilter = string.Format( " DEPCODE ='{0}'",dep.DepCode);
            }

            this.ProcedurePager1.SortString = " order by depname desc";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (this.txtHphm.Text.Trim().Length > 0)
            this.ProcedurePager1.RowFilter = " hmhp like '%"+this.txtHphm.Text.Trim()+"%'";
        //else
            //this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Pop(-1);
    }

    private void Pop(int id)
    {
        string url = "SchoolCarInfoEdit.aspx";
        DepartMent dep = ViewState["dep"] as DepartMent;
        if (id > 0&&dep!=null)
        {
            url += string.Format("?id={0}&depId={1}", id, dep.Id);

        }
        else if (dep != null) {
            url += string.Format("?depId={0}", dep.Id);
        }

        WebTools.ShowModalWindows(this, url, 1000, 350);
    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SchoolCarInfoOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
}
