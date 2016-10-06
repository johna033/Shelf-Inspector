using System.Collections.Generic;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.CannyEdge;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Census;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.ChromosomeLength;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.DFT;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Distance;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.DoG;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.GaussianBlur;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HarrisCornerStrength;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughCircles;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughLines;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.IntegralImage;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.LaplacianEdgeDetector;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MedianBlur;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MorphologicalDilate;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MorphologicalErosion;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Normalize;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Sobel;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions
{
    internal enum GenericDistributionOperation
    {
        ChromosomeLengthDistributor
    };

    class DistributedValuesFactory
    {
        private readonly Dictionary<TransformationType, List<IDistributedValue>> _valuesManager;
        private readonly Dictionary<GenericDistributionOperation, IDistributedValue> _genericRandomValuesFactory; 
        private static  DistributedValuesFactory _instance;

        private DistributedValuesFactory()
        {
            List<IDistributedValue> adaptiveThrehsDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.AdaptiveThresholding));
            adaptiveThrehsDistributors[AdaptiveThreholdingParams.AdaptiveThresholdType] = new AdaptiveThresholdingAdaptiveThresholdingTypeDistributor();
            adaptiveThrehsDistributors[AdaptiveThreholdingParams.Blocksize] = new AdaptiveThresholdingBlockSizeDistributor();
            adaptiveThrehsDistributors[AdaptiveThreholdingParams.Param1] = new AdaptiveThresholdingParam1Distributor();
            adaptiveThrehsDistributors[AdaptiveThreholdingParams.ThresholdType] = new AdaptiveThresholdingThresholdTypeDistributor();
            adaptiveThrehsDistributors[AdaptiveThreholdingParams.ThresholdValue] = new AdaptiveThresholdingThreholdValueDistributor();

            List<IDistributedValue> cannyEdgeDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.CannyEdge));
            cannyEdgeDistributors[CannyEdgeParams.Threshold] = new CannyEdgeThresholdDistributor();

            List<IDistributedValue> censusDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.Census));
            censusDistributors[CensusParams.WindowSize] = new CensusWindowSizeDistributor();

            List<IDistributedValue> dftDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.Dft));
            dftDistributors[DftParams.NonZeroRows] = new DftNonZeroRowsDistributor();

            List<IDistributedValue> dogDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.DoG));
            dogDistributors[DoGParams.KernelSize1] = new DogKernelSizeDistributor();
            dogDistributors[DoGParams.KernelSize2] = new DogKernelSizeDistributor();

            List<IDistributedValue> distanceTransformDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.DistanceTransform));

            distanceTransformDistributors[DistanceTransformParams.DistanceType] = new DistanceDistanceTypeDistributor();
            distanceTransformDistributors[DistanceTransformParams.MaskSize] = new DistanceMaskSizeDistributor();
            distanceTransformDistributors[DistanceTransformParams.Threshold] = new DistanceThresholdDistributor();

            List<IDistributedValue> gaborDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.GaborFilter));
            gaborDistributors[GaborParams.Gamma] = new GaborGammaDistributor();
            gaborDistributors[GaborParams.KernelSize] = new GaborKernelSizeDistributorcs();
            gaborDistributors[GaborParams.Lambda] = new GaborLambdaDistributor();
            gaborDistributors[GaborParams.Psi] = new GaborPsiDistributor();
            gaborDistributors[GaborParams.Sigma] = new GaborSigmaDistributor();
            gaborDistributors[GaborParams.Theta] = new GaborThetaDistributor();

            List<IDistributedValue> gaussianBlurDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.GaussianBlur));

            gaussianBlurDistributors[GaussianBlurParams.KernelSize] = new GaussianBlurKernelSizeDistributor();
            gaussianBlurDistributors[GaussianBlurParams.SigmaX] = new GaussianBlurSigmaXDistributor();
            gaussianBlurDistributors[GaussianBlurParams.SigmaY] = new GaussianBlurSigmaYDistributor();

            List<IDistributedValue> harrisCornerDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.HarrisCornerStrength));
            harrisCornerDistributors[HarrisCornerStrengthParams.ApertureSize] = new HarrisCornerStrengthApertureDistributor();
            harrisCornerDistributors[HarrisCornerStrengthParams.BlockSize] = new HarrisCornerStrengthBlockSizeDistributor();
            harrisCornerDistributors[HarrisCornerStrengthParams.K] = new HarrisCornerStrengthKDistributor();

            List<IDistributedValue> houghCirclesDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.HoughCircles));

            houghCirclesDistributors[HoughCirclesParams.AccumulatorThreshold] = new HoughCirclesAccumulatorThresholdDistributor();
            houghCirclesDistributors[HoughCirclesParams.CannyThreshold] = new HoughCirclesCannyThresholdDistributor();

            List<IDistributedValue> houghLinesDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.HoughLines));
            houghLinesDistributors[HoughLinesParams.Threshold] = new HoughLinesThresholdDistributor();
            houghLinesDistributors[HoughLinesParams.MaxLineGap] = new HoughLinesMaxLineGapDistributor();
            houghLinesDistributors[HoughLinesParams.MinLineLength] = new HoughLinesMinLineLengthDistributor();

            List<IDistributedValue> integralImageDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.IntegralImage));
            integralImageDistributors[IntegralImageParams.Type] = new IntegralImageTypeDistributor();

            List<IDistributedValue> laplacianEdgeDetectorDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.LaplacianEdgeDetection));
            laplacianEdgeDetectorDistributors[LaplacianEdgeDetectorParams.ApertureSize] = new LaplacianEdgeDetectorApertureSizeDistributor();

            List<IDistributedValue> medianBlurDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.MedianBlur));
            medianBlurDistributors[MedianBlurParams.Size] = new MedianBlurSizeDistributor();

            List<IDistributedValue> morphDialteDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.MorphologicalDilate));
            morphDialteDistributors[MorphologicalDilateParams.ElementShape] = new MorphologicalDilateElementShapeDistributor();
            morphDialteDistributors[MorphologicalDilateParams.KernelSize] = new MorphologicalDilateKernelSizeDistributor();

            List<IDistributedValue> morphErosionDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.MorphologicalErode));
            morphErosionDistributors[MorphologicalErosionParams.ElementShape] = new MorphologicalErosionElementShapeDistributor();
            morphErosionDistributors[MorphologicalErosionParams.KernelShape] = new MorphologicalErosionKernelSizeDistributor();

            List<IDistributedValue> normalizeDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.Normalize));
            normalizeDistributors[NormalizeParams.Alpha] = new NormalizeAlphaDistributor();
            normalizeDistributors[NormalizeParams.Beta] = new NormalizeBetaDistributor();

            List<IDistributedValue> sobelDistributors = Util.Util.AllocateList<IDistributedValue>(TransformationInfo.
                                                                            GetNumberOfParamsForTransformationType(TransformationType.SobelOperator));
            sobelDistributors[SobelOperatorParams.Delta] = new SobelDeltaDistributor();
            sobelDistributors[SobelOperatorParams.Scale] = new SobelScaleDistributor();
            sobelDistributors[SobelOperatorParams.XWeight] = new SobelYWeightDistributor();
            sobelDistributors[SobelOperatorParams.YWeight] = new SobelYWeightDistributor();

            

            _valuesManager = new Dictionary<TransformationType, List<IDistributedValue>>
            {
                {TransformationType.AdaptiveThresholding, adaptiveThrehsDistributors},
                {TransformationType.CannyEdge, cannyEdgeDistributors},
                {TransformationType.Census, censusDistributors},
                {TransformationType.Dft, dftDistributors},
                {TransformationType.DistanceTransform, distanceTransformDistributors},
                {TransformationType.DoG, dogDistributors},
                {TransformationType.GaborFilter, gaborDistributors},
                {TransformationType.GaussianBlur, gaussianBlurDistributors},
                {TransformationType.HarrisCornerStrength, harrisCornerDistributors},
                {TransformationType.HoughCircles, houghCirclesDistributors},
                {TransformationType.HoughLines, houghLinesDistributors},
                {TransformationType.IntegralImage, integralImageDistributors},
                {TransformationType.LaplacianEdgeDetection, laplacianEdgeDetectorDistributors},
                {TransformationType.MedianBlur, medianBlurDistributors},
                {TransformationType.MorphologicalDilate, morphDialteDistributors},
                {TransformationType.MorphologicalErode, morphErosionDistributors},
                {TransformationType.Normalize, normalizeDistributors},
                {TransformationType.SobelOperator, sobelDistributors},
            };

            IDistributedValue chromosomeLengthDistributor =  new ChromosomeLengthDistributor();

            _genericRandomValuesFactory = new Dictionary<GenericDistributionOperation, IDistributedValue>
            {
                {GenericDistributionOperation.ChromosomeLengthDistributor, chromosomeLengthDistributor }
            };
        }

        public static int GetDistributedValue(GenericDistributionOperation operation, double uniformlyDistributedVariable
            )
        {
            if (_instance == null)
            {
                _instance = new DistributedValuesFactory();
            }
            return (int)_instance._genericRandomValuesFactory[operation].GetDistributedValue(uniformlyDistributedVariable);
        }

        public static object GetDistributedValue(TransformationType type, int paramIndex, double uniformlyDistributedVariable)  // this comes from enum
        {
            if (_instance == null)
            {
                _instance = new DistributedValuesFactory();
            }
            return _instance._valuesManager[type][paramIndex].GetDistributedValue(uniformlyDistributedVariable);
        }
    }
}
