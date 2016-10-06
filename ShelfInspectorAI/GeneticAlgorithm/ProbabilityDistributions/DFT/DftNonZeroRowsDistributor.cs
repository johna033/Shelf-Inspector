namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.DFT
{
    class DftNonZeroRowsDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int) (uniformlyDistributedVariableValue*10);
        }
    }
}
