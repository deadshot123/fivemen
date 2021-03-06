﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using log4net;
using System.Drawing;
using FT.Commons.Tools;
using FT.WebServiceInterface.DrvQuery;
namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DriverInterface 的摘要说明
    /// </summary>
    public class DriverInterface
    {

/*
         
接口类型：写入类接口
接口标识：02C69
功能说明：供各地外挂系统将初学、增驾、补换证等业务的预录入信息写入驾驶证系统的预录入表（drv_temp_mid表）
传入参数：流水号,身份证明号码,身份证明名称,号码长度,姓名,性别,出生日期,国籍,登记住所行政区划,登记住所详细地址,联系住所行政区划,联系住所详细地址,联系住所邮政编码,来源,行政区划,联系电话,暂住证明号码,准考证明编号,档案编号,准考车型,驾校名称,身高,左视力,右视力,辨色力,听力,上肢,左下肢,右下肢,躯干颈部,体检日期,体检医院名称,手机号码,电子邮箱。
WriteXmlDoc文档说明：节点标签DrvtempMid，写入数据字段如下表：

         
*/

/*

接口类型：写入类接口
接口标识：02C77
功能说明：供各地照相系统调用，写入或更新驾驶人的照片信息。更新驾驶人照片表中相关字段（drv_photo表）。
传入参数：身份证明号码、照片。
WriteXmlDoc文档说明：节点标签drvphoto，写入数据字段如下表：
序号	参数项	名称	类型	长度	是否可空	备注
1	sfzmhm	身份证明号码	varchar2	18	不可空	
2	zp	照片	blob		不可空	Base64字符串格式
返回结果XML文档：retcode（标记，1成功；非1失败）、retdesc（描述信息）

*/
        protected static ILog log = log4net.LogManager.GetLogger("DriverInterface");
        public DriverInterface()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        #region 模拟获取用户的接口
        public static BusAllInfo GetFromUser(string idcardtype, string idcard, string dabh)
        {
            BusAllInfo info = new BusAllInfo();
            info.Dabh = "200120234";
            info.Lsh = "44040120101022";
            info.IdCardType = "身份证明号码";
            info.IdCard = "350128198403122135";
            info.Nation = "中国";
            info.CarType = "C1";
            info.Birthday = "1984-03-12";
            info.Sex = "男";
            info.Xm = "模拟用户1";
            info.CheckDate = "2010-10-02";
            return info;
        }

        public static bool WriteBusAllInfo(BusAllInfo info)
        {
            return true;
        }
        #endregion

        #region Tmri新接口

        private static TmriJaxRpcOutAccessService GetNewService()
        {
            TmriJaxRpcOutAccessService service = new TmriJaxRpcOutAccessService();
            //service.AllowAutoRedirect
            //service.RequestEncoding = System.Text.Encoding.UTF8;
           // service.SoapVersion
            log.Debug("服务默认的编码是：" + service.RequestEncoding);
            //TestLog.Log("服务的URL：" + service.Url);
            //service
            service.Url = System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrl"];
            log.Debug("服务的URL：" + service.Url);
           // TestLog.LogStep();
            TestLog.Log("服务的URL：" + service.Url);
            service.Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrl-Timeout"]);
            return service;
        }

        public static TmriResponse WriteDrvBaseTmriRequest(string xtlb,string jkxlh,string jkid,string xml)
        {
            log.Debug("预约写入接口的xtlb：" + xtlb);
            log.Debug("预约写入接口的jkxlh：" + jkxlh);
            log.Debug("预约写入接口的jkid：" + jkid);
            log.Debug("预约写入接口的文本为：" + xml);


            string responseText = "";
            try
            {
                responseText = GetNewService().writeObjectOut(xtlb,jkxlh,jkid,xml);
            }
            catch (Exception exe)
            {
                log.Info(exe);
                return new TmriResponse();
            }
            log.Debug("调用写入接口返回的文本为：" + responseText);
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            log.Debug("返回的结果code为：" + response.Code);
            return response;

        }

        public static TmriResponse WriteDrvBaseTmriRequest(DrvBaseTmriRequest request)
        {
            log.Debug("预约写入接口的xtlb：" + request.GetXtlb());
            log.Debug("预约写入接口的jkxlh：" + request.GetJkxlh());
            log.Debug("预约写入接口的jkid：" + request.GetJkid());
            log.Debug("预约写入接口的文本为：" + request.ToXml());
           // TestLog.LogStep();
            TestLog.Log("预约写入接口的文本为：" + request.ToXml());
           
            string responseText = "";
            try
            {
                responseText = GetNewService().writeObjectOut(request.GetXtlb(), request.GetJkxlh(), request.GetJkid(), request.ToXml());
            }
            catch (Exception exe)
            {
                TestLog.Log("预约写入接口的返回为：" + exe.ToString());
                log.Info(exe);
                
                return new TmriResponse();
            }
            log.Debug("调用写入接口" + request.GetXtlb() + ";" + request.GetJkxlh() + ";" + request.GetJkid() + ";" + request.ToXml() + "返回的文本为：" + responseText);
            TestLog.Log("调用写入接口" + request.GetXtlb() + ";" + request.GetJkxlh() + ";" + request.GetJkid() + ";" + request.ToXml() + "返回的文本为：" + responseText);
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            log.Debug("返回的结果code为："+response.Code);
            //TestLog.Log("返回的结果code为：" + response.Code);
            return response;

        }

        public static TmriResponse WritePersonInfoChange(DrvPresonInfoChangeRequest request)
        {
            log.Debug("预约写入接口的xtlb：" + request.GetXtlb());
            log.Debug("预约写入接口的jkxlh：" + request.GetJkxlh());
            log.Debug("预约写入接口的jkid：" + request.GetJkid());
            log.Debug("预约写入接口的文本为：" + request.ToXml());

            string responseText = "";
            try
            {
                responseText = GetNewService().writeObjectOut(request.GetXtlb(), request.GetJkxlh(), request.GetJkid(), request.ToXml());
            }
            catch (Exception exe)
            {
                log.Info(exe);
                TmriResponse err = new TmriResponse();
                err.Message = exe.Message;
                return err;
            }
            log.Debug("调用写入接口返回的文本为：" + responseText);
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            return response;

        }

        public static TmriResponse WriteCarOwnerInfoChange(DrvCarOwnerInfoChangeRequest request)
        {
            log.Debug("预约写入接口的xtlb：" + request.GetXtlb());
            log.Debug("预约写入接口的jkxlh：" + request.GetJkxlh());
            log.Debug("预约写入接口的jkid：" + request.GetJkid());
            log.Debug("预约写入接口的文本为：" + request.ToXml());

            string responseText = "";
            try
            {
                responseText = GetNewService().writeObjectOut(request.GetXtlb(), request.GetJkxlh(), request.GetJkid(), request.ToXml());
            }
            catch (Exception exe)
            {
                log.Info(exe);
                TmriResponse err = new TmriResponse();
                err.Message = exe.Message;
                return err;
            }
            log.Debug("调用写入接口返回的文本为：" + responseText);
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            return response;

        }

        public static TmriResponse ReadStudentInfo(DrvStudentInfoRequest request) {

            string responseText = "";
            try
            {
                responseText = GetNewService().queryObjectOut(request.GetXtlb(), request.GetJkxlh(), request.GetJkid(), request.ToXml());
            }
            catch (Exception exe)
            {
                log.Info(exe);
                TmriResponse err = new TmriResponse();
                err.Message = exe.Message;
                return err;
            }
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            return response;
        }
        #endregion

        #region 老接口

        public static bool WriteApplyOld(DrvPresonApplyInfoRequest req)
        {

            string str = GetOldService().write_drvtempmid(req.Sfzmhm, req.Sfzmmc, req.Hmcd, req.Xm, req.Xb,
                req.Csrq, req.Gj, req.Djzsxzqh, req.Djzsxxdz, req.Lxzsxzqh, req.Lxzsxxdz,req.Lxzsyzbm,
                req.Ly,req.Xzqh,req.Lxdh,req.Zzzm,req.Zkzmbh,req.Dabh,req.Zkcx,req.Jxmc,
                req.Sg.ToString(),req.Zsl.ToString(),req.Ysl.ToString(),req.Bsl.ToString()
                ,req.Tl.ToString(),req.Sz.ToString(),req.Zxz.ToString(),req.Yxz.ToString(),
                req.Qgjb.ToString(),req.Tjrq,req.Tjyymc,req.Sn);
            //.write_drvimage(idcardtype, idcard, ImageHelper.ImageToBase64Str(img), sn);
            string code = XmlHelper.GetTextInXml(str, "//code");
            return code == "0";

        }


        public static bool WritePreasignOld(DrvPreasignRequest req)
        {

            string str = GetOldService().write_yyxx(req.Lsh, req.Xxsj, req.Kskm,req.Ksdd, req.Jbr,
                req.Dlr,req.Ykrq,req.Kscc,req.Kchp,req.Pxshrq,req.Sn);
            //.write_drvimage(idcardtype, idcard, ImageHelper.ImageToBase64Str(img), sn);
            string code=XmlHelper.GetTextInXml(str, "//code");
            return code == "0";
         
        }

        public static bool WritePersonPhoto(string idcardtype, string idcard,Image img)
        {
              //  tmpimgdata = WebService. GetService(config).write_drvimage(idcardtype, idcard,
        //                        ImageHelper.ImageToBase64Str(file.FullName), config.ServiceWriteSn);
            string sn =System.Configuration.ConfigurationManager.AppSettings["DriverInterface_WritePersonPhoto_Old_Sn"];
            string str=GetOldService().write_drvimage(idcardtype, idcard, ImageHelper.ImageToBase64Str(img), sn);
            string code=XmlHelper.GetTextInXml(str, "//code");
            return code == "0";
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public static string GetPersonPhoto(string idcard)
        {
            return GetPersonPhoto("A", idcard);
        }
        /// <summary>
        /// 身份证明类别+身份证明号码查询
        /// </summary>
        /// <param name="idcardtype"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public static  string GetPersonPhoto(string idcardtype, string idcard)
        {
            string result = string.Empty;
            try
            {
                result = GetOldService().getDrvImage(idcardtype, idcard, System.Configuration.ConfigurationManager.AppSettings["getDrvimage-old-sn"]);

            }
            catch (Exception exe)
            {
                log.Info(exe);
                return string.Empty;
            }
            log.Debug("获取照片返回的xmldoc结果为："+result);
            DrvOldGetImageResponse response = new DrvOldGetImageResponse();
            response.ParseFromXml(result);
            if (response.zp != null && response.zp.Length > 0)
            {
                result=response.zp;
            }
            else
            {
                result = string.Empty;
            }
            return result;

        }
        #endregion

        private static DrvService GetOldService()
        {
            DrvService srv = new DrvService();
            srv.Url = System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrlOld"];
            srv.Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrlOld-Timeout"]);
            return srv;
        }
    }
}
