using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
	public interface IOrderHeaderRepository : IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);

	}
}
