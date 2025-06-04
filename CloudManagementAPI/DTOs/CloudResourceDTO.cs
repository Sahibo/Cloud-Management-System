namespace CloudManagementAPI.DTOs
{
    public class CloudResourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string ResourceType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
