namespace ProductManagement.API.DomainModels
{
    public class Product
    {
        public string CodIdx { get; set; } = Guid.NewGuid().ToString();
        public string CodIdxAlt { get; set; } = Guid.NewGuid().ToString();
        public string CodMagazin { get; set; } = string.Empty;
        public string Denumire { get; set; } = string.Empty;
        public DateTime DataInregistrare { get; set; }
        public int Cantitate { get; set; }
        public decimal PretUnitar { get; set;}

    }
}
