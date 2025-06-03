using Rackets.Domain;
using Rackets.Domain.Model;

namespace Rackets.Infrastructure;

public class RacketsRepository(List<Racket> rackets) : IRacketsRepository
{
    public List<Racket> GetRackets()
    {
        return rackets;
    }

    public Racket? GetRacket(string name)
    {
        return null;
    }
}