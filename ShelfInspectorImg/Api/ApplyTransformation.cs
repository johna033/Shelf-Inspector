using System;
using Emgu.CV.Structure;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;
using ShelfInspectorImg.Transfromations;

namespace ShelfInspectorImg.Api
{
    public sealed class ApplyTransformation
    {
        public static ImageContainer Apply(ImageContainer image, TransformationParameters parameters, TransformationType type)
        {
            IImgTransform<Rgb, byte> transformation = TransformationFactory.GetTransformation(type);
            try
            {
                image.Image = transformation.PerformTransform(image.Image, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message+" "+e.Source+" "+e.StackTrace+" "+type);
            }
            return image;
        }
    }
}
