using System;
using ShelfInspectorImg.Data;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    
    public sealed class EcoTransformation: IComparable
    {
        public TransformationType TrasformationType;
        public EcoFeatureParameterContainer Parameters;

        public EcoTransformation(TransformationType transformationType, EcoFeatureParameterContainer parameters)
        {
            TrasformationType = transformationType;
            Parameters = parameters;
        }

        public int CompareTo(object obj)
        {
            var transformation = (EcoTransformation) obj;

            return TrasformationType - transformation.TrasformationType;
        }

        public override bool Equals(object obj)
        {
            return ((EcoTransformation) obj).TrasformationType == TrasformationType;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            // remember kids - always override Equals and toString, but never use HashCode!
            return base.GetHashCode();
        }
    }
}
