using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    class HistogramEqualizationTest
    {
        public static void RunTest()
        {

            HistogramEqualization histogramEqualization = new HistogramEqualization();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>()
            };
            try
            {
                var result = histogramEqualization.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"), parameters);
                ImageViewer.Show(result, "Histogram equalization");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
