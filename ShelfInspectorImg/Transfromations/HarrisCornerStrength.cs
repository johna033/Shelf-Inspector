using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class HarrisCornerStrength : IImgTransform<Rgb, byte>
    {
        private const int HarrisCornerStrengthParameterNumber = 3;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            if (_params.Count != HarrisCornerStrengthParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in harris corner strength!");
            }

            var blockSize = (int) _params[0]; //[0;200]
            var apertureSize = (int) _params[1]; // [0;1]
            var k = (double) _params[2];

            var resultingCornersImage = new Image<Gray, float>(emguImage.Size);
            CvInvoke.cvCornerHarris(emguImage.Convert<Gray, float>().Ptr, resultingCornersImage.Ptr, blockSize, apertureSize, k);
            CvInvoke.cvNormalize(resultingCornersImage.Ptr, resultingCornersImage.Ptr, 0, 255, NORM_TYPE.CV_MINMAX,
                new IntPtr());
            Image<Gray, byte> resultingImage = new Image<Gray, byte>(emguImage.Size);

            CvInvoke.cvConvertScaleAbs(resultingCornersImage.Ptr, resultingImage.Ptr, 1, 0);

            return resultingImage.Convert<Rgb, byte>();
        }
    }
}
