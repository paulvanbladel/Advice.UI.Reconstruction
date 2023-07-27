using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvestmentAnalysis.Core.Domain;

[DebuggerDisplay("{Amount} €")]
//[JsonConverter(typeof(MoneyJsonConverter))]
public record class Money
{
    private const string _defaultCurrencyCode = "EUR";
    
    public double Amount { get; init; }

    [JsonIgnore]
    public string CurrencyCode { get; } = _defaultCurrencyCode;

    /// <summary>
    /// Constructor only used via reflection. Do not use it for regular object creation.
    /// </summary>
    public Money()
    {

    }

    [JsonConstructor]
    private Money(double amount)
    {
        this.Amount = amount;
    }
    public static Money FromDouble(double amount)
    {
        return new Money(amount);
    }
    public Money Add(Money summand)
    {
        return new Money(Amount + summand.Amount);
    }
    public Money Multiply(Money multiplier)
    {
        return new Money(Amount * multiplier.Amount);
    }
    public Money Subtract(Money subtrahend)
    {
        return new Money(Amount - subtrahend.Amount);
    }
    public static Money operator +(Money summand1, Money summand2)
    {
        return summand1.Add(summand2);
    }
    public static Money operator *(Money multiplier1, Money multiplier2) => multiplier1.Multiply(multiplier2);
    public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);

    public override string ToString() => $"{CurrencyCode} {Amount}";
    public static implicit operator double(Money money)
    {
        return money.Amount;
    }
    public static implicit operator Money(double amount)
    {
        return new Money(amount);
    }
}
//public class MoneyJsonConverter : JsonConverter<Money>
//{
//    public override Money Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        if (reader.TokenType != JsonTokenType.StartObject)
//        {
//            throw new JsonException();
//        }

//        double amount = 0;

//        while (reader.Read())
//        {
//            if (reader.TokenType == JsonTokenType.EndObject)
//            {
//                return  Money.FromDouble(amount);
//            }

//            if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Amount")
//            {
//                reader.Read();
//                amount = reader.GetDouble();
//            }
//        }

//        throw new JsonException();
//    }

//    public override void Write(Utf8JsonWriter writer, Money value, JsonSerializerOptions options)
//    {
//        writer.WriteStartObject();
//        writer.WriteNumber("Amount", value.Amount);
//        writer.WriteEndObject();
//    }
//}

