using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class AdaptiveThresholding : IImgTransform<Rgb, byte>
    {
        private const int AdaptiveThresholdingParameterNumber = 5;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            List<object> _params = parameters.Parameters;
            if (_params.Count != AdaptiveThresholdingParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in adaptive thresholding");
            }

            var threshold = (Gray) _params[AdaptiveThreholdingParams.ThresholdValue];
            var adaptiveThresholdType = (ADAPTIVE_THRESHOLD_TYPE)_params[AdaptiveThreholdingParams.AdaptiveThresholdType]; // method to use
            var threshholdType = (THRESH) _params[AdaptiveThreholdingParams.ThresholdType]; // BINARY or BINARY_INV
            var blockSize = (int)_params[AdaptiveThreholdingParams.Blocksize];
            var param1 = (Gray) _params[AdaptiveThreholdingParams.Param1];
            Image<Gray, byte> emguGrayImage = emguImage.Convert<Gray, byte>();
            
            return    emguGrayImage.ThresholdAdaptive(threshold, adaptiveThresholdType, threshholdType, blockSize, param1)
                    .Convert<Rgb, byte>();
        }
    }
}
