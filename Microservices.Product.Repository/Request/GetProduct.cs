using MediatR;
using Microservices.Product.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Product.Repository.Request
{
    public class GetProduct: IRequest<List<ProductModel>>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CultureId { get; set; }
    }
}
