using ShelfInspectorImg.Api;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding
{
    class AdaptiveThresholdingThreholdValueDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return BuildEmguType.BuildGrayColor(uniformlyDistributedVariableValue*255);
        }
    }
}
