using KSYUN.SDK.VPC.JSONValid;
using Manatee.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using Manatee.Json.Serialization;
using Manatee.Json.Schema;
using System;

namespace KSYUN.SDK.VPC.Model.ModifyNat.query
{
    public class ModifyNatqueryModel
    {
        public JsonSchema _schema;
        public ModifyNatqueryModel()
        {
            JsonSerializer serializer = new JsonSerializer();
            JsonValue json = JsonValue.Parse("{\"type\":\"object\",\"properties\":{\"Action\":{\"type\":\"string\",\"enum\":[\"ModifyNat\"],\"default\":\"ModifyNat\"},\"Version\":{\"type\":\"string\",\"default\":\"2016-03-04\"},\"NatId\":{\"type\":\"string\"},\"BandWidth\":{\"type\":\"string\"},\"NatName\":{\"type\":\"string\"}}}");
            _schema = serializer.Deserialize<JsonSchema>(json);
        }
        public JSONValidStruct validtor(JToken data)
        {
            JSONValidStruct _JSONValidStruct = new JSONValidStruct();

            JsonSerializer serializer = new JsonSerializer();

            JsonSchemaOptions.OutputFormat = SchemaValidationOutputFormat.List;

            JsonValue jsonvalue = JsonValue.Parse(data.ToString());

            SchemaValidationResults Results = _schema.Validate(jsonvalue);

            _JSONValidStruct.status = Results.IsValid;
            _JSONValidStruct.message = Results.ToJson(serializer).ToString();
            _JSONValidStruct.result = Results;

            return _JSONValidStruct;
        }
    }
}