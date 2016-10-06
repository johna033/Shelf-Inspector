using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class MorphologicalDilate : IImgTransform<Rgb, byte>
    {
        private const int MorphologicalErodeParameterNumber = 2;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;

            if (parameters.Parameters.Count != MorphologicalErodeParameterNumber)
            {
                throw new ArgumentException("Wrong parameters in morphological dilate");
            }

            CV_ELEMENT_SHAPE elementShape = (CV_ELEMENT_SHAPE)_params[0];
            int kernelSize = (int)_params[1];

            switch (elementShape)/* erode type */
            {
                case CV_ELEMENT_SHAPE.CV_SHAPE_RECT:
                    break;
                case CV_ELEMENT_SHAPE.CV_SHAPE_CROSS:
                    break;
                case CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE:
                    break;
                default:
                    elementShape = CV_ELEMENT_SHAPE.CV_SHAPE_RECT;
                    break;
            }

   
            Size size = new Size(2*kernelSize+1, 2*kernelSize+1);
            Point point = new Point(kernelSize, kernelSize);
            StructuringElementEx structuringElement = new StructuringElementEx(size.Width, size.Height, point.X, point.Y, elementShape);

            //tmp.convertTo(tmp,CV_8UC1);
            return emguImage.Convert<Gray, byte>().MorphologyEx(structuringElement, new CV_MORPH_OP(), 1).Convert<Rgb, byte>();
        }
    }
}
