using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ShelfInspectorImg.DTO
{
    public class ImageContainer
    {
        public Image<Rgb, byte> Image;
        public int BelongsToClass;
        public string PathToFile;

    }
}
