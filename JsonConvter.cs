using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Member
{
    public int Seq { get; set; }
    public string Name { get; set; }
}

public class MemberConverter : JsonConverter<List<Member>>
{
    public override List<Member> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var jsonObject = doc.RootElement;
            var columnList = jsonObject.GetProperty("column_list").ToObject<List<Column>>();
            var dataList = jsonObject.GetProperty("data_list").ToObject<List<List<object>>>();

            var result = new List<Member>();

            foreach (var data in dataList)
            {
                var member = new Member();

                for (int i = 0; i < columnList.Count; i++)
                {
                    var columnName = columnList[i].ColumnName;
                    var columnType = columnList[i].ColumnType;
                    var value = data[i];

                    switch (columnName)
                    {
                        case "seq":
                            member.Seq = Convert.ChangeType(value, Type.GetType(columnType));
                            break;
                        case "name":
                            member.Name = Convert.ChangeType(value, Type.GetType(columnType)).ToString();
                            break;
                        // Add more cases for other columns if needed
                    }
                }

                result.Add(member);
            }

            return result;
        }
    }

    public override void Write(Utf8JsonWriter writer, List<Member> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteStartArray("column_list");

        // Write column_list
        foreach (var member in value)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        writer.WriteEndArray();

        // Write data_list
        writer.WriteStartArray("data_list");
        foreach (var member in value)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(member.Seq);
            writer.WriteStringValue(member.Name);
            writer.WriteEndArray();
        }
        writer.WriteEndArray();

        writer.WriteEndObject();
    }
}

public class Column
{
    public string ColumnName { get; set; }
    public string ColumnType { get; set; }
}

class Program
{
    static void Main()
    {
        string jsonString = @"{
            ""column_list"":[
                {""column_name"": ""seq"", ""column_type"": ""int""},
                {""column_name"": ""name"", ""column_type"": ""string""}
            ],
            ""data_list"": [
                [1, ""kebin""],
                [2, ""suji""]
            ]
        }";

        var members = JsonSerializer.Deserialize<List<Member>>(jsonString, new JsonSerializerOptions
        {
            Converters = { new MemberConverter() }
        });

        foreach (var member in members)
        {
            Console.WriteLine($"Seq: {member.Seq}, Name: {member.Name}");
        }

        string serializedJson = JsonSerializer.Serialize(members, new JsonSerializerOptions
        {
            Converters = { new MemberConverter() },
            WriteIndented = true
        });

        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(serializedJson);
    }
}
