namespace ProductManagement.API.DomainModels
{
    public class Store
    {
        public string CodMagazin { get; set; } = Guid.NewGuid().ToString();
        public string Denumire { get; set; } = string.Empty;
        public string Detalii { get; set; } = string.Empty;
    }
}
