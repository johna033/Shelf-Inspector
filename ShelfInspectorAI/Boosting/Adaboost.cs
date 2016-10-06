using System;
using System.Collections.Generic;
using System.Linq;
using ShelfInspectorAI.GeneticAlgorithm;
using ShelfInspectorAI.NeuralNetworks;
using ShelfInspectorDataModel.Infrastructure.Dto;
using ShelfInspectorImg.Api;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Util;

namespace ShelfInspectorAI.Boosting
{
    public class Adaboost : AbstractAdaboost<EcoModel, TrainingImage>
    {
        private EcoModel _ecoModel;
        private readonly LinkedList<TrainingImageHolder> _loadedTrainingSet;

        public Adaboost(LinkedList<ImageContainer> trainingSet)
        {
            _loadedTrainingSet = PrepareTrainingImages(trainingSet);
        }

        public override void Train(EcoModel ecoModel, double threshold = 0.2)
        {
            SetStartWeight();

            _amountClassifiers = ecoModel.ModelElements.Count;
            _weights = new double[_amountClassifiers];
            _ecoModel = ecoModel;

            int sizeOfTrainingSet = _loadedTrainingSet.Count;
            
            Threshold = threshold;


            double[] errorClassifiers = new double[_amountClassifiers];
            // Foreach classificator in ecoModel

            int[,] classificationResults = ClassifyTrainingImages(ecoModel);

            

            for (int classif = 0; classif < _amountClassifiers; ++classif)
            {
                // Set intial error for each classificator
                for (int j = 0; j < _amountClassifiers; ++j)
                    errorClassifiers[j] = 0;

                // Foreach classificator
                for (int classifier = 0; classifier < _amountClassifiers; classifier++)
                {

                    int j = 0;
                    // Foreach trainingImage
                    foreach (var trainingImageHolder in _loadedTrainingSet)
                    {
                        // Classify
                        if (classificationResults[classifier, j] !=
                            trainingImageHolder.Image.BelongsToClass)
                        {
                            errorClassifiers[classifier] += trainingImageHolder.Weight;
                        }
                        j++;
                    }
                }

                //Find best
                int classifierWithMinimumError = 0;
                for (int i = 1; i < _amountClassifiers; ++i)
                    if (errorClassifiers[i] < errorClassifiers[classifierWithMinimumError])
                        classifierWithMinimumError = i;

                // Weak classifiers work too bad
                if (errorClassifiers[classifierWithMinimumError] >= 0.5)
                    break;

                // Weight of current classifier
                _weights[classif] = 0.5*Math.Log((1 - errorClassifiers[classif])/errorClassifiers[classif]); //eq (5)

                // TODO: think about normalization factor
                double normalizationFactor = sizeOfTrainingSet;
                int counter = 0;
                foreach (var trainingImageHolder in _loadedTrainingSet)
                {
                    int c = 1;

                    if (classificationResults[classifierWithMinimumError, counter] !=
                        trainingImageHolder.Image.BelongsToClass)
                    {
                        c = -1;
                    }

                    counter++;

                    trainingImageHolder.Weight = trainingImageHolder.Weight*Math.Exp(_weights[classif]*c)/
                                                 normalizationFactor;
                }
            }
        }

        public int Run(ImageContainer image)
        {
           double result = _ecoModel.ModelElements.Aggregate<EcoModelElement, double>(0,
                    (current, modelElement) => current + ClassifyImage(image, modelElement));

            return result > Threshold ? 1 : 0;
        }

        private int ClassifyImage(ImageContainer image, EcoModelElement modelElement)
        {
            ImageContainer subImage = modelElement.Feature.Transformations.Aggregate(ImageHandler.GetSubregion(modelElement.Feature.Subregion, image),
                (current, ecoTransformation) =>
                    ApplyTransformation.Apply(current, ecoTransformation.Parameters.GetParameters(),
                        ecoTransformation.TrasformationType));

            byte[,,] transformationResult = ImageHandler.GetImageAsByteArray(subImage);

            return SinglePerceptronFactory.Classify(transformationResult, modelElement.Classifier);
        }

        private int[,] ClassifyTrainingImages(EcoModel ecoModel)
        {
            int[,] classificationResults = new int[_amountClassifiers, _loadedTrainingSet.Count];

            for (int i = 0; i < _amountClassifiers; i++)
            {
                int j = 0;
                foreach (var trainingImageHolder in _loadedTrainingSet)
                {
                    // Get current modelElement
                    EcoModelElement modelElement = ecoModel.ModelElements[i];
                    classificationResults[i, j] = ClassifyImage(trainingImageHolder.Image, modelElement);
                    j++;
                }
            }

            return classificationResults;
        }

        private LinkedList<TrainingImageHolder> PrepareTrainingImages(LinkedList<ImageContainer> trainingImages)
        {
            LinkedList<TrainingImageHolder> loadedImages = new LinkedList<TrainingImageHolder>();
            double startWeght = 1.0/trainingImages.Count;

            foreach (var trainingImage in trainingImages)
            {
                loadedImages.AddLast(new TrainingImageHolder(trainingImage, startWeght));
            }

            

            return loadedImages;
        }

        private void SetStartWeight()
        {
            double startWeght = 1.0 / _loadedTrainingSet.Count;
            foreach (var trainigImage in _loadedTrainingSet)
            {
                trainigImage.Weight = startWeght;
            }
        }

        private class TrainingImageHolder
        {
            public double Weight { get; set; }
            public readonly ImageContainer Image;

            public TrainingImageHolder(ImageContainer image, double weight) 
            {
                Weight = weight;
                Image = image;

            }
        }
    }
}