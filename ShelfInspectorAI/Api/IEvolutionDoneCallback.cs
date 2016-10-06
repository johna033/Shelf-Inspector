using ShelfInspectorAI.GeneticAlgorithm;

namespace ShelfInspectorAI.Api
{
    public interface IEvolutionDoneCallback
    {
        void EvolutionDone(EcoModel model);
    }
}
