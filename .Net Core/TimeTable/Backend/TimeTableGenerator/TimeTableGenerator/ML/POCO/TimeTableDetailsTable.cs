namespace TimeTableGenerator.ML.POCO
{
    public class TimeTableDetailsTable
    {

        public int TimeTableDetailsID { get; set; }
        public int TimeTableID { get; set; }
        public int ProgramSemesterSubjectID { get; set; }
        public string SubjectTitle { get; set; }
        public int RoomID { get; set; }
        public int LabID { get; set; }
        public int DayTimeSlotID { get; set; }
        public int LectureID { get; set; }
        public int DayID { get; set; }
        public bool IsActive { get; set; }
        public int SessionID { get; set; }
        public string SessionTitle { get; set; }
    }
}
