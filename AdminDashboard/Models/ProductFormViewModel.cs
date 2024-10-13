using Core.Entities;

namespace AdminDashboard.Models
{
	public class ProductFormViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public decimal Price { get; set; }

		public string? PictureUrl { get; set; }
        public IFormFile Picture { get; set; }

        public int ProductTypeId { get; set; }
		public int ProductBrandId { get; set; }
	}
}
