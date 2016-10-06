using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.HarrisCornerStrength
{
    class HarrisCornerStrengthApertureDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (int)Math.Round(uniformlyDistributedVariableValue);
        }
    }
}
