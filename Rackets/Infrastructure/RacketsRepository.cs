using Rackets.Domain;
using Rackets.Domain.Model;

namespace Rackets.Infrastructure;

public class RacketsRepository : IRacketsRepository
{
    public List<Racket> GetRackets()
    {
        return new List<Racket> { 
                new("Babolat X-Feel Origin Lite", Brand.Babolat, Flex.Flexible, Balance.Neutral, WeightCategory.Four)
            };
    }
}