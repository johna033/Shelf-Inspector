using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Transfromations;

namespace Tests.Img
{
    class LogTest
    {
        public static void RunTest()
        {
            ShelfInspectorImg.Transfromations.Log log = new Log();
            TransformationParameters parameters = new TransformationParameters
            {
                Parameters = new List<object>()
            };
            try
            {
                var result = log.PerformTransform(new Image<Rgb, byte>(@"~/../../../TestImages//sample1.jpg"), parameters);
                ImageViewer.Show(result, "Log");
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
