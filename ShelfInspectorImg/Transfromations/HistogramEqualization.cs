using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class HistogramEqualization : IImgTransform<Rgb, byte>
    {
        private const int HistogramEqualizationParameterNumber = 0;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.Parameters.Count != HistogramEqualizationParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in histogram equalization");
            }

            Image<Gray, byte> emguImageGrayImage = emguImage.Convert<Gray, byte>();
            emguImageGrayImage._EqualizeHist();

            return emguImageGrayImage.Convert<Rgb, byte>();
        }
    }
}
