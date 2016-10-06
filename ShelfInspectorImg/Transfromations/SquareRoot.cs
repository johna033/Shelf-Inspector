using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class SquareRoot : IImgTransform<Rgb, byte>
    {
        private const int SquareRootParameterNumber = 0;
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != SquareRootParameterNumber)
                throw new ArgumentException("Wrong parameters number in SquareRoot!");

            Image<Gray, Single> grayImage = emguImage.Convert<Gray, Single>();
            CvInvoke.cvSqrt(grayImage.Ptr, grayImage.Ptr);

            return grayImage.Convert<Rgb, byte>();
        }
    }
}
