using System;
using System.Collections.Generic;

namespace ShelfInspectorAI.Boosting
{
    public abstract class AbstractAdaboost< TClassifiers, TTrainingObject>
    {
        protected double[] _weights;
        protected int _amountClassifiers; 

        public abstract void Train(TClassifiers classifiers, double threshold = 0.2);

        //public abstract double Run(TTrainingObject verifiableObject);
        private double _threshold;

        public double Threshold
        {
            get { return _threshold; }
            set
            {
                if (value >= 0 && value <= 1)
                    _threshold = value;
                else
                    throw new ArgumentException("Threshold must be in [0..1]");
            }
        }
    }
}
