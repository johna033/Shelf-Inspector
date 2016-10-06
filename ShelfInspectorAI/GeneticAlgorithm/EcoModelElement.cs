using ShelfInspectorAI.NeuralNetworks;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    public class EcoModelElement
    {
        public EcoFeature Feature { get; set; }
        public double[] Classifier { get; set; }
        public double Score;

    }
}
