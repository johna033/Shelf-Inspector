using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class Dft : IImgTransform<Rgb, byte>
    {
        private const int DftParameterNumber = 1;
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != DftParameterNumber)
                throw new ArgumentException("Wrong parameters number in Dft!");
            if (emguImage.Width == 1)
            {
                return emguImage;
            }

            int nonzeroRows = (int) parameters.Parameters[0]; //[0; 10]

            Image<Gray, Single> grayImage = emguImage.Convert<Gray, Single>();

            CvInvoke.cvDFT(grayImage.Ptr, grayImage.Ptr, CV_DXT.CV_DXT_FORWARD, 1);

            return grayImage.Convert<Rgb, Byte>();
        }
    }
}