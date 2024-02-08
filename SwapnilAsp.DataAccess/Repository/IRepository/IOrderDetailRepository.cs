using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
	public interface IOrderDetailRepository : IRepository<OrderDetail>
	{
		void Update(OrderDetail obj);

	}
}
