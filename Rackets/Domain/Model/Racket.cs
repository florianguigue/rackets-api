using System.Text.Json.Serialization;
using Rackets.Extensions;

namespace Rackets.Domain.Model;

public class Racket
{
    public int Id { get; init; }
    public string Name { get; init; }
    public Brand Brand { get; init; }
    public Flex Flex { get; init; }
    public Balance Balance { get; init; }
    [JsonConverter(typeof(WeightCategoryConverter))]
    public WeightCategory WeightCategory { get; init; }

    public Racket(int id, string name, Brand brand, Flex flex, Balance balance, WeightCategory weightCategory)
    {
        Id = id;
        Name = name;
        Brand = brand;
        Flex = flex;
        Balance = balance;
        WeightCategory = weightCategory;
    }
}