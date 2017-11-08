using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GameRater.Helpers
{
    public static class BannerCollageGenerator
    {
        public static MemoryStream CreateBanner(string imagesPath)
        {
            var imagePaths = Directory.GetFiles(imagesPath, "*.jpg", SearchOption.AllDirectories);

            var rnd = new Random();
            imagePaths = imagePaths.OrderBy(_ => rnd.Next()).ToArray();

            var x = 0;
            var y = 0;
            using (var bannerBitmap = new Bitmap(800, 300))
            using (var g = Graphics.FromImage(bannerBitmap))
            {
                foreach (var path in imagePaths)
                {
                    using (var image = Image.FromFile(path))
                    {
                        g.DrawImage(image, x, y, 100, 100);

                        if (x == 700 && y == 200) break;

                        if (x == 700)
                        {
                            x = 0;
                            y += 100;
                        }
                        else
                        {
                            x += 100;
                        }
                    }
                }
                g.FillRectangle(new SolidBrush(Color.FromArgb(200, 238, 238, 238)), 0, 0, 800, 300);

                var stream = new MemoryStream();
                bannerBitmap.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                return stream;
            }
        }
    }
}