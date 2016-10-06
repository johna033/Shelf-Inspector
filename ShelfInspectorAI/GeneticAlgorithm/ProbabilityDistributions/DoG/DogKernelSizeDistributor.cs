using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfInspectorAI.GeneticAlgorithm.ProbabilityDistributions.DoG
{
    class DogKernelSizeDistributor: IDistributedValue
    {
        public object GetDistributedValue(double uniformlyDistributedVariableValue)
        {
            return ((int) uniformlyDistributedVariableValue*25) | 0x1;
        }
    }
}
