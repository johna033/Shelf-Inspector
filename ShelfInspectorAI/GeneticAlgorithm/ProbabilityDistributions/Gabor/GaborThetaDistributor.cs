using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor
{
    class GaborThetaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*Math.PI;
        }
    }
}
