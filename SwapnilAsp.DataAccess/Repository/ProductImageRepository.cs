﻿using SwapnilAsp.DataAccess.Data;
using SwapnilAsp.DataAccess.Repository.IRepository;
using SwapnilAsp.Models;


namespace SwapnilAsp.DataAccess.Repository
{
	public class  ProductImageRepository : Repository<ProductImage>, IProductImageRepository
	{

		private ApplicationDbContext _db;
		public ProductImageRepository(ApplicationDbContext db) :
			base(db)
		{
			_db = db;
		}


		public void Update(ProductImage obj)
		{
			_db.ProductImages.Update(obj);
		}
	}
}
