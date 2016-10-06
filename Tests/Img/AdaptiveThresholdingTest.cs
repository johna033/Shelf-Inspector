using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    class AdaptiveThresholdingTest
    {
        public static void RunTest()
        {

            AdaptiveThresholding adaptiveThresholding = new AdaptiveThresholding();
            
            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>
                {
                    new Gray(255), 
                    ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C, 
                    THRESH.CV_THRESH_BINARY,
                    7,
                    new Gray(2)
                }
            };
            try
            {
                var result = adaptiveThresholding.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"), parameters);
                ImageViewer.Show(result, "Adaptive thresholding");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
