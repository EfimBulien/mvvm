using generator.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
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

    public static ObservableCollection<Test>? Deserialize()
    {
        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<ObservableCollection<Test>>(json);
    }
}