using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
	public interface ICompanyRepository : IRepository<Company>
	{
		void Update(Company obj);


	}
}
