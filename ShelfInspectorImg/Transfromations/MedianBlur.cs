using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class MedianBlur : IImgTransform<Rgb, byte>
    {
        private const int MedianBlurParameterNumber = 1;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            if (_params.Count != MedianBlurParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in median blur");
            }
            var size = (int) _params[0]; // [0;21]

            Image<Gray, byte> emguGrayImage = emguImage.Convert<Gray, byte>();

            emguGrayImage = emguGrayImage.SmoothMedian(size);

            return emguGrayImage.Convert<Rgb, byte>();
        }
    }
}
