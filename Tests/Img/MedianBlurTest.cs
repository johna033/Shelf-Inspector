using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    class MedianBlurTest
    {
        public static void RunTest()
        {

            MedianBlur medianBlur = new MedianBlur();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> {11}
            };
            try
            {
                var result = medianBlur.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"), parameters);
                ImageViewer.Show(result, "Median blur");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
