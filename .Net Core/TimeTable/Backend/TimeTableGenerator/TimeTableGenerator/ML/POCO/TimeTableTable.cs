namespace TimeTableGenerator.ML.POCO
{
    public class TimeTableTable
    {
        public int TimeTableID { get; set; }
        public int SessionID { get; set; }
        public int ProgramSemesterID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string TimeTableTitle { get; set; }
        public string SemesterTitle { get; set; }
        public string SessionTitle { get; set; }
    }
}
