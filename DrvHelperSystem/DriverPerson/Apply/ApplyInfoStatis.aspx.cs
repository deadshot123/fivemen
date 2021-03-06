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
using FT.Web;
using FT.Web.Tools;
using FT.WebServiceInterface.DrvQuery;

public partial class DriverPerson_Apply_ApplyInfoStatis : AuthenticatedPage
{

    private string _sqlPattern = @" select c_jxdm
        ,count(id) as total 
,(select c_depnickname from table_departments where c_depcode=c_jxdm and c_deptype='驾校' ) as jxmc
    ,sum(decode(i_checked,1,1,0 )) as total_checked
    ,sum(decode(i_checked,0,1,0 )) as total_uncheck 
 ,sum(decode(i_checked,2,1,0 )) as total_checkfail  
 ,sum(decode(i_checked,1,1,0 )*decode(c_ly,'A',1,0)) as local_total_checked
 ,sum(decode(i_checked,0,1,0 )*decode(c_ly,'A',1,0)) as local_total_uncheck 
 ,sum(decode(i_checked,2,1,0 )*decode(c_ly,'A',1,0)) as local_total_checkfail
  ,sum(decode(i_checked,1,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_checked
 ,sum(decode(i_checked,0,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_uncheck 
 ,sum(decode(i_checked,2,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_checkfail
 from   table_student_apply_info_c
 where to_date(c_check_date,'yyyy-MM-dd') 
  between to_date('{0}','yyyy-MM-dd') and to_date('{1}','yyyy-MM-dd')
  group by c_jxdm  
	".Replace("\r\n", "").Replace("\t", "");

    private string _sqlPattern2 = @" select c_jxdm
        ,count(id) as total 
,(select c_depnickname from table_departments where c_depcode=c_jxdm and c_deptype='驾校' ) as jxmc
    ,sum(decode(i_checked,1,1,0 )) as total_checked
    ,sum(decode(i_checked,0,1,0 )) as total_uncheck 
 ,sum(decode(i_checked,2,1,0 )) as total_checkfail  
 ,sum(decode(i_checked,1,1,0 )*decode(c_ly,'A',1,0)) as local_total_checked
 ,sum(decode(i_checked,0,1,0 )*decode(c_ly,'A',1,0)) as local_total_uncheck 
 ,sum(decode(i_checked,2,1,0 )*decode(c_ly,'A',1,0)) as local_total_checkfail
  ,sum(decode(i_checked,1,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_checked
 ,sum(decode(i_checked,0,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_uncheck 
 ,sum(decode(i_checked,2,1,0 )*decode(c_ly,'A',0,1)) as nolocal_total_checkfail
 from   table_student_apply_info_c
 where to_date(c_check_date,'yyyy-MM-dd') 
  between to_date('{0}','yyyy-MM-dd') and to_date('{1}','yyyy-MM-dd') and c_Photo_Src='{2}'
  group by c_jxdm  
	".Replace("\r\n", "").Replace("\t", "");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrvQueryHelper.BindDropDownListBustype(this.cbBustype);
            string startDate = DateTime.Now.ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.txtBeginDate.Value = startDate;
            this.txtEndDate.Value = endDate;
            cbBustype.Items.Insert(0,new ListItem("全部","@"));
           // this.cbBustype.DataTextField = "全部";
           // this.cbBustype.DataValueField = "@";
            BindData(startDate, endDate);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string type = this.cbBustype.SelectedValue;
        string begin = this.txtBeginDate.Value;
        string end = this.txtEndDate.Value;
        if (begin.Length == 0 || end.Length == 0)
        {
            WebTools.Alert(this, "必须选择待统计的时间范围！");
            return;
        }
        if (type != "@")
        {
            this.BindData(begin, end, type);
        }
        else
        this.BindData(begin, end);
    }


    private void BindData(string begin, string end)
    {

        string sql = string.Format(_sqlPattern, begin, end);
        DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }
    private void BindData(string begin, string end, string type)
    {
        string sql = string.Format(_sqlPattern2, begin, end, type);
        DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }
    }

}
