using System.Text.Json;
using System.Text.Json.Nodes;

var values = JsonNode.Parse(File.ReadAllText(args[0]))!;
var tests = JsonNode.Parse(File.ReadAllText(args[1]))!;

var map = new Dictionary<int, string>();
foreach (var v in values["values"]!.AsArray())
{
  map[v!["id"]!.GetValue<int>()] = v["value"]!.GetValue<string>();
}

void Fill(JsonNode node)
{
  if (node is JsonObject obj)
  {
    if (obj["id"] != null && obj["value"] != null)
    {
      obj["value"] = map[obj["id"]!.GetValue<int>()];
    }

    foreach (var kv in obj)
    {
      if (kv.Value is JsonArray arr)
      {
        foreach (var child in arr) Fill(child);
      }
    }
  }
}
Fill(tests);

File.WriteAllText(args[2], tests.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
