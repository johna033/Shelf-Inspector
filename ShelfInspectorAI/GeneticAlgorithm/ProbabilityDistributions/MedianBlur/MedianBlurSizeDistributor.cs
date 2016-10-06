namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MedianBlur
{
    class MedianBlurSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int)uniformlyDistributedVariableValue * 21) | 0x1;
        }
    }
}
