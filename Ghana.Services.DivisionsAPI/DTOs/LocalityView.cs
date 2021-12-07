namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class LocalityView
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public string CityCode { get; set; }
        public string LocalityCode { get; set; }
        public string PostCode => $"{RegionCode} {CityCode}{LocalityCode}".ToString();
    }
}
