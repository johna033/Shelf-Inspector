using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class DifferenceOfGaussians : IImgTransform<Rgb, byte>
    {
        private const int DifferenceGaussiansParameterNumber = 2;

        public Image<Rgb, Byte> PerformTransform(Image<Rgb, Byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;

            if (_params.Count != DifferenceGaussiansParameterNumber)
            {
               throw new ArgumentException("Wrong parameters passed to DoG!");
            }

            var kern1 = (int)_params[0]; // [0;25]
            var kern2 = (int)_params[1];// [0;25]

            var g1 = emguImage.Clone();
            var g2 = emguImage.Clone();

            g1 = g1.SmoothGaussian(kern1);
            g2 = g2.SmoothGaussian(kern2);

            return g1-g2;
        }

        private int FilterKernelSize(int kernelSize)
        {
            if ((kernelSize & 0x1) == 0)
                kernelSize++;
            return kernelSize;
        }
    }
}
