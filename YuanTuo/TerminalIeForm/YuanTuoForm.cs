﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Win32;
using log4net;

namespace TerminalIeForm
{
    public partial class YuanTuoForm : Form
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        public YuanTuoForm()
        {
            InitializeComponent();
            SystemDefine.ShowTaskTools();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            //导航已取消
            //res://ieframe.dll/navcancl.htm#http://localhost:12346/BuyWebSiteDemo/YuanTuo/Index.aspx
            string urlTmp = this.webBrowser1.Document.Url.AbsoluteUri;
#if DEBUG
            if (log.IsDebugEnabled)
            {
                log.Debug("访问的地址为："+urlTmp);
            }
#endif
            if (urlTmp.StartsWith("res://ieframe.dll"))
            {
                this.timer1.Stop();
                this.NavigateNetError();
                return;
            }
            if (urlTmp == urlBaidu)
            {
                HtmlElement lg = this.webBrowser1.Document.GetElementById("lg");
                lg.Style = "display:none";
            }
            else if (urlTmp == urlRealRoadCondition)
            {
               HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                tables[0].Children[0].Children[0].Children[2].Children[0].Style = "display:none";
                tables[1].Style = "display:none";
                if (!this.timer1.Enabled)
                {
                    this.timer1.Start();
                }
                /*
                                for (int i = 0; i < tables.Count; i++)
                                {
                                    string str = tables[i].InnerHtml;
                                    string mmm=tables[0].Children[0].Children[0].Children[2].InnerHtml;
                                    Console.WriteLine(string.Format("获取的表格的内容为：{0},{1}",i,str));
                                    string ttt = "";

                                   // tables[0].Style = "display:none";
                                   // tables[1].Style = "display:none";
                                }
                 * */
            }
            else if (!urlTmp.StartsWith(urlHome))
            {
#if DEBUG
                Console.WriteLine("WebBrowser加载网页完成！");
                Console.WriteLine(System.DateTime.Now.ToShortTimeString()+"-"+urlTmp);
#endif
                this.timer1.Stop();
                this.timer1.Start();
                this.SetVerButtons(false);
                if (urlTmp.StartsWith(domainPrefix))
                {
                    this.btnReturnHome.Visible = false;
                }
                else
                {
                    this.btnReturnHome.Visible = true;
                }
            }
            
            else if (urlTmp.StartsWith(urlHome))
            {
                this.SetVerButtons(true);
                //if(GlobalTools.skypeForm==null)
                  //  this.timer1.Stop();
                //this.timer1.Start();
            }
           
            if (this.webBrowser1.Document.Title.IndexOf("无法显示该网页") != -1 || this.webBrowser1.Document.Title.IndexOf("导航已取消")!=-1)
            {
                this.NavigateNetError();
                return;
            }
            if (this.webBrowser1.Document.Title.IndexOf("自定义临时网页错误") != -1)
            {
                this.SetVerButtons(true);
                this.SetHorButtons(true);
                this.btnReturnHome.Visible = false;
                return;
            }


            foreach (HtmlElement archor in this.webBrowser1.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }

            //将所有的FORM的提交目标，指向本窗体
            foreach (HtmlElement form in this.webBrowser1.Document.Forms)
            {
                form.SetAttribute("target", "_self");

            }
           
#if DEBUG
            Console.WriteLine("浏览的地址是："+this.webBrowser1.Url.ToString());
            //无法显示该网页

            //净值
            Console.WriteLine("title:"+this.webBrowser1.Document.Title);
            Console.WriteLine("IsOffline:" + this.webBrowser1.IsOffline);

#endif
#if DEBUG
            if (log.IsDebugEnabled)
            {
                log.Debug("title:" + this.webBrowser1.Document.Title);
            }
#endif
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //设置不用浏览器打开新窗体
            e.Cancel = true;
        }

        private static string urlBaidu = "http://www.baidu.com/";

        private static string urlRealRoadCondition = "http://sslk.bjjtgl.gov.cn/roadpublish/Map/trafficOutNew1.jsp";

        private static string urlBeijingMember = "http://www.bjoil.com/";

        private static string urlCtrip = "http://www.ctrip.com";
        private static string urlHome = string.Empty;

        private static string domainPrefix = string.Empty;
        private void NavigateHome()
        {
            this.webBrowser1.Navigate(urlHome+"?t="+System.DateTime.Now.ToString("yyyyMMddHHmmss"));
            this.SetVerButtons(true);
            this.SetHorButtons(true);
            //this.webBrowser1.Document.Body.sr
        }

