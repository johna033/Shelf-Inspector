using System;

namespace ShelfInspectorImg.Data
{

    public static class AdaptiveThreholdingParams
    {
        public const int ThresholdValue = 0;
        public const int AdaptiveThresholdType = 1;
        public const int ThresholdType = 2;
        public const int Blocksize = 3;
        public const int Param1 = 4;
    };

    public static class CannyEdgeParams
    {
        public const int Threshold = 0;
    }

    public static class CensusParams
    {
        public const int WindowSize = 0;
    }

    public static class DftParams
    {
        public const int NonZeroRows = 0;
    }

    public static class DoGParams
    {
        public const int KernelSize1 = 0;
        public const int KernelSize2 = 1;
    }

    public static class DistanceTransformParams
    {
        public const int DistanceType = 0;
        public const int MaskSize = 1;
        public const int Threshold = 2;
    }

    public static class GaborParams
    {
        public const int KernelSize = 0;
        public const int Sigma = 1;
        public const int Theta = 2;
        public const int Lambda = 3;
        public const int Gamma = 4;
        public const int Psi = 5;
    }

    public static class GaussianBlurParams
    {
        public const int KernelSize = 0;
        public const int SigmaX = 1;
        public const int SigmaY = 2;
    }

    public static class HarrisCornerStrengthParams
    {
        public const int BlockSize = 0;
        public const int ApertureSize = 1;
        public const int K = 2;
    }

    public static class HoughCirclesParams
    {
        public const int CannyThreshold = 0;
        public const int AccumulatorThreshold = 1;
    }

    public static class HoughLinesParams
    {
        public const int Threshold = 0;
        public const int MinLineLength = 1;
        public const int MaxLineGap = 2;
    }

    public static class IntegralImageParams
    {
        public const int Type = 0;
    }

    public static class LaplacianEdgeDetectorParams
    {
        public const int ApertureSize = 0;
    }

    public static class MedianBlurParams
    {
        public const int Size = 0;
    }

    public static class MorphologicalDilateParams
    {
        public const int ElementShape = 0;
        public const int KernelSize = 1;
    }

    public static class MorphologicalErosionParams
    {
        public const int ElementShape = 0;
        public const int KernelShape = 1;
    }

    public static class NormalizeParams
    {
        public const int Alpha = 0;
        public const int Beta = 1;
    }

    public static class SobelOperatorParams
    {
        public const int Scale = 0;
        public const int Delta = 1;
        public const int XWeight = 2;
        public const int YWeight = 3;
    }

    public enum TransformationType //used also for sorting, to ensure the correct ordering in the chromosome
    {
        GaborFilter, //0 //Alex
        MorphologicalErode, //1 //Alex
        GaussianBlur, // 2 //Alex
        HoughCircles, // 3 //Alex
        Normalize, // 4 //Alex
        Dft, // 5 //Alex
        SquareRoot, //6 //Alex
        CannyEdge, //7 //Alex
        IntegralImage, // 8 //Alex
        DoG, // 9 
        Census, // 10
        SobelOperator, // 11
        MorphologicalDilate, // 12
        AdaptiveThresholding, // 13
        HoughLines, // 14
        HarrisCornerStrength, // 15
        HistogramEqualization, // 16
        Log, // 17 
        MedianBlur, //18
        DistanceTransform, // 19
        LaplacianEdgeDetection, //20
    };

    public sealed class TransformationInfo
    {
        public static bool IsTransformationGray(TransformationType type) // TODO write the actual number of parameters
        {
            switch (type)
            {
                case TransformationType.AdaptiveThresholding: 
                    return true;
                case TransformationType.CannyEdge:
                    return true;
                case TransformationType.Census:
                    return true;
                case TransformationType.Dft:
                    return true;
                case TransformationType.DistanceTransform:
                    return true;
                case TransformationType.DoG:
                    return false;
                case TransformationType.GaborFilter:
                    return false;
                case TransformationType.GaussianBlur:
                    return false;
                case TransformationType.HarrisCornerStrength:
                    return true;
                case TransformationType.HistogramEqualization:
                    return true;
                case TransformationType.HoughCircles:
                    return false;
                case TransformationType.HoughLines:
                    return true;
                case TransformationType.IntegralImage:
                    return true;
                case TransformationType.LaplacianEdgeDetection:
                    return true;
                case TransformationType.Log:
                    return false;
                case TransformationType.MedianBlur:
                    return true;
                case TransformationType.MorphologicalDilate:
                    return true;
                case TransformationType.MorphologicalErode:
                    return false;
                case TransformationType.Normalize:
                    return true;
                case TransformationType.SobelOperator:
                    return true;
                case TransformationType.SquareRoot:
                    return true;

            }
            throw new ArgumentException("Transformation not supported!");
        }

        public static int GetNumberOfParamsForTransformationType(TransformationType type) 
        {
            switch (type)
            {
                case TransformationType.AdaptiveThresholding:
                    return 5;
                case TransformationType.CannyEdge:
                    return 1;
                case TransformationType.Census:
                    return 1;
                case TransformationType.Dft:
                    return 1;
                case TransformationType.DistanceTransform:
                    return 3;
                case TransformationType.DoG:
                    return 2;
                case TransformationType.GaborFilter:
                    return 6;
                case TransformationType.GaussianBlur:
                    return 3;
                case TransformationType.HarrisCornerStrength:
                    return 3;
                case TransformationType.HistogramEqualization:
                    return 0;
                case TransformationType.HoughCircles:
                    return 2;
                case TransformationType.HoughLines:
                    return 3;
                case TransformationType.IntegralImage:
                    return 1;
                case TransformationType.LaplacianEdgeDetection:
                    return 1;
                case TransformationType.Log:
                    return 0;
                case TransformationType.MedianBlur:
                    return 1;
                case TransformationType.MorphologicalDilate:
                    return 2;
                case TransformationType.MorphologicalErode:
                    return 2;
                case TransformationType.Normalize:
                    return 2;
                case TransformationType.SobelOperator:
                    return 4;
                case TransformationType.SquareRoot:
                    return 0;
               
            }
            throw new ArgumentException("Transformation not supported!");
        }
    }
}