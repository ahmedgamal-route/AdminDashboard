using AdminDashboard.Models;
using AdminDashboard.Services;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Specification;
using Microsoft.AspNetCore.Mvc;
using Services.Helper;
using Services.Services.Dto;


namespace AdminDashboard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IDocumentService documentService )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _documentService = documentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var specs = new ProductsWithBrandsAndTypesspecification(new ProductSpecification { PageSize = 50 });
            //var products = await _unitOfWork.Reposatory<Product>().GetAllWithSpecificationsAsync(specs);
            var products = await _unitOfWork.Reposatory<Product>().GetAllAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductResultDto>>(products);
            return View(mappedProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {

            var product = await _unitOfWork.Reposatory<Product>().GetByIdAsync(id);

            var mappedProduct = _mapper.Map<ProductFormViewModel>(product);

            return View(mappedProduct);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductFormViewModel productVm)
        {
            if (ModelState.IsValid)
            {
                if(productVm.Picture != null)
                {
                    productVm.PictureUrl = await _documentService.UploadFileAsync(productVm.Picture, "products");

                }

                var mappedProduct = _mapper.Map<Product>(productVm);


                await _unitOfWork.Reposatory<Product>().Add(mappedProduct);
                await _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(productVm);
        }


    }
}
