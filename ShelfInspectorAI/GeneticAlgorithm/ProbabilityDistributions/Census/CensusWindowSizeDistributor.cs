using System;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Census
{
    class CensusWindowSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int) (uniformlyDistributedVariableValue*3)) | 0x1;
        }
    }
}
