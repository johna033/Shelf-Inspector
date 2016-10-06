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
    class HoughLinesTest
    {
        public static void RunTest()
        {

            HoughLines houghLines = new HoughLines();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { 1.0 , 107.0 , 2.0 } 
            };
            try
            {
                var result = houghLines.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//Hough_Lines.jpg"), parameters);
                ImageViewer.Show(result, "Hough lines");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
