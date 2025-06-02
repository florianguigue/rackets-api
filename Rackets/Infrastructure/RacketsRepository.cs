using Microsoft.EntityFrameworkCore;
using Rackets.Domain;
using Rackets.Domain.Model;

namespace Rackets.Infrastructure;

public class RacketsRepository : IRacketsRepository
{
    private readonly AppDbContext _dbContext;

    public RacketsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Racket> GetRackets()
    {
        return _dbContext.Rackets.ToList();
    }

    public Racket? GetRacket(int id)
    {
        return _dbContext.Rackets.FirstOrDefault(r => r.Id == id);
    }
}