﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlWorkFlowApp
{
    public class XmlSerializerHelper
    {
        private static XmlSerializer GetSerializer<T>()
        {
            Activity.GetAllActivities();
            return new XmlSerializer(typeof(T),
                AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.StartsWith(typeof(XmlSerializerHelper).Namespace))
                .SelectMany(x => x.GetTypes())
                    .Where(t =>
                        typeof(Node).IsAssignableFrom(t) ||
                        typeof(Port).IsAssignableFrom(t) ||
                        typeof(Activity).IsAssignableFrom(t)).ToArray());
        }

        public static string ToString<T>(T obj)
        {
            using (var writer = new StringWriter())
            {
                GetSerializer<T>().Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static T ToObject<T>(string str)
        {
            using (var reader = new StringReader(str))
            {
                return (T)GetSerializer<T>().Deserialize(reader);
            }
        }
    }
}
