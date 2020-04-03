using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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

            Dictionary<string, List<string>> container = new Dictionary<string, List<string>>();

            foreach(JProperty el in token.Values<JProperty>())
            {
                container.Add(el.Name, el.Value.Values<string>().ToList());
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
