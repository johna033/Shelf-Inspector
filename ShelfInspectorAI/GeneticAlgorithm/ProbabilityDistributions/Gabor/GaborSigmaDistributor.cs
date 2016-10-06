
namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor
{
    class GaborSigmaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*10;
        }
    }
}
