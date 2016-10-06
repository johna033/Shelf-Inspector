using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class GaussianBlurTest
    {
        public static void RunTest()
        {
            GaussianBlur gaussianBlur = new GaussianBlur();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>
                {
                    3,
                    5,
                    7
                }
            };
            try
            {
                var result = gaussianBlur.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"),
                    parameters);
                ImageViewer.Show(result, "Gaussian Blur");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}