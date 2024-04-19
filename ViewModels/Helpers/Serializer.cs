using generator.Model;
using Newtonsoft.Json;
using System.IO;

namespace generator.Helpers;

public static class Serializer
{
    private const string FilePath = "test.json";
    public static void Serialize(ICollection<Test>? tests)
    {
        var json = JsonConvert.SerializeObject(tests);
        File.WriteAllText(FilePath, json);
    }

    public static List<Test>? Deserialize()
    {
        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Test>>(json);
    }
}