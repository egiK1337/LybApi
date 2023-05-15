namespace ServiceLayer.Abstractions
{
    public enum OrderByOptions
    {
        [JsonProperty(PropertyName = "simple_order")]
        SimpleOrder = 0,

        [JsonProperty(PropertyName = "by_votes")]
        ByVotes,

        [JsonProperty(PropertyName = "by_publication_date")]
        ByPublicationDate,

        [JsonProperty(PropertyName = "by_price_lowest_first")]
        ByPriceLowestFirst,

        [JsonProperty(PropertyName = "by_price_higest_first")]
        ByPriceHigestFirst
    }
}

