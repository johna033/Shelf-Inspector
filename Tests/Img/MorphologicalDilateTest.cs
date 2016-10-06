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
    class MorphologicalDilateTest
    {
        public static void RunTest()
        {

            MorphologicalDilate morphologicalDilate = new MorphologicalDilate();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> 
                {
                   CV_ELEMENT_SHAPE.CV_SHAPE_RECT, 2 
                }
            };
            try
            {
                var result = morphologicalDilate.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"), parameters);
                ImageViewer.Show(result, "Morphological dilateg");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
