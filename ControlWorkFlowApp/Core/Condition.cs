using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace ControlFlow.Activities.Apps
{
    public sealed class Condition
    {
        public bool Use
        {
            get => this.Required || this.Enabled;
            set => this.Enabled = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }

        public bool Enabled { get; set; }

        public bool Required { get; set; }

        private Condition()
        {

        }

        public Condition(string name, object value, bool enabled, bool required)
        {
            this.Name = name;
            this.Value = value;
            this.Enabled = enabled;
            this.Required = required;
        }

        public bool Compare(object otherValue, Type otherType)
        {
            var value = this.Value ?? string.Empty;
            otherValue = otherValue ?? string.Empty;
            if (otherType == typeof(string))
            {
                return LikeOperator.LikeString(
                    value.ToString(),
                    otherValue.ToString().Replace("[", "[[]").Replace("#", "[#]").Replace("?", "[?]"),
                    Microsoft.VisualBasic.CompareMethod.Binary);
            }
            else
            {
                return otherValue.Equals(value);
            }
        }
    }
}

