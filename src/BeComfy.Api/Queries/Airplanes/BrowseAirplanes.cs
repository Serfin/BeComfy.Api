using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BeComfy.Api.Queries.Airplanes
{
    public class BrowseAirplanes : IQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }
    }
}