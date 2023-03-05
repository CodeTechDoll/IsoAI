using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using System;

namespace Assets.Scripts.DataFlow
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            Vector3 vector = new Vector3();
            vector.x = (float)jsonObject["x"];
            vector.y = (float)jsonObject["y"];
            vector.z = (float)jsonObject["z"];

            return vector;
        }

        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);
            writer.WritePropertyName("z");
            writer.WriteValue(value.z);
            writer.WriteEndObject();
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;
    }
}