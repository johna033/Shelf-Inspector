
namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.GaussianBlur
{
    class GaussianBlurSigmaXDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int) uniformlyDistributedVariableValue)*5;
        }
    }
}
