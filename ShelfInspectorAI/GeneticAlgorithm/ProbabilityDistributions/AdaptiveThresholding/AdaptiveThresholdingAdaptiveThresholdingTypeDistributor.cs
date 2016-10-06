using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding
{
    class AdaptiveThresholdingAdaptiveThresholdingTypeDistributor: IDistributedValue
    {
        private readonly object _gaussian = BuildEmguType.BuildAdaptiveThresholdType(AdaptiveThresholdType.Gaussian);
        private readonly object _mean = BuildEmguType.BuildAdaptiveThresholdType(AdaptiveThresholdType.Mean);
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue >= 0.5 ? _mean : _gaussian;
        }
    }
}
