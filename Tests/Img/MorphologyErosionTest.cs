using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    public class MorphologyErosionTest
    {
        public static void RunTest()
        {
            MorphologyErosion morphologyErosion = new MorphologyErosion();

            TransformationParameters parameters = new TransformationParameters()
            {
                Parameters = new List<object>
                {
                    CV_ELEMENT_SHAPE.CV_SHAPE_RECT,
                    5
                }
            };
            try
            {
                var result = morphologyErosion.PerformTransform(
                    new Image<Rgb, byte>(@"~/../../../TestImages//lena.jpg"), parameters);
                ImageViewer.Show(result, "MorphologyErode");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}