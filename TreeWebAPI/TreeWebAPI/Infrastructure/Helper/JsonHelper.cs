using Newtonsoft.Json;

namespace TreeWebAPI.Infrastructure.Helper;

public static class JsonHelper
{
    public static string ToJsonIgnoreLoopHandling(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
        );
    }
}