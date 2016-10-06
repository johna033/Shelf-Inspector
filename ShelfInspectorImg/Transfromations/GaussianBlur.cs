using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class GaussianBlur : IImgTransform<Rgb, byte>
    {
        private const int GaussianBlurParameterNumber = 3;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != GaussianBlurParameterNumber)
                throw new ArgumentException("Wrong parameters in CannyEdge!");

            var _params = parameters.Parameters;
            int kernelSize = (int)_params[0]; //[0, 25]
            int sigmaX = (int)_params[0]; //[0..5]
            int sigmaY = (int)_params[0]; //[0..5]

            return emguImage.SmoothGaussian(kernelSize, kernelSize, sigmaX, sigmaY);
        }
    }
}