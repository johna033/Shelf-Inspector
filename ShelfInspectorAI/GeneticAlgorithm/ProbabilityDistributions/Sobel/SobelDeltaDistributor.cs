namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Sobel
{
    class SobelDeltaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int) uniformlyDistributedVariableValue*10;
        }
    }
}
