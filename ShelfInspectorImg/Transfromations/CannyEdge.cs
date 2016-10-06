using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class CannyEdge: IImgTransform<Rgb, byte>
    {
        private const int CannyEdgeParameterNumber = 1;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != CannyEdgeParameterNumber)
                throw new ArgumentException("Wrong parameters in CannyEdge!");

            var treshold = (double) parameters.Parameters[0]; // [0; 100]

            Image<Gray, byte> grayImage = emguImage.Convert<Gray, byte>();
            // reduce noise
            grayImage.SmoothBlur(3, 3);
            // Canny
            grayImage = grayImage.Canny(treshold, treshold*3, 3);

            return grayImage.Convert<Rgb, byte>();
        }
    }
}