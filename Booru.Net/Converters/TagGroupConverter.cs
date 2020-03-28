using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Booru.Net.Converters
{
    public class TagGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Dictionary<string, List<string>>>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            List<Dictionary<string, List<string>>> container = new List<Dictionary<string, List<string>>>();

            foreach(var el in token.Children<JObject>())
            {
                Dictionary<string, List<string>> att = new Dictionary<string, List<string>>();
                foreach (JProperty prop in el.Properties())
                {
                    List<string> children = new List<string>();

                    foreach(var child in prop.Value.Children())
                    {
                        children.Add(child.Value<string>());
                    }

                    att.Add(prop.Name, children);
                    break;
                }

                container.Add(att);
            }

            return container;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
