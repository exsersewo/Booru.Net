using Newtonsoft.Json;

namespace Booru.Net
{
    public class E621ImageSource
    {
        [JsonProperty("width")]
        public int Width { get; private set; }

        [JsonProperty("height")]
        public int Height { get; private set; }

        [JsonProperty("ext")]
        public string Extension { get; private set; }

        [JsonProperty("size")]
        public ulong Size { get; private set; }

        [JsonProperty("has")]
        public bool Has { get; private set; }

        [JsonProperty("md5")]
        public string MD5 { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}
