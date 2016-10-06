

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Distance
{
    class DistanceThresholdDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int) (uniformlyDistributedVariableValue*255);
        }
    }
}
