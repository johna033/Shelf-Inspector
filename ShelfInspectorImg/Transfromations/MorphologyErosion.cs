using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class MorphologyErosion : IImgTransform<Rgb, byte>
    {
        private const int MorphologyErosionParameterNumber = 2; 

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            var _params = parameters.Parameters;

            if (_params.Count != MorphologyErosionParameterNumber)
            {
                throw new ArgumentException("Wrong argument in MorphologyErosion!");
            }

            CV_ELEMENT_SHAPE elementShape = (CV_ELEMENT_SHAPE) _params[0];
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

            int kernelSize = (int)_params[1]; //0..25
            Size size = new Size(2 * kernelSize + 1, 2 * kernelSize + 1);
            Point point = new Point(kernelSize, kernelSize);
            StructuringElementEx structuringElement = new StructuringElementEx(size.Width, size.Height, point.X, point.Y, elementShape);

            return emguImage.MorphologyEx(structuringElement, CV_MORPH_OP.CV_MOP_CLOSE, 1);
        }
    }
}
