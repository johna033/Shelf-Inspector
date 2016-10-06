using System.ComponentModel;

namespace ShelfInspectorDataModel
{
    public partial class DataSource : Component
    {
        public DataSource()
        {
            InitializeComponent();
        }

        public DataSource(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
