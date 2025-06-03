using Rackets.Domain.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Rackets.Extensions;

public abstract class YamlConfigLoader
{
    public static List<Racket> Load()
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
        
        return deserializer.Deserialize<List<Racket>>(File.ReadAllText("Properties/rackets.yml"));
    }
}