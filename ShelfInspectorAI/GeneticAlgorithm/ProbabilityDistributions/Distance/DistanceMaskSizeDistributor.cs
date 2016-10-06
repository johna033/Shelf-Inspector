namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Distance
{
    class DistanceMaskSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (uniformlyDistributedVariableValue <= 0.3)
                ? 3
                : (uniformlyDistributedVariableValue > 0.3 && uniformlyDistributedVariableValue <= 0.6) ? 5 : 0;
        }
    }
}
