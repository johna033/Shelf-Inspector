using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    public class CensusTransform: IImgTransform<Rgb, byte>
    {
        private const int CensusTransformParameterNumber = 1;

        /// <summary>
        /// Returns grayscaled image in bgr TODO bug in architecture, think of a better interface generalizations
        /// </summary>
        /// <param name="emguImage"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Image<Rgb, Byte> PerformTransform(Image<Rgb, Byte> emguImage, TransformationParameters parameters)
        {

            if (parameters.Parameters.Count != CensusTransformParameterNumber)
            {
                throw new ArgumentException("Wrong number of parameters in census trasform!");
            }

            var param = (int)parameters.Parameters[0]; // [0;25]
    
            Size imgSize = emguImage.Size;
            var  resultingImage = new Image<Gray, byte>(imgSize);

            var m = param;
            var n = param;//window size

                for (int x = m/2; x < imgSize.Height - m/2; x++)
                {
                    int y;
                    for (y = n/2; y < imgSize.Width - n/2; y++)
                    {
                        int census = 0;
                        int shiftCount = 0;
                        int i;

                        for (i = x - m/2; i <= x + m/2; i++)
                        {
                            int j;
                            for (j = y - n/2; j <= y + n/2; j++)
                            {
                                if (shiftCount != m*n/2) //skip the center pixel
                                {
                                    census <<= 1;
                                    
                                    var bit = emguImage.Data[i, j, 0] < emguImage.Data[x, y, 0] ? 1 : 0;

                                    census = census + bit;
                                }
                                shiftCount ++;
                            }
                        }

                        resultingImage.Data[x,y,0] = (byte)(census & 0xFF);
                    }
                }
            
            //tmp1.convertTo(tmp1,CV_8UC1);

            return resultingImage.Convert<Rgb, Byte>();
        }
    }
}
