using Rackets.Domain.Model;

namespace Rackets.Domain;

public interface IRacketsRepository
{
    List<Racket> GetRackets();
}