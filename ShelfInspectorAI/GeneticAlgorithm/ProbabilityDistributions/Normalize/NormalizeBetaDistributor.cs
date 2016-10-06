namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Normalize
{
    class NormalizeBetaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int)uniformlyDistributedVariableValue * 255;
        }
    }
}
