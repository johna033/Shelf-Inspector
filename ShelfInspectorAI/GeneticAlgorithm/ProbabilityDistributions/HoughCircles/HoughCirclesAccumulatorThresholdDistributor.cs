using System;
using ShelfInspectorImg.Api;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughCircles
{
    class HoughCirclesAccumulatorThresholdDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return BuildEmguType.BuildGrayColor(Math.Abs(uniformlyDistributedVariableValue) < 0.01 ? 255.0 / 2 : 255*uniformlyDistributedVariableValue / 2);
        }
    }
}
