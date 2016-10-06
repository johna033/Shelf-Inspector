using System;

namespace ShelfInspectorAI.Api
{
    public struct GaProgressInfo
    {
        public int GenerationNumber;
        public double MaximumScore;
        public double MinimumScore;
        public double ExpectedScore;
        public TimeSpan TimeToCalculateFitness;
        public TimeSpan TimeToReproduce;

        public override string ToString()
        {
            return
                String.Format(
                    "Generation #{0}\n Fitness calculation time: {1}\n Reproduction time: {2}\n Expected score: {3}\n Maximum score: {4}\n Minimum score:{5}\n\n",
                    GenerationNumber, TimeToCalculateFitness, TimeToReproduce, ExpectedScore, MaximumScore, MinimumScore);
        }
    }
}
