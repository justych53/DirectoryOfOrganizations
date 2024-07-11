namespace DirectoryOrganizations.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public Address()
        {
            Location = "none";
        }
    }
}
