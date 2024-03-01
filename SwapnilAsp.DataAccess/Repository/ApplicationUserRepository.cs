﻿using SwapnilAsp.DataAccess.Data;
using SwapnilAsp.DataAccess.Repository.IRepository;
using SwapnilAsp.Models;


namespace SwapnilAsp.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {

        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) :
            base(db)
        {
            _db = db;
        }
		public void Update(ApplicationUser applicationUser)
		{
			_db.ApplicationUsers.Update(applicationUser);
		}


	}
}
