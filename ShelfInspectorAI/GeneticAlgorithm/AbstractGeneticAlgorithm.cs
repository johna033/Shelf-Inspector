namespace ShelfInspectorAI.GeneticAlgorithm
{
    /// <summary>
    /// A class of an abstract genetic algorithm
    /// </summary>
    /// <typeparam name="TCreature">Type of the creature</typeparam>
    /// <typeparam name="TFittnessValue">Type, returned by the fitness function</typeparam>
    /// <typeparam name="TEvolvedModel">Type, representing trained model</typeparam>
    /// <typeparam name="TFittnessFunctionArgument">Argument for the fitness function</typeparam>
    public abstract class AbstractGeneticAlgorithm<TCreature, TFittnessValue, TFittnessFunctionArgument ,TEvolvedModel>
    {
        protected int PopulationSize;
        protected int NumberOfGenerations;
        protected double MutationRate;

        protected AbstractGeneticAlgorithm(int populationSize, int numberOfGenerations, double mutationRate)
        {
            PopulationSize = populationSize;
            NumberOfGenerations = numberOfGenerations;
            MutationRate = mutationRate;
        }

        protected abstract void GeneratePopulation();

        protected abstract TCreature CrossoverCreatures(TCreature creature1, TCreature creature2);

        protected abstract TCreature MutateCreature(TCreature creature);

        protected abstract TFittnessValue FitnessFunction(TFittnessFunctionArgument argument);

        public abstract TEvolvedModel Run();

    }
}
