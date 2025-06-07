using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagementAPI.Models
{
    public abstract class CloudResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string ResourceType { get; set; }
        public DateTime CreatedAt { get; set; }

        public abstract string GetResourceDetails();
        public abstract string PerformAction(string actionType);
    }
}
