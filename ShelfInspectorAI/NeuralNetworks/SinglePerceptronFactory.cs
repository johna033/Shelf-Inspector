using System;


namespace ShelfInspectorAI.NeuralNetworks
{
    /// <summary>
    /// SinglePerceptron class - models perceptron, linear, fully matches Lillywhites proposed linear filter
    /// </summary>

    public class SinglePerceptronFactory
    {
        private const double LearningRate = 0.5;
        private const double Bias = 0.3;
        private static SinglePerceptronFactory _instance;
      

        private SinglePerceptronFactory(){}

        public static double[] GetWeightVector(int length)
        {
            return new double[length];
        }

        public static void Train(int targetOutput, byte[,,] input, double[] weightVector)
        {
            if (_instance == null)
            {
                _instance = new SinglePerceptronFactory();
            }

            int output = _instance.ComputeOutput(input, weightVector);
            int sz = input.Length;

            double coeff = (targetOutput - output)*LearningRate;

            unsafe
            {
                fixed (byte* p = input)
                {
                    for (int i = 0; i < sz; i++)
                    {
                        weightVector[i] += coeff*p[i];
                    }
                }
            }
        }

        public static int Classify(byte[,,] input, double[] trainedWeightVector)
        {
            return _instance.ComputeOutput(input, trainedWeightVector);
        }

        private int ComputeOutput(byte[,,] input, double[] weightVector)
        {
            
            if (weightVector.Length != input.Length)
            {
                throw new ArgumentException("Sizes of WeightVector & input must match"); 
            }

            double outputValue = 0;

            int sz = input.Length;
            unsafe
            {
                fixed (byte* p = input)
                {
                    for (int i = 0; i < sz; i++)
                    {
                        outputValue += weightVector[i]*p[i];
                    }
                }
            }

            return (outputValue+Bias > 0 ? 1 : 0);
        }   
    }
}
