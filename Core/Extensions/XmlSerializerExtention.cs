using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Core.Extensions
{
    public static class XmlSerializerExtention
    {
        #region Public Methods and Operators

        /// <summary>
        /// Deserialize xml to <see cref="T"/> type.
        /// </summary>
        /// <param name="xml">
        /// The xml value.
        /// </param>
        /// <typeparam name="T">
        /// Type of the output value.
        /// </typeparam>
        /// <returns>
        /// Returns deserialized value.
        /// </returns>
        public static T Deserialize<T>(this string xml)
        {
            return xml.Deserialize<T>(new Type[0]);
        }

        public static T Deserialize<T>(this string xml, Type[] extraTypes)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T), extraTypes);
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serialize to xml.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// Type of the input value.
        /// </typeparam>
        /// <returns>
        /// The xml <see cref="string"/>.
        /// </returns>
        public static string Serialize<T>(this T value)
        {
            return value.Serialize(new Type[0]);
        }

        public static string Serialize<T>(this T value, Type[] extraTypes)
        {
            XmlSerializer serializer = new XmlSerializer(value.GetType(), extraTypes);
            StringBuilder builder = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var w = new StringWriter(builder, CultureInfo.InvariantCulture))
            {
                serializer.Serialize(w, value, namespaces);
                return builder.ToString();
            }
        }

        #endregion
    }
}
