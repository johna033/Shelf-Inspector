using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class GaborFilterTest
    {
        public static void RunTest()
        {
            GaborFilter gaborFilter = new GaborFilter();
            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>
                {
                    5,
                    3.0,
                    Math.PI/6,
                    Math.PI,
                    1.0,
                    Math.PI
                }
            };
            try
            {
                var result = gaborFilter.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"),
                    parameters);
                ImageViewer.Show(result, "Gabor Filter");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}