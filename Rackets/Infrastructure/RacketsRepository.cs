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

    public List<Racket> SearchRackets(string? brand, Flex? flex, Balance? balance, WeightCategory? weightCategory)
    {
        return rackets.FindAll(BrandPredicate)
            .FindAll(FlexPredicate)
            .FindAll(BalancePredicate)
            .FindAll(WeightCategoryPredicate);

        bool BrandPredicate(Racket racket) => brand == null || brand == racket.Brand;
        bool FlexPredicate(Racket racket) => flex == null || racket.Flex == flex;
        bool BalancePredicate(Racket racket) => balance == null || racket.Balance == balance;
        bool WeightCategoryPredicate(Racket racket) => weightCategory == null || racket.WeightCategory == weightCategory;
    }
}