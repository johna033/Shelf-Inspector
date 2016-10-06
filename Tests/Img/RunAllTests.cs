using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Img
{
    class RunAllTests
    {

        public void Run()
        {
            MorphologyErosionTest.RunTest();
            GaborFilterTest.RunTest();
            NormalizeTest.RunTest();
            GaussianBlurTest.RunTest();
            IntegralImageTest.RunTest();
            SquareRootTest.RunTest();
            DftTest.RunTest();
            HoughCirclesTest.RunTest();
            CannyEdgeTest.RunTest();
            LogTest.RunTest();
            MedianBlurTest.RunTest();
            HistogramEqualizationTest.RunTest();
            LaplacianEdgeDetectionTest.RunTest();
            DifferenceOfGaussiansTest.RunTest();
            CensusTransformTest.RunTest();
            DistanceTransformTest.RunTest();
            SobelOperatorTest.RunTest();
            HarrisCornerStrengthTest.RunTest();
            HoughLinesTest.RunTest();
            AdaptiveThresholdingTest.RunTest();
            MorphologicalDilateTest.RunTest();
        }

    }
}
