using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms.CommonForm;

namespace FT.Windows.Forms
{
    public partial class CaptureImage : DevExpress.XtraEditors.XtraForm
    {
        private Dragger dragger;
        public  CaptureImage()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public CaptureImage(int width,int height)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.panelSelect.Size = new Size(width,height);
        }

        private CapturePhotoSet set;

        public CaptureImage(CapturePhotoSet set)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.panelSelect.Size = new Size(set.CapWidth, set.CapHeight);
            this.panelSource.Size = new Size(set.DevWidth, set.DevHeight);
            this.Size = new Size(set.DevWidth + 100, set.DevHeight + 100);
            this.set = set;
        }

       // private Image image;
        private PictureBox pic;

        public CaptureImage(PictureBox pic)
            : this()
        {
            //this.image = image;
            this.panelSource.BackgroundImage = pic.Image;
            this.pic = pic;
            //dragger = new Dragger(this.panelSource, this.panelSelect, this.panelSelect.Location);
        }

        public CaptureImage(Image image,PictureBox pic):this()
        {
            //this.image = image;
            this.panelSource.BackgroundImage = image;
            this.pic = pic;
            //dragger = new Dragger(this.panelSource, this.panelSelect, this.panelSelect.Location);
        }

        public CaptureImage(Image image, PictureBox pic,int width,int height)
            : this(width,height)
        {
            //this.panelSelect.Size = new Size(width, height);
            this.panelSource.BackgroundImage = image;
            this.pic = pic;
            //dragger = new Dragger(this.panelSource, this.panelSelect, this.panelSelect.Location);
        }

        public CaptureImage(Image image, PictureBox pic, CapturePhotoSet set)
            : this(set)
        {
            //this.panelSelect.Size = new Size(width, height);
            this.panelSource.BackgroundImage = image;
            this.pic = pic;
            //dragger = new Dragger(this.panelSource, this.panelSelect, this.panelSelect.Location);
        }


        private void panelSelect_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Console.WriteLine("MouseDown,X:" + e.X + "Y:" + e.Y);
                dragger = new Dragger(this.panelSource, this.panelSelect, e.Location);
            }
        }

        private void panelSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               // Console.WriteLine("MouseMove,X:" + e.X + "Y:" + e.Y);
                if(dragger!=null)
                    dragger.DragTo(e.Location);
            }
        }

        private void panelSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Console.WriteLine("MouseUp,X:" + e.X + "Y:" + e.Y);
                if (dragger != null)
                    dragger.End(e.Location);
                dragger = null;
            }
        }

        private void panelSelect_DoubleClick(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            int iWidth = rc.Width;
            int iHeight = rc.Height;
            //创建一个和屏幕一样大的Bitmap

            Image myImage = new Bitmap(this.panelSelect.Width-2, this.panelSelect.Height-2);
            //从一个继承自Image类的对象中创建Graphics对象

            Graphics g = Graphics.FromImage(myImage);
            //抓屏并拷贝到myimage里

            g.CopyFromScreen(this.panelSource.PointToScreen(new Point(this.panelSelect.Location.X+1,this.panelSelect.Location.Y+1)), new Point(0, 0),new Size(this.panelSelect.Width-2,this.panelSelect.Height-2));
            //保存为文件
            //this.image = myImage;
            Console.WriteLine("after capture width:"+myImage.Width+",height:"+myImage.Height);
            if (set.BgRgbEnable)
            {
                //((Bitmap)myImage).MakeTransparent(transColor);
                Color transColor = Color.FromArgb(set.BgRgbR, set.BgRgbG, set.BgRgbB);
                myImage=ImageHelper.SetImageColorAll(myImage, transColor, Color.White,set.SeCha);
            }
            this.pic.Image = myImage;
            //this.pictureBox1.Image = this.image;
            //this.Close();
           // this.pictureBox2.Image = myImage;
        }

        private void CaptureImage_Load(object sender, EventArgs e)
        {
            this.panelSelect.BackColor = Color.Transparent;
        }
    }
}