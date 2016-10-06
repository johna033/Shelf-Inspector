using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class Log : IImgTransform<Rgb, byte>
    {
        private const int LogParameterNumber = 0;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.Parameters.Count != LogParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in log");
            }

            Image<Rgb, float> floatImage = emguImage.Convert<Rgb, float>();
            floatImage = floatImage.Log();

            return floatImage.Convert<Rgb, byte>();
        }
    }
}
