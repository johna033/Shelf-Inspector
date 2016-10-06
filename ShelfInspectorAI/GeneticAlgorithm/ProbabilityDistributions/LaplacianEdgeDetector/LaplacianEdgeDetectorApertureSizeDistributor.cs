namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.LaplacianEdgeDetector
{
    class LaplacianEdgeDetectorApertureSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int) uniformlyDistributedVariableValue*21) | 0x1;
        }
    }
}
