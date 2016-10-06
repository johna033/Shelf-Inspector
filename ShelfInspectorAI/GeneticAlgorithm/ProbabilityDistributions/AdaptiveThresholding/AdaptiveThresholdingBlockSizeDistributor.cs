namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.AdaptiveThresholding
{
    class AdaptiveThresholdingBlockSizeDistributor: IDistributedValue
    {
        private readonly int[] _possibleBlockSizes = { 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            int index = ((int) (10*uniformlyDistributedVariableValue));
            return _possibleBlockSizes[ index == 10 ? index - 1 : index];
        }
    }
}
