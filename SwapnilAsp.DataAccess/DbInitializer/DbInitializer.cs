using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SwapnilAsp.DataAccess.Data;
using SwapnilAsp.Models;
using SwapnilAsp.Utility;

namespace SwapnilAsp.DataAccess.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _db;

		public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_db = db;
		}
		public void Initialize()
		{
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}

			}
			catch (Exception ex)
			{

				throw;
			}

			// create roles if they are not already created
			if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();
				_userManager.CreateAsync(new ApplicationUser
				{
					UserName = "admin@nypti.org",
					Email = "admin@nypti.org",
					Name = "Admin",
					PhoneNumber = "1234567890",
					StreetAddress = "123 Main St",
					City = "New York",
					PostalCode = "12345",
					State = "NY"
				}, "Admin123*").GetAwaiter().GetResult();
				ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@nypti.org");
				_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
			}
			// if role is not created then create the admin user
			return;
		}
	}
}
