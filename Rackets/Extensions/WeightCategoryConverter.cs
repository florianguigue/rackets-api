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
            WeightCategory.One => "1U",
            WeightCategory.Two => "2U",
            WeightCategory.Three => "3U",
            WeightCategory.Four => "4U",
            WeightCategory.Five => "5U",
            WeightCategory.Six => "6U",
            WeightCategory.Eight => "8U",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(label);
    }
}