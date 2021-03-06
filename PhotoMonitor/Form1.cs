using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.NoUser;
using FT.Commons.Cache;
using FT.Windows.Forms.SimpleLog;
using FT.Commons.Tools;
using System.IO;
using System.Text.RegularExpressions;
using log4net;
using System.Xml;
using FT.Windows.ExternalTool;
using System.Web;
using PhotoMonitor.DrvNewService;


namespace PhotoMonitor
{
    public partial class Form1 : Form
    {

        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        //protected static ILog log = log4net.LogManager.GetLogger("tools");

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log != null && log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Info(object obj)
        {
            if (log != null && log.IsInfoEnabled)
            {
                log.Info(obj);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }

        private void 查看日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ChangePwd();
        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NoUserHelper.Unlock())
            {
                Form form=new SystemMonitorConfig();
                form.ShowDialog();
            }
        }

        public const string OptUserConst = "图片导入工具";

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemConfig config=StaticCacheManager.GetConfig<SystemConfig>();
            timer1.Interval = config.MonitorTimes;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            this.CreateLog("系统初启动");
        }

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = OptUserConst;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        //private DrvService service;
        //新接口调用类
        private TmriJaxRpcOutAccessService service;

      /*  private DrvService GetService(SystemConfig config)
        {

            if(service==null)
            {
                
                service = new DrvService();
                service.Url = config.ServiceIp;
            }
            return service;
        }
       */

        private TmriJaxRpcOutAccessService GetService(SystemConfig config) {
            if (service == null)
            {

                service = new TmriJaxRpcOutAccessService();
                service.Url = config.ServiceIp;
            }
            return service;
        }


        public void ImportPhto(SystemConfig config)
        {
            string tmp = "找到监控目录，进行照片导入！";
            this.CreateLog(tmp);
            this.SetHintText(tmp);
             DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
            string school=dir.GetDirectories()[0].Name;
            string impdate=System.DateTime.Now.ToString("yyyyMMddHHmmss");
             FileInfo[] files=dir.GetDirectories()[0].GetFiles();
            FileInfo file=null;
            string bakdir=config.BakPath + "/"
                             + school + "/" + impdate
                             + "/";
            FileHelper.CheckDirExistsAndCreate(bakdir);
            string nowzp = string.Empty;
            int success = 0;
            int error = 0;
           
            string idcardtype="A";
            string filename=string.Empty;
            string idcard = string.Empty;
            string tmpimgdata = string.Empty;
           
            
             for (int i = 0; i < files.Length;i++ )
             {
                 file = files[i];
                 this.SetHintText("正在处理"+file.Name);
                 if (file.Extension.ToUpper() == ".JPG" || file.Extension.ToUpper() == ".JPEG")
                 {
                     filename = file.Name;
                     try
                     {
                         if(filename.IndexOf("-")!=-1)
                         {
                             string[] filenames = filename.Split('-');
                             string tmpsplit = filenames[0];
                             if (!Regex.IsMatch(tmpsplit[0].ToString(), "[0-9]"))
                             {
                                 idcardtype = tmpsplit[0].ToString();
                                 idcard = tmpsplit.Substring(1);
                             }
                             else
                             {
                                 idcard = tmpsplit;
                                 if (idcard.Length == 15)
                                 {
                                     idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
                                 }
                                 
                                 if (FT.Commons.Tools.IDCardHelper.Validate(idcard).Length > 0)
                                 {
                                     
                                     error++;
                                     FileHelper.CheckDirExistsAndCreate(bakdir + "非法身份证号码/");
                                     this.CreateLog("非法身份证号码" + file.Name);
                                     File.Copy(file.FullName, bakdir + "非法身份证号码/" + file.Name, true);
                                     file.Delete();
                                     continue;
                                 }
                             }
                         }
                         else
                         {
                             if(! Regex.IsMatch(file.Name[0].ToString(),"[0-9]"))
                             {
                                 idcardtype=file.Name[0].ToString();
                                 idcard = filename.Substring(1, filename.IndexOf(".")-1);
                             }
                             else{
                                 idcard = filename.Substring(0, filename.IndexOf(".")-1);
                                 if (idcard.Length == 15)
                                 {
                                     idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
                                 }
                                 if(FT.Commons.Tools.IDCardHelper.Validate(idcard).Length>0)
                                 {
                                     error++;
                                     FileHelper.CheckDirExistsAndCreate(bakdir + "非法身份证号码/");
                                     this.CreateLog("非法身份证号码" + file.Name);
                                     File.Copy(file.FullName, bakdir + "非法身份证号码/" + file.Name, true);
                                     file.Delete();
                                     continue;
                                 }
                             }
                        }
                         tmpimgdata = string.Empty;
                             //= this.GetService(config).getDrvimageAsync(idcardtype, idcard, config.ServiceReadSn,null);
                         //log.Debug("读取驾驶人" + idcardtype + "-" + idcard + "照片信息");
                         //log.Debug("读取结果-》"+tmpimgdata);
                         //if(tmpimgdata!=null&&tmpimgdata.Length>0)
                        // {
                            // this.CreateLog("已存在照片" + file.Name);
                            // FileHelper.CheckDirExistsAndCreate(bakdir + "已存在照片/");
                            // File.Copy(file.FullName, bakdir +"已存在照片/"+ file.Name, true);
                            // file.Delete();
                             
                         //}
                         //else
                         //{

                         /*
                          <?xml version="1.0" encoding="utf-8" ?>
                          <root>
                          <drvphoto>
                             <sfzmhm></sfzmhm>
                             <zp></zp>
                          </drvphoto>
                          </root>
                          
                          public string writeObjectOut ("02","","02C77",String WriteXmlDoc)
                            
                          */
                         
 
                        // tmpimgdata =this.GetService(config).write_drvimage(idcardtype, idcard,
                        //         ImageHelper.ImageToBase64Str(file.FullName),config.ServiceWriteSn);
                         String base64Zp = ImageHelper.ImageToBase64Str(file.FullName);
                         byte[] bsZp = Encoding.UTF8.GetBytes(base64Zp);
                         String zpUtf8 = Encoding.UTF8.GetString(bsZp);
                         String writeXmlDoc = RemoteXmlHelper.toXml_02C77(idcard, zpUtf8);
                       tmpimgdata = this.GetService(config).writeObjectOut("02", config.ServiceWriteSn, "02C77", writeXmlDoc);

                             log.Debug("写入驾驶人" + idcardtype + "-" + idcard + "照片信息");
                             log.Debug(tmpimgdata);
                             //-31 ORA-00001 主键约束
                             //-31 ORA-12899:  超出范围
                             //0 成功

                             //if (tmpimgdata.StartsWith("0 成功"))
                             //{
                             //    if (config.SuccessBak)
                             //    {
                             //        File.Copy(file.FullName, bakdir + file.Name, true);
                             //    }
                             //    file.Delete();
                             //    success++;
                             //}
                             //else if (tmpimgdata.StartsWith("-31 ORA-00001"))
                             //{
                             //    error++;
                             //    FileHelper.CheckDirExistsAndCreate(bakdir + "已存在的照片/");
                             //    this.CreateLog("已存在的照片" + file.Name);
                             //    File.Copy(file.FullName, bakdir + "已存在的照片/" + file.Name, true);
                             //    file.Delete();
                             //}
                             //else
                             //{
                             //    //string message = this.GetTextInXml(tmpimgdata, "//message");
                             //    error++;
                             //    FileHelper.CheckDirExistsAndCreate(bakdir + "处理失败的照片/");
                             //    this.CreateLog("处理失败的照片" + file.Name + "失败的原因未知");
                             //    File.Copy(file.FullName, bakdir + "处理失败的照片/" + file.Name, true);
                             //    file.Delete();
                             //}


                         /*
                             string code = this.GetTextInXml(tmpimgdata, "//code");
                             log.Debug("返回的result-code为：" + "'" + code + "'");
                             if (code == "0")
                             {

                                 if (config.SuccessBak)
                                 {
                                     File.Copy(file.FullName, bakdir + file.Name, true);
                                 }
                                 file.Delete();
                                 success++;
                             }
                             else if (code == "-2")
                             {
                                 error++;
                                 FileHelper.CheckDirExistsAndCreate(bakdir + "已存在的照片/");
                                 this.CreateLog("已存在的照片" + file.Name);
                                 File.Copy(file.FullName, bakdir + "已存在的照片/" + file.Name, true);
                                 file.Delete();
                             }
                             else
                             {
                                 string message = this.GetTextInXml(tmpimgdata, "//message");
                                 error++;
                                 log.Debug("返回的message为：" + "'" + message + "'");
                                 FileHelper.CheckDirExistsAndCreate(bakdir + "处理失败的照片/");
                                 this.CreateLog("处理失败的照片" + file.Name + "失败的原因" + message);
                                 File.Copy(file.FullName, bakdir + "处理失败的照片/" + file.Name, true);
                                 file.Delete();
                             }
                         
                           */
                             string code = this.GetTextInXml(tmpimgdata, "//code");
                             string retcode = this.GetTextInXml(tmpimgdata, "//retcode");
                             log.Debug("返回的result-code为：" + "'" + code + "'");
                             if (code == "1"||retcode=="1")
                             {

                                 if (config.SuccessBak)
                                 {
                                     File.Copy(file.FullName, bakdir + file.Name, true);
                                 }
                                 try
                                 {
                                     file.Delete();
                                 }
                                 catch (Exception ex) { }
                                 success++;
                             }
 
                             else
                             {
                                 string message = this.GetTextInXml(tmpimgdata, "//retdesc");
                                 error++;
                                 log.Debug("返回的message为：" + "'" + message + "'");
                                 FileHelper.CheckDirExistsAndCreate(bakdir + "处理失败的照片/");
                                 this.CreateLog("处理失败的照片" + file.Name + "失败的原因" + message);
                                 File.Copy(file.FullName, bakdir + "处理失败的照片/" + file.Name, true);
                                 try{
                                 file.Delete();
                                 }
                                 catch (Exception ex) { }
                             }


                         //}
                         
                         
                     }
                     
                     catch (System.Exception ex)
                     {
                         log.Info("services的ip设置：" + this.GetService(config).Url);
                         log.Info(ex);
                         error++;
                         FileHelper.CheckDirExistsAndCreate(bakdir + "处理失败的照片/");
                         this.CreateLog("处理失败的照片" + file.Name + "失败的原因" + ex.Message);
                         File.Copy(file.FullName, bakdir + "处理失败的照片/" + file.Name, true);
                         try{
                               file.Delete();
                             }
                          catch (Exception ex1) { }
                     }
                     
                 }
                 else
                 {
                     error++;
                     this.CreateLog("非照片文件" + file.Name);
                     FileHelper.CheckDirExistsAndCreate(bakdir + "非照片文件/");
                     File.Copy(file.FullName, bakdir + "非照片文件/" + file.Name, true);
                     try{
                     file.Delete();
                     }
                     catch (Exception ex1) { }
                    
                 }
                 System.GC.Collect();
             }
             int all=error+success;
             this.SetHintText("处理完毕，共" + all.ToString() + "照片，成功" + success + "张，失败" + error + "张！");
            if(error>0)
            {
                if (MessageBoxHelper.Confirm("有"+error.ToString()+"张处理失败的照片，是否打开图片文件夹?"))
                System.Diagnostics.Process.Start("explorer.exe", bakdir.Replace("/","\\"));

            }

        }

        private String GetTextInXml(string xml, string xpath)
        {
            XmlDocument   doc=new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node=doc.SelectSingleNode(xpath);
            if(node!=null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "驾驶人图片监控软件-" + str;
        }

        /// <summary>
        /// 是否接口有效
        /// </summary>
        private bool InterfaceEnabled = true;

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if(this.InterfaceEnabled)
            {
                SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                if (FileHelper.CheckDirExists(config.MonitorPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);

                    if (dir.GetDirectories().Length > 0 && dir.GetDirectories()[0].GetFiles().Length > 0)
                    {
                        if (config.HintImport)
                        {
                            if (MessageBoxHelper.Confirm("发现监控目录，是否进行照片导入？"))
                            {
                                this.ImportPhto(config);
                            }
                        }
                        else
                        {
                            this.ImportPhto(config);
                        }
                    }

                }
                else
                {

                }

                timer1.Start();
            }
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "<?xml version=\"1.0\" encoding=\"GBK\" ?> "
+"<response><head><code>integer</code>"
+"<message>String</message>"
+"</head>"
+"<body>"
+"	    <rownum>int</rownum>"
+"	    <item>"
 +"<hpzl>string</hpzl>"
 +"<hphm>string</hphm>"
 +"<zp>string</zp>"
+"</item>"
+ "</body>"
+"</response>";
            Console.WriteLine(this.GetTextInXml(str, "//code"));
            Console.WriteLine(this.GetTextInXml(str, "//message"));
            Console.WriteLine(this.GetTextInXml(str, "//body"));
            Console.WriteLine(this.GetTextInXml(str, "//rownum"));
            Console.WriteLine(this.GetTextInXml(str, "//zp"));

            Form form = new Form();
            Control editor = new FT.Windows.Controls.Editor();
            editor.Dock = DockStyle.Fill;
            form.Controls.Add(editor);
            form.Show();
        }

        private void 图片转换测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image2Base64Test form = new Image2Base64Test();
            form.ShowInTaskbar = true;
            form.ShowDialog();
        }

    }
}