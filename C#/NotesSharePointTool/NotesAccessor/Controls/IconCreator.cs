using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Controls
{
    /// <summary>
    /// アイコン作成用クラスを実装する
    /// </summary>
    public class IconCreator
    {
        private Color[] colors = {Color.FromArgb(0, 0, 0), // 黒
									Color.FromArgb(255, 255, 255), // 白
									Color.FromArgb(255, 0, 0), // 赤
									Color.FromArgb(0, 255, 0), // 緑
									Color.FromArgb(0, 0, 255), // 青
									Color.FromArgb(255, 0, 255), // マゼンタ
									Color.FromArgb(255, 255, 0), // 黄
									Color.FromArgb(0, 255, 255), // シアン
									Color.FromArgb(128, 0, 0), // 濃赤
									Color.FromArgb(0, 128, 0), // 濃緑
									Color.FromArgb(0, 0, 128), // 濃青
									Color.FromArgb(128, 0, 128), // 濃マゼンタ
									Color.FromArgb(128, 128, 0), // 濃黄
									Color.FromArgb(0, 128, 128), // 濃シアン
									Color.FromArgb(70, 70, 70), // 濃灰
									Color.FromArgb(128, 128, 128), // 薄灰
									Color.FromArgb(220, 220, 220) // 極薄灰（この色を背景とする）
                                 };

        private const string IconFontName = "ＭＳ ゴシック";
        private const float IconFontSize = 9.0F;

        /// <summary>
        /// データベースアイコンをBufferedImageとして取得します。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Image getRawIconImage(byte[] data)
        {
            int[] bg = new int[32 * 32]; //背景データ
            int[] fg = new int[32 * 32]; //前景データ
            //背景データ
            for (int i = 0x0006, j = 0; i <= 0x0085; i++)
            {
                int b = (int)data[i];

                //背景データは１ビットずつ確認する
                for (int k = 0; k < 8; k++)
                {
                    int mask = 128 >> k;
                    int x = (b & mask) >> (7 - k);
                    bg[j + k] = x;
                }
                j += 8;
            }

            //前景データ
            for (int i = 0x0086, j = 0; i <= 0x0285; i++)
            {
                int b = (int)data[i];

                // 前景データは４ビットずつ確認する
                for (int k = 0; k < 2; k++)
                {
                    int mask = 0xf0 >> (k * 4);
                    int x = (b & mask) >> (4 - (k * 4));
                    fg[j + k] = x;
                }
                j += 2;
            }
            Image bi = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bi);
            Brush br;
            // 描画
            for (int i = 0; i < 32 * 32; i++)
            {

                int x = (i % 32);
                int y = (31 - (i / 32)); //データは下から入っている点に注意
                if (bg[i] == 1)
                {
                    br = new SolidBrush(colors[16]);
                }
                else
                {
                    br = new SolidBrush(colors[fg[i]]);
                    g.FillRectangle(br, x, y, 2, 2);
                }

            }
            return bi;
        }

        public Image GetLargeIcon(Image rawIcon,string title)
        {
            return DrawIconFrame(rawIcon, title);
        }

        public Image GetLargeMonoIcon(Image rawIcon)
        {
            Image MonoIcon = GetMonoIcon(rawIcon);
            Image largIcon = ZoomIcon(MonoIcon, 52);
            return largIcon;
        }

        public Image GetSmallIcon(Image rawIcon)
        {
            return ZoomIcon(rawIcon, 16);
        }

        private Image ZoomIcon(Image rawIcon,int width)
        {
            return rawIcon.GetThumbnailImage(width, width, ThumbnailCallback, System.IntPtr.Zero);
        }

        private bool ThumbnailCallback(){
             return false;
        }

        private Image GetMonoIcon(Image rawIcon)
        {
            Bitmap decBmp = new Bitmap(rawIcon);
            for (int x = 0; x < decBmp.Width; x++)
            {
                for (int y = 0; y < decBmp.Height; y++)
                {
                    Color color = decBmp.GetPixel(x, y);
                    int gray = ((int)color.R + (int)color.G + (int)color.B) / 3;
                    //int gray = (int)((color.R*0.3 + color.G*0.59 + color.B*0.11) / 3.0);
                    if (gray > 127)
                    {
                        gray = 255;
                    }
                    else
                    {
                        gray = 0;
                    }
                    Color monoColor = Color.FromArgb(gray, gray, gray);
                    decBmp.SetPixel(x, y, monoColor);
                }
            }
            return decBmp;
        }

        private Image DrawIconFrame(Image icon, string title)
        {
            Image iconFrame = new Bitmap(96, 96, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(iconFrame);
            Image iconBg = Properties.Resources.IconBg;
            g.DrawImage(iconBg, new Rectangle(0, 0, 95, 95));
            g.DrawRectangle(Pens.DarkGray, 0, 0, 95, 95);
            if (icon != null)
            {
                g.DrawImage(icon, new Point(5, 5));
            }
            if (!string.IsNullOrEmpty(title))
            {
                Font font = new Font(IconFontName,IconFontSize);
                g.DrawString(title, font, Brushes.Black, new RectangleF(8, 42, 80, 36));
            }
            return iconFrame;
        }
    }
}
