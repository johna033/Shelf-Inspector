using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ShelfInspectorAI.Api;
using ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions;
using ShelfInspectorAI.NeuralNetworks;
using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Util;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    public class EcoGeneticAlgorithm : AbstractGeneticAlgorithm<EcoFeature, double,EcoModelElement, EcoModel>
    {
        private const int ImageSize = 64;
        private const double Penalty = 1.2; 

        private readonly LinkedList<ImageContainer> _holdingSetFiles;
        private readonly LinkedList<ImageContainer> _trainingSetFiles;

        private readonly EcoModel _population;
        private readonly Random _random = new Random();

        private readonly TransformationType[] _transformationTypes =
        {
           TransformationType.GaborFilter,
           TransformationType.Dft,
           TransformationType.Dft,
           TransformationType.GaussianBlur,
           TransformationType.GaussianBlur
        };

        private readonly int _numberOfTransforms;
        private readonly Task[] _tasksForTrainingAndScoring;

        private readonly IGaProgressReporter _progressReporter;
        private readonly IEvolutionDoneCallback _evolutionDoneCallback;
        private BackgroundWorker _evolutionBackgroundWorker;

        private GaProgressInfo _progressInfo;

        private int[] _populationDistribution;

        public EcoGeneticAlgorithm(int populationSize, int numberOfGenerations, double mutationRate,
            LinkedList<ImageContainer> holdingSetFiles, LinkedList<ImageContainer> trainingSetFiles, IGaProgressReporter progressReporter, IEvolutionDoneCallback evolutionDoneCallBack)
            : base(populationSize, numberOfGenerations, mutationRate)
        {
            _progressReporter = progressReporter;
            _evolutionDoneCallback = evolutionDoneCallBack;

            

            _holdingSetFiles = holdingSetFiles;
            _trainingSetFiles = trainingSetFiles;

            
            _numberOfTransforms = _transformationTypes.Length;
            _population = new EcoModel(PopulationSize);
            _tasksForTrainingAndScoring = new Task[populationSize];

            _populationDistribution = new int[1000]; // magic number, upper bound on fitness function
        }

        protected override void GeneratePopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                int x = _random.Next(0, ImageSize);
                int y = _random.Next(0, ImageSize);

                var subregion = new Rectangle(x, y, _random.Next(1, ImageSize - x), _random.Next(1, ImageSize - y));
                var transformations = new List<EcoTransformation>(8);
                int chromosomeLength = DistributedValuesFactory.GetDistributedValue(GenericDistributionOperation.ChromosomeLengthDistributor, _random.NextDouble());

                //transformations.Add();

                //TODO max results seem to be yielded from DFT at the end
                int numberOfParams;
                List<double> rawParamValues;

                for (int j = 0; j < chromosomeLength-1; j++)
                {
                    var type = _transformationTypes[_random.Next(_numberOfTransforms)];
                    numberOfParams = EcoFeatureParameterContainer.GetNumberOfParametersForTransformation(type);

                    rawParamValues = new List<double>(numberOfParams);

                    for (int u = 0; u < numberOfParams; u++)
                    {
                        rawParamValues.Add(_random.NextDouble()); // 0-1
                    }

                    transformations.Add(new EcoTransformation(type,
                        new EcoFeatureParameterContainer(rawParamValues, type))); //TODO EcoFeature should be way more encapsulated
                }

                numberOfParams = EcoFeatureParameterContainer.GetNumberOfParametersForTransformation(TransformationType.Dft);

                rawParamValues = new List<double>(numberOfParams);

                for (int u = 0; u < numberOfParams; u++)
                {
                    rawParamValues.Add(_random.NextDouble()); // 0-1
                }

                transformations.Add(new EcoTransformation(TransformationType.Dft,
                    new EcoFeatureParameterContainer(rawParamValues, TransformationType.Dft)));

                _population.ModelElements[i] = new EcoModelElement{Feature = new EcoFeature(subregion, transformations)};
            }
        }

        protected override EcoFeature CrossoverCreatures(EcoFeature creature1, EcoFeature creature2)
        {
            var transformations = new List<EcoTransformation>();
            int subregionParent = _random.Next(2);

            Rectangle subregion = (subregionParent == 0) ? creature1.Subregion : creature2.Subregion; // TODO possibly will have to select parts of regions from parents

            int totalNumberOfChromosomes = creature1.GetChromosomeLength() + creature2.GetChromosomeLength();
            int numberOfChromosomesForNewCreature =
                DistributedValuesFactory.GetDistributedValue(GenericDistributionOperation.ChromosomeLengthDistributor,
                    _random.NextDouble());

            if (numberOfChromosomesForNewCreature > totalNumberOfChromosomes)
            {
                numberOfChromosomesForNewCreature -= (numberOfChromosomesForNewCreature - totalNumberOfChromosomes);
            }
            int[] indices = new int[totalNumberOfChromosomes];
            for (int i = 0; i < totalNumberOfChromosomes; i++)
            {
                indices[i] = i;
            }
            indices = Util.Util.ArrayShuffle(indices);
            List<EcoTransformation> jointTransforms = new List<EcoTransformation>(totalNumberOfChromosomes);
            jointTransforms.AddRange(creature1.Transformations);
            jointTransforms.AddRange(creature2.Transformations);
            for (int j = 0; j < numberOfChromosomesForNewCreature; j++)
            {
                transformations.Add(jointTransforms[indices[j]]);
            }

            //transformations.Add(jointTransforms[totalNumberOfChromosomes-1]);

            return new EcoFeature(subregion, transformations);
        }

        protected override EcoFeature MutateCreature(EcoFeature creature)
        {
            int chromosomeLength = creature.GetChromosomeLength();
            if (_random.NextDouble() <= 0.02)
            {
                int mutationIndex = (int) (_random.NextDouble()*chromosomeLength);
               /* if (mutationIndex == 0) // mutating subregion
                {
                    int partToMutate = _random.Next(0, 4);
                    int delta;
                    switch (partToMutate)
                    {
                        case 0:
                            creature.Subregion.X = _random.Next(0, ImageSize);
                            delta = ImageSize - creature.Subregion.X;
                            if (delta > creature.Subregion.Width)
                            {
                                creature.Subregion.Width = delta - creature.Subregion.Width;
                            }
                            return creature;
                        case 1:
                            creature.Subregion.Y = _random.Next(0, ImageSize);
                            delta = ImageSize - creature.Subregion.Y;
                            if (delta > creature.Subregion.Height)
                            {
                                creature.Subregion.Height = delta - creature.Subregion.Height;
                            }

                            return creature;
                        case 2:
                            creature.Subregion.Width = _random.Next(1, ImageSize - creature.Subregion.X);
                            return creature;
                        case 3:
                            creature.Subregion.Height = _random.Next(1, ImageSize - creature.Subregion.Y);
                            return creature;
                    }
                }
                else
                {
                    mutationIndex--;*/
                    int numberOfParams =
                        EcoFeatureParameterContainer.GetNumberOfParametersForTransformation(
                            creature.Transformations[mutationIndex].TrasformationType);
                    int paramToModify = _random.Next(numberOfParams);
                    
                    creature.Transformations[mutationIndex].Parameters.SetParamValueByIndex(paramToModify,
                        _random.NextDouble());

                    return creature;
               // }
            }
            return creature;
        }

        private double[] TrainPerceptronForFeature(EcoFeature creature)
        {
            LinkedList<ImageContainer>.Enumerator e = _trainingSetFiles.GetEnumerator();
            e.MoveNext();

            byte[,,] transformationResult = ApplyFeatureToSubregion(creature, e.Current);

            var perceptron = SinglePerceptronFactory.GetWeightVector(transformationResult.Length);

            while (e.MoveNext())
            {
                transformationResult = ApplyFeatureToSubregion(creature, e.Current);

                SinglePerceptronFactory.Train(e.Current.BelongsToClass, transformationResult, perceptron);
            }
            return perceptron;
        }

        private double CalculateScoreForPerceptron(double[] perceptron, EcoFeature creature)
        {
            int tp = 0, tn = 0, fn = 0, fp = 0;
            foreach (ImageContainer holdingSetFile in _holdingSetFiles)
            {
                byte[,,] transformationResult = ApplyFeatureToSubregion(creature, holdingSetFile);

                int result = SinglePerceptronFactory.Classify(transformationResult, perceptron); // TODO run these classifiers in multiple threads

                int realBelonging = holdingSetFile.BelongsToClass;

                if (result == realBelonging && realBelonging == 1)
                {
                    tp++;
                }
                if (result == realBelonging && realBelonging == 0)
                {
                    tn++;
                }
                if (result != realBelonging && realBelonging == 1)
                {
                    fn++;
                }
                if (result != realBelonging && realBelonging == 0)
                {
                    fp++;
                }
            }
            return (500.0*tp)/(fn + tp) + (tn*500.0)/(Penalty*fp + tn);
        }

        protected override double FitnessFunction(EcoModelElement argument)
        {
            return CalculateScoreForPerceptron(argument.Classifier, argument.Feature);
        }

        private byte[,,] ApplyFeatureToSubregion(EcoFeature creature, ImageContainer image)
        {
            ImageContainer subImage = ImageHandler.GetSubregion(creature.Subregion, image);

            subImage = creature.Transformations.Aggregate(subImage,
                (current, ecoTransformation) =>
                    ApplyTransformation.Apply(current, ecoTransformation.Parameters.GetParameters(),
                        ecoTransformation.TrasformationType));

            return ImageHandler.GetImageAsByteArray(subImage);
        }

        private void MakeNewGeneration(double maxScore)
        {
            List<EcoModelElement> newGeneration = Util.Util.AllocateList<EcoModelElement>(PopulationSize);
            bool accepted = false;
            int[] index = new int[2];

            for (int i = 0; i < PopulationSize; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 20; k++)
                    {
                        while (!accepted)
                        {
                            int candiateIndex = (int) (_random.NextDouble()*(PopulationSize));
                            if (_random.NextDouble() <= (_population.ModelElements[candiateIndex].Score/maxScore))
                            {
                                accepted = true;
                                index[j] = candiateIndex;
                            }
                        }
                        accepted = false;
                    }
                }
                newGeneration[i] =
                    new EcoModelElement
                    {
                        Feature = MutateCreature(CrossoverCreatures(_population.ModelElements[index[0]].Feature,
                            _population.ModelElements[index[1]].Feature))
                    };

            }
            _population.ModelElements = newGeneration;
        }

        /// <summary>
        /// Does as it says
        /// </summary>
        /// <returns></returns>
        private void BuildClassifiersAndUpdateScoresForModel()
        {
            int modelElementsCount = _population.ModelElements.Count;

            Parallel.For(0, modelElementsCount, i =>
            {
                int elementNumber = i;
                _tasksForTrainingAndScoring[i] = Task.Factory.StartNew(() =>
                {
                    double[] perceptron = TrainPerceptronForFeature(_population.ModelElements[elementNumber].Feature);
                    _population.ModelElements[elementNumber].Classifier = perceptron;
                    _population.ModelElements[elementNumber].Score =
                        FitnessFunction(_population.ModelElements[elementNumber]);
                });
            });

            Task.WaitAll(_tasksForTrainingAndScoring);
            
        }

        private void CalculateScoresForPopulation(out double maxScore, out double expectedScore, out double minScore)
        {
            maxScore = 0;
            minScore = 1001;
            expectedScore = 0;
            foreach (var element in _population.ModelElements)
            {
                double score = element.Score;
                if (score > maxScore)
                {
                    maxScore = score;
                }
                if (score < minScore)
                {
                    minScore = score;
                }
                _populationDistribution[(int) score]++;

            }
            double numberOfScores = _population.ModelElements.Count;
            for(int i = 0; i < 1000; i++)
            {
                double part = _populationDistribution[i]/numberOfScores;
                _populationDistribution[i] = 0;
                expectedScore += i*(part);
            }
        }

        private void Evolve(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            _progressInfo = new GaProgressInfo();

            for (int generation = 0; generation < NumberOfGenerations; generation++)
            {
                _progressInfo.GenerationNumber = generation;
                sw.Start();
                BuildClassifiersAndUpdateScoresForModel();
                sw.Stop();

                _progressInfo.TimeToCalculateFitness = sw.Elapsed;
                double maxScore, minScore, expectedScore;

                CalculateScoresForPopulation(out maxScore, out expectedScore, out minScore);

                _progressInfo.MaximumScore = maxScore;
                _progressInfo.MinimumScore = minScore;
                _progressInfo.ExpectedScore = expectedScore;

                sw.Reset();
                sw.Start();
                MakeNewGeneration(maxScore);
                sw.Stop();
                _progressInfo.TimeToReproduce = sw.Elapsed;
                sw.Reset();

                _evolutionBackgroundWorker.ReportProgress(0);
            }
            BuildClassifiersAndUpdateScoresForModel();
        }

        public override EcoModel Run()
        {
            GeneratePopulation();
            _evolutionBackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            _evolutionBackgroundWorker.DoWork += Evolve;
            _evolutionBackgroundWorker.ProgressChanged += _evolutionBackgroundWorker_ProgressChanged;
            _evolutionBackgroundWorker.RunWorkerCompleted += _evolutionBackgroundWorker_RunWorkerCompleted;

            _evolutionBackgroundWorker.RunWorkerAsync();

            return _population;
        }

        void _evolutionBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _evolutionDoneCallback.EvolutionDone(_population);
        }

        void _evolutionBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progressReporter.ReportProgress(ref _progressInfo);
        }
    }
}