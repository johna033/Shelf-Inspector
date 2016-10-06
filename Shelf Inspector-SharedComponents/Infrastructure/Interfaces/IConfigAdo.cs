using System.Collections.Generic;
using ShelfInspectorDataModel.Infrastructure.Dto;

namespace ShelfInspectorDataModel.Infrastructure.Interfaces
{
    internal interface IConfigAdo
    {
        List<ConfigParam> GetSettings();
        void SetSettings(List<ConfigParam> settings);
    }
}
