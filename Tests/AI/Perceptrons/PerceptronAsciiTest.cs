using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelfInspectorAI.NeuralNetworks;

namespace Tests.AI.Perceptrons
{
    class PerceptronAsciiTest
    {
        public static void TestPerceptron(string pathToTestingFileSet, string pathToHoldingFileSet)
        {
           /* GenerateAsciiTests.Generate(pathToTestingFileSet, pathToHoldingFileSet);
            SinglePerceptron perceptron = new SinglePerceptron {NumberOfWeights = 10000};
            LinkedList<float> trainingLinkedList = new LinkedList<float>();

            using (TextReader config = new StreamReader(pathToTestingFileSet + @"/config"))
            {
                while (config.Peek() >= 0)
                {
                    string confStr = config.ReadLine();
                    string[] confParams = confStr.Split(' ');
                    int desirableOutput = Int32.Parse(confParams[1]);
                    
                    using (TextReader trainingFile = new StreamReader(pathToTestingFileSet + @"\" + confParams[0]))
                    {
                        while (trainingFile.Peek() >= 0)
                        {
                            string line = trainingFile.ReadLine();
                            foreach (char c in line)
                            {
                                trainingLinkedList.AddLast(c=='0' ? 0.0f : 1.0f);
                            }
                        }
                    }
                    perceptron.Train(desirableOutput, trainingLinkedList.ToList());
                    trainingLinkedList.Clear();

                }
            }

            using (TextWriter weightVecWriter = new StreamWriter("weights.txt"))
            {
                int k = 0;
                foreach (var weight in perceptron.WeightVector)
                {
                    weightVecWriter.Write(weight+" ");
                    k++;
                    if (k%100 == 0)
                    {
                        weightVecWriter.Write(weightVecWriter.NewLine);
                    }
                }
            }

            using (TextReader config = new StreamReader(pathToHoldingFileSet + @"/config"))
            {
                int correctlyClassified = 0;
                while (config.Peek() >= 0)
                {
                    string confStr = config.ReadLine();
                    string[] confParams = confStr.Split(' ');
                    int desirableOutput = Int32.Parse(confParams[1]);

                    using (TextReader holdingFile = new StreamReader(pathToHoldingFileSet + @"\" + confParams[0]))
                    {
                        while (holdingFile.Peek() >= 0)
                        {
                            string line = holdingFile.ReadLine();
                            foreach (char c in line)
                            {
                                trainingLinkedList.AddLast(c == '0' ? 0.0f : 1.0f);
                            }
                        }
                    }
                    if (perceptron.Classify(trainingLinkedList.ToList()) == desirableOutput)
                        correctlyClassified++;
                    trainingLinkedList.Clear();

                }
                Console.WriteLine("(PERCEPTRON ASCII)Correctly classified: "+correctlyClassified/100.0*100.0+"%");
            }*/

        }
    }
}
