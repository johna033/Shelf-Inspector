using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfInspectorImg
{
    public partial class ImageSupport : Component
    {
        public ImageSupport()
        {
            InitializeComponent();
        }

        public ImageSupport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
