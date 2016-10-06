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
    class DistanceTransformTest
    {
        public static void RunTest()
        {

            DistanceTransform distanceTransform = new DistanceTransform();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> {DIST_TYPE.CV_DIST_L1, 3, 5}
            };
            try
            {
                var result = distanceTransform.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages/distance_transform.jpg"), parameters);
                ImageViewer.Show(result, "Distance transform");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
