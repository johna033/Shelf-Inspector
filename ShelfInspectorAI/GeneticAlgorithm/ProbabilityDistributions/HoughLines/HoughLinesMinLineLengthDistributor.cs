namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughLines
{
    class HoughLinesMinLineLengthDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*200;
        }
    }
}
