using System.Collections.Generic;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    public class EcoModel
    {
        public List<EcoModelElement> ModelElements { get; set; }

        public EcoModel(int populationSize)
        {
            ModelElements = Util.Util.AllocateList<EcoModelElement>(populationSize);
        }

    }
}
