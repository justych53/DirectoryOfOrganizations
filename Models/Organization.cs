namespace DirectoryOrganizations.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // для связи между Organization и Category
        public List<Branch> Branches { get; set; } = new(); // филиалы организации
        public Organization()
        {
            Name = "none";
            FullName = "none";
        }
    }
}
