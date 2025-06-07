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

        public override string PerformAction(string actionType)
        {
            switch (actionType.ToLower())
            {
                case "upload":
                    return $"Initiating file upload to Storage Bucket '{Name}'.";
                case "download":
                    return $"Initiating file download from Storage Bucket '{Name}'.";
                case "set_policy":
                    return $"Updating access policy for Storage Bucket '{Name}'.";
                case "empty":
                    return $"Warning: All contents of Storage Bucket '{Name}' are being deleted!";
                default:
                    return $"Unknown action '{actionType}' for Storage Bucket '{Name}'.";
            }
        }
    }
}
