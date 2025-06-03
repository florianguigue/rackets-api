using Rackets.Domain.Model;

namespace Rackets.Domain;

public interface IRacketsRepository
{
    List<Racket> GetRackets();
    
    Racket? GetRacket(string name);
    
    
    List<Racket> SearchRackets(Brand? brand, Flex? flex, Balance? balance, WeightCategory? weightCategory);
}