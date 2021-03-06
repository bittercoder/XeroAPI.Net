﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XeroApi.Model
{
    public class ModelSerializer
    {
        internal static IModelList<TModel> Deserialize<TModel>(string xml, Type modelListType)
            where TModel : ModelBase
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            var serializer = new System.Runtime.Serialization.DataContractSerializer(modelListType);

            using (TextReader tr = new StringReader(xml))
            using (XmlReader xr = new XmlTextReader(tr))
            {
                return (IModelList <TModel>)serializer.ReadObject(xr);
            }
        }

        internal static T DeserializeTo<T>(string xml)
            where T : class
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            var serializer = new XmlSerializer(typeof(T));

            using (TextReader tr = new StringReader(xml))
            using (XmlReader xr = new XmlTextReader(tr))
            {
                return (T)serializer.Deserialize(xr);
            }
        }

        public static string Serialize<TModel>(ICollection<TModel> itemsToSerialise)
            where TModel : ModelBase
        {
            // Specify the namespaces to be used for the serializer - rather than using the default ones.
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            var serializer = new XmlSerializer(itemsToSerialise.GetType());

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, itemsToSerialise);
                sw.Flush();
            }

            return CleanXml(sb.ToString());
        }

        public static string Serialize<TModel>(TModel itemsToSerialise)
            where TModel : ModelBase
        {
            // Specify the namespaces to be used for the serializer - rather than using the default ones.
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            var serializer = new XmlSerializer(typeof(TModel));

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, itemsToSerialise, xmlnsEmpty);
                sw.Flush();
            }

            return CleanXml(sb.ToString());
        }

        private static string CleanXml(string xml)
        {
            XElement xElement = XElement.Parse(xml);
            xElement.Descendants().Where(el => el.IsEmpty).Remove();
            return xElement.ToString();
        }
    }
}
