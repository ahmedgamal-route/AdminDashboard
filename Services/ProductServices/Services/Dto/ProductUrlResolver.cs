using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Services.Services.Dto;

namespace Services.ProductServices.Services.Dto
{

	public class ProductUrlResolver : IValueResolver<Product, ProductResultDto, string>
    {
        private readonly IConfiguration _Configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
                return _Configuration["BaseUrl"] + source.PictureUrl;
            
            return null;
        }
    }
}
