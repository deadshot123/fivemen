﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using FT.Commons.Tools;
using HiPiaoTerminal.CommonForm;
using FT.Windows.Controls.PanelEx;
using HiPiaoInterface;
using HiPiaoTerminal.Maintain;
//using HiPiaoTerminalWpf;
using HiPiaoTerminal.Account;
using HiPiaoTerminal.BuyTicket;
using HiPiaoTerminal.ConfigModel;
using HiPiaoTerminal.UserControlEx;
using FT.Windows.Controls.TextBoxEx;
using System.Collections;
using FT.Commons.Win32;
using log4net;

namespace HiPiaoTerminal
{
    /// <summary>
    /// 全局工具，界面跳转
    /// </summary>
    public class GlobalTools
    {
        private GlobalTools()
        {
        }

        

        public static bool PrintTickets(ArrayList lists)
        {
#if DEBUG

           // MessageBox.Show("准备打印的影票个数为："+lists.Count.ToString());
#endif
            if (lists != null)
            {
               // MyOpaqueLayerTools.ShowOpaqueLayer(this.panelHeader, 60, true);
                if (!GlobalHardwareTools.OpenHotPrinter())
                {
                    GlobalTools.Pop("打印机打开错误，请检查！");
                    return false;
                }
                else
                {
                    for (int i = 0; i < lists.Count; i++)
                    {
#if DEBUG

                 //   MessageBox.Show("正在打印第"+i+"个影票");
#endif
                        if (lists[i] is TicketPrintObject)
                        {
                            GlobalHardwareTools.PrintTicket(lists[i] as TicketPrintObject);
                        }
                        else
                        {
                            GlobalHardwareTools.PrintSellProduct(lists[i] as SellProductPrinter);
                        }
                    }
                    GlobalHardwareTools.CloseHotPrinter();
                    return true;
                }

            }
            return false;
        }

        public static bool PrintTickets(string mobile, string validCode)
        {
            string msgType = "30";
            //string str = this.txtMobile.Text.Trim() + "\t" + this.txtValidCode.Text.Trim() + "\t" + this.txtFlag.Text.Trim() + "\n";
            string str = "1,2,3,4,5,6,7\r1,2,3\r" + mobile + "\t" + validCode + "\t0\n";
            //str = msgType + str;
            //helper.Send(str);
            //HipiaoTcpHelper.GetTicket(str);
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
           return  PrintTickets(HipiaoTcpHelper.GetTicket(config.CinemaServerIp, config.CinemaServerPort, HiPiaoProtocol.PackSend(msgType, str)));
        }

       // public 

        public static void PrintTickets(TicketPrintObject ticket)
        {
            if (ticket != null)
            {
                // MyOpaqueLayerTools.ShowOpaqueLayer(this.panelHeader, 60, true);
                GlobalHardwareTools.OpenHotPrinter();
                GlobalHardwareTools.PrintTicket(ticket);
                
                GlobalHardwareTools.CloseHotPrinter();

            }
        }

        public static void MaskFormKeyDown(Form maskKeyForm)
        {
          //  maskKeyForm.FormClosing += new FormClosingEventHandler(maskKeyForm_FormClosing);
          //  maskKeyForm.Load += new EventHandler(maskKeyForm_Load);
            //  ctr.PreviewKeyDown += new PreviewKeyDownEventHandler(ctr_PreviewKeyDown);
        }

        static void maskKeyForm_Load(object sender, EventArgs e)
        {
            WinFormHelper.HookStart();
        }

        static void maskKeyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinFormHelper.HookStop(0);
        }


        public static void MaskFormKeyDownControl(Control ctr)
        {
            ctr.KeyDown += new KeyEventHandler(GlobalTools.ctr_KeyDown);
          //  ctr.PreviewKeyDown += new PreviewKeyDownEventHandler(ctr_PreviewKeyDown);
        }

