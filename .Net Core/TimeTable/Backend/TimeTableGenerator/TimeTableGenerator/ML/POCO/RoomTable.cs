namespace TimeTableGenerator.ML.POCO
{
    public class RoomTable
    {
        public int RoomId { get; set; }

        public string RoomNo { get; set; }

        public int Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
