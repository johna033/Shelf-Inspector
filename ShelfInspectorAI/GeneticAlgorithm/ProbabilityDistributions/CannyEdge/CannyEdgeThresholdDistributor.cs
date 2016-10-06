namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.CannyEdge
{
    class CannyEdgeThresholdDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {

            return uniformlyDistributedVariableValue*99+1;
        }
    }
}
