namespace DotNet8.JsonCRUD.WebApi.Models
{

    public class CityModel
    {
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public string eng { get; set; }
        public string mm { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string capital { get; set; }
        public List<District> districts { get; set; }
    }

    public class District
    {
        public string eng { get; set; }
        public string mm { get; set; }
        public List<Township> townships { get; set; }
    }

    public class Township
    {
        public string eng { get; set; }
        public string mm { get; set; }
    }


}
