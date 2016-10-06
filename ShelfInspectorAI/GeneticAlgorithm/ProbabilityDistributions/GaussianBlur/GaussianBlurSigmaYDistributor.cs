
namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.GaussianBlur
{
    class GaussianBlurSigmaYDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int)uniformlyDistributedVariableValue) * 5;
        }
    }
}
