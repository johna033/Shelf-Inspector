using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class NormalizeTest
    {
        public static void RunTest()
        {
            Normalize normalize = new Normalize();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>
                {
                    30,
                    150
                }
            };
            try
            {
                var result = normalize.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//dft.gif"),
                    parameters);
                ImageViewer.Show(result, "Normalize");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}