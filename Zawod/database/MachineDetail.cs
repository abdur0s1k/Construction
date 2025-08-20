namespace Zawod.Data
{
    public class MachineDetail
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}
