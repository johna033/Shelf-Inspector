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
    class HarrisCornerStrengthTest
    {
        public static void RunTest()
        {

            HarrisCornerStrength harrisCornerStrength = new HarrisCornerStrength();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { 3 , 0, 0.04} 
            };
            try
            {
                var result = harrisCornerStrength.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"), parameters);
                ImageViewer.Show(result, "Harris corner stength");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
