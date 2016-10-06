using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class LaplacianEdgeDetection : IImgTransform<Rgb, byte>
    {
        private const int LaplacianEdgeDetectionParameterNumber = 1;
#warning Two parameters from the original ignored (scale, and shift)
#warning Type-casting - huge performance buster
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            if (_params.Count != LaplacianEdgeDetectionParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in laplacian edge detection");
            }


            var apertureSize = (int) _params[0]; // [0;21]

            emguImage= emguImage.SmoothGaussian(3);

            var grayLaplacianImage = emguImage.Convert<Gray, byte>();

            CvInvoke.cvLaplace(grayLaplacianImage.Ptr, grayLaplacianImage.Ptr, apertureSize);

            var resultImage = new Image<Gray, byte>(emguImage.Size);
            
           CvInvoke.cvConvertScaleAbs(grayLaplacianImage.Ptr, resultImage.Ptr, 1, 1);

            return resultImage.Convert<Rgb, byte>();
        }
    }
}
