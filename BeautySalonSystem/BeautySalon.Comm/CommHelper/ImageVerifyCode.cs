using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeautySalon.Comm.CommHelper
{
    /// <summary>
    /// 网页图片验证码
    /// </summary>
    public class ImageVerifyCode
    {
        #region 定义显示验证码的方法(Web格式的)

        /// <summary>
        /// 定义显示验证码的方法(Web格式的)
        /// </summary>
        public void ValidateCode()
        {
            // 验证码文本内容字段
            string strChkCode = string.Empty;
            // 字体颜色数组
            Color[] colors =
             {
                Color.Black ,
                Color.Blue,
                Color.Green,
                Color.Red,
                Color.Orange,
                Color.Aqua,
                Color.Brown,
                Color.Pink
            };
            // 字体列表
            string[] fonts =
            {
                "黑体",
                "微软雅黑",
                "微软正黑体",
                "隶书",
                "幼圆",
                "宋体",
                "新宋体",
                "华文黑体",
                "楷体",
                "苹果丽中黑",
                "华文宋体",

            };
            // 验证码字符集
            char[] chars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

            Random rnd = new Random();
            // 验证码长度为5位
            for (int i = 0; i < 1; i++)
            {
                strChkCode += chars[rnd.Next(chars.Length)];
            }
            // 将生成的验证码存入Session
            HttpContext.Current.Session["CheckCode"] = strChkCode;

            // 创建位图
            Bitmap bmp = new Bitmap(150, 60);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            // 画噪线
            for (int i = 0; i < 20; i++)
            {
                int x1 = rnd.Next(150);
                int y1 = rnd.Next(60);
                int x2 = rnd.Next(150);
                int y2 = rnd.Next(60);
                Color rndColor = colors[rnd.Next(colors.Length)];
                g.DrawLine(new Pen(rndColor), x1, y1, x2, y2);
            }

            PointF pointF = new PointF(0, 2);
            float sepDistance = 6.5F;
            // 画验证码字符串
            for (int i = 0; i < strChkCode.Length; i++)
            {
                string fnt = fonts[rnd.Next(fonts.Length)];
                Font ft = new Font(fnt, 38, FontStyle.Bold);
                string sChar = strChkCode[i].ToString();
                SizeF sizeF = g.MeasureString(sChar, ft);
                Color rndColor = colors[rnd.Next(colors.Length)];

                g.DrawString(sChar, ft, new SolidBrush(rndColor), pointF);
                pointF.X += sizeF.Width - sepDistance;
            }

            // 画噪点
            for (int i = 0; i < 150; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color rndColor = colors[rnd.Next(colors.Length)];
                bmp.SetPixel(x, y, rndColor);
            }

            try
            {
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/png";
                bmp.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Png);
            }
            finally
            {
                bmp.Dispose();
                g.Dispose();
            }

        }

        #endregion

    }
}
