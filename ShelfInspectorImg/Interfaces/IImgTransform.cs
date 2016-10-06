using Emgu.CV;
using ShelfInspectorImg.DTO;

namespace ShelfInspectorImg.Interfaces
{
    interface IImgTransform<TColor, TDepth> where TColor: struct, IColor where TDepth: new()
    {
        Image<TColor, TDepth> PerformTransform(Image<TColor, TDepth> emguImage, TransformationParameters parameters);
    }
}
