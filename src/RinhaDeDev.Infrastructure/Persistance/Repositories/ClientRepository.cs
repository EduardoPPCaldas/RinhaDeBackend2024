using System.Linq.Expressions;

using FluentResults;

using Microsoft.EntityFrameworkCore;

using RinhaDeDev.Domain.Entities;
using RinhaDeDev.Domain.Errors;
using RinhaDeDev.Domain.Repositories;

namespace RinhaDeDev.Infrastructure.Persistance.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDatabase _database;

    public ClientRepository(ApplicationDatabase database)
    {
        _database = database;
    }

    public async Task<Result> Add(Client obj, CancellationToken cancellationToken = default)
    {
        await _database.Clients.AddAsync(obj, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result> Delete(int id, CancellationToken cancellationToken = default)
    {
        var client = await _database.Clients.FindAsync(id, cancellationToken);
        if(client is null)
        {
            return Result.Fail(new EntityNotFoundError());
        }

        _database.Clients.Remove(client);
        await _database.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<List<Client>> Get(Expression<Func<Client, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _database.Clients.Include(x => x.Transactions).Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<Client?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _database.Clients.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Result> Update(Client obj, int id, CancellationToken cancellationToken = default)
    {
        var client = await _database.Clients.FindAsync(id, cancellationToken);
        if(client is null)
        {
            return Result.Fail(new EntityNotFoundError());
        }

        client = obj;
        await _database.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
