namespace DotNet8.JsonCRUD.WebApi.Helpers
{
    public class JsonFileHelper
    {
        private readonly string _filePath;

        public JsonFileHelper()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/Blog.json");
        }

        public async Task<List<T>> GetJsonStringAsync<T>()
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

        public async Task WriteJson<T>(List<T> lst)
        {
            try
            {
                string jsonStr = lst.ToJson();
                await File.WriteAllTextAsync(_filePath, jsonStr);
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
