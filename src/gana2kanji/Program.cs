using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Gana2Kanji
{
    public class Segment
    {
        public string original { get; set; }
        public List<string> candidates { get; set; }
    }
    public static class G2KExtension
    {
        public static string CommonCase(this List<Segment> result)
        {
            return result
                .Select(m => m.candidates.First())
                .Aggregate((x, y) => x + y);
        }
    }

    public class G2K
    {
        private static readonly string BaseUri = "http://www.google.com/transliterate?langpair=ja-Hira|ja&text=";

        private static async Task<string> RequestGet(string source)
        {
            var http = new HttpClient();
            var uri = new Uri(BaseUri + source);

            return await http.GetStringAsync(uri);
        }
        public static async Task<List<Segment>> Convert(string source)
        {
            var result = new List<Segment>();
            var root = JArray.Parse(await RequestGet(source));

            foreach(var segment in root)
            {
                result.Add(new Segment()
                {
                    original = segment[0].Value<string>(),
                    candidates = segment[1].Select(m => m.Value<string>()).ToList()
                });
            }

            return result;
        }
    }
}
