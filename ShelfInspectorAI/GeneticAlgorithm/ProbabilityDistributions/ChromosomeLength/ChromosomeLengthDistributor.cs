namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.ChromosomeLength
{
    class ChromosomeLengthDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int) (3*(uniformlyDistributedVariableValue)+1);
        }
    }
}
