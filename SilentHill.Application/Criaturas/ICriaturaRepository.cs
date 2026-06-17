using SilentHill.Domain;

namespace SilentHill.Application.Criaturas;

public interface ICriaturaRepository
{
    Task<List<Criatura>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Criatura> AddAsync(Criatura criatura, CancellationToken cancellationToken = default);
}