        static void ctr_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
            {
               //e.k
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F1
                || e.KeyCode == Keys.F2
                || e.KeyCode == Keys.F3
                || e.KeyCode == Keys.F4
                || e.KeyCode == Keys.F5
                || e.KeyCode == Keys.F6
                || e.KeyCode == Keys.F7
                || e.KeyCode == Keys.F8
                || e.KeyCode == Keys.F9
                || e.KeyCode == Keys.F10
                || e.KeyCode == Keys.F11
                || e.KeyCode == Keys.F12
                || e.KeyCode == Keys.LWin
                || e.KeyCode == Keys.RWin
                || e.KeyCode == Keys.Alt
                || e.KeyCode == Keys.Control
                )
            {
                //e.Handled = true;
            }
        }

       public static void ctr_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
             {
　　             e.Handled = true;
　           }
             else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F1
                 || e.KeyCode == Keys.F2
                 || e.KeyCode == Keys.F3
                 || e.KeyCode == Keys.F4
                 || e.KeyCode == Keys.F5
                 || e.KeyCode == Keys.F6
                 || e.KeyCode == Keys.F7
                 || e.KeyCode == Keys.F8
                 || e.KeyCode == Keys.F9
                 || e.KeyCode == Keys.F10
                 || e.KeyCode == Keys.F11
                 || e.KeyCode == Keys.F12
                 || e.KeyCode==Keys.LWin
                 || e.KeyCode == Keys.RWin
                 || e.KeyCode == Keys.Alt
                 || e.KeyCode == Keys.Control
                 )
             {
                 e.Handled = true;
             }
        }
        
        // 屏蔽按键需求
           // CTRL 、ALT、windows、ESC、F1到F12


        public static void InitInterface(string url)
        {
            CommonHiPiaoStringOperator.InitInterface(url);
        }

        public static FullScreenSeatSelectorForm fullScreenSeatSelectorForm = null;

        private static FullAdShowForm fullAdForm = new FullAdShowForm();
        public static void ShowFullAdForm()
        {
            if (!fullAdForm.Visible&&(MainForm.Controls[0] is MainPanel))
            {
#if DEBUG
                Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"开始显示全屏广告!");
#endif
                fullAdForm.BringToFront();
                fullAdForm.ShowDialog();
            }
        }

        public static void HideFullAdForm()
        {
            if (fullAdForm.Visible)
            {
#if DEBUG
                Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "开始隐藏全屏广告!");
#endif
                fullAdForm.Hide();
               // fullAdForm.ShowDialog();
            }
        }

        private static VitualKeyBoardPanel allKeyBoard=new VitualKeyBoardPanel();

        private static VitualKeyBoardPanel2 allKeyBoard2 = new VitualKeyBoardPanel2();

        private static VitualKeyboardForm allKeyBoardForm = new VitualKeyboardForm();
        private static VitualNumKeyboardForm numKeyBoardForm = new VitualNumKeyboardForm();

        public static void SetAllKeyBoardWithForm(TextBox txt, int keyboardType)
        {
            if (keyboardType == 7)
            {
                return;
            }
            Form frm=null;
            if (keyboardType == 1)
            {
                if (allKeyBoardForm == null)
                {
                    allKeyBoardForm = new VitualKeyboardForm();
                }
                frm = allKeyBoardForm;
                allKeyBoardForm.InputTextBox = txt;
#if DEBUG
                Console.WriteLine("SetAllKeyBoardWithForm开始显示键盘VitualKeyboardForm");
#endif
            }
            else
            {
                if (numKeyBoardForm == null)
                {
                    numKeyBoardForm = new VitualNumKeyboardForm();
                }
                frm = numKeyBoardForm;
                numKeyBoardForm.InputTextBox = txt;
#if DEBUG
                Console.WriteLine("SetAllKeyBoardWithForm开始显示键盘numKeyBoardForm");
#endif
            }
           

            Point point = txt.Parent.PointToScreen(txt.Location);
#if DEBUG
            Console.WriteLine("转化屏幕的坐标是：X=" + point.X.ToString() + "=Y=" + point.Y.ToString());
#endif
            int height = txt.Parent.Parent.Height;
            // allKeyBoard2.InputTextBox = txt;
#if DEBUG
            Console.WriteLine("userinput下划线的坐标是：X=" + txt.Parent.Location.X.ToString() + "=Y=" + txt.Parent.Location.Y.ToString() + "userinput高度:" + height.ToString() + "键盘窗体高度：" + frm.Height.ToString() + "键盘窗体宽度：" + frm.Width.ToString());
#endif
            frm.Hide();
#if DEBUG
            Console.WriteLine("转化前键盘的坐标是：X=" + frm.Location.X.ToString() + "=Y=" + frm.Location.Y.ToString()+"-txt所在窗体的宽度为："+txt.FindForm().Width.ToString());
#endif
            int tmpx = point.X;

            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            if (SW< tmpx + frm.Width)
            {
                tmpx =SW - frm.Width - 30;
            }
           // if (txt.FindForm().Width < tmpx + frm.Width)
          //  {
                //tmpx = txt.FindForm().Width - frm.Width - 30;
           // }
            
           

            if (point.Y > frm.Height+14)
            {
                
                if (txt is HintTextBox)
                {
                    frm.Location = new Point(tmpx - 14, point.Y - frm.Height - 15);
                }
                else
                {
                    frm.Location = new Point(tmpx, point.Y - frm.Height);
                }
            }
            else
            {
                if (txt is HintTextBox)
                {
                    frm.Location = new Point(tmpx - 14, point.Y + height - 14 + 1);
                }
                else
                {
                    frm.Location = new Point(tmpx, point.Y + height + 1);
                }
            }
            frm.TabStop = false;
#if DEBUG
            //allKeyBoardForm.BringToFront();
            Console.WriteLine("转化后键盘的坐标是：X=" + frm.Location.X.ToString() + "=Y=" + frm.Location.Y.ToString());
#endif
            // frm.ShowDialog();
           // frm.Show();
            frm.Visible = true;
        }

        public static void HideAllKeyBoard()
        {
            allKeyBoard2.InputTextBox = null;
            allKeyBoard2.Visible = false;
            allKeyBoard.InputTextBox = null;
            allKeyBoard.Visible = false;
            allKeyBoardForm.InputTextBox = null;
            allKeyBoardForm.Visible = false;
            //allKeyBoardForm.Hide();
            
            numKeyBoardForm.InputTextBox = null;
            numKeyBoardForm.Visible = false;
            //numKeyBoardForm.Hide();
        }

        public static void SetAllKeyBoard(TextBox txt)
        {
            
            allKeyBoard2.InputTextBox = txt;
           
            Point point = txt.Parent.PointToScreen(txt.Location);
#if DEBUG
            Console.WriteLine("转化屏幕的坐标是：X=" + point.X.ToString() + "=Y=" + point.Y.ToString());
#endif
            Form frm = allKeyBoard2.FindForm();

            if (frm == null)
            {
               
                txt.FindForm().Controls.Add(allKeyBoard2);
            }
            else
            {
                frm.Controls.Remove(allKeyBoard2);
                txt.FindForm().Controls.Add(allKeyBoard2);
               
            }

           // allKeyBoard2.InputTextBox = txt;
#if DEBUG
            Console.WriteLine("txt下划线的坐标是：X=" + txt.Location.X.ToString() + "=Y=" + txt.Location.Y.ToString() + "txt高度:" + txt.Height.ToString() + "键盘高度：" + allKeyBoard2.Height.ToString() + "键盘宽度：" + allKeyBoard2.Width.ToString());
            Console.WriteLine("转化前键盘的坐标是：X=" + allKeyBoard2.Location.X.ToString() + "=Y=" + allKeyBoard2.Location.Y.ToString());
#endif
            int tmpx = point.X-30;
            if (txt.FindForm().Width < point.X + allKeyBoard2.Width)
            {
                tmpx=txt.FindForm().Width-allKeyBoard2.Width-30;
            }
            if (point.Y > allKeyBoard2.Height + txt.Height)
            {
                allKeyBoard2.Location = new Point(tmpx, point.Y - allKeyBoard2.Height - txt.Height + 20);
            }
            else
            {
                allKeyBoard2.Location = new Point(tmpx, point.Y + txt.Height + 1);
            }
            allKeyBoard2.TabStop = false;
            allKeyBoard2.BringToFront();
#if DEBUG
            Console.WriteLine("转化后键盘的坐标是：X=" + allKeyBoard2.Location.X.ToString() + "=Y=" + allKeyBoard2.Location.Y.ToString());
#endif
            allKeyBoard2.Visible = true;
        }


        public static void SetAllKeyBoard2(TextBox txt)
        {

            allKeyBoard.InputTextBox = txt;
            Point point = txt.Parent.PointToScreen(txt.Location);
            Form frm = allKeyBoard.FindForm();

            if (frm == null)
            {
               // Console.WriteLine("");
                txt.FindForm().Controls.Add(allKeyBoard);
            }
            else
            {
                frm.Controls.Remove(allKeyBoard);
                txt.FindForm().Controls.Add(allKeyBoard);
            }

            if (point.Y > allKeyBoard.Height + txt.Height)
            {
                allKeyBoard.Location = new Point(point.X, point.Y - allKeyBoard.Height - txt.Height + 20);
            }
            else
            {
                allKeyBoard.Location = new Point(point.X, point.Y + txt.Height + 1);
            }
            allKeyBoard.Visible = true;
        }
        /*
        public static void PopFirstWpf(System.Windows.Controls.UserControl panel)
        {
            NotifyUserForm form = new NotifyUserForm(panel);
            
            form.ColorType = 2;
            form.ShowDialog();
            
        }
         * */

        public static void PopNetError()
        {
            GlobalTools.Pop("网络故障，请向影院工作人员垂询！", "或拨打400-601-5566");
        }

        public static void PopSecond(string hint1)
        {
            // MessageForm form = new MessageForm(hint1);
            //  form.ShowDialog();
            MessagePanelSecond panel = new MessagePanelSecond(hint1);
            Pop(panel, 1);
        }

        public static void Pop(string hint1)
        {
           // MessageForm form = new MessageForm(hint1);
          //  form.ShowDialog();
            MessagePanelFirst panel=new MessagePanelFirst(hint1);
            Pop(panel,1); 
        }

        public static void PopSeatSelectHint()
        {
            // MessageForm form = new MessageForm(hint1);
            //  form.ShowDialog();
            SelectSeatMessageFirst panel = new SelectSeatMessageFirst();
            Pop(panel, 1);
        }

        public static void PopFlashCardError()
        {
            // MessageForm form = new MessageForm(hint1);
            //  form.ShowDialog();
            SelectSeatMessageFirst panel = new SelectSeatMessageFirst("刷卡错误，请重试！");
            Pop(panel, 1);
        }


        public static void Pop(string hint1, string hint2)
        {
           // MessageForm form = new MessageForm(hint1, hint2);
            //form.ShowDialog();

            MessagePanelFirst panel = new MessagePanelFirst(hint1,hint2);
            Pop(panel, 1); 
        }

        public static void ChangePanel(Form frm,Control panel)
        {
           
                if (frm != null && panel != null)
                {

                    FT.Commons.Win32.WindowFormDelegate.RemoveAllControlFrom(frm);
                   
                   
                    frm.MaximizeBox = true;
                    frm.MinimizeBox = true;
                    frm.FormBorderStyle = FormBorderStyle.Sizable;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.WindowState = FormWindowState.Normal;
                    frm.Parent = null;
                    // MessageBox.Show("1-现有窗体宽度为Width：" + frm.Width.ToString() + ":Height:" + frm.Height.ToString());
                    frm.MaximumSize = new Size(panel.Width, panel.Height);
                    frm.MinimumSize = new Size(panel.Width, panel.Height);
                    frm.Width = panel.Width;
                    frm.Height = panel.Height;
                    //frm.WindowState = FormWindowState.Maximized;
                    //System.Threading.Thread.Sleep(1000);

                    //frm.
                    // MessageBox.Show("2-现有窗体宽度为Width：" + frm.Width.ToString() + ":Height:" + frm.Height.ToString());
                    // frm.Size = new Size(panel.Width, panel.Height);

                    // frm.BackColor = Color.Red;
                    panel.Dock = DockStyle.Fill;
                    //frm.StartPosition = FormStartPosition.CenterScreen;

                    WinFormHelper.CenterForm(frm);
                    FT.Commons.Win32.WindowFormDelegate.AddControlTo(frm, panel);

                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Invalidate();
                    // frm.ResumeLayout(true);
                    // frm.PerformLayout();
                    //MessageBox.Show("3-现有窗体宽度为Width：" + frm.Width.ToString() + ":Height:" + frm.Height.ToString());

                    //frm.Controls.Add(panel);
                }
            
        }

        public static DialogResult Pop(Control panel)
        {
            return Pop(panel, 1);
        }
        /// <summary>
        /// 启动全屏广告的倒计时
        /// </summary>
        public static void StartFullTimer()
        {
            if (MainForm != null)
            {
                if (MainForm.Controls.Count > 0&&popForms.Count==0)
                {
                    MainPanel oldPanel = MainForm.Controls[0] as MainPanel;
                    if (oldPanel != null)
                    {
#if DEBUG
                        Console.WriteLine("启动主界面控件的全屏广告倒计时");
#endif
                        oldPanel.StopAdTimer();
                        oldPanel.StartAdTimer();
                    }
                }
            }
        }
        /// <summary>
        /// 停止全屏广告的倒计时
        /// </summary>
        public static void StopFullTimer()
        {
            if (MainForm != null)
            {
                if (MainForm.Controls.Count > 0)
                {
                    MainPanel oldPanel = MainForm.Controls[0] as MainPanel;
                    if (oldPanel != null)
                    {
#if DEBUG
                        Console.WriteLine("停止主界面控件的全屏广告倒计时");
#endif
                        oldPanel.StopAdTimer();
                    }
                }
            }
        }


        public static DialogResult Pop(Control panel,int type)
        {
            GlobalTools.StopFullTimer();
            ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<ConfigModel.SystemConfig>();
            if (config.UseVirtualKeyboard)
            {
#if DEBUG
                Console.WriteLine("Pop方法开始隐藏小键盘");
#endif
                GlobalTools.HideAllKeyBoard();
            }
            if (config.UseMaskPanel)
            {
                return PopMask(panel,type);
            }
            else
            {
                return PopUnMask(panel,type);
            }
        }


        public static DialogResult PopMask(Control panel,int type)
        {
            InitUnOperationControl(panel);
           // MyOpaqueLayerTools.ShowOpaqueLayer(MainForm, 60, true);
           // return PopUnMask(panel, type);
           
            NotifyUserForm popForm2 = new NotifyUserForm(panel);
            //popForm2.FormClosing += new FormClosingEventHandler(popForm2_FormClosing);
            popForm2.ColorType = type;
           // popForm.Show();
           // return DialogResult.OK;
            popForm2.BringToFront();
            return popForm2.ShowDialog();
           
        }

        static void popForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalTools.StartFullTimer();
        }

        public static ArrayList popForms = new ArrayList();

        /// <summary>
        /// 定时关闭弹出窗口
        /// </summary>
        public static void CloseAllPopForms()
        {
            Form frm = null;
            for (int i = 0; i < popForms.Count; i++)
            {
                frm=popForms[i] as Form;
                frm.Close();

            }
            popForms.Clear();
            GlobalTools.StartFullTimer();
        }

        public static void popForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyOpaqueLayerTools.HideOpaqueLayer();
            for (int i = 0; i < popForms.Count; i++)
            {
                if (popForms[i] == sender)
                {
                    popForms.RemoveAt(i);
                    GlobalTools.StartFullTimer();
                    break;
                }

            }
        }

        public static DialogResult PopUnMask(Control panel,int type)
        {
            InitUnOperationControl(panel);
           // /*
           // GlobalTools.StopFullTimer();
           Form form =null;
           
           if (type == 1)
           {
               form = new FirstRoundNotifyForm();
           }
           else
           {
               form = new SecondRoundNotifyForm();
           }
           GlobalTools.popForms.Add(form);
           form.FormClosing += new FormClosingEventHandler(popForm_FormClosing);
                
                form.FormBorderStyle = FormBorderStyle.None;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Width = panel.Width;
                form.Height = panel.Height;
                //panel.Dock = DockStyle.Fill;
                //form.BackColor = Color.Red;
                //form.BackColor = Color.FromArgb(117, 117, 117);
                //form.Opacity = 0.6d;
                //form.TransparencyKey = Color.FromArgb(117, 117, 117);
                //form.BackgroundImage = TestResource.TestRegister;
                form.Controls.Add(panel);
                form.BringToFront();
               // form.FormClosing += new FormClosingEventHandler(form_FormClosing);
              return  form.ShowDialog();
            // */
           // Form form = new NotifyUserForm(panel);
            
            
           // return form.ShowDialog();

        }

        public static UserObject loginUser;

        public static void GoLoginPanel()
        {
            GlobalTools.GoPanel(new UserLoginPanel(0));
        }

        public static UserObject GetLoginUser()
        {
            if (loginUser == null)
            {
                GoLoginPanel();
                return null;
            }
            return loginUser;
        }

        /// <summary>
        /// 登陆账户
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public static bool LoginAccount(string memberId)
        {

            UserObject obj = HiPiaoInterface.HiPiaoOperatorFactory.GetHiPiaoOperator().Login(memberId);
            if (obj != null)
            {
                loginUser = obj;
                return true;
            }
            else
            {
                return false;
            }


        }

        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");


        public static void Log(object obj)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }

        /// <summary>
        /// 登陆账户
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public static bool LoginAccount(string uid, string pwd)
        {
            
                UserObject obj = HiPiaoInterface.HiPiaoOperatorFactory.GetHiPiaoOperator().Login(uid, pwd);
                if (obj != null)
                {
                    loginUser = obj;
                    return true;
                }
                else
                {
                    return false;
                }

                
        }
        /// <summary>
        /// 退出账户
        /// </summary>
        public static bool QuitAccount()
        {
            loginUser = null;
            GlobalTools.ReturnMain();
            return true;
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        public static bool QueryAccount()
        {
            HiPiaoInterface.HiPiaoOperatorFactory.GetHiPiaoOperator().QueryUser(GlobalTools.GetLoginUser());
            //GlobalTools.ReturnUserAccout();
            return true;
        }

        private static Timer UpdateTimer;

        private static Timer UnOperationTimer;

        private static Timer AutoCloseComputerTimer;
       

        public static void InitAll(Form form)
        {
            
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            GlobalTools.InitInterface(config.HiPiaoInterfaceUrl);
            RefreshMovieShowList();
            AutoCloseComputerTimer = new Timer();
            AutoCloseComputerTimer.Interval = 6000;
            AutoCloseComputerTimer.Tick += new EventHandler(AutoCloseComputerTimer_Tick);
            AutoCloseComputerTimer.Start();
            UpdateTimer = new Timer();
            UpdateTimer.Interval = 60000*config.UpdateMovieTime;
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Start();
            UnOperationTimer = new Timer();
            
            //UnOperationTimer.Interval = config.UnOperationTime*1000;
            UnOperationTimer.Interval = 1000;
            UnOperationMaxSecond = config.UnOperationTime;
            UnOperationTimer.Tick += new EventHandler(UnOperationTimer_Tick);
            UnOperationTimer.Start();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            MainForm = form;
            InitKeyboard();
        }
        private static bool isFirstKeyboardLoad = false;

        public static void InitKeyboard()
        {
            if (!isFirstKeyboardLoad)
            {
#if DEBUG
                Console.WriteLine("开始初始化小键盘");
#endif
                allKeyBoardForm.Show();
                allKeyBoardForm.Hide();

                numKeyBoardForm.Show();
                numKeyBoardForm.Hide();
                isFirstKeyboardLoad = true;
            }
        }

        static void AutoCloseComputerTimer_Tick(object sender, EventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            int hour = dt.Hour;
            int minute = dt.Minute;
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.AutoCloseComputer && hour == config.AutoCloseComputerHour && (config.AutoCloseComputerMinitues == minute || config.AutoCloseComputerMinitues == minute+1))
            {
                WindowExHelper.CloseComputer();
            }
        }

        static void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Stop();
            }
            if (UnOperationTimer != null)
            {
                UnOperationTimer.Stop();
            }
        }

        public static int UnOperationLeaveSecond = 30;
        private static int UnOperationMaxSecond = 30;

        public static void ResetUnOperationTime()
        {
            UnOperationLeaveSecond = UnOperationMaxSecond;
        }

        //主操作窗体，所有控件创建和销毁都在被窗体内
        public static Form MainForm;

        private static UpdateUnOperationTimeDelegate UpdateUnOperationTime;

        public static void RegistUpdateUnOperationTime(UpdateUnOperationTimeDelegate updateDelegate)
        {
            UpdateUnOperationTime = updateDelegate;
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]

        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);



        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);



        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]

        private static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);

        const int GWL_EXSTYLE = -20;

        const int WS_EX_TRANSPARENT = 0x20;

        const int WS_EX_LAYERED = 0x80000;

        const int LWA_ALPHA = 2;

        //弹出提示窗体时候的遮罩
        public static void Mask(Form form)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.Yellow;
            panel.TabIndex = 2999;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Transparent;
            
           // panel.BackColor = Color.FromArgb(65, 204, 212, 230);
            panel.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255); 
            
            form.Controls.Add(panel);
            panel.BringToFront();
            //SetWindowLong(form.Handle, GWL_EXSTYLE, GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

           // SetLayeredWindowAttributes(form.Handle, 0, 128, LWA_ALPHA);
        }

        //关闭提示窗体时候的遮罩
        public static void UnMask(Form form)
        {
            form.Controls.RemoveAt(0);
            //SetWindowLong(form.Handle, GWL_EXSTYLE, GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

           // SetLayeredWindowAttributes(form.Handle, 0, 128, LWA_ALPHA);
        }

        
        //未操作时候返回主界面
        static void UnOperationTimer_Tick(object sender, EventArgs e)
        {
            
            if (MainForm.Controls.Count > 0)
            {
                MainPanel panel = MainForm.Controls[0] as MainPanel;
                if (panel != null)
                {
                    UnOperationLeaveSecond = UnOperationMaxSecond;
                    UpdateUnOperationTime = null;
                    UnOperationTimer.Stop();
                    
                }
                else
                {

                    UnOperationLeaveSecond--;
#if DEBUG
                    Console.WriteLine("未操作时间剩余" + UnOperationLeaveSecond.ToString());
#endif
                    if (UpdateUnOperationTime != null)
                    {
                        UpdateUnOperationTime();
                    }
                    if (UnOperationLeaveSecond == 0)
                    {
#if DEBUG
                        Console.WriteLine("未操作时间已到，跳转到主界面");
#endif
                        CloseAllPopForms();
                        ReturnMain();

                    }
                }
            }
            
            
        }
        /// <summary>
        /// 停止未操作计数
        /// </summary>
        public static void StopUnOperationCounter()
        {
#if DEBUG
            Console.WriteLine("停止未操作计数");
#endif
            UnOperationTimer.Stop();
            UnOperationLeaveSecond = UnOperationMaxSecond;
        }
        /// <summary>
        /// 开始未操作计数
        /// </summary>
        public static void StartUnOperationCounter()
        {
#if DEBUG
            Console.WriteLine("开启未操作计数");
#endif
            UnOperationLeaveSecond = UnOperationMaxSecond;
            UnOperationTimer.Start();
        }

        static void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTimer.Stop();
            if (!FirstStart)
            {
                //DoSomeThing
                UpdateMovieShows();
            }
            else
            {
                FirstStart = false;
            }

            UpdateTimer.Start();
        }
        public static List<MovieObject> MovieShowList = new List<MovieObject>();

        private static readonly object synObj = new object();

        /// <summary>
        /// 是否程序初启动
        /// </summary>
        private static bool FirstStart = true;

        /// <summary>
        /// 定时更新影片显示内容。内容见于下载到MovieShows目录下
        /// </summary>
        public static void UpdateMovieShows()
        {
            //download new adshows
            RefreshMovieShowList();
        }

        

        

        /// <summary>
        /// 定时刷新影片显示内容
        /// </summary>
        public static void RefreshMovieShowList()
        {
            lock (synObj)
            {
                try
                {
#if DEBUG
                    Console.WriteLine("定时刷新热门电影和广告缓存"+System.DateTime.Now.ToString());
#endif
                    SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                   
                    HiPiaoCache.RefreshHotMovie(config.Province, config.City);
                    HiPiaoCache.RefreshAdvertisement(config.Cinema);
                    
                    /*
                    MovieShowList.Clear();
                    DirectoryInfo dir = new DirectoryInfo("MovieShows");
                    if (dir != null)
                    {
                        FileInfo[] files = dir.GetFiles();
                        MovieObject movie = null;
                        Image img = null;
                        for (int i = 0; i < files.Length; i++)
                        {

                            try
                            {
                                img = Image.FromFile(files[i].FullName);
                                movie = new MovieObject();
                                movie.AdImage = (Image)img.Clone();
                                movie.Name = files[i].Name;
                                MovieShowList.Add(movie);
                            }
                            catch (Exception ex)
                            {
                                //MessageBoxHelper.Show(ex.ToString());
                            }
                        }
                    }
                     * */

                   
                }
                catch(Exception ex)
                {
                    GlobalTools.Log(ex);
                    Console.WriteLine("定时刷新出现异常："+ex.ToString());
                    GlobalTools.PopNetError();
                }
            }
            //FileInfo

        }

        /// <summary>
        /// 初始化所有的控件操作，只要有操作就认为重算未操作时间
        /// </summary>
        /// <param name="ctr"></param>
        public static void InitUnOperationControl(Control ctr)
        {
            ctr.Click+=new EventHandler(ctr_Click);
            if (ctr.Controls.Count == 0)
            {
                if (ctr is Button || ctr is PictureBox)
                {
                    ctr.Click += new EventHandler(ctr_Click);
                    ctr.Enter += new EventHandler(ctr_Click);
                    ctr.Leave += new EventHandler(ctr_Click);
                }
                
            }
            foreach (Control tmp in ctr.Controls)
            {
                InitUnOperationControl(tmp);
            }
        }

        

        //private static

        public static void ShowInput(TextBox txt)
        {
            //.ShowToTextBox(txt);
             VitualKeyBoardPanel panel=new VitualKeyBoardPanel();
             panel.InputTextBox = txt;
            Form form = new Form();
           // Form formBorder = new Form();
           // formBorder.Paint += new PaintEventHandler(formBorder_Paint);
            //form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.FormBorderStyle = FormBorderStyle.None;
            panel.Paint += new PaintEventHandler(formBorder_Paint);
            form.Width = panel.Width;
            form.Height = panel.Height;
            panel.Dock = DockStyle.Fill;
            form.Controls.Add(panel);
            Point point=txt.FindForm().PointToScreen(txt.Location);
            form.StartPosition = FormStartPosition.Manual;
            if (point.Y > panel.Height+txt.Height)
            {
                form.Location = new Point(point.X, point.Y -panel.Height- txt.Height+20);
            }
            else
            {
                form.Location = new Point(point.X, point.Y + txt.Height+1);
            }
            
            //txt.Text = point.X.ToString() + "-" + point.Y.ToString()+"-"+txt.Height;
            //form.StartPosition = FormStartPosition.CenterParent;
            // form.Paint += new PaintEventHandler(form_Paint);
            // MainForm.BackColor = Color.Blue;
            form.ShowDialog();
        }

        static void formBorder_Paint(object sender, PaintEventArgs e)
        {
            Control frm = sender as Control;
            Color color = Color.OrangeRed;// Color.LightSeaGreen
            int width=1;
            ControlPaint.DrawBorder(e.Graphics,
                                frm.ClientRectangle,
                                color,//7f9db9
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// 仅仅显示提示信息，并点击确定的时候可设置是否返回操作首页
        /// </summary>
        /// <param name="text"></param>
        /// <param name="returnHome"></param>
        public static void ShowMessage(string text, bool returnHome)
        {
            /*
            NotifyUserInfoPanel ctr = new NotifyUserInfoPanel(text);
            ctr.ReturnHome = returnHome;
            ShowMessage(ctr);
             */
            MessageForm form = new MessageForm(text);
            form.ReturnHome = returnHome;
            form.ShowDialog();
        }
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="panel"></param>
        public static void ShowMessage(Control panel)
        {
            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.Width = panel.Width;
            form.Height = panel.Height;
            panel.Dock = DockStyle.Fill;
            form.Controls.Add(panel);
            form.StartPosition = FormStartPosition.CenterParent;
           // form.Paint += new PaintEventHandler(form_Paint);
           // MainForm.BackColor = Color.Blue;
            form.Load += new EventHandler(form_Load);
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
            form.ShowDialog();
        }

        static void form_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PaintSecondRound(sender,e);
        }

        static void form_Load(object sender, EventArgs e)
        {
           // Mask(MainForm);
            StopUnOperationCounter();
            
        }

        static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
           // MainForm.BackColor = SystemColors.Control;
           // UnMask(MainForm);
            StartUnOperationCounter();
        }

        static void ctr_Click(object sender, EventArgs e)
        {
            ResetUnOperationTime();
        }

        //隐藏光标
        public static void SetCursor()
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            
            if (!config.AllowShowMouse)
            {
               // Cursor.Current= Cursors.Hand;
                //this.Cursor 
               Cursor.Hide();
            }
            else
            {
                Cursor.Show();
            }
        }

        /// <summary>
        /// 返回主界面
        /// </summary>
        public static void GoPanel(Control panel)
        {
            try
            {
                if (MainForm != null)
                {
                    MainForm.AutoScroll = true;
                    if (GlobalTools.fullScreenSeatSelectorForm != null)
                    {
                        Form frm = GlobalTools.fullScreenSeatSelectorForm;
                        GlobalTools.fullScreenSeatSelectorForm = null;
                        frm.Close();
                    }
                    Control parent = MainForm;
                    if (parent.Controls.Count > 0)
                    {
                        MainPanel oldPanel = parent.Controls[0] as MainPanel;
                        if (oldPanel != null)
                        {
                            oldPanel.StopAdTimer();
                        }
                        parent.Controls.Clear();
                    }
#if DEBUG
                Console.WriteLine("GoPanel开始隐藏小键盘");
#endif
                    HideAllKeyBoard();
                    
                    WindowFormDelegate.AddControlTo(parent, panel);
                    //parent.Controls.Add(panel);
                    if (panel is MainPanel)
                    {
                        StopUnOperationCounter();
                    }
                    else if (panel is OperationTimeParentPanel)
                    {
                        StopUnOperationCounter();

                        InitUnOperationControl(parent.Controls[0]);
                    }
                    else
                    {
                        ResetUnOperationTime();
                        StopUnOperationCounter();
                        StartUnOperationCounter();
                        InitUnOperationControl(parent.Controls[0]);
                    }

                }
            }
            catch (Exception ex)
            {
                GlobalTools.Log(ex);
                MessageBox.Show("切换界面出现异常："+ex.ToString());
            }

        }

       
        /// <summary>
        /// 返回主界面
        /// </summary>
        public static void ReturnMain()
        {
            GlobalTools.CloseAllPopForms();
            GoPanel(new MainPanel());  
        }
        /// <summary>
        /// 快速购票
        /// </summary>

        public static void QuickBuyTicket()
        {
            //GlobalTools.GetLoginUser().IsBindMobile = false;
            if (!GlobalTools.GetLoginUser().IsBindMobile)
            {
                if (GlobalTools.Pop(new NotifyBindMobilePanel()) == DialogResult.OK)
                {
                   // GoPanel(new MovieSelectorPanel());
                }
            }
            else
            {
                GoPanel(new MovieSelectorPanel());
            }
           
            //InitUnOperationControl(parent.Controls[0]);   
        }

        public static bool Confirm(string str)
        {
            ConfirmForm form = new ConfirmForm(str);
            return form.ShowDialog()==DialogResult.OK;
        }

        public static int ErrorManagePwdTimes = 0;

        public static DateTime ErrorManagePwdLastTime = System.DateTime.Now;

        public static void ReturnMaintainWithPwd()
        {
            /*
            if (DialogResult.OK == Pop(new UnLockPanel()))
            {
                ReturnMaintain();
            }
             * */

            if (ErrorManagePwdTimes == 3)
            {
                DateTime now = System.DateTime.Now;
                TimeSpan time = now.Subtract(ErrorManagePwdLastTime);
                int times=(int)time.TotalMilliseconds;
                if (times < 5 * 1000 * 60)
                {
                    return;
                }
                else
                {
                    ErrorManagePwdTimes = 0;
                }
            }
            GoPanel(new ManagerLoginWithPwdPanel());
        }

        /// <summary>
        /// 用户跳转到维护界面
        /// </summary>
        public static void ReturnMaintain()
        {
            GoPanel(new ManagerFunctionsPanel());
        }

        /// <summary>
        /// 用户快速注册
        /// </summary>
        public static void QuickRegister()
        {
            GoPanel(new QuickRegisterPanel());
        }

        /// <summary>
        /// 影票打印
        /// </summary>
        public static void ReturnTicketPrint()
        {
            GoPanel(new TicketPrintPanel());
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public static void UserLogin()
        {
            GoPanel(new UserLoginPanel(0));   
        }

       
        /// <summary>
        /// 哈票网体验
        /// </summary>
        public static void UserTaste()
        {
            GoPanel(new UserTastePanel());
        }



        /// <summary>
        /// 用户账户
        /// </summary>
        public static void ReturnUserAccout()
        {
            //GlobalTools.LoginAccount("", "");
            UserObject user=GlobalTools.GetLoginUser();
            if (user != null)
            {
                GlobalTools.QueryAccount();
                GoPanel(new MyAccountPanel());
            }
        }


        




        public static void ToManagePanel()
        {

        }
    }

    /// <summary>
    /// 未操作时候的委托
    /// </summary>
    public delegate void UpdateUnOperationTimeDelegate();
}
