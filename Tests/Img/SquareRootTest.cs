using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class SquareRootTest
    {
        public static void RunTest()
        {
            SquareRoot squareRoot = new SquareRoot();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>()
            };

            try
            {
                var result = squareRoot.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//dft.gif"),
                    parameters);
                ImageViewer.Show(result, "Square Root");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}