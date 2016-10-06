using System.Collections.Generic;
using Emgu.CV.Structure;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.Interfaces;

namespace ShelfInspectorImg.Transfromations
{
    class TransformationFactory
    {
        private readonly Dictionary<TransformationType, IImgTransform<Rgb, byte>> _transformations;
        private static TransformationFactory _instance;

        private TransformationFactory()
        {
            _transformations = new Dictionary<TransformationType, IImgTransform<Rgb, byte>>
            {
                {TransformationType.AdaptiveThresholding, new AdaptiveThresholding()},
                {TransformationType.CannyEdge, new CannyEdge()},
                {TransformationType.Census, new CensusTransform()},
                {TransformationType.Dft, new Dft()},
                {TransformationType.DistanceTransform, new DistanceTransform()},
                {TransformationType.DoG, new DifferenceOfGaussians()},
                {TransformationType.GaborFilter, new GaborFilter()},
                {TransformationType.GaussianBlur, new GaussianBlur()},
                {TransformationType.HarrisCornerStrength, new HarrisCornerStrength()},
                {TransformationType.HistogramEqualization, new HistogramEqualization()},
                {TransformationType.HoughCircles, new HoughCircles()},
                {TransformationType.HoughLines, new HoughLines()},
                {TransformationType.IntegralImage, new IntegralImage()},
                {TransformationType.LaplacianEdgeDetection, new LaplacianEdgeDetection()},
                {TransformationType.Log, new Log()},
                {TransformationType.MedianBlur, new MedianBlur()},
                {TransformationType.MorphologicalDilate, new MorphologicalDilate()},
                {TransformationType.MorphologicalErode, new MorphologyErosion()},
                {TransformationType.Normalize, new Normalize()},
                {TransformationType.SobelOperator, new SobelOperator()},
                {TransformationType.SquareRoot, new SquareRoot()}
            };
        }

        public static IImgTransform<Rgb, byte> GetTransformation(TransformationType type)
        {
            if (_instance == null)
            {
                _instance = new TransformationFactory();
            }

            return _instance._transformations[type];
        }
    }
}
