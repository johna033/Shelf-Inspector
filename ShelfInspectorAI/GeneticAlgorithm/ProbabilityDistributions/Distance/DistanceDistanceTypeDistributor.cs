using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.Distance
{
    class DistanceDistanceTypeDistributor: IDistributedValue
    {
        private readonly object _l1 = BuildEmguType.BuildDistanceType(DistanceType.L1);
        private readonly object _l2 = BuildEmguType.BuildDistanceType(DistanceType.L2);
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return (uniformlyDistributedVariableValue <= 0.5) ? _l1 : _l2;
        }
    }
}
