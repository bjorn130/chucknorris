using System.Collections.Generic;

namespace ChuckNorris.Infra.Models
{
    public class JsonResult
    {
        public string type { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public string joke { get; set; }
        public List<string> categories { get; set; }
    }
}