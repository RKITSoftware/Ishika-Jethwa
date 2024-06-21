namespace TimeTableGenerator.ML.POCO
{
    public class DayTimeSlotTable
    {
        public int DayTimeSlotID { get; set; }
        public int DayID { get; set; }
        public string SlotTitle { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
