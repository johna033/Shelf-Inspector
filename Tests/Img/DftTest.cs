using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class DftTest
    {
        public static void RunTest()
        {
            Dft dft = new Dft();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> {1}
            };
            try
            {
                var result = dft.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//dft.gif"), parameters);
                ImageViewer.Show(result, "DFT");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}