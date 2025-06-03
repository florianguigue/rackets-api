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
        return rackets.FirstOrDefault(r => string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}