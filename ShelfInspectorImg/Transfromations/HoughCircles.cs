using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class HoughCircles : IImgTransform<Rgb, byte>
    {
        private const int HoughCirclesParameterNumber = 2;
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != HoughCirclesParameterNumber)
                throw new ArgumentException("Wrong parameters number in HoughCircles!");

            var _params = parameters.Parameters;

            Gray cannyTreshold = (Gray)_params[0]; // [0; 100]
            Gray accumulatorTreshold = (Gray)_params[1]; // [0; 200]

            Image<Gray, byte> grayImage = emguImage.Convert<Gray, byte>();
            // smooth it, otherwise a lot of false circles may be detected (from OpenCV tutorial)
            CvInvoke.cvSmooth(grayImage.Ptr, grayImage.Ptr, SMOOTH_TYPE.CV_GAUSSIAN, 3, 3, 0.4, 0);

            CircleF[] circles = grayImage.HoughCircles(cannyTreshold,
                                                       accumulatorTreshold, 
                                                       3.0, 
                                                       15.0, 
                                                       10, 
                                                       0)[0];

            Image<Rgb, byte> resultImage = new Image<Rgb, byte>(grayImage.Size);
            foreach (CircleF circle in circles)
            {
                //draw center
                var centerCircle = circle;
                centerCircle.Radius = 3;
                resultImage.Draw(centerCircle, new Rgb(Color.Blue), -1);
                //draw circle
                resultImage.Draw(circle, new Rgb(Color.Red), 3);
            }

            return resultImage;
        }
    }
}