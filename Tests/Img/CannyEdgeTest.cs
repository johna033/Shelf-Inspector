using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.Transfromations;
using ShelfInspectorImg.DTO;

namespace Tests.Img
{
    class CannyEdgeTest
    {
        public static void RunTest()
        {
            CannyEdge cannyEdge = new CannyEdge();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>{ 75.0}
            };
            try
            {
                var result = cannyEdge.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"),
                    parameters);
                ImageViewer.Show(result, "Canny Edge");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}