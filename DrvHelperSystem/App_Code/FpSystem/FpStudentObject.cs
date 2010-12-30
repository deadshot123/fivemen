﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;

/// <summary>
///FpStudentObject 的摘要说明
/// </summary>
///
[SimpleTable("FP_STUDENT")] 
[Alias("学员表")]
public class FpStudentObject
{
    public FpStudentObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [SimpleColumn(Column= "IDCARD")]
    private string idcard;
    [SimpleColumn(Column="NAME")]
    private string name;
    [SimpleColumn(Column="SEX")]
    private string sex;
    [SimpleColumn(Column="BRITHDAY")]
    private DateTime brithday;
    [SimpleColumn(Column="PHONE")]
    private string phone;
    [SimpleColumn(Column="ADDRESS")]
    private string address;
    [SimpleColumn(Column="DRV_SCHOOL")]
    private string drv_school;
    [SimpleColumn(Column="DRV_TYPE")]
    private string drv_type;
    [SimpleColumn(Column="DRV_DOCNUM")]
    private string drv_docnum;
    [SimpleColumn(Column="REMARK")]
    private string remark;
    [SimpleColumn(Column="CREATER")]
    private string creater;
    [SimpleColumn(Column="CREATE_TIME")]
    private DateTime create_time;
    [SimpleColumn(Column="LASTMODIFY_TIME")]
    private DateTime lastmodify_time;
    [SimpleColumn(Column = "LESSON_ENTER_1")]
    private DateTime lesson_enter_1;
    [SimpleColumn(Column = "LESSON_LEAVE_1")]
    private DateTime lesson_leave_1;
    [SimpleColumn(Column = "LESSON_ENTER_2")]
    private DateTime lesson_enter_2;
    [SimpleColumn(Column = "LESSON_LEAVE_2")]
    private DateTime lesson_leave_2;


    [SimpleColumn(Column = "TRAIN_ENTER_1")]
    private DateTime train_enter_1;
    [SimpleColumn(Column = "TRAIN_LEAVE_1")]
    private DateTime train_leave_1;
    [SimpleColumn(Column = "TRAIN_ENTER_2")]
    private DateTime train_enter_2;
    [SimpleColumn(Column = "TRAIN_LEAVE_2")]
    private DateTime train_leave_2;
    [SimpleColumn(Column = "TRAIN_ENTER_3")]
    private DateTime train_enter_3;
    [SimpleColumn(Column = "TRAIN_LEAVE_3")]
    private DateTime train_leave_3;
    [SimpleColumn(Column = "TRAIN_ENTER_4")]
    private DateTime train_enter_4;
    [SimpleColumn(Column = "TRAIN_LEAVE_4")]
    private DateTime train_leave_4;
    [SimpleColumn(Column = "TRAIN_ENTER_5")]
    private DateTime train_enter_5;
    [SimpleColumn(Column = "TRAIN_LEAVE_5")]
    private DateTime train_leave_5;
    [SimpleColumn(Column = "TRAIN_ENTER_6")]
    private DateTime train_enter_6;
    [SimpleColumn(Column = "TRAIN_LEAVE_6")]
    private DateTime train_leave_6;
    [SimpleColumn(Column = "TRAIN_ENTER_7")]
    private DateTime train_enter_7;
    [SimpleColumn(Column = "TRAIN_LEAVE_7")]
    private DateTime train_leave_7;
    [SimpleColumn(Column = "TRAIN_ENTER_8")]
    private DateTime train_enter_8;
    [SimpleColumn(Column = "TRAIN_LEAVE_8")]
    private DateTime train_leave_8;


    

    
    public string IDCARD
    {
        get { return this.idcard; }
        set { this.idcard = value; }
    }
   
    public string NAME
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string SEX
    {
        get { return this.sex; }
        set { this.sex = value; }
    }
    

    public DateTime  BRITHDAY
    {
        get { return this.brithday ; }
        set { this.brithday = value; }
    }


