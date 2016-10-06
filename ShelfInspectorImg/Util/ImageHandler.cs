using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;

namespace ShelfInspectorImg.Util
{
    public sealed class ImageHandler
    {
        public static ImageContainer LoadImage(string pathToFile)
        {
            ImageContainer container = new ImageContainer
            {
                Image = new Image<Rgb, byte>(pathToFile),
                PathToFile = pathToFile
            };
            return container;
        }

        public static ImageContainer GetSubregion(Rectangle subregion, ImageContainer image)
        {
            try
            {
                lock (image)
                {
                    ImageContainer subImage = new ImageContainer
                    {
                        Image = image.Image.Copy(subregion)
                    };

                    return subImage;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message+" "+e.Source+" "+e.StackTrace);
            }
        }

        public static byte[,,] GetImageAsByteArray(ImageContainer image)
        {
            return image.Image.Data;
        }
    }
}
