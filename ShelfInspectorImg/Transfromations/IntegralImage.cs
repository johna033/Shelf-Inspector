using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class IntegralImage : IImgTransform<Rgb, byte>
    {
        private const int IntegralImageParameterNumber = 1;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != IntegralImageParameterNumber)
                throw new ArgumentException("Wrong parameters number in IntegralImage!");

            int type = (int) parameters.Parameters[0]; //[0; 2]

            Image<Rgb, double> sumImage, squareSumImage, titledSumImage;

            emguImage.Integral(out sumImage, out squareSumImage, out titledSumImage);
            Image<Rgb, double> resultImage = new Image<Rgb, double>(new Size(0, 0)); //blank image

            switch (type)
            {
                case 0:
                    resultImage = sumImage;
                    break;
                case 1:
                    resultImage = squareSumImage;
                    break;
                case 2:
                    resultImage = titledSumImage;
                    break;
            }

            return resultImage.Convert<Rgb, byte>();
        }
    }
}