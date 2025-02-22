﻿using ModularArc.Identity.Application.Repositories;

namespace ModularArc.Identity.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityAppDbContext _db;

        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }

        public UnitOfWork(IdentityAppDbContext db)
        {
            _db = db;
        }

        public Task CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        public ValueTask RollBackAsync()
        {
            return _db.DisposeAsync();
        }
    }
}
