using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tests.AI.Perceptrons
{
    class GenerateAsciiTests
    {
        private const int Size = 100;
        private const int Number = 100;
 
        public static void Generate(string pathToTestingFileSet, string pathToHoldingFileSet)
        {
            
            GenerateInSet(pathToTestingFileSet);
            GenerateInSet(pathToHoldingFileSet);

        }

        private static void GenerateInSet(string pathToSet)
        {
            TextWriter configFile = new StreamWriter(pathToSet+@"/config");
            Random rand  = new Random();

            for (int u = 0; u < Number; u++)
            {
                int belongs = rand.Next(2);
                configFile.WriteLine(u+".txt "+belongs);
                using (TextWriter fileWriter = new StreamWriter(pathToSet + @"/" + u + ".txt"))
                {
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            int position = 0;
                            if (belongs == 1)
                            {
                                position = rand.Next(i + 1, Size);
                            }
                            else
                            {
                                position = rand.Next(0, i);
                            }
                            fileWriter.Write(j == position ? "1" : "0");
                        }
                        fileWriter.Write(fileWriter.NewLine);
                    }
                }
            }
            configFile.Close();
        }
    }
}
