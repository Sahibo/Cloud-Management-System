namespace CloudManagementAPI.Models
{
    public class VirtualMachine : CloudResource
    {
        public int CPUCores { get; set; }
        public int RAMGb { get; set; }
        public string OS { get; set; }

        public override string GetResourceDetails()
        {
            return $"VM: {Name}, CPU: {CPUCores} cores, RAM: {RAMGb}GB, Operating System: {OS}, Region: {Region}";
        }

        public override string PerformAction(string actionType)
        {
            switch (actionType.ToLower())
            {
                case "start":
                    return $"Virtual Machine '{Name}' is starting...";
                case "stop":
                    return $"Virtual Machine '{Name}' is stopping...";
                case "reboot":
                    return $"Virtual Machine '{Name}' is rebooting...";
                case "migrate":
                    return $"Virtual Machine '{Name}' is migrating to another host.";
                default:
                    return $"Unknown action '{actionType}' for Virtual Machine '{Name}'.";
            }
        }
    }
}