    public string PHONE
    {
        get { return this.phone; }
        set { this.phone = value; }
    }

    public string ADDRESS
    {
        get { return this.address; }
        set { this.address = value; }
    }



    public string DRV_SCHOOL
    {
        get { return this.drv_school; }
        set { this.drv_school = value; }
    }


    public string DRV_TYPE
    {
        get { return this.drv_type; }
        set { this.drv_type = value; }
    }


    public string DRV_DOCNUM
    {
        get { return this.drv_docnum; }
        set { this.drv_docnum = value; }
    }

    public string REMARK
    {
        get { return this.remark; }
        set { this.remark = value; }
    }
   
    public string CREATER
    {
        get { return this.creater; }
        set { this.creater = value; }
    }


    public DateTime CREATE_TIME
    {
        get { return this.create_time; }
        set { this.create_time = value; }
    }


    public DateTime LASTMODIFY_TIME
    {
        get { return this.lastmodify_time; }
        set { this.lastmodify_time = value; }
    }

    public DateTime LESSON_ENTER_1
    {
        get { return this.lesson_enter_1; }
        set { this.lesson_enter_1 = value; }
    }

    public DateTime LESSON_LEAVE_1
    {
        get { return this.lesson_leave_1; }
        set { this.lesson_leave_1 = value; }
    }

    public DateTime LESSON_ENTER_2
    {
        get { return this.lesson_enter_2; }
        set { this.lesson_enter_2 = value; }
    }

    public DateTime LESSON_LEAVE_2
    {
        get { return this.lesson_leave_2; }
        set { this.lesson_leave_2 = value; }
    }






    public DateTime TRAIN_ENTER_1
    {
        get { return this.train_enter_1; }
        set { this.train_enter_1 = value; }
    }

    public DateTime TRAIN_LEAVE_1
    {
        get { return this.train_leave_1; }
        set { this.train_leave_1 = value; }
    }

    public DateTime TRAIN_ENTER_2
    {
        get { return this.train_enter_2; }
        set { this.train_enter_2 = value; }
    }

    public DateTime TRAIN_LEAVE_2
    {
        get { return this.train_leave_2; }
        set { this.train_leave_2 = value; }
    }

    public DateTime TRAIN_ENTER_3
    {
        get { return this.train_enter_3; }
        set { this.train_enter_3 = value; }
    }

    public DateTime TRAIN_LEAVE_3
    {
        get { return this.train_leave_3; }
        set { this.train_leave_3 = value; }
    }

    public DateTime TRAIN_ENTER_4
    {
        get { return this.train_enter_4; }
        set { this.train_enter_4 = value; }
    }

    public DateTime TRAIN_LEAVE_4
    {
        get { return this.train_leave_4; }
        set { this.train_leave_4 = value; }
    }

    public DateTime TRAIN_ENTER_5
    {
        get { return this.train_enter_5; }
        set { this.train_enter_5 = value; }
    }

    public DateTime TRAIN_LEAVE_5
    {
        get { return this.train_leave_5; }
        set { this.train_leave_5 = value; }
    }

    public DateTime TRAIN_ENTER_6
    {
        get { return this.train_enter_6; }
        set { this.train_enter_6 = value; }
    }

    public DateTime TRAIN_LEAVE_6
    {
        get { return this.train_leave_6; }
        set { this.train_leave_6 = value; }
    }

     public DateTime TRAIN_ENTER_7
    {
        get { return this.train_enter_7; }
        set { this.train_enter_7 = value; }
    }

    public DateTime TRAIN_LEAVE_7
    {
        get { return this.train_leave_7; }
        set { this.train_leave_7 = value; }
    }

    public DateTime TRAIN_ENTER_8
    {
        get { return this.train_enter_8; }
        set { this.train_enter_8 = value; }
    }

    public DateTime TRAIN_LEAVE_8
    {
        get { return this.train_leave_8; }
        set { this.train_leave_8 = value; }
    }



}