using System;
using System.Collections.Generic;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.DTO;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    internal interface IBuildParamsBlock
    {
        TransformationParameters Build(List<double> values);
    }

    internal sealed class ParameterBlockFactory
    {
        private readonly Dictionary<TransformationType, IBuildParamsBlock> _builders;
        private static readonly ParameterBlockFactory Instance = new ParameterBlockFactory();

        private ParameterBlockFactory()
        {
            _builders = new Dictionary<TransformationType, IBuildParamsBlock>
            {
                {TransformationType.AdaptiveThresholding, new AdaptiveThresholdParamBlockBuilder()},
                {TransformationType.CannyEdge, new CannyEdgeParamBlockBuilder()},
                {TransformationType.Census, new CensusTransformParamBlockBuilder()},
                {TransformationType.Dft, new DftParamBlockBuilder()},
                {TransformationType.DistanceTransform, new DistanceParamBlockBuilder()},
                {TransformationType.DoG, new DoGParamBlockBuilder()},
                {TransformationType.GaborFilter, new GaborFilterParamBlockBuilder()},
                {TransformationType.GaussianBlur, new GaussianBlurParamBlockBuilder()},
                {TransformationType.HarrisCornerStrength, new HarrisCornerParamBlockBuilder()},
                {TransformationType.HistogramEqualization, new StubParamBlockBuilder()},
                {TransformationType.HoughCircles, new HoughCirclesParamBlockBuilder()},
                {TransformationType.HoughLines, new HoughLinesParamBlockBuilder()},
                {TransformationType.IntegralImage, new IntegralImageParamBlockBuilder()},
                {TransformationType.LaplacianEdgeDetection, new LaplacianEdgeDetectorParamBlockBuilder()},
                {TransformationType.Log, new StubParamBlockBuilder()},
                {TransformationType.MedianBlur, new MedianBlurDetectorParamBlockBuilder()},
                {TransformationType.MorphologicalDilate, new MorphologicalDilateParamBlockBuilder()},
                {TransformationType.MorphologicalErode, new MorphologicalErodeParamBlockBuilder()},
                {TransformationType.Normalize, new NormalizeParamBlockBuilder()},
                {TransformationType.SobelOperator, new SobelParamBlockBuilder()},
                {TransformationType.SquareRoot, new StubParamBlockBuilder()},
            };
        }

        public static TransformationParameters BuildParameterBlock(TransformationType type, List<double> values)
        {
            return Instance._builders[type].Build(values);
        }
    }
    internal sealed class StubParamBlockBuilder: IBuildParamsBlock
    {
        private readonly TransformationParameters _params = new TransformationParameters{Parameters = new List<object>(0)};
        public TransformationParameters Build(List<double> values)
        {
            return _params;
        }
    }

    internal sealed class AdaptiveThresholdParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.AdaptiveThresholding))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for adaptive thresholding!");
            }
            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[AdaptiveThreholdingParams.ThresholdValue] = DistributedValuesFactory.GetDistributedValue(TransformationType.AdaptiveThresholding,
                AdaptiveThreholdingParams.ThresholdValue, values[AdaptiveThreholdingParams.ThresholdValue]);

            _params.Parameters[AdaptiveThreholdingParams.AdaptiveThresholdType] = DistributedValuesFactory.GetDistributedValue(TransformationType.AdaptiveThresholding,
                AdaptiveThreholdingParams.AdaptiveThresholdType, values[AdaptiveThreholdingParams.AdaptiveThresholdType]);

            _params.Parameters[AdaptiveThreholdingParams.ThresholdType] = DistributedValuesFactory.GetDistributedValue(TransformationType.AdaptiveThresholding,
                AdaptiveThreholdingParams.ThresholdType, values[AdaptiveThreholdingParams.ThresholdType]);

            _params.Parameters[AdaptiveThreholdingParams.Blocksize] = DistributedValuesFactory.GetDistributedValue(TransformationType.AdaptiveThresholding,
                AdaptiveThreholdingParams.Blocksize, values[AdaptiveThreholdingParams.Blocksize]);

            _params.Parameters[AdaptiveThreholdingParams.Param1] = DistributedValuesFactory.GetDistributedValue(TransformationType.AdaptiveThresholding,
                AdaptiveThreholdingParams.Param1, values[AdaptiveThreholdingParams.Param1]);

            return _params;
        }
    }
    internal sealed class CannyEdgeParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.CannyEdge))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for CannyEdge!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[CannyEdgeParams.Threshold] = DistributedValuesFactory.GetDistributedValue(TransformationType.CannyEdge,
                CannyEdgeParams.Threshold, values[CannyEdgeParams.Threshold]);

            return _params;
        }
    }
    internal sealed class CensusTransformParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.Census))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for CensusTransform!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[CensusParams.WindowSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.Census,
                CensusParams.WindowSize, values[CensusParams.WindowSize]);

            return _params;
        }
    }
    internal sealed class DftParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.Dft))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for DFT!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[DftParams.NonZeroRows] = DistributedValuesFactory.GetDistributedValue(TransformationType.Dft,
                DftParams.NonZeroRows, values[DftParams.NonZeroRows]);

            return _params;
        }
    }
    internal sealed class DistanceParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.DistanceTransform))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for DistanceTransform!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[DistanceTransformParams.Threshold] = DistributedValuesFactory.GetDistributedValue(TransformationType.DistanceTransform,
                DistanceTransformParams.Threshold, values[DistanceTransformParams.Threshold]);
            _params.Parameters[DistanceTransformParams.DistanceType] = DistributedValuesFactory.GetDistributedValue(TransformationType.DistanceTransform,
                DistanceTransformParams.DistanceType, values[DistanceTransformParams.DistanceType]);
            _params.Parameters[DistanceTransformParams.MaskSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.DistanceTransform,
                DistanceTransformParams.MaskSize, values[DistanceTransformParams.MaskSize]);

            return _params;
        }
    }
    internal sealed class DoGParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.DoG))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for DoG!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[DoGParams.KernelSize1] = DistributedValuesFactory.GetDistributedValue(TransformationType.DoG,
                DoGParams.KernelSize1, values[DoGParams.KernelSize1]);
            _params.Parameters[DoGParams.KernelSize2] = DistributedValuesFactory.GetDistributedValue(TransformationType.DoG,
                DoGParams.KernelSize2, values[DoGParams.KernelSize2]);

            return _params;
        }
    }
    internal sealed class GaborFilterParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.GaborFilter))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for Gabor filter!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[GaborParams.Gamma] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.Gamma, values[GaborParams.Gamma]);
            _params.Parameters[GaborParams.KernelSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.KernelSize, values[GaborParams.KernelSize]);
            _params.Parameters[GaborParams.Sigma] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.Sigma, values[GaborParams.Sigma]);
            _params.Parameters[GaborParams.Lambda] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.Lambda, values[GaborParams.Lambda]);
            _params.Parameters[GaborParams.Psi] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.Psi, values[GaborParams.Psi]);
            _params.Parameters[GaborParams.Theta] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaborFilter,
                GaborParams.Theta, values[GaborParams.Theta]);

            return _params;
        }
    }
    internal sealed class GaussianBlurParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.GaussianBlur))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for Gaussian blur!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[GaussianBlurParams.KernelSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaussianBlur,
                GaussianBlurParams.KernelSize, values[GaussianBlurParams.KernelSize]);
            _params.Parameters[GaussianBlurParams.SigmaX] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaussianBlur,
                GaussianBlurParams.SigmaX, values[GaussianBlurParams.SigmaX]);
            _params.Parameters[GaussianBlurParams.SigmaY] = DistributedValuesFactory.GetDistributedValue(TransformationType.GaussianBlur,
                GaussianBlurParams.SigmaY, values[GaussianBlurParams.SigmaY]);

            return _params;
        }
    }
    internal sealed class HarrisCornerParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.HarrisCornerStrength))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for HarrisCornerStrength!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[HarrisCornerStrengthParams.ApertureSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.HarrisCornerStrength,
                HarrisCornerStrengthParams.ApertureSize, values[HarrisCornerStrengthParams.ApertureSize]);
            _params.Parameters[HarrisCornerStrengthParams.BlockSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.HarrisCornerStrength,
                HarrisCornerStrengthParams.BlockSize, values[HarrisCornerStrengthParams.BlockSize]);
            _params.Parameters[HarrisCornerStrengthParams.K] = DistributedValuesFactory.GetDistributedValue(TransformationType.HarrisCornerStrength,
                HarrisCornerStrengthParams.K, values[HarrisCornerStrengthParams.K]);

            return _params;
        }
    }
    internal sealed class HoughCirclesParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.HoughCircles))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for HoughCircles!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[HoughCirclesParams.AccumulatorThreshold] = DistributedValuesFactory.GetDistributedValue(TransformationType.HoughCircles,
                HoughCirclesParams.AccumulatorThreshold, values[HoughCirclesParams.AccumulatorThreshold]);
            _params.Parameters[HoughCirclesParams.CannyThreshold] = DistributedValuesFactory.GetDistributedValue(TransformationType.HoughCircles,
                HoughCirclesParams.CannyThreshold, values[HoughCirclesParams.CannyThreshold]);

            return _params;
        }
    }
    internal sealed class HoughLinesParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.HoughLines))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for HoughLines!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[HoughLinesParams.Threshold] = DistributedValuesFactory.GetDistributedValue(TransformationType.HoughLines,
                HoughLinesParams.Threshold, values[HoughLinesParams.Threshold]);
            _params.Parameters[HoughLinesParams.MaxLineGap] = DistributedValuesFactory.GetDistributedValue(TransformationType.HoughLines,
                HoughLinesParams.MaxLineGap, values[HoughLinesParams.MaxLineGap]);
            _params.Parameters[HoughLinesParams.MinLineLength] = DistributedValuesFactory.GetDistributedValue(TransformationType.HoughLines,
                HoughLinesParams.MinLineLength, values[HoughLinesParams.MinLineLength]);

            return _params;
        }
    }
    internal sealed class IntegralImageParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.IntegralImage))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for IntegralImage!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[IntegralImageParams.Type] = DistributedValuesFactory.GetDistributedValue(TransformationType.IntegralImage,
                IntegralImageParams.Type, values[IntegralImageParams.Type]);

            return _params;
        }
    }
    internal sealed class LaplacianEdgeDetectorParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.LaplacianEdgeDetection))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for LaplacianEdgeDetection!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[LaplacianEdgeDetectorParams.ApertureSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.LaplacianEdgeDetection,
                LaplacianEdgeDetectorParams.ApertureSize, values[LaplacianEdgeDetectorParams.ApertureSize]);

            return _params;
        }
    }
    internal sealed class MedianBlurDetectorParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.MedianBlur))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for MedianBlur!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[MedianBlurParams.Size] = DistributedValuesFactory.GetDistributedValue(TransformationType.MedianBlur,
                MedianBlurParams.Size, values[MedianBlurParams.Size]);

            return _params;
        }
    }
    internal sealed class MorphologicalDilateParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.MorphologicalDilate))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for MorphologicalDilate!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[MorphologicalDilateParams.KernelSize] = DistributedValuesFactory.GetDistributedValue(TransformationType.MorphologicalDilate,
                MorphologicalDilateParams.KernelSize, values[MorphologicalDilateParams.KernelSize]);
            _params.Parameters[MorphologicalDilateParams.ElementShape] = DistributedValuesFactory.GetDistributedValue(TransformationType.MorphologicalDilate,
                MorphologicalDilateParams.ElementShape, values[MorphologicalDilateParams.ElementShape]);

            return _params;
        }
    }
    internal sealed class MorphologicalErodeParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.MorphologicalErode))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for MorphologicalErose!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[MorphologicalErosionParams.ElementShape] = DistributedValuesFactory.GetDistributedValue(TransformationType.MorphologicalErode,
                MorphologicalErosionParams.ElementShape, values[MorphologicalErosionParams.ElementShape]);
            _params.Parameters[MorphologicalErosionParams.KernelShape] = DistributedValuesFactory.GetDistributedValue(TransformationType.MorphologicalErode,
                MorphologicalErosionParams.KernelShape, values[MorphologicalErosionParams.KernelShape]);

            return _params;
        }
    }
    internal sealed class NormalizeParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.Normalize))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for Normalize!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[NormalizeParams.Alpha] = DistributedValuesFactory.GetDistributedValue(TransformationType.Normalize,
                NormalizeParams.Alpha, values[NormalizeParams.Alpha]);
            _params.Parameters[NormalizeParams.Beta] = DistributedValuesFactory.GetDistributedValue(TransformationType.Normalize,
                NormalizeParams.Beta, values[NormalizeParams.Beta]);

            return _params;
        }
    }
    internal sealed class SobelParamBlockBuilder : IBuildParamsBlock
    {
        public TransformationParameters Build(List<double> values)
        {
            if (values.Count !=
                TransformationInfo.GetNumberOfParamsForTransformationType(TransformationType.SobelOperator))
            {
                throw new ArgumentException("Incorrect number of parameters for building param block for SobelOperator!");
            }

            TransformationParameters _params = new TransformationParameters { Parameters = Util.Util.AllocateList<object>(values.Count) };

            _params.Parameters[SobelOperatorParams.Delta] = DistributedValuesFactory.GetDistributedValue(TransformationType.SobelOperator,
                SobelOperatorParams.Delta, values[SobelOperatorParams.Delta]);
            _params.Parameters[SobelOperatorParams.Scale] = DistributedValuesFactory.GetDistributedValue(TransformationType.SobelOperator,
                SobelOperatorParams.Scale, values[SobelOperatorParams.Scale]);
            _params.Parameters[SobelOperatorParams.XWeight] = DistributedValuesFactory.GetDistributedValue(TransformationType.SobelOperator,
                SobelOperatorParams.XWeight, values[SobelOperatorParams.XWeight]);
            _params.Parameters[SobelOperatorParams.YWeight] = DistributedValuesFactory.GetDistributedValue(TransformationType.SobelOperator,
                SobelOperatorParams.YWeight, values[SobelOperatorParams.YWeight]);

            return _params;
        }
    }
    

    public sealed class EcoFeatureParameterContainer
    {
        private readonly TransformationParameters _params;
        private readonly TransformationType _type;

        public EcoFeatureParameterContainer(List<double> values, TransformationType type)
        {
            _type = type;
            _params = ParameterBlockFactory.BuildParameterBlock(_type, values);
        }



        public TransformationParameters GetParameters()
        {
            return _params;
        }

        public void SetParamValueByIndex(int index, double value)
        {
            _params.Parameters[index] = DistributedValuesFactory.GetDistributedValue(_type, index, value);
        }

        public static int GetNumberOfParametersForTransformation(TransformationType type)
        {
            return TransformationInfo.GetNumberOfParamsForTransformationType(type);
        }
    }
}
