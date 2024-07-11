using System.Net;

namespace DirectoryOrganizations.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string WorkTime { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; } // широта
        public double Longitude { get; set; } // долгота
        public Address? Address { get; set; } // связь Branch и Address
        public int AddressId { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; } // организация филиала

        public Branch()
        {
            WorkTime = "none";
            Phone = "none";
            Latitude = 0;
            Longitude = 0;
        }
    }
}
