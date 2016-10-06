using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class SobelOperator : IImgTransform<Rgb, byte>
    {
        private const int SobelOperatorParameterNumber = 4;
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            

            if (parameters.Parameters.Count != SobelOperatorParameterNumber)
            {
                throw new ArgumentException("Wrong parameters passed to Sobel Operator");
            }

            var scale = (int)_params[0]; // [0;10]
            var delta = (int)_params[1]; // [0;10]
            double xWeight = (double)_params[2];
            double yWeight = (double)_params[3]; //  0 <= xWeight+yWeight <=1

            if (xWeight + yWeight > 1)
            {
                xWeight = 1 - yWeight;
            }

            emguImage = emguImage.SmoothGaussian(3);

            Image<Gray, byte> emguGrayImage = emguImage.Convert<Gray, byte>();

            Image<Gray, float> gradX = emguGrayImage.Sobel(0, 1, 3);
            Image<Gray, float> gradY = emguGrayImage.Sobel(1, 0, 3);

            Size size = emguImage.Size;

            Image<Gray, byte> absGradXImage = new Image<Gray, byte>(size);
            Image<Gray, byte> absGradYImage = new Image<Gray, byte>(size);

            CvInvoke.cvConvertScaleAbs(gradX.Ptr, absGradXImage.Ptr, scale, delta); //scale = 0, delta = 1 by default
            CvInvoke.cvConvertScaleAbs(gradY.Ptr, absGradYImage.Ptr, scale, delta);

            absGradXImage = absGradXImage.AddWeighted(absGradYImage, xWeight, yWeight, 0);

            return absGradXImage.Convert<Rgb,Byte>();
        }
    }
}
