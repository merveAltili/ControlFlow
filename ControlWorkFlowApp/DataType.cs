﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public abstract class DataType
    {
        public abstract string Id { get; }

        public abstract string Name { get; }

        public abstract object GetValue();

        public abstract void SetValue(object value);

        public abstract string ToExpression();

        public abstract DataGridViewCell CellTemplate { get; }

        public static List<DataType> GetCommonTypes()
        {
            return new List<DataType>()
            {
                new Text(),
                new Number(),
                new TrueFalse(),
                new DateTime(),
                //new Password(),
                //new Collection()
            };
        }

        public static DataType GetDefault() => new Text();

        public static DataType CreateInstance(string fullName)
        {
            if (AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(DataType).IsAssignableFrom(x) && !x.IsAbstract && !x.IsGenericType)
                .Select(x => Activator.CreateInstance(x) as DataType)
                .FirstOrDefault(x => x.GetType().FullName == fullName) is DataType type)
            {
                return type;
            }
            throw new Exception();
        }
    }

    public abstract class DataType<T> : DataType
    {
        public override string Id => this.GetType().FullName;

        public override string Name => this.GetType().Name;

        public override DataGridViewCell CellTemplate => new GhostTextBoxCell();

        protected T Value { get; set; }

        protected DataType(T value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is DataType<T> other && this.Value.Equals(other.Value);
        }

        public override object GetValue()
        {
            return this.Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public sealed class Text : DataType<String>
    {
        public Text() : this(string.Empty) { }

        public Text(string value) : base(value ?? string.Empty) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value = Convert.ToString(value);
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            return string.Format("\"{0}\"", this.Value.Replace("\\", "\\\\").Replace("\"", "\\\""));
        }

        public static implicit operator String(Text item) => item.Value;

        public static implicit operator Text(String item) => new Text(item);

        public override string ToString() => this.Value;
    }

    public sealed class Number : DataType<Decimal>
    {
        public Number() : this(new Decimal()) { }

        public Number(Decimal value) : base(value) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value = Convert.ToDecimal(value);
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            return string.Format("{0}", this.Value);
        }

        public static implicit operator Decimal(Number item) => item.Value;

        public static implicit operator Number(Decimal item) => new Number(item);

        public static implicit operator Int32(Number item) => Convert.ToInt32(item.Value);
    }

    public sealed class TrueFalse : DataType<Boolean>
    {
        public TrueFalse() : this(new Boolean()) { }

        public TrueFalse(Boolean value) : base(value) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value = Convert.ToBoolean(value);
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            return string.Format("{0}", this.Value.ToString().ToLower());
        }

        public static implicit operator Boolean(TrueFalse item) => item.Value;

        public static implicit operator TrueFalse(Boolean item) => new TrueFalse(item);
    }

    public sealed class DateTime : DataType<System.DateTime>
    {
        public DateTime() : this(new System.DateTime()) { }

        public DateTime(System.DateTime value) : base(value) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value = Convert.ToDateTime(value);
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            return string.Format("DateTime.Parse(\"{0}\")", this.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static implicit operator System.DateTime(DateTime item) => item.Value;

        public static implicit operator DateTime(System.DateTime item) => new DateTime(item);
    }

    public sealed class Collection : DataType<DataTable>
    {
        public Collection() : this(new DataTable()) { }

        public Collection(DataTable value) : base(value) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value = (DataTable)value;
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            throw new NotImplementedException();
        }

        public static implicit operator DataTable(Collection item) => item.Value;

        public static implicit operator Collection(DataTable item) => new Collection(item);
    }

    public sealed class Password : DataType<SecureString>
    {
        public Password() : this(new SecureString()) { }

        public Password(SecureString value) : base(value) { }

        public override void SetValue(object value)
        {
            try
            {
                this.Value.Clear();
                Convert.ToString(value).ToList().ForEach(this.Value.AppendChar);
            }
            catch
            {
                throw;
            }
        }

        public override string ToExpression()
        {
            throw new NotImplementedException();
        }

        public static implicit operator SecureString(Password item) => item.Value;

        public static implicit operator Password(SecureString item) => new Password(item);
    }
}
