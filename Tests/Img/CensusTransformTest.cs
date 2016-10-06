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
    class CensusTransformTest
    {
        public static void RunTest()
        {

            CensusTransform censusTransform = new CensusTransform();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { 10 } 
            };
            try
            {
                var result = censusTransform.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//census_transform.png"), parameters);
                ImageViewer.Show(result, "Census transform");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
