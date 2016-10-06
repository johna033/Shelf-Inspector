using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class Normalize : IImgTransform<Rgb, byte>
    {
        private const int NormalizeParameterNumber = 2;
        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != NormalizeParameterNumber)
                throw new ArgumentException("Wrong parameters number in Normalize!");

            var _params = parameters.Parameters;
            int alpha = (int) _params[0]; //[0 255]
            int beta = (int) _params[1]; //[0 255];

            CvInvoke.cvNormalize(emguImage.Ptr, emguImage.Ptr, alpha, beta, NORM_TYPE.CV_MINMAX, IntPtr.Zero);

            return emguImage;
        }
    }
}