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
using FT.DAL;

public partial class FpSystem_FpHelper_FpRecordCollect : System.Web.UI.Page
{

    private const string ACTION_NAME="ACTION_RECORD_COLLECT";
    private const int ACTION_NONE = 0;
    private const int ACTION_NEW_ENROLL_STUDENT = 1;
    private const int ACTION_VERIFY_STUDENT = 2;
    private const int ACTION_IDENTITY_STUDENT = 3;
    private FpBase _FP;
    

   

    protected void Page_Load(object sender, EventArgs e)
    {
        this._FP = new FpBase(this,new EventHandler(TrustLink_OperDlgPostEvent));
        if(Request.Params[FPSystemBiz.PARAM_RESULT]!=null)
        {
            this.txtIDCard.Text=Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
            FpStudentObject lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text);
            this.fnUIQuerySucess(lObjStudent != null);
    
        }
    }
    protected void btnQueryStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        FpStudentObject lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text);
        if (lObjStudent == null)
        {
            this.fnUIQuerySucess(false);
            return;
        }
        else
        {
            this.fnUIQuerySucess(true);
            Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsolutePath, FPSystemBiz.PARAM_RESULT, this.txtIDCard.Text.Trim()));
        }
        

    }
    protected void btnVerifyStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        _FP.FpVerifyUser(this.txtIDCard.Text);
        Session[ACTION_NAME] = ACTION_VERIFY_STUDENT;
    }



    protected void btnNewEnrolStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        string lStrIDCard = this.txtIDCard.Text.Trim();
        if (_FP.FpNewUser(lStrIDCard) == 31)
            _FP.FpUpdateUser(lStrIDCard);
        Session[ACTION_NAME] = ACTION_NEW_ENROLL_STUDENT;
    }

    protected void btnIdentity_Click(object sender, EventArgs e)
    {
        _FP.FpIdentityUser();
        Session[ACTION_NAME] = ACTION_IDENTITY_STUDENT;
    }



    protected void btnSaveStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        string lStrIDCard = this.txtIDCard.Text.Trim();
        FpStudentObject lObjStu = new FpStudentObject();
        lObjStu.IDCARD = this.txtIDCard.Text.Trim();
        lObjStu.NAME = "hhlin";
        if (FPSystemBiz.fnAddOrEditStudentRecord(lObjStu))
        {
            fnUISaveStudentInfoSucess(true);
        }
    }



    /// <summary>
    /// Process user action after operation fingerprint
    /// Notice: if don't process user operation fingerprint then use the TrustLinkGereralControler achieve the Result
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TrustLink_OperDlgPostEvent(object sender, EventArgs e)
    {
        ResultCodeArgs re = (ResultCodeArgs)e;
        string[] lArrUserIds = FpBase.getUserIds(re);
        FpStudentObject lObjStudent = null;
        int lIntAction =ACTION_NONE;
        if (Session[ACTION_NAME] == null)
            return;
        try {
            lIntAction = int.Parse(Session[ACTION_NAME].ToString());
        }catch(Exception ex)
        {
            lIntAction = ACTION_NONE;
        }
        switch (lIntAction)
        {
            case ACTION_NONE: break;
            case ACTION_NEW_ENROLL_STUDENT:
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text.Trim());
                if (lObjStudent == null)
                {
                    this.fnUINewEnrollStudentSucess(false);
                    return;
                }
                else
                {
                    this.fnUINewEnrollStudentSucess(true);
                }
                break;
            case ACTION_VERIFY_STUDENT:
                if (lArrUserIds.Length < 1)
                    return;
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(lArrUserIds[0].ToString());
                if (lObjStudent == null)
                {
                    this.fnUIVerifyStudentInfoSucess(false);
                    return; 
                }
                else
                {
                    this.fnUIVerifyStudentInfoSucess(true);
                    Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsolutePath, FPSystemBiz.PARAM_RESULT, this.txtIDCard.Text.Trim()));
                }
                

                break;
            case ACTION_IDENTITY_STUDENT:
                if (lArrUserIds.Length < 1)
                {
                    //this.lbIdentityAlertMsg.Text = "没有该学员的指纹信息";
                    return;
                } lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(lArrUserIds[0].ToString());
                if (lObjStudent == null)
                {
                    this.lbIdentityAlertMsg.Text = "没有该学员的信息";
                    return;
                }
                Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsolutePath, FPSystemBiz.PARAM_RESULT, this.txtIDCard.Text.Trim()));
   
                this.btnSaveStudent.Visible = true;
                this.lbIdentityAlertMsg.Text = "";
                break;

        }
    }


    
    private void fnUIQuerySucess( Boolean bl)
    {
        if (bl)
        {
            this.lbQueryAlertMsg.Text = "";
            this.btnSaveStudent.Visible = true;
        }
        else
        {
 
            this.lbQueryAlertMsg.Text = "没有该学员的信息";
            this.btnSaveStudent.Visible = false;
        }
    }

    private void fnUISaveStudentInfoSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存成功，可进行指纹采集";
            this.btnNewEnrolStudent.Visible = true;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存失败";
            this.btnNewEnrolStudent.Visible = true;
            this.btnNewEnrolStudent.Visible = false;
        }
    }

    private void fnUINewEnrollStudentSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹采集成功";
            this.btnVerifyStudent.Visible = true;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹采集失败";
            this.btnVerifyStudent.Visible = false;
        }
    }


    private void fnUIVerifyStudentInfoSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹匹配正确";
            this.btnVerifyStudent.Visible = true;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹匹配错误";
            this.btnVerifyStudent.Visible = false;
        }
    }


    /**
    private void fnUISetStudentInfo(FpStudentObject fso)
    {
        this.lbXm.Text = fso.NAME;
        this.lbIdCard.Text = fso.IDCARD;
    }
    **/
   
}