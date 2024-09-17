namespace DotNet8.JsonCRUD.WebApi;

public static class DevCode
{
    public static string ToJson(this Object obj) => JsonConvert.SerializeObject(obj);

    public static T ToObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json)!;

    public static string GetUlid() => Ulid.NewUlid().ToString();

    public static bool IsNullOrEmpty(this string str) =>
        string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
}
