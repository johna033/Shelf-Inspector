using System;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class HoughLines : IImgTransform<Rgb, byte>
    {
        private const int HoughLinesParameterNumber = 3;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;
            Image<Gray, byte> emguGrayImage = emguImage.Convert<Gray, byte>();

            if (_params.Count != HoughLinesParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in hough lines!");
            }
            var threshold = (double) _params[0]; // both canny and HoughLines should be between [1, 100]
            var minLineLength = (double) _params[1]; // [0;100]
            var maxLineGap = (double) _params[2]; // [0;20]  

            //emguGrayImage = emguGrayImage.Canny(threshold, 4*threshold);

            LineSegment2D[][] lines = emguGrayImage.HoughLines(threshold, threshold*4, 1, Math.PI/180, (int) threshold,
                minLineLength, maxLineGap);

            //vector<Vec4i> lines;
            //HoughLinesP(tmp, lines, 1, CV_PI/180, threshold, minlinelength, maxlinegap );

            //Mat tmp1(tmp.rows,tmp.cols,CV_8UC3,Scalar(0,0,0));
            var resultingImage = new Image<Gray, byte>(emguGrayImage.Size);
            
            LineSegment2D[] linesForChannel = lines[0];
            foreach (var lineSegment2D in linesForChannel)
            {
                resultingImage.Draw(lineSegment2D, new Gray(100), 1); // TODO check if 100 means white crucial!!!
            }

            return resultingImage.Convert<Rgb, byte>();
        }
    }
}
