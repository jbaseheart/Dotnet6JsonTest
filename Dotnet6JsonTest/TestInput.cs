using Newtonsoft.Json;
using System.Linq;

namespace Dotnet6JsonTest
{
    public class TestInput
    {
        public string Name { get; set; }

        [JsonConverter(typeof(CustomEnumConverter))]
        public GenderType Gender { get; set; }

        public int Age { get; set; }
    }

    
    public enum GenderType
    {
        Male,
        Female
    }

    public class CustomEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType.IsEnum)
            {
                if (reader.TokenType == JsonToken.Integer && reader.ValueType == typeof(long))
                {
                    if (Enum.GetValues(objectType).Cast<int>().Select(e => (long)e).Contains((long)reader.Value))
                        return Convert.ToInt32(reader.Value);
                }
                if (reader.TokenType == JsonToken.Integer && reader.ValueType == typeof(int))
                {
                    if (Enum.GetValues(objectType).Cast<int>().Contains((int)reader.Value))
                        return reader.Value;
                }
                else if (reader.TokenType == JsonToken.String)
                {
                    if (Enum.GetNames(objectType).Contains((string)reader.Value))
                        return Enum.Parse(objectType, (string)reader.Value);
                }
            }

            return existingValue;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
