using Newtonsoft.Json;

namespace Booru.Net
{
    public class E621ImageFlags
    {
        [JsonProperty("pending")]
        public bool Pending { get; private set; }

        [JsonProperty("flagged")]
        public bool Flagged { get; private set; }

        [JsonProperty("note_locked")]
        public bool NoteLocked { get; private set; }

        [JsonProperty("status_locked")]
        public bool StatusLocked { get; private set; }

        [JsonProperty("rating_locked")]
        public bool RatingLocked { get; private set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; private set; }
    }
}
