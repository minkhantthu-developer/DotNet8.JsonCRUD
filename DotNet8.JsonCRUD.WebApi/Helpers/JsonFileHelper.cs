namespace DotNet8.JsonCRUD.WebApi.Helpers
{
    public class JsonFileHelper
    {
        private readonly string _filePath;

        public JsonFileHelper()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/Blog.json");
        }

        private async Task<List<T>> GetJsonString<T>()
        {
            try
            {
                string jsonStr = await ReadFile();
                var lst = jsonStr.ToObject<List<T>>();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        public async Task WriteJson<T>(T model)
        {
            try
            {
                var lst =await GetJsonString<T>();
                lst.Add(model);

                string jsonStr = JsonConvert.SerializeObject(lst, Formatting.Indented);
                await File.WriteAllTextAsync(_filePath,jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private async Task<string> ReadFile() => 
            await File.ReadAllTextAsync(_filePath);
    }
}
