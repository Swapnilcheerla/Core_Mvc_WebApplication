﻿using SwapnilAsp.DataAccess.Data;
using SwapnilAsp.DataAccess.Repository.IRepository;
using SwapnilAsp.Models;


namespace SwapnilAsp.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{

		private ApplicationDbContext _db;
		public OrderHeaderRepository(ApplicationDbContext db) :
			base(db)
		{
			_db = db;
		}


		public void Update(OrderHeader obj)
		{
			_db.OrderHeaders.Update(obj);
		}
	}
}