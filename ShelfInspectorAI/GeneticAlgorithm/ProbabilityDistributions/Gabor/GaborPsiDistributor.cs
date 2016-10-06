
using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor
{
    class GaborPsiDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*Math.PI;
        }
    }
}
