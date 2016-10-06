using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfInspectorAI
{
    public partial class GA : Component
    {
        public GA()
        {
            InitializeComponent();
        }

        public GA(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
