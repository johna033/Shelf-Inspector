namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MorphologicalErosion
{
    class MorphologicalErosionKernelSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int)((uniformlyDistributedVariableValue + 1.0) * 10.5);
        }
    }
}
