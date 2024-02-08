﻿using SwapnilAsp.Models;

namespace SwapnilAsp.DataAccess.Repository.IRepository
{
	public interface IOrderHeaderRepository : IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);
		void UpdateStatus(int id, string status, string? paymentStatus = null);

		void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);

	}
}
