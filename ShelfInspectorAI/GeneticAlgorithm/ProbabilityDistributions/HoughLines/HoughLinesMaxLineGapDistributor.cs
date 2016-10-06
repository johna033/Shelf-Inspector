

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughLines
{
    class HoughLinesMaxLineGapDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*20;
        }
    }
}
