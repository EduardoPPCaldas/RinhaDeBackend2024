using System.Linq.Expressions;

using FluentResults;

namespace RinhaDeDev.Domain.Repositories;

public interface IRepository<T>
{
    Task<List<T>> Get(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T?> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result> Add(T obj, CancellationToken cancellationToken = default);
    Task<Result> Update(T obj, int id, CancellationToken cancellationToken = default);
    Task<Result> Delete(int id, CancellationToken cancellationToken = default);
}
