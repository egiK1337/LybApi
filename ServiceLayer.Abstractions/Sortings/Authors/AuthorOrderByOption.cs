using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstractions.Sortings.Authors
{
    public enum AuthorOrderByOption
    {
        [JsonProperty(PropertyName = "simple_order")]
        SimpleOrder = 0,

        [JsonProperty(PropertyName = "Name")]
        Name,

        [JsonProperty(PropertyName = "WebUrl")]
        WebUrl
    }
}
