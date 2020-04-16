using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    [JsonConverter(typeof(EnumConvert))]
    public enum JsonTest
    {
        [EnumMember(Value = "0001")]
        Test = 0001
    }
    public class EnumConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // 反序列化時，如果有帶EnumConvert，才會進來判斷，如: var testObject = JsonConvert.DeserializeObject<Testmodel>(test,new EnumConvert());
            //一般使用 var testObject = JsonConvert.DeserializeObject<Testmodel>(test) 不會進此method
            return objectType == typeof(object);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object value, JsonSerializer serializer)
        {
            // 反序列化才會用到
            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // 序列化時要做的事情
            var data = (JsonTest)value;
            serializer.Serialize(writer, data.GetHashCode().ToString("0000"));
        }
    }
}
