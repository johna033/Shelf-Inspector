using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.MorphologicalErosion
{
    class MorphologicalErosionElementShapeDistributor: IDistributedValue
    {
        private readonly object _rect = BuildEmguType.BuildMorphologyElementShape(MorphologyElementShape.Rectangle);
        private readonly object _cross = BuildEmguType.BuildMorphologyElementShape(MorphologyElementShape.Cross);
        private readonly object _ellipse = BuildEmguType.BuildMorphologyElementShape(MorphologyElementShape.Ellipse);

        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return uniformlyDistributedVariableValue <= 0.3
                ? _rect
                : uniformlyDistributedVariableValue > 0.3 && uniformlyDistributedVariableValue <= 0.6
                    ? _cross
                    : _ellipse;
        }
    }
}
