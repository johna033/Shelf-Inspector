using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding
{
    class AdaptiveThresholdingThresholdTypeDistributor: IDistributedValue
    {
        private readonly object _bin = BuildEmguType.BuildThresholdType(ThresholdType.BinaryInv);
        private readonly object _inv = BuildEmguType.BuildThresholdType(ThresholdType.BinaryInv);
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue >= 0.5 ? _inv : _bin;
        }
    }
}
