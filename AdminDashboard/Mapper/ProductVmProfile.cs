using AdminDashboard.Models;
using AutoMapper;
using Core.Entities;

namespace AdminDashboard.Mapper
{
    public class ProductVmProfile : Profile
	{
        public ProductVmProfile()
        {


			CreateMap<Product, ProductFormViewModel>().ReverseMap();
			 
		}
    }
}
