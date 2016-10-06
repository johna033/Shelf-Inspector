using System.Collections.Generic;
using System.Drawing;

namespace ShelfInspectorAI.GeneticAlgorithm
{
    public class EcoFeature
    {
        public Rectangle Subregion;
        private List<EcoTransformation> _transformations;

        public List<EcoTransformation> Transformations 
        {
            get { return _transformations; } 
            set
            {
                _transformations = value;
                _transformations.Sort();
            }
        }

        public EcoTransformation this[int idx]
        {
            get { return _transformations[idx]; }
            set
            {
                _transformations[idx] = value;
                _transformations.Sort();
            }
        }

        public EcoFeature(Rectangle subregion, List<EcoTransformation> transformations)
        {
            Subregion = subregion;
            Transformations = transformations;
        }

        public void AddTransformation(EcoTransformation transformation)
        {
            
            _transformations.Add(transformation);
            _transformations.Sort();
        }

        public void RemoveTransformation(EcoTransformation transformation)
        {
            _transformations.Remove(transformation);
        }

        public int GetChromosomeLength()
        {
            return _transformations.Count;
        }
    }
}
