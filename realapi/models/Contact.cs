namespace realapi.models
{
    public class Contact
    {
        public  Guid id { get; set; }
        public string? name { get; set; }

        public string? email { get; set; }
        public long phone { get; set; }
        public string? address { get; set; }

    }
}
