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
    class LaplacianEdgeDetectionTest
    {
        public static void RunTest()
        {

            LaplacianEdgeDetection laplacianEdgeDetection = new LaplacianEdgeDetection();

            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object> { 3 } // aperture should be relatively low
            };
            try
            {
                var result = laplacianEdgeDetection.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//laplacian_edge_detection.jpg"), parameters);
                ImageViewer.Show(result, "Laplacian edge detection");
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
