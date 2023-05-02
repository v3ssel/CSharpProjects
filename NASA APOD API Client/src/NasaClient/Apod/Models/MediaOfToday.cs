using System.Text.Json.Serialization;
using System.Globalization;

namespace AdAstra
{
    public struct MediaOfToday
    {
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override string ToString() =>
            $"{Date.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n‘{Title}’ {(string.IsNullOrEmpty(Copyright) ? "" : $"by {Copyright}")}\n{Explanation}\n{Url}\n";
    }
}
