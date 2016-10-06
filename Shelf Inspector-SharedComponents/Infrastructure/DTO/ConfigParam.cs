namespace ShelfInspectorDataModel.Infrastructure.Dto
{
    sealed class ConfigParam
    {
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        public ConfigParam(string name, string value)
        {
            ParamName = name;
            ParamValue = value;
        }
    }
}