        private void NavigateNetError()
        {
            this.webBrowser1.Navigate(Application.StartupPath+"/NetError.htm");
            this.SetVerButtons(true);
            this.SetHorButtons(true);
            this.btnReturnHome.Visible = false;
            this.timerConnectNet.Interval = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["connectNetTime"].ToString()) * 1000;
            this.timerConnectNet.Stop();
            this.timerConnectNet.Start();
            //this.webBrowser1.Document.Body.sr
        }

        private static string locationPrefix = string.Empty;

        private void YuanTuoForm_Load(object sender, EventArgs e)
        {
            string width = System.Configuration.ConfigurationSettings.AppSettings["width"];
            string height = System.Configuration.ConfigurationSettings.AppSettings["height"];
            this.Size = new Size(Int32.Parse(width), Int32.Parse(height));
            this.Location = new Point(0, 0);
            urlHome = System.Configuration.ConfigurationSettings.AppSettings["configUrl"];
            domainPrefix = urlHome;
            // nowUrl.in
            domainPrefix = domainPrefix.Substring(domainPrefix.IndexOf(":") + 3);//http://之后的
            domainPrefix = domainPrefix.Substring(0, domainPrefix.IndexOf('/'));
            domainPrefix = "http://" + domainPrefix;
            locationPrefix = System.Configuration.ConfigurationSettings.AppSettings["locationPrefix"];
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.AutoScroll = false;
            int unoperationTime = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["unoperationTime"])*1000;
            this.timer1.Interval = unoperationTime;
            this.timer1.Start();
            this.NavigateHome();
            SystemDefine.HideTaskTools();
            try
            {
                SkypeHelper.StartSkype();
            }
            catch
            {
                MessageBox.Show("Skype未能正常启动！！");
            }
            GlobalTools.yuantuoForm = this;
            HideHint();
           string topfirstTimer= System.Configuration.ConfigurationSettings.AppSettings["TopFirstTimer"];
           if (topfirstTimer == "true")
           {
               this.timerTopFirst.Start();
           }
           // this.webBrowser1.n
            
        }

        

        private void btnRealRoadCondition_Click(object sender, EventArgs e)
        {
            this.NavigateWeb(urlRealRoadCondition);
        }

        private void btnMemberService_Click(object sender, EventArgs e)
        {
            this.NavigateWeb(urlBeijingMember);
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            this.NavigateWeb(urlCtrip);
        }

        private void btnServicePhone_Click(object sender, EventArgs e)
        {
            string phone = System.Configuration.ConfigurationSettings.AppSettings["servicePhone"];
            SkypeHelper.Call(phone);
            this.BringToFront();
        }

        private void btnMagazine_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("易捷微刊");
        }
        public void SetHint(string hint)
        {
            if (hint.Length > 0)
            {
                this.panelHint.Visible = true;
            }
            this.lbHint.Text = hint;
        }

        public void HideHint()
        {
            this.panelHint.Visible = false;
        }
        

        private void btnFreePhone_Click(object sender, EventArgs e)
        {
            try
            {
              //  string skypePath = System.Configuration.ConfigurationSettings.AppSettings["skypePath"];
               // System.Diagnostics.Process.Start(skypePath);
              //  SkypeForm form = new SkypeForm();
            //    form.Show();
               // form.TopLevel = true;
                GlobalTools.CallSkype();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            //this.webBrowser1.Navigate(urlHome);
            this.NavigateHome();
        }

        private string GetLocationHtml(string type)
        {
            return string.Format("{1}\\终端本地文件\\{0}\\{0}.htm", type, locationPrefix);
        }

        private void SetVerButtons(bool visible)
        {
            this.btnRealRoadCondition.Visible = this.btnMemberService.Visible
                    = this.btnMagazine.Visible = this.btnFreePhone.Visible
                    = this.btnServicePhone.Visible = this.btnTickets.Visible
                    = visible;
            this.btnReturnHome.Visible = !visible;
            
        }

        private void SetHorButtons(bool visible)
        {
            this.btnBenQiTopic.Visible = visible;
            this.btnWeiGuanDian.Visible = visible;
            this.btnKanke.Visible = visible;
            this.btnShike.Visible = visible;
            this.btnJiaqu.Visible = visible;
            this.btnReturnHome.Visible = !visible;
            this.btnHks.Visible = visible;
        }
        private void NavigateWeb(string url)
        {
            this.webBrowser1.Navigate(url);

            this.SetVerButtons(false);
            this.SetHorButtons(false);
            
        }

        private void NavigateLocation(string type)
        {
            this.webBrowser1.Navigate(this.GetLocationHtml(type));
            this.SetVerButtons(false);
            this.SetHorButtons(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.GetLocationHtml("本期专题"));
        }

        private void btnBenQiTopic_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("本期专题");
        }

        private void btnWeiGuanDian_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("微观点");
        }

        private void btnKanke_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("看客");
        }

        private void btnShike_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("食客");
        }

        private void btnJiaqu_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("驾趣");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.timer1.Stop();
#if DEBUG
            Console.WriteLine(DateTimeHelper.DtToLongString(System.DateTime.Now) + "-" + "时间到进行跳转！");
#endif
            GlobalTools.CloseSkypeForm();
            try
            {
                string urlTmp = this.webBrowser1.Document.Url.AbsoluteUri;
                if (!urlTmp.StartsWith(urlHome))
                {
                    this.NavigateHome();
                }
            }
            catch (Exception ex)
            {
            }
           
            this.timer1.Start();
        }

        private void timerConnectNet_Tick(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToShortTimeString()+"-"+"时间到进行跳转！");
#endif
            
            this.NavigateHome();
            this.timerConnectNet.Stop();
        }
        private int  WeatherDay = System.DateTime.Now.DayOfYear;

        private void timerAnotherDay_Tick(object sender, EventArgs e)
        {

            this.timerAnotherDay.Stop();
            DateTime dt=System.DateTime.Now;

            if (dt.DayOfYear > WeatherDay)
            {
#if DEBUG
                Console.WriteLine("夜晚刷新首页！！");
#endif
                WeatherDay = dt.DayOfYear;
                this.NavigateHome();
            }
            this.timerAnotherDay.Start();
        }

        private void YuanTuoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalTools.yuantuoForm = null;
            
            SystemDefine.ShowTaskTools();
            SkypeHelper.CloseSkype();
            
        }

        private void timerTopFirst_Tick(object sender, EventArgs e)
        {
            this.timerTopFirst.Stop();
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToShortTimeString()+"定时检测拨号窗体是否存在，结果为："+GlobalTools.skypeForm);
#endif
            if (GlobalTools.skypeForm == null)
            {
                this.BringToFront();
                SystemDefine.SetWindowTop(this.Handle);
            }
            this.timerTopFirst.Start();
        }

        private void panelHint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            SkypeHelper.HandOff();
        }

        private void btnHks_Click(object sender, EventArgs e)
        {
            this.NavigateLocation("香港卫视");
        }
    }
}
