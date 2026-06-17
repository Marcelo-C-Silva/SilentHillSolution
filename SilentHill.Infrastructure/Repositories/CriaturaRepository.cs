using Microsoft.EntityFrameworkCore;
using SilentHill.Application.Criaturas;
using SilentHill.Domain;
using SilentHill.Infrastructure.Persistence;

namespace SilentHill.Infrastructure.Repositories;

public class CriaturaRepository : ICriaturaRepository
{
    private readonly AppDbContext _context;

    public CriaturaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Criatura>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Criaturas.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Criatura> AddAsync(Criatura criatura, CancellationToken cancellationToken = default)
    {
        _context.Criaturas.Add(criatura);
        await _context.SaveChangesAsync(cancellationToken);
        return criatura;
    }
}
