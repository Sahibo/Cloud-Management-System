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
    }
}
