namespace CloudManagementAPI.Models
{
    public class StorageBucket : CloudResource
    {
        public int CapacityGb { get; set; }
        public bool IsEncrypted { get; set; }

        public override string GetResourceDetails()
        {
            return $"Bucket: {Name}, Capacity: {CapacityGb}GB, Encrypted: {IsEncrypted}, Region: {Region}";
        }
    }
}
