using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class HoughCirclesTest
    {
        public static void RunTest()
        {
            HoughCircles houghCircles = new HoughCircles();
            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { new Gray(120), new Gray(145)}
            };
            try
            {
                var result = houghCircles.PerformTransform(new Image<Rgb, Byte>(@"~/../../../TestImages/hough_circle.png"), parameters);
                ImageViewer.Show(result, "Hough Circle");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}