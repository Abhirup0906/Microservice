using MediatR;
using MediatR.Pipeline;
using Microservices.Product.Repository.Model;
using Microservices.Product.Repository.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Product.Repository.RequestFolder
{
    public class GetProductHandler : IRequestHandler<GetProduct, List<ProductModel>>
    {
        public async Task<List<ProductModel>> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var products = JsonConvert.DeserializeObject<List<ProductModel>>(await File.ReadAllTextAsync(".\\Data\\Products.json"));
            return products.Where(item => (string.IsNullOrWhiteSpace(request.CultureId) || item.CultureId == request.CultureId) ||
                                           (request.ProductId > 0 || item.ProductId == request.ProductId) ||
                                           (string.IsNullOrWhiteSpace(request.Name) || item.Name == request.Name)).ToList();
        }
    }
}
