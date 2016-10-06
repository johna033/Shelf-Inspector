using System;
using ShelfInspectorImg.Api;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HoughCircles
{
    class HoughCirclesCannyThresholdDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return BuildEmguType.BuildGrayColor(Math.Abs(uniformlyDistributedVariableValue) < 0.01 ? 1.0 : 255*uniformlyDistributedVariableValue);
        }
    }
}
