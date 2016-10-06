using System;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ShelfInspectorImg.Data;

namespace ShelfInspectorImg.Api
{
    public class BuildEmguType
    {
        public static object BuildGrayColor(double intensity)
        {
            return new Gray(intensity);
        }

        public static object BuildAdaptiveThresholdType(AdaptiveThresholdType type)
        {
            return (type == AdaptiveThresholdType.Gaussian)
                ? ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C
                : ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C;
        }

        public static object BuildThresholdType(ThresholdType type)
        {
            switch (type)
            {
                case ThresholdType.Binary:
                    return THRESH.CV_THRESH_BINARY;
                case ThresholdType.BinaryInv:
                    return THRESH.CV_THRESH_BINARY_INV;
                case ThresholdType.Mask:
                    return THRESH.CV_THRESH_MASK;
                case ThresholdType.Otsu:
                    return THRESH.CV_THRESH_OTSU;
                case ThresholdType.ToZero:
                    return THRESH.CV_THRESH_TOZERO;
                case ThresholdType.ToZeroInv:
                    return THRESH.CV_THRESH_TOZERO_INV;
                case ThresholdType.Trunc:
                    return THRESH.CV_THRESH_TRUNC;
                default:
                    throw new Exception("Threshold type not fucking supported!!!");
            }
        }

        public static object BuildDistanceType(DistanceType type)
        {
            return (type == DistanceType.L1) ? DIST_TYPE.CV_DIST_L1 : DIST_TYPE.CV_DIST_L2;
        }

        public static object BuildMorphologyElementShape(MorphologyElementShape shape)
        {
            return (shape == MorphologyElementShape.Cross)
                ? CV_ELEMENT_SHAPE.CV_SHAPE_CROSS
                : (shape == MorphologyElementShape.Ellipse)
                    ? CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE
                    : CV_ELEMENT_SHAPE.CV_SHAPE_RECT;
        }
    }
}
