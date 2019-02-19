using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Apps
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class Property : Attribute
    {
        public bool Enabled { get; }

        public bool Required { get; }

        public Property(bool Enabled = false, bool Required = false)
        {
            this.Enabled = Enabled;
            this.Required = Required;
        }
    }
}
