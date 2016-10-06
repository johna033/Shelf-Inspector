using System.Collections.Generic;
using ShelfInspectorDataModel.Infrastructure.Dto;

namespace ShelfInspectorDataModel.Model
{
    public interface ITrainingFilesProvider
    {
        LinkedList<TrainingImage> GetFileNames(string folder);
    }
}
