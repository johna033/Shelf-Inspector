namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor
{
    class GaborKernelSizeDistributorcs: IDistributedValue
    {
        private readonly int[] _possibleKernelSizes = {2, 4, 6, 8, 10};
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return _possibleKernelSizes[((int) uniformlyDistributedVariableValue*5)];
        }
    }
}
