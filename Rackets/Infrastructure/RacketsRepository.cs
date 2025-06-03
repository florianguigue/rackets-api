using Rackets.Domain;
using Rackets.Domain.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Rackets.Infrastructure;

public class RacketsRepository : IRacketsRepository
{
    private readonly string _yaml = File.ReadAllText("Properties/rackets.yml");
    
    public List<Racket> GetRackets()
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
        
        var result = deserializer.Deserialize<List<YamlRacket>>(_yaml);
        
        List<Racket> rackets = [];
        
        foreach (var racket in result)
        {
            Console.WriteLine($"{racket.Name}, {racket.Balance}, {racket.Flex}, {racket.WeightCategory}");
            rackets.Add(new Racket(racket.Name, racket.Brand, racket.Flex, racket.Balance, racket.WeightCategory));
        }
        
        return rackets;
    }

    public Racket? GetRacket(string name)
    {
        return null;
    }
}

public class YamlRacket
{
    public string Name { get; set; }
    public Brand Brand { get; set; }
    public Flex Flex { get; set; }
    public WeightCategory WeightCategory { get; set; }
    public Balance Balance { get; set; }
}