using System.Collections.Generic;
using System.Linq;


namespace ShelfInspectorImg.DTO
{
    public class TransformationParameters
    {
        public List<object> Parameters;

        public int GetParametersCount()
        {
            return Parameters.Count;
        }
    }
}
