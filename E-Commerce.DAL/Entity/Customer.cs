namespace E_Commerce.DAL.Entity
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public List<Customer_Oreders>? Oreders { get; set; }
    }
}