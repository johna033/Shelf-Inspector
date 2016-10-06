using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Util;

namespace Tests.Img.Api
{
    class ApplyTransformTest
    {
        public static void TestTransformationApplication()
        {
            TransformationParameters cannyEdgeParameters = new TransformationParameters
            {
                Parameters = new List<object> 
                {
                   75
                }
            };
            TransformationParameters adaptiveThresholdParameters = new TransformationParameters
            {
                Parameters = new List<object>
                {
                    new Gray(255),
                    ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C, 
                    THRESH.CV_THRESH_BINARY, 
                    11,
                    new Gray(2)
                }
            };
            TransformationParameters censusParameters = new TransformationParameters
            {
                Parameters = new List<object> { 10 } 
            };
            TransformationParameters dftParameters = new TransformationParameters
            {
                Parameters = new List<object> 
                {
                   10
                }
            };
            TransformationParameters dogParameters = new TransformationParameters
            {//somehow doesn't want to cast from 3.0 to 3 (double->int)
                Parameters = new List<object> { 3, 15 } // the closer two kernel sizes are, the less details we see
            };

            ImageContainer container = ImageHandler.LoadImage(@"~/../../../TestImages//lena.jpg");
            ImageContainer subregion = ImageHandler.GetSubregion(new Rectangle(10, 10, 100, 100), container);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ImageContainer transformResult = ApplyTransformation.Apply(subregion, adaptiveThresholdParameters,
                TransformationType.AdaptiveThresholding);
            sw.Stop();
            Console.WriteLine("1 transformation: "+sw.Elapsed);
            ImageViewer.Show(transformResult.Image);
            sw.Reset();

            sw.Start();
            transformResult = ApplyTransformation.Apply(ApplyTransformation.Apply(subregion, adaptiveThresholdParameters,
                TransformationType.AdaptiveThresholding), dftParameters, TransformationType.Dft);
            Console.WriteLine("2 chained transformations: " + sw.Elapsed);
            sw.Stop();
            ImageViewer.Show(transformResult.Image);
            

            sw.Start();
            transformResult = ApplyTransformation.Apply(ApplyTransformation.Apply(subregion, adaptiveThresholdParameters,
                TransformationType.AdaptiveThresholding), adaptiveThresholdParameters, TransformationType.AdaptiveThresholding);
            Console.WriteLine("2 chained transformations (indempotence): " + sw.Elapsed);
            sw.Stop();
            ImageViewer.Show(transformResult.Image);
            
        }
    }
}
