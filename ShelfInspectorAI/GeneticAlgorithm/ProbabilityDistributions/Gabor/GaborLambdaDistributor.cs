using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Gabor
{
    class GaborLambdaDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue*Math.PI;
        }
    }
}
