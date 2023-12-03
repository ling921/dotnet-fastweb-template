using System.Text.Json.Serialization;

namespace FastWeb.Core.Models.Sample.GetList;

public class GetListSampleResponse
{
    public int Id { get; set; }
#if is-project
    public string Name { get; set; } = default!;

    [JsonIgnore]
    public DateOnly Birthday { get; set; }

    public int Age
    {
        get
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            return now.Year - Birthday.Year - 1 + (((now.Month > Birthday.Month) || ((now.Month == Birthday.Month) && (now.Day >= Birthday.Day))) ? 1 : 0);
        }
    }
#endif
}
