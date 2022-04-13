using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Record.json
{
    public record Person(
        [property: JsonPropertyName("name_test")] string Name,
        [property: JsonPropertyName("age_test")] int Age
        );

    public record PersonExt(
        [property: JsonPropertyName("name_test")] string Name,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] DateTime? Created
        );

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("userA", 42);
            var json = JsonSerializer.Serialize(person);
            Console.WriteLine(json);
            // {
            //     "name_test":"userA",
            //     "age_test":42
            // }

            var personExt = new PersonExt("userA", default);
            var jsonExt = JsonSerializer.Serialize(personExt);
            Console.WriteLine(jsonExt);
            // {
            //     "name_test":"userA"
            // }

            var personExt2 = new PersonExt("userA", null);
            var jsonExt2 = JsonSerializer.Serialize(personExt2);
            Console.WriteLine(jsonExt2);
            // {
            //     "name_test":"userA"
            // }
        }
    }
}
