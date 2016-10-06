namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MorphologicalDilate
{
    class MorphologicalDilateKernelSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int) ((uniformlyDistributedVariableValue + 1.0)*10.5);
        }
    }
}
