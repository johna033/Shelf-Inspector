using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    class SobelOperatorTest
    {
        public static void RunTest()
        {

            SobelOperator sobelOperator = new SobelOperator();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { 1, 0, 0.5, 0.5 }
            };
            try
            {
                var result = sobelOperator.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"), parameters);
                ImageViewer.Show(result, "Sobel operator");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
