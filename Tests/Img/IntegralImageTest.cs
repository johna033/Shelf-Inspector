using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class IntegralImageTest
    {
        public static void RunTest()
        {
            IntegralImage integralImage = new IntegralImage();

            TransformationParameters parameters = new TransformationParameters()
            {
                Parameters = new List<object>
                {
                    0
                }
            };
            try
            {
                var result = integralImage.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//dft.gif"),
                    parameters);
                ImageViewer.Show(result, "Integral Image");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}