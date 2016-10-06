using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class DistanceTransform : IImgTransform<Rgb, byte> // TODO note, may be incorrectly implemented
    {
        private const int DistanceTransformParameterNumber = 3;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            if (_params.Count != DistanceTransformParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in distance transform");
            }
            var distType = (DIST_TYPE) _params[0]; // one of DIST_TYPE.CV_DIST_L1, L2

            int maskSize = (int) _params[1];
            int thresh = (int) _params[2];

            Image<Gray, byte> grayImage = emguImage.Convert<Gray, byte>();
            CvInvoke.cvThreshold(grayImage.Ptr, grayImage.Ptr, thresh, 255, THRESH.CV_THRESH_BINARY_INV|THRESH.CV_THRESH_OTSU);

            if (distType == DIST_TYPE.CV_DIST_L1)
            {
                Image<Gray, byte> resultingImage = new Image<Gray, byte>(emguImage.Size);
                CvInvoke.cvDistTransform(grayImage.Ptr, resultingImage.Ptr, distType, maskSize, null, IntPtr.Zero);

                var thresholdedImage = resultingImage.Convert<Gray, byte>();
                CvInvoke.cvThreshold(thresholdedImage.Ptr, thresholdedImage.Ptr, thresh, 255, THRESH.CV_THRESH_BINARY | THRESH.CV_THRESH_OTSU);
                return thresholdedImage.Convert<Rgb, byte>();
            }
            else
            {
                Image<Gray, float> resultingImage = new Image<Gray, float>(emguImage.Size);
                CvInvoke.cvDistTransform(grayImage.Ptr, resultingImage.Ptr, distType, maskSize, null, IntPtr.Zero);

                var thresholdedImage = resultingImage.Convert<Gray, byte>();
                CvInvoke.cvThreshold(thresholdedImage.Ptr, thresholdedImage.Ptr, thresh, 255, THRESH.CV_THRESH_BINARY | THRESH.CV_THRESH_OTSU);
                return thresholdedImage.Convert<Rgb, byte>();
            }
            
           //CvInvoke.cvNormalize(resultingImage.Ptr, resultingImage.Ptr, 0, 1, NORM_TYPE.CV_MINMAX, IntPtr.Zero);

        }

    }
}
