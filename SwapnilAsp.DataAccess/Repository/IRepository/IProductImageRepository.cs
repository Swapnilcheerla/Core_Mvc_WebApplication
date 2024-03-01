using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
	public interface IProductImageRepository : IRepository<ProductImage>
	{
		void Update(ProductImage obj);

	}
}
