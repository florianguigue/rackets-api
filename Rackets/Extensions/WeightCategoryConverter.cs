using System.Text.Json;
using System.Text.Json.Serialization;
using Rackets.Domain;
using Rackets.Domain.Model;

namespace Rackets.Extensions;

public class WeightCategoryConverter : JsonConverter<WeightCategory>
{
    public override WeightCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, WeightCategory value, JsonSerializerOptions options)
    {
        var label = value switch
        {
            WeightCategory.Two => "2U",
            WeightCategory.Three => "3U",
            WeightCategory.Four => "4U",
            WeightCategory.Five => "5U",
            WeightCategory.Six => "6U",
        };
        writer.WriteStringValue(label);
    }
}