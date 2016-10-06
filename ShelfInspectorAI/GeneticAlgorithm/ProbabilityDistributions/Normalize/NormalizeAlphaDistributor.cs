namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Normalize
{
    class NormalizeAlphaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int)uniformlyDistributedVariableValue*255;
        }
    }
}
