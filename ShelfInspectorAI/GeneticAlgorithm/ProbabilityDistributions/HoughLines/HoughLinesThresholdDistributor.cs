using System;
using ShelfInspectorImg.Api;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughLines
{
    class HoughLinesThresholdDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return Math.Abs(uniformlyDistributedVariableValue) < 0.01 ? 1.0 : 100*uniformlyDistributedVariableValue ;
        }
    }
}
