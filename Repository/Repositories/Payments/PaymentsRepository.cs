﻿using Entra21.CSharp.Area21.RepositoryDataBase;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using System.Data.Entity;

namespace Entra21.CSharp.Area21.Repository.Repositories.Payments
{
    public class PaymentsRepository : GenericRepository<Payment>, IPaymentsRepository
    {
        private readonly ShortTermParkingContext _context;

        public PaymentsRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        public override IList<Payment> GetAll() =>
            _context.Payments
            .ToList();
    }
}


