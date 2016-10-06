using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.GaussianBlur
{
    class GaussianBlurKernelSizeDistributor: IDistributedValue
    {
        private int[] _possibleValues = {3, 5, 7, 9, 11, 13, 15, 17, 29, 21};
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            int index = ((int) (uniformlyDistributedVariableValue*10));
            return _possibleValues[index == 10 ? index  - 1 : index];
        }
    }
}
