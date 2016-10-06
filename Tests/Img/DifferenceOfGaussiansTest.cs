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
    class DifferenceOfGaussiansTest
    {
        public static void RunTest()
        {

            DifferenceOfGaussians differenceOfGaussians = new DifferenceOfGaussians();

            TransformationParameters parameters = new TransformationParameters
            {//somehow doesn't want to cast from 3.0 to 3 (double->int)
                Parameters = new List<object> {  3 , 15 } // the closer two kernel sizes are, the less details we see
            };
            try
            {
                var result = differenceOfGaussians.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"), parameters);
                ImageViewer.Show(result, "Diffrence of Gaussians");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
