namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Sobel
{
    class SobelScaleDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int)uniformlyDistributedVariableValue * 10;
        }
    }
}
