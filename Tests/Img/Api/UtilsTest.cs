using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Util;

namespace Tests.Img.Api
{
    class UtilsTest
    {
        public static void RunUtilsTest()
        {
            ImageContainer container = ImageHandler.LoadImage(@"~/../../../TestImages//lena.jpg");
            ImageContainer subregion = ImageHandler.GetSubregion(new Rectangle(10, 10, 100, 100), container);
            ImageViewer.Show(subregion.Image, "Utils: subregion");
            Stopwatch sw = new Stopwatch();
            
          /*  List<float> pixels;
            sw.Start();
            pixels = ImageHandler.GetImageAsFloats(subregion);
            sw.Stop();
            Console.WriteLine("100x100 copying: "+sw.Elapsed);
            sw.Reset();
            subregion = ImageHandler.GetSubregion(new Rectangle(10, 10, 500, 500), container); // if x+width > width || y+height > height -> Exception (src.size == dst.size)
            sw.Start();
            pixels = ImageHandler.GetImageAsFloats(subregion);
            sw.Stop();
            Console.WriteLine("500x500 copying: " + sw.Elapsed);*/

            /*int k = 0;
            foreach (float pixel in pixels)
            {
                Console.Write(pixel+" ");
                k++;
                if(k%600 == 0)
                Console.WriteLine();
            }*/
            

        }
    }
}
