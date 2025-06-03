using System.Text.Json.Serialization;
using Rackets.Extensions;

namespace Rackets.Domain.Model;

public class Racket
{
    public string Name { get; init; }
    public Brand Brand { get; init; }
    public Flex Flex { get; init; }
    public Balance Balance { get; init; }
    [JsonConverter(typeof(WeightCategoryConverter))]
    public WeightCategory WeightCategory { get; init; }

    public Racket()
    {
        // Used for YAML deserialization process
    }
    
    public Racket(string name, Brand brand, Flex flex, Balance balance, WeightCategory weightCategory)
    {
        Name = name;
        Brand = brand;
        Flex = flex;
        Balance = balance;
        WeightCategory = weightCategory;
    }
}