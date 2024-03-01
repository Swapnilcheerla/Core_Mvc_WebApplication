using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
		public void Update(ApplicationUser applicationUser);

	}
}
