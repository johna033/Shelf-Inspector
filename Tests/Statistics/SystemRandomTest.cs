using System;

namespace Tests.Statistics
{
    class SystemRandomTest
    {
        public static void RandomTest()
        {
            double expectation = 0;
            double squaredExpectation = 0;
            Random random = new Random();
            
            for (int i = 0; i < 1000000; i++)
            {
                double t = random.NextDouble();
                expectation += t;
                squaredExpectation += t*t;
            }
            expectation /= 1000000;
            squaredExpectation /= 1000000;
            Console.WriteLine("E: "+ expectation);
            Console.WriteLine("Dispersion: "+Math.Sqrt(squaredExpectation-expectation*expectation));
        }
    }
}
