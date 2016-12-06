﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace printTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          this.printDocument1.OriginAtMargins = true;//启用页边距
          this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.printPreviewDialog1.Document = printDocument1; 
            this.pageSetupDialog1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.printPreviewDialog1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //if (this.printDialog1.ShowDialog() == DialogResult.OK)
        //    {

                this.printDocument1.Print();
               // this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);

         //   }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////打印内容 为 整个Form
            //Image myFormImage;
            //myFormImage = new Bitmap(this.Width, this.Height);
            //Graphics g = Graphics.FromImage(myFormImage);
            //g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //e.Graphics.DrawImage(myFormImage, 0, 0);

            //打印内容 为 局部的 this.groupBox1
            // Bitmap _NewBitmap = new Bitmap(groupBox1.Width, groupBox1.Height);
            //groupBox1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            //  e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height); 
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 1;
            qrCodeEncoder.QRCodeVersion = 9;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

            string data = "ajfie wjfqoqfioq i";
            Font font = new Font("宋体", 12);
            var txt = new TextBox();
            txt.Text = data;
            txt.Font = font;
            //txt.PreferredSize.Height只能取到一行的高度(连边距)   
            //所以需要乘以行数, 但是必须先减掉边距, 乘了以后,再把边距加上.   
            //5是目测的边距   
            var image = new Bitmap(txt.PreferredSize.Width, (txt.PreferredSize.Height - 5) * txt.Lines.Length + 5);
            var g = Graphics.FromImage(image);
            var b = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);
            g.Clear(System.Drawing.Color.White);
            g.DrawString(data, font, b, 1, 1);
            //return image;

            e.Graphics.DrawImage(image, 20, 20);
            var item_barcode = _Code.GetCodeImage(string.Format("{0}", "90A51B300020"),
BarCode.Code128.Encode.Code128A);
            e.Graphics.DrawImage(image, 20, 20);
            //  Image image;
            // string BN =" mConnectedDut[i].BuildNumber";
            //  string data = "Model:"+
            //   "OS Version:"  +
            //   "SN:" + 
            //     "IMEI:"  +
            //     "Memory:"+
            //      "Flash:" + "BuildNumber:";//bonnie20160805

            //    image = qrCodeEncoder.Encode(data + BN);
            // mDuts[i].SetQRCode_IMEI(image);
            //打印内容 为 自定义文本内容 
            //  Font font = new Font("宋体", 12);
            // Brush bru = Brushes.Blue;

            //
            //    e.Graphics.DrawString("Hello world ", font, bru,0, 0);
            //  e.Graphics.DrawImage(image, 20, 20);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}