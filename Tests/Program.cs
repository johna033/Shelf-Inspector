using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ShelfInspectorAI;
using ShelfInspectorAI.GeneticAlgorithm;
using ShelfInspectorAI.Util;
using ShelfInspectorDataModel.Infrastructure.Dto;
using ShelfInspectorDataModel.Model;
using ShelfInspectorImg.Api;
using ShelfInspectorImg.Data;
using Tests.AI.Perceptrons;
using Tests.Img;
using Tests.Img.Api;
using Tests.Statistics;
using ShelfInspectorAI.Api;

namespace Tests
{
    internal class ProgressReporter: IGaProgressReporter
    {
        public void ReportProgress(ref GaProgressInfo progressInfo)
        {
            Console.WriteLine(progressInfo);
        }
    }

    internal class DoneCallback : IEvolutionDoneCallback
    {
        public void EvolutionDone(EcoModel model)
        {
            
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            /*SystemRandomTest.RandomTest();
            ApplyTransformTest.TestTransformationApplication();
            UtilsTest.RunUtilsTest();
            PerceptronAsciiTest.TestPerceptron(@"PerceptronTest\AsciiTesting", @"PerceptronTest\AsciiHolding");*/
            

           /* Console.WriteLine("Running GA with 200 generations...\n");
            
            EcoGeneticAlgorithm ecoGA = new EcoGeneticAlgorithm(1000, 200, 0.02, @"~/../../../dataset/test", @"~/../../../dataset/training", new ProgressReporter(), new DoneCallback());    
            ecoGA.Run();*/


           /* double[] array = new double[3000000];
            for (int i = 0; i < 3000000; i++)
                array[i] = 1;
            double output = 0;
            int coeff = 2;
            gaPerformance.Start();
            for (int i = 0; i < 3000000; i++)
                output += array[i];
            gaPerformance.Stop();
            Console.WriteLine("Sequential: "+gaPerformance.Elapsed + " " + coeff*output);
            gaPerformance.Reset();

            output = 0;
            double[,,] array3d = new double[1000,1000,3];
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 3; k++)
                        array3d[i, j, k] = 1;
                }
            }
            gaPerformance.Start();
            //Parallel.For(0, 1000000, i => { output += coeff*array[i]; });
            // output = (from x in array.AsParallel() select x).Sum();
                unsafe
                {
                    fixed (double* p = array3d)
                    {
                        //var doubleSize = Marshal.SizeOf(typeof(double));
                        for (int i = 0; i < 3000000; i++)
                        {
                            output += p[i];
                        }
                    }
                }
            gaPerformance.Stop();
            Console.WriteLine("Parallel: "+gaPerformance.Elapsed+ " "+ coeff*output);
               */
            //Console.WriteLine("GA running 1000 population, 100000 generations: "+gaPerformance.Elapsed);
            //DftTest.RunTest();
            //RunAllTests runAll = new RunAllTests();
            //HoughLinesTest.RunTest();
           // HarrisCornerStrengthTest.RunTest();
           // Console.WriteLine(((int)(0.98263107*10)));
            /*NtfsFileNamesProvider prov = new NtfsFileNamesProvider();
            LinkedList<TrainingImage> images = prov.GetFileNames("ProviderTest");
            foreach (TrainingImage image in images)
            {
                Console.WriteLine(image.File+" "+image.BelongsToClass);
                using (TextReader reader = new StreamReader(image.File))
                {
                    while (reader.Peek() >= 0)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }*/

           
            /*LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3); 
            list.AddLast(4);
            Util.ShuffleLinkedList(list);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }*/
            LinkedList<temp> t = new LinkedList<temp>();
            t.AddLast(new temp{i=1});
            t.AddLast(new temp{i=2});
            t.AddLast(new temp{i=3});

            foreach (var ku in t)
            {
                ku.i = 0;

            }
            foreach (var tu in t)
            {
                Console.WriteLine(tu.i);
            }
            Console.ReadLine();
        }

        private class temp
        {
            public int i;
        }
    }
}
