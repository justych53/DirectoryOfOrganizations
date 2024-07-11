namespace DirectoryOrganizations.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category() { Name = "none"; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
