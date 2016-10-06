namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.IntegralImage
{
    class IntegralImageTypeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue <= 0.3
                ? 0
                : uniformlyDistributedVariableValue > 0.3 && uniformlyDistributedVariableValue < 0.6 ? 1 : 2;

        }
    }
}
