using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Product.Repository.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [JsonProperty("ProductModel")]
        public string Model { get; set; }
        public string CultureId { get; set; }
        public string Description { get; set; }

    }
}
