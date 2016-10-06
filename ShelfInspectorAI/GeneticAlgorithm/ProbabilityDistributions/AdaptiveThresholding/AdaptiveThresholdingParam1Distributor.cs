using ShelfInspectorImg.Api;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding
{
    class AdaptiveThresholdingParam1Distributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return BuildEmguType.BuildGrayColor((255*uniformlyDistributedVariableValue+1)/2.0);
        }
    }
}
