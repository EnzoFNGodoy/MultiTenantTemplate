using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Infra.Data.Context;
using MultiTenantTemplate.Infra.Data.Core;

namespace MultiTenantTemplate.Infra.Data.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(LibraryContext context) : base(context)
    { }
}